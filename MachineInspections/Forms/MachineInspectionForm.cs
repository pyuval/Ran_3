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
        //private ListBox lstMachines;
        private TabControl tabIntervals;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblSerial;
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
        private System.Windows.Forms.Label DataLabel;
        private List<MachineDefinition> _machines = new List<MachineDefinition>();

        public MachineInspectionForm(Inspector loggedInInspector, string machineName)
        {
            InitializeComponent();
            inspectionScheduleResult = new InspectionScheduleResult();
            m_loggedInInspector = loggedInInspector;
            m_currentMachineName = machineName;
            if (!string.IsNullOrEmpty(machineName))
            {
                if (lblMachineName != null)
                {
                    lblMachineName.Text = machineName;
                }
            }
        }
        private void InitializeComponent()
        {
            panelRight = new Panel();
            lblSerial = new System.Windows.Forms.Label();
            lblMachineName = new System.Windows.Forms.Label();
            DataLabel = new System.Windows.Forms.Label();
            tabIntervals = new TabControl();
            btnBack = new Button();
            scrollPanel = new Panel();
            btnSaveInspection = new Button();
            panelOuter = new Panel();
            lblInspectionStatus = new System.Windows.Forms.Label();
            panelRight.SuspendLayout();
            panelOuter.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.Controls.Add(lblSerial);
            panelRight.Controls.Add(lblMachineName);
            panelRight.Controls.Add(DataLabel);
            panelRight.Controls.Add(tabIntervals);
            panelRight.Controls.Add(btnBack);
            panelRight.Controls.Add(scrollPanel);
            panelRight.Controls.Add(btnSaveInspection);
            panelRight.Dock = DockStyle.Fill;
            panelRight.Location = new Point(0, 0);
            panelRight.Name = "panelRight";
            panelRight.Padding = new Padding(10, 20, 0, 0);
            panelRight.Size = new Size(1500, 703);
            panelRight.TabIndex = 0;
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Font = new Font("Segoe UI", 11F);
            lblSerial.Location = new Point(875, 15);
            lblSerial.Name = "lblSerial";
            lblSerial.RightToLeft = RightToLeft.Yes;
            lblSerial.Size = new Size(46, 20);
            lblSerial.TabIndex = 1;
            lblSerial.Text = "Serial";
            // 
            // lblMachineName
            // 
            lblMachineName.AutoSize = true;
            lblMachineName.Font = new Font("Segoe UI", 14F);
            lblMachineName.ForeColor = Color.Red;
            lblMachineName.Location = new Point(955, 10);
            lblMachineName.Name = "lblMachineName";
            lblMachineName.RightToLeft = RightToLeft.Yes;
            lblMachineName.Size = new Size(135, 25);
            lblMachineName.TabIndex = 0;
            lblMachineName.Text = "MachineName";
            // 
            // DataLabel
            // 
            DataLabel.AutoSize = true;
            DataLabel.Location = new Point(60, 10);
            DataLabel.Name = "DataLabel";
            DataLabel.Size = new Size(38, 19);
            DataLabel.TabIndex = 4;
            DataLabel.Text = "Date";
            // 
            // tabIntervals
            // 
            tabIntervals.Anchor = AnchorStyles.None;
            tabIntervals.Appearance = TabAppearance.Buttons;
            tabIntervals.DrawMode = TabDrawMode.OwnerDrawFixed;
            tabIntervals.Font = new Font("Segoe UI", 11F);
            tabIntervals.ItemSize = new Size(150, 40);
            tabIntervals.Location = new Point(56, 220);
            tabIntervals.MaximumSize = new Size(1370, 400);
            tabIntervals.MinimumSize = new Size(1370, 400);
            tabIntervals.Name = "tabIntervals";
            tabIntervals.RightToLeft = RightToLeft.Yes;
            tabIntervals.RightToLeftLayout = true;
            tabIntervals.SelectedIndex = 0;
            tabIntervals.Size = new Size(1370, 400);
            tabIntervals.TabIndex = 0;
            tabIntervals.DrawItem += tabIntervals_DrawItem;
            // 
            // btnBack
            // 
            btnBack.Location = new Point(1413, 10);
            btnBack.Name = "btnBack";
            btnBack.RightToLeft = RightToLeft.Yes;
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 1;
            btnBack.Text = "חזור";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // scrollPanel
            // 
            scrollPanel.AutoScroll = true;
            scrollPanel.BorderStyle = BorderStyle.Fixed3D;
            scrollPanel.Location = new Point(56, 68);
            scrollPanel.Name = "scrollPanel";
            scrollPanel.RightToLeft = RightToLeft.Yes;
            scrollPanel.Size = new Size(1372, 146);
            scrollPanel.TabIndex = 1;
            // 
            // btnSaveInspection
            // 
            btnSaveInspection.Anchor = AnchorStyles.None;
            btnSaveInspection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSaveInspection.Location = new Point(56, 653);
            btnSaveInspection.Name = "btnSaveInspection";
            btnSaveInspection.Size = new Size(1370, 50);
            btnSaveInspection.TabIndex = 2;
            btnSaveInspection.Text = "חתום בדיקה";
            btnSaveInspection.Click += btnSaveInspection_Click;
            // 
            // panelOuter
            // 
            panelOuter.Controls.Add(panelRight);
            panelOuter.Dock = DockStyle.Fill;
            panelOuter.Location = new Point(0, 0);
            panelOuter.Name = "panelOuter";
            panelOuter.RightToLeft = RightToLeft.Yes;
            panelOuter.Size = new Size(1500, 703);
            panelOuter.TabIndex = 2;
            // 
            // lblInspectionStatus
            // 
            lblInspectionStatus.AutoSize = true;
            lblInspectionStatus.BackColor = Color.WhiteSmoke;
            lblInspectionStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInspectionStatus.Location = new Point(260, 10);
            lblInspectionStatus.Name = "lblInspectionStatus";
            lblInspectionStatus.Padding = new Padding(10);
            lblInspectionStatus.RightToLeft = RightToLeft.Yes;
            lblInspectionStatus.Size = new Size(20, 41);
            lblInspectionStatus.TabIndex = 0;
            // 
            // MachineInspectionForm
            // 
            ClientSize = new Size(1500, 703);
            Controls.Add(lblInspectionStatus);
            Controls.Add(panelOuter);
            Font = new Font("Segoe UI", 10F);
            Name = "MachineInspectionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "מערכת בדיקות מכונות";
            panelRight.ResumeLayout(false);
            panelRight.PerformLayout();
            panelOuter.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            LoadMachine();
            
            this.DataLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");
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

            foreach (var file in Directory.GetFiles(folder, m_currentMachineName + ".json"))
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
                    this.lblSerial.Text = currentMachine?.SerialNumber;
                    BuildIntervalTabs(currentMachine);
                    ShowInspectionStatus(currentMachine);

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading machine definition file {Path.GetFileName(file)}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BindMachineList()
        {
            //lstMachines.DisplayMember = "MachineName";
            //lstMachines.ValueMember = "SerialNumber";
            //lstMachines.DataSource = _machines;
        }

        //private void lstMachines_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    currentMachine = lstMachines.SelectedItem as MachineDefinition;
        //    if (currentMachine == null)
        //        return;
        //    if (currentMachine?.IsOperational == true)
        //    {

        //        this.btnSaveInspection.Enabled = true;
        //        this.btnSaveInspection.Text = "שמור";

        //    }
        //    else
        //    {

        //        this.btnSaveInspection.Enabled = false;
        //        this.btnSaveInspection.Text = "המכונה מושבתת";
        //    }
        //    BuildIntervalTabs(currentMachine);
        //    ShowInspectionStatus(currentMachine);
        //}

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
            var machine = currentMachine;
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

                    
            scrollPanel.Controls.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (var msg in inspectionSchedules.StatusMessages.Values)
            {
                sb.Append(msg + "                                                                                                                                  ");
                sb.Append("                                                                          ");
                sb.AppendLine("                                                                             ");
            }

            System.Windows.Forms.Label label = new System.Windows.Forms.Label
            {
                AutoSize = true,
                Text = sb.ToString(),
                TextAlign = ContentAlignment.TopLeft,
                

            };
            scrollPanel.Controls.Add(label);



            _IsOverdue = inspectionSchedules.IsOverdue;


            tabIntervals.Invalidate(); // Triggers re-rendering of layout elements with current alerts
        }
    }
}