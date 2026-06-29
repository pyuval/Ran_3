using FileOperationsNS;
using FileOperationsNS.Models;
using MachineInspections.Forms;
using System.Configuration;
using System.Data;
using System.Text;
using System.Text.Json;

namespace MachineInspections
{
    public partial class MachineInspectionForm : Form
    {
        private InspectionScheduleResult inspectionScheduleResult;
        private readonly FileOperationsNS.Models.Inspector m_loggedInInspector;
        private string m_currentMachineName;
        private bool _IsOverdue;
        private MachineDefinition currentMachine;
        //private ListBox lstMachines;
        private TabControl tabIntervals;
        private Label lblMachineName;
        private Label lblSerial;
        private Label lblInspectionStatus;
        private Button btnSaveInspection;
        private Panel InnerPanel;
        private Panel scrollPanel;
        private Panel panelOuter;
        private Button btnBack;
        private GroupBox DefectiveGroupBox;
        private Label DefectiveLabel;
        private TextBox DefectiveExplanationTextBox;
        private Label SavedResultLabel;
        private Label label1;
        private Label DataLabel;

        //private Dictionary<string, Color> _intervalColors = new Dictionary<string, Color>
        //{
        //    { "Weekly", Color.LightGreen },
        //    { "Monthly", Color.LightBlue },
        //    { "BiMonthly", Color.Khaki },
        //    { "TriMonthly", Color.Gold },
        //    { "MidYear", Color.Orange },
        //    { "Annual", Color.LightCoral }
        //};

        // private List<MachineDefinition> _machines = new List<MachineDefinition>();

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
            InnerPanel = new Panel();
            lblSerial = new Label();
            lblMachineName = new Label();
            DataLabel = new Label();
            tabIntervals = new TabControl();
            btnBack = new Button();
            scrollPanel = new Panel();
            btnSaveInspection = new Button();
            DefectiveGroupBox = new GroupBox();
            DefectiveLabel = new Label();
            DefectiveExplanationTextBox = new TextBox();
            panelOuter = new Panel();
            lblInspectionStatus = new Label();
            label1 = new Label();
            SavedResultLabel = new Label();
            InnerPanel.SuspendLayout();
            DefectiveGroupBox.SuspendLayout();
            panelOuter.SuspendLayout();
            SuspendLayout();
            // 
            // InnerPanel
            // 
            InnerPanel.Controls.Add(SavedResultLabel);
            InnerPanel.Controls.Add(lblSerial);
            InnerPanel.Controls.Add(lblMachineName);
            InnerPanel.Controls.Add(DataLabel);
            InnerPanel.Controls.Add(tabIntervals);
            InnerPanel.Controls.Add(btnBack);
            InnerPanel.Controls.Add(scrollPanel);
            InnerPanel.Controls.Add(btnSaveInspection);
            InnerPanel.Controls.Add(DefectiveGroupBox);
            InnerPanel.Dock = DockStyle.Fill;
            InnerPanel.Location = new Point(0, 0);
            InnerPanel.Name = "InnerPanel";
            InnerPanel.Padding = new Padding(10, 20, 0, 0);
            InnerPanel.Size = new Size(1500, 703);
            InnerPanel.TabIndex = 0;
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Font = new Font("Segoe UI", 14F);
            lblSerial.ForeColor = Color.Red;
            lblSerial.Location = new Point(396, 26);
            lblSerial.MinimumSize = new Size(150, 25);
            lblSerial.Name = "lblSerial";
            lblSerial.RightToLeft = RightToLeft.Yes;
            lblSerial.Size = new Size(150, 31);
            lblSerial.TabIndex = 1;
            lblSerial.Text = "Serial";
            lblSerial.TextAlign = ContentAlignment.MiddleRight;
            lblSerial.UseCompatibleTextRendering = true;
            // 
            // lblMachineName
            // 
            lblMachineName.AutoSize = true;
            lblMachineName.Font = new Font("Segoe UI", 14F);
            lblMachineName.ForeColor = Color.Red;
            lblMachineName.Location = new Point(225, 26);
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
            tabIntervals.MinimumSize = new Size(1370, 300);
            tabIntervals.Multiline = true;
            tabIntervals.Name = "tabIntervals";
            tabIntervals.RightToLeft = RightToLeft.Yes;
            tabIntervals.RightToLeftLayout = true;
            tabIntervals.SelectedIndex = 0;
            tabIntervals.Size = new Size(1370, 300);
            tabIntervals.TabIndex = 0;
            tabIntervals.DrawItem += tabIntervals_DrawItem;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.Location = new Point(1307, 10);
            btnBack.Name = "btnBack";
            btnBack.RightToLeft = RightToLeft.Yes;
            btnBack.Size = new Size(119, 50);
            btnBack.TabIndex = 1;
            btnBack.Text = "חזור";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // scrollPanel
            // 
            scrollPanel.AutoScroll = true;
            scrollPanel.BorderStyle = BorderStyle.FixedSingle;
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
            btnSaveInspection.Location = new Point(1222, 649);
            btnSaveInspection.Name = "btnSaveInspection";
            btnSaveInspection.Size = new Size(206, 28);
            btnSaveInspection.TabIndex = 2;
            btnSaveInspection.Text = "חתום בדיקה";
            btnSaveInspection.Click += btnSaveInspection_Click;
            // 
            // DefectiveGroupBox
            // 
            DefectiveGroupBox.Controls.Add(DefectiveLabel);
            DefectiveGroupBox.Controls.Add(DefectiveExplanationTextBox);
            DefectiveGroupBox.Location = new Point(60, 526);
            DefectiveGroupBox.Name = "DefectiveGroupBox";
            DefectiveGroupBox.Size = new Size(1368, 100);
            DefectiveGroupBox.TabIndex = 5;
            DefectiveGroupBox.TabStop = false;
            DefectiveGroupBox.Text = "מכונה לא שמישה";
            // 
            // DefectiveLabel
            // 
            DefectiveLabel.AutoSize = true;
            DefectiveLabel.Location = new Point(1272, 29);
            DefectiveLabel.MinimumSize = new Size(90, 20);
            DefectiveLabel.Name = "DefectiveLabel";
            DefectiveLabel.Size = new Size(90, 20);
            DefectiveLabel.TabIndex = 1;
            DefectiveLabel.Text = "הסבר ופרט";
            // 
            // DefectiveExplanationTextBox
            // 
            DefectiveExplanationTextBox.Location = new Point(120, 24);
            DefectiveExplanationTextBox.Name = "DefectiveExplanationTextBox";
            DefectiveExplanationTextBox.Size = new Size(1127, 25);
            DefectiveExplanationTextBox.TabIndex = 0;
            // 
            // panelOuter
            // 
            panelOuter.Controls.Add(InnerPanel);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 3;
            label1.Text = "label1";
            // 
            // SavedResultLabel
            // 
            SavedResultLabel.AutoSize = true;
            SavedResultLabel.Location = new Point(925, 649);
            SavedResultLabel.MinimumSize = new Size(250, 28);
            SavedResultLabel.Name = "SavedResultLabel";
            SavedResultLabel.Size = new Size(250, 28);
            SavedResultLabel.TabIndex = 6;
            SavedResultLabel.Text = "";
            SavedResultLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MachineInspectionForm
            // 
            ClientSize = new Size(1500, 703);
            Controls.Add(label1);
            Controls.Add(lblInspectionStatus);
            Controls.Add(panelOuter);
            Font = new Font("Segoe UI", 10F);
            Name = "MachineInspectionForm";
            RightToLeft = RightToLeft.Yes;
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "מערכת בדיקות מכונות";
            InnerPanel.ResumeLayout(false);
            InnerPanel.PerformLayout();
            DefectiveGroupBox.ResumeLayout(false);
            DefectiveGroupBox.PerformLayout();
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
 
