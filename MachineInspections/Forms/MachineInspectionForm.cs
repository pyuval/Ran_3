using System.Configuration;
using System.Data;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;

namespace MachineInspections
{
    public partial class MachineInspectionForm : Form
    {
        private InspectionScheduleResult inspectionScheduleResult;
        private readonly Inspector m_loggedInInspector;
        private string _mostUrgentInterval;
        private bool _IsOverdue;
        private MachineDefinition currentMachine;

        private Dictionary<string, Color> _intervalColors = new Dictionary<string, Color>
        {
            { "Weekly", Color.LightGreen },
            { "Monthly", Color.LightBlue },
            { "BiMonthly", Color.Khaki },
            { "TriMonthly", Color.Gold },
            { "MidYear", Color.Orange },
            { "Annual", Color.LightCoral }
        };
        private List<MachineDefinition> _machines = new List<MachineDefinition>();

        public MachineInspectionForm(Inspector loggedInInspector)
        {
            InitializeComponent();
            inspectionScheduleResult = new InspectionScheduleResult();
            m_loggedInInspector = loggedInInspector;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadMachines();
            BindMachineList();
            this.lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private string GetSharedFolder()
        {

            string folder = GetSetting("Machines", "Machines");
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            folder = @Path.GetFullPath(Path.Combine(baseDir, folder));

            return folder;

        }

        private void LoadMachines()
        {
            var folder = GetSharedFolder();

            if (!Directory.Exists(folder))
                return;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foreach (var file in Directory.GetFiles(folder, "*.json"))
            {
                try
                {
                    var json = File.ReadAllText(file, Encoding.UTF8);
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;
                    var pri = root.GetProperty("MaintenanceDateToCodeDesc");

                    var machine = JsonSerializer.Deserialize<MachineDefinition>(json, options);

                    if (machine != null)
                    {

                        if (machine != null)
                        {
                            _machines.Add(machine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading machine definition file {Path.GetFileName(file)}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindMachineList()
        {
            lstMachines.DisplayMember = "MachineName";
            lstMachines.ValueMember = "SerialNumber";
            lstMachines.DataSource = _machines;
        }

        private void lstMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentMachine = lstMachines.SelectedItem as MachineDefinition;
            if (currentMachine == null)
                return;

            BuildIntervalTabs(currentMachine);
            ShowInspectionStatus(currentMachine);
        }

        //private void ShowMachineDetails(MachineDefinition machine)
        //{
        //    // lblMachineName.Text = machine.MachineName; 
        //    // lblSerial.Text = machine.SerialNumber;
        //    // TODO: compute next inspection and set lblNextInspection.Text

        //    BuildIntervalTabs(machine);
        //}

        private void BuildIntervalTabs(MachineDefinition machine)
        {
            tabIntervals.TabPages.Clear();

            if (machine?.MaintenanceDateToCodeDesc == null)
                return;




            foreach (var interval in machine.MaintenanceDateToCodeDesc)
            {
                string key = interval.Key;
                var tests = interval.Value;
                if (tests == null || tests.Count == 0)
                    continue; // Skip empty intervals

                var tab = new TabPage(GetIntervalDisplayName(key))
                {
                    Tag = key,
                    Width = 9000


                };

                var panel = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false
                };



                foreach (var test in machine.MaintenanceDateToCodeDesc[key])


                {
                    // var inspections = test.Codealue;
                    //foreach (var inspection in inspections)
                    //{
                    var chk = new CheckBox
                    {
                        AutoSize = true,
                        Text = $"{test.Code} - {test.Description}",
                        Tag = test
                    };
                    panel.Controls.Add(chk);
                    //}
                }

                tab.Controls.Add(panel);
                tab.Width = 400;

                tabIntervals.TabPages.Add(tab);
            }
        }

        private Color GetIntervalColor(string? interval)
        {
            if (string.IsNullOrEmpty(interval))
                return Color.Black;

            switch (interval)
            {
                case "שבועי":
                    return Color.DarkGreen;

                case "חודשי":
                    return Color.DarkBlue;

                case "דו-חודשי":
                    return Color.DarkViolet;

                case "רבעוני":
                    return Color.DarkSalmon;

                case "חצי-שנתי":
                    return Color.DarkOrange;

                case "שנתי":
                    return Color.DarkRed;

                default:
                    return Color.Black;
            }
        }

        private string GetIntervalDisplayName(string key)
        {
            switch (key)
            {
                case "Weekly":
                    return "בדיקה שבועית";

                case "Monthly":
                    return "בדיקה חודשית";

                case "BiMonthly":
                    return "בדיקה דו־חודשית";

                case "TriMonthly":
                    return "בדיקה רבעונית";

                case "MidYear":
                    return "בדיקה חצי־שנתית";

                case "Annual":
                    return "בדיקה שנתית";

                default:
                    return key;
            }
        }


        private void btnSaveInspection_Click(object sender, EventArgs e)
        {
            var machine = lstMachines.SelectedItem as MachineDefinition;
            if (machine == null)
                return;

            string folder = GetSharedFolder();
            Directory.CreateDirectory(folder);

            // Loop through ALL tabs
            foreach (TabPage tab in tabIntervals.TabPages)
            {
                string intervalKey = tab.Tag as string ?? GetIntervalKeyFromTab(tab.Text);

                var panel = tab.Controls.OfType<FlowLayoutPanel>().FirstOrDefault();
                if (panel == null)
                    continue;

                // VALIDATION
                bool allChecked = panel.Controls.OfType<CheckBox>().All(c => c.Checked);
                if (!allChecked)
                {
                    MessageBox.Show(
                        this,
                        $"לא ניתן לשמור. יש להשלים את כל הבדיקות עבור '{tab.Text}'.",
                        "שגיאה",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning,
                        MessageBoxDefaultButton.Button1,
                        MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
                    );

                    return; // Halt saving logic if a checklist evaluation layout remains incomplete
                }

                var results = new List<(string Code, bool Done)>();
                foreach (var chk in panel.Controls.OfType<CheckBox>())
                {
                    var test = chk.Tag as MaintenanceTest;
                    if (test != null)
                    {
                        results.Add((test.Code, chk.Checked));
                    }
                }

                // Append runtime persistence metrics per configured maintenance unit
                AppendInspectionToCsv(machine, intervalKey, results);
            }

            MessageBox.Show(
                this,
                "הבדיקות נשמרו.",
                "",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading
            );
        }

        #region CSV FILE HANDLING

        private void AppendInspectionToCsv(MachineDefinition machine, string intervalKey, List<(string Code, bool Done)> results)
        {
            try
            {
                string filePath = GetActiveCsvFile(machine);

                using (var writer = new StreamWriter(filePath, append: true, new UTF8Encoding(true)))
                {
                    foreach (var r in results)
                    {
                        string result = r.Done ? "עבר" : "נכשל";

                        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}," +
                                         $"{m_loggedInInspector.FirstName} {m_loggedInInspector.LastName}," +
                                         $"{m_loggedInInspector.ID}," +
                                         $"{machine.MachineName}," +
                                         $"{machine.SerialNumber}," +
                                         $"{intervalKey}," +
                                         $"{r.Code}," +
                                         $"{result}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error writing CSV: " + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private string GetActiveCsvFile(MachineDefinition machine)
        {
            string folder = GetSharedFolder();
            Directory.CreateDirectory(folder);

            string baseName = GetSetting("CsvBaseName", "Results");
            int maxSizeMB = GetSettingInt("CsvMaxSizeMB", 2);
            int maxFiles = GetSettingInt("CsvMaxFiles", 50);

            // Find existing target logs matching patterns
            var files = Directory.GetFiles(folder, $"{machine.MachineName}*.csv")
                                 .OrderBy(f => f)
                                 .ToList();

            if (files.Count == 0)
                return CreateNewCsvFile(machine, folder, baseName);

            string latest = files.Last();

            // Perform rolling-file dimension check limits
            long sizeMB = new FileInfo(latest).Length / (1024 * 1024);
            if (sizeMB >= maxSizeMB)
            {
                latest = CreateNewCsvFile(machine, folder, baseName);
                files.Add(latest);
            }

            // Evict overflow historical log sets if criteria bounds are exceeded
            if (files.Count > maxFiles)
            {
                int toDelete = files.Count - maxFiles;
                foreach (var old in files.Take(toDelete))
                {
                    try
                    {
                        File.Delete(old);
                    }
                    catch
                    {
                        // Fail silently or log background diagnostic details if file lock exists
                    }
                }
            }

            return latest;
        }

        private string CreateNewCsvFile(MachineDefinition machine, string folder, string baseName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = Path.Combine(folder, $"{machine.MachineName}.{baseName}_{timestamp}.csv");

            using (var writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("תאריך,שם הבודק,מספר אישי,מכונה,מס סיריאלי,תדירות,סוג הבדיקה,תוצאות הבדיקה");
            }

            return filePath;
        }


        private string GetSetting(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }


        private int GetSettingInt(string key, int defaultValue)
        {
            if (int.TryParse(ConfigurationManager.AppSettings[key], out int value))
                return value;
            return defaultValue;
        }

        #endregion CSV FILE HANDLING

        private string GetIntervalKeyFromTab(string displayName)
        {
            switch (displayName)
            {
                case "בדיקה שבועית":
                    return "Weekly";

                case "בדיקה חודשית":
                    return "Monthly";

                case "בדיקה דו־חודשית":
                    return "BiMonthly";

                case "בדיקה רבעונית":
                    return "TriMonthly";

                case "בדיקה חצי־שנתית":
                    return "MidYear";

                case "בדיקה שנתית":
                    return "Annual";

                default:
                    return displayName;
            }
        }

        private void tabIntervals_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tabIntervals.TabPages.Count)
                return;

            TabControl tc = (TabControl)sender;
            TabPage tab = tabIntervals.TabPages[e.Index];

            Rectangle tabRect = tc.GetTabRect(e.Index);
            string? intervalKey = tab.Tag as string;
            Color backgroundColor = Color.White;
            Color textColor;

            //bool isUrgent = intervalKey == _IsOverdue;
            bool isSelected = e.Index == tabIntervals.SelectedIndex;

            //result.InspectionTimeIsOverdue[intervalKey];
            using (Brush bgBrush = new SolidBrush(backgroundColor))
            {
                // e.Graphics.FillRectangle(bgBrush, tabRect);
            }


            var inspectionSchedules = currentMachineInspectionScheduleResult[currentMachine.MachineName];
            var inspectionOverdue = inspectionSchedules.InspectionTimeIsOverdue[intervalKey];


            isSelected = true;
            using (Font font = new Font(tab.Font, isSelected ? (FontStyle.Bold | FontStyle.Underline) : FontStyle.Bold))
            {
                Color color = GetIntervalColor(intervalKey);
                if (!inspectionOverdue)
                {
                    color = Color.DarkGreen;
                }
                else
                {
                    color = Color.Red;
                }

                TextRenderer.DrawText(
                    e.Graphics,
                    tab.Text,
                    font,
                    e.Bounds,
                    color,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
            }
        }


        Dictionary<string, InspectionScheduleResult> currentMachineInspectionScheduleResult = new Dictionary<string, InspectionScheduleResult>();
        private void ShowInspectionStatus(MachineDefinition machine)
        {
            var inspectionSchedules = inspectionScheduleResult.CalculateSchedule(machine);
            currentMachineInspectionScheduleResult[machine.MachineName] = inspectionSchedules;
            currentMachine = machine;


            if (inspectionSchedules?.StatusMessages == null)
                return;

            var machineToUpdate = _machines.Find(m => m.MachineName == machine.MachineName);


            if (machineToUpdate?.MaintenanceDateToCodeDesc == null)
                return;

            scrollPanel.Controls.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (var msg in inspectionSchedules.StatusMessages.Values)
            {
                sb.AppendLine(msg);
            }

            System.Windows.Forms.Label label = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Text = sb.ToString(),
                TextAlign = ContentAlignment.TopLeft,
                RightToLeft = RightToLeft.Yes,

                Padding = new Padding(950, 0, 0, 0),

            };
            scrollPanel.Controls.Add(label);



            _IsOverdue = inspectionSchedules.IsOverdue;


            tabIntervals.Invalidate(); // Triggers re-rendering of layout elements with current alerts
        }
    }
}