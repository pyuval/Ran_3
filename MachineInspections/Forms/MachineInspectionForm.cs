using MachineInspections.Forms;
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
        private string m_currentMachineName;
        private string _mostUrgentInterval;
        private bool _IsOverdue;
        private MachineDefinition currentMachine;
        private ListBox lstMachines;
        private TabControl tabIntervals;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblNextInspection;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblInspectionStatus;
        private System.Windows.Forms.Button btnSaveInspection;
        private System.Windows.Forms.Panel panelRight;
        private Panel scrollPanel;
        private Panel panelOuter;
        private Button btnBack;

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

        public MachineInspectionForm(Inspector loggedInInspector, string machineName)
        {
            InitializeComponent();
            inspectionScheduleResult = new InspectionScheduleResult();
            m_loggedInInspector = loggedInInspector;
            m_currentMachineName = machineName;
            lblMachineName.Text = machineName;

        }
        private void InitializeComponent()
        {
            this.lstMachines = new System.Windows.Forms.ListBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblNextInspection = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();

            this.tabIntervals = new System.Windows.Forms.TabControl();
            this.btnSaveInspection = new System.Windows.Forms.Button();
            this.lblInspectionStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();

            this.lblDate.Location = new Point(0, 0);


            // panelOuter (LTR container)

            this.panelOuter.Dock = DockStyle.Fill;
            this.panelOuter.RightToLeft = RightToLeft.Yes;   // stops RTL flipping
            this.panelOuter.Padding = new Padding(0);

            this.panelOuter.Controls.Add(this.panelRight);

            // 
            // lstMachines
            // 
            this.lstMachines.Dock = DockStyle.Left;
            this.lstMachines.Font = new Font("Segoe UI", 11F);
            this.lstMachines.ItemHeight = 25;
            this.lstMachines.Width = 250;
            this.lstMachines.RightToLeft = RightToLeft.Yes;
            this.lstMachines.SelectedIndexChanged += new EventHandler(this.lstMachines_SelectedIndexChanged);

            // 
            // panelRight
            // 
            // panelRight
            this.panelRight.Dock = DockStyle.Fill;
            this.panelRight.Padding = new Padding(10, 20, 0, 0);

            // RTL FIX — must be BEFORE adding controls
            //this.panelRight.RightToLeft = RightToLeft.Yes;
            //this.panelRight.RightToLeftLayout = false;

            // Now add controls
            this.panelRight.Controls.Add(this.tabIntervals);
            this.panelRight.Controls.Add(this.scrollPanel);
            this.panelRight.Controls.Add(this.btnSaveInspection);
            //this.panelRight.Controls.Add(this.lblDate);




            // 
            // scrollPanel
            // 
            this.scrollPanel.Dock = DockStyle.Top;
            this.scrollPanel.Height = 100;
            this.scrollPanel.AutoScroll = true;
            //this.scrollPanel.Padding = new Padding(200, 20, 0, 0);
            this.scrollPanel.RightToLeft = RightToLeft.No;



            // Add labels to scrollPanel
            //this.scrollPanel.Controls.Add(this.lblMachineName);
            //this.scrollPanel.Controls.Add(this.lblSerial);
            //this.scrollPanel.Controls.Add(this.lblNextInspection);
            //this.scrollPanel.Controls.Add(this.lblDate);

            // 
            // lblMachineName
            // 
            this.lblMachineName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new Point(10, 10);
            this.lblMachineName.RightToLeft = RightToLeft.Yes;

            // 
            // lblSerial
            // 
            this.lblSerial.Font = new Font("Segoe UI", 11F);
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new Point(10, 50);
            this.lblSerial.RightToLeft = RightToLeft.Yes;

            // 
            // lblNextInspection
            // 
            this.lblNextInspection.Font = new Font("Segoe UI", 11F);
            this.lblNextInspection.AutoSize = true;
            this.lblNextInspection.Location = new Point(10, 80);
            this.lblNextInspection.RightToLeft = RightToLeft.Yes;

            // 
            // lblDate
            // 
            this.lblDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(0, 0);
            this.lblDate.RightToLeft = RightToLeft.Yes;

            // 
            // tabIntervals
            // 
            this.tabIntervals.Dock = DockStyle.Fill;
            this.tabIntervals.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabIntervals.ItemSize = new Size(150, 40);
            this.tabIntervals.Font = new Font("Segoe UI", 11F);
            this.tabIntervals.RightToLeft = RightToLeft.Yes;
            this.tabIntervals.RightToLeftLayout = true;
            this.tabIntervals.DrawItem += new DrawItemEventHandler(this.tabIntervals_DrawItem);

            // 
            // btnSaveInspection
            // 
            this.btnSaveInspection.Dock = DockStyle.Bottom;
            this.btnSaveInspection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSaveInspection.Height = 50;
            this.btnSaveInspection.Text = "חתום בדיקה";
            this.btnSaveInspection.Click += new EventHandler(this.btnSaveInspection_Click);

            // 
            // lblInspectionStatus
            // 
            this.lblInspectionStatus.AutoSize = true;
            this.lblInspectionStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblInspectionStatus.BackColor = Color.WhiteSmoke;
            this.lblInspectionStatus.Padding = new Padding(10);
            this.lblInspectionStatus.Location = new Point(260, 10);
            this.lblInspectionStatus.RightToLeft = RightToLeft.Yes;

            this.btnBack.Location = new Point(1410, 10);
            this.btnBack.Size = new Size(75, 23);
            this.btnBack.Text = "חזור";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // 
            // MachineInspectionForm
            // 
            this.ClientSize = new Size(1500, 703);

            this.Controls.Add(this.lblInspectionStatus);
            this.Controls.Add(this.btnBack);
            //this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelOuter);
            this.Controls.Add(this.lstMachines);
            this.Font = new Font("Segoe UI", 10F);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "מערכת בדיקות מכונות";
        }

        protected override void OnLoad(EventArgs e)
        {
          
            base.OnLoad(e);
            LoadMachine();
         // BindMachineList();
            this.lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private string GetSharedFolder()
        {

            string folder = GetSetting("Machines", "Machines");
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            folder = @Path.GetFullPath(Path.Combine(baseDir, folder));

            return folder;

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            var home = new MachineSelectionForm();
            home.Show();
            this.Close();
        }

        private void LoadMachine()
        {
            var folder = GetSharedFolder();

            if (!Directory.Exists(folder))
                return;

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            foreach (var file in Directory.GetFiles(folder, m_currentMachineName+".json"))
            {
                try
                {
                    var json = File.ReadAllText(file, Encoding.UTF8);
                    using var doc = JsonDocument.Parse(json);
                    var root = doc.RootElement;
                    var pri = root.GetProperty("MaintenanceDateToCodeDesc");

                     currentMachine = JsonSerializer.Deserialize<MachineDefinition>(json, options);

                
                    if (currentMachine == null)
                        return;
                    if (currentMachine?.IsOperational == true)
                    {

                        this.btnSaveInspection.Enabled = true;
                        this.btnSaveInspection.Text = "שמור";

                    }
                    else
                    {

                        this.btnSaveInspection.Enabled = false;
                        this.btnSaveInspection.Text = "המכונה מושבתת";
                    }
                    BuildIntervalTabs(currentMachine);
                    ShowInspectionStatus(currentMachine);


                    //if (machine != null)
                    //{

                    //    if (machine != null)
                    //    {
                    //        _machines.Add(machine);
                    //    }
                    //}



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
            if (currentMachine?.IsOperational == true)
            {

                this.btnSaveInspection.Enabled = true;
                this.btnSaveInspection.Text = "שמור";

            }
            else
            {

                this.btnSaveInspection.Enabled = false;
                this.btnSaveInspection.Text = "המכונה מושבתת";
            }
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