        private void btnBack_Click(object sender, EventArgs e)
        {
            var home = new MachineSelectionForm(m_loggedInInspector);
            home.Show();
            this.Close();
        }

        private void LoadMachine()
        {
            var folder = FileOperations.GetSharedFolder("Machines");

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
                        this.btnSaveInspection.Text = "חתום בדיקה";

                    }
                    else
                    {

                        this.btnSaveInspection.Enabled = false;
                        this.btnSaveInspection.Text = "המכונה מושבתת";

                    }

                    if (lblMachineName != null)
                    {
                        lblMachineName.Text = currentMachine?.MachineName;

                        this.lblSerial.Text = currentMachine?.SerialNumber;
                    }

                    if (currentMachine != null)
                    {
                        BuildIntervalTabs(currentMachine);
                        ShowInspectionStatus(currentMachine);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error reading machine definition file {Path.GetFileName(file)}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

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

            string folder = FileOperationsNS.FileOperations.GetSharedFolder("Machines");
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
                machine.DefectExplanation = DefectiveExplanationTextBox.Text.Trim();
                machine.IsOperational = false;
                if (!string.IsNullOrEmpty(machine.DefectExplanation))
                {
                    SaveToJsonResultFile(machine);
                    return;
                }


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
                FileOperationsNS.FileOperations.AppendInspectionToCsv(m_loggedInInspector, machine, intervalKey, results);
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

        private void SaveToJsonResultFile(MachineDefinition machine)
        {
            try
            {

                string folder = FileOperations.GetSharedFolder("Machines");
                var result = FileOperations.SaveToJsonResultFile(machine, folder);
                if (string.IsNullOrEmpty(result))
                {
                    SavedResultLabel.Text = $"הבדיקה נשמרה בהצלחה";
                }
                else
                {
                    SavedResultLabel.Text = result;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving machine definition file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

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


            //bool isUrgent = intervalKey == _IsOverdue;
            bool isSelected = e.Index == tabIntervals.SelectedIndex;

            //result.InspectionTimeIsOverdue[intervalKey];
            using (Brush bgBrush = new SolidBrush(backgroundColor))
            {
                // e.Graphics.FillRectangle(bgBrush, tabRect);
            }


            var inspectionSchedules = currentMachineInspectionScheduleResult[key: currentMachine.MachineName!];
            var inspectionOverdue = inspectionSchedules.InspectionTimeIsOverdue[key: intervalKey];


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
            currentMachineInspectionScheduleResult[key: machine.MachineName!] = inspectionSchedules;
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