using MachineMaintenance.Models;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace MachineMaintenance
{
    public partial class MachineMaintenenceForm : Form
    {
        private bool _isLoadingMachine = false;
        private MachineDefinition _machine;

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };

        public MachineMaintenenceForm()
        {
            InitializeComponent();
            LoadMachineList();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblSerial = new Label();
            txtSerial = new TextBox();
            lblSchedule = new Label();
            dgvSchedule = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            lblTests = new Label();
            treeTests = new TreeView();
            btnAddTest = new Button();
            btnEditTest = new Button();
            btnDeleteTest = new Button();
            btnLoadJson = new Button();
            btnSaveJson = new Button();
            lblSelectMachine = new Label();
            cmbMachines = new ComboBox();
            label1 = new Label();
            btnAddInterval = new Button();
            btnDeleteInterval = new Button();
            label2 = new Label();
            btnMachineInoperative = new Button();
            lblMachineOperational = new Label();
            btnAddMachine = new Button();
            grpIntervals = new GroupBox();
            grpTests = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // lblSerial
            // 
            lblSerial.AutoSize = true;
            lblSerial.Location = new Point(803, 92);
            lblSerial.Margin = new Padding(4, 0, 4, 0);
            lblSerial.Name = "lblSerial";
            lblSerial.Size = new Size(56, 15);
            lblSerial.TabIndex = 2;
            lblSerial.Text = "מס סידורי";
            // 
            // txtSerial
            // 
            txtSerial.Location = new Point(494, 89);
            txtSerial.Margin = new Padding(4);
            txtSerial.Name = "txtSerial";
            txtSerial.Size = new Size(232, 23);
            txtSerial.TabIndex = 3;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Location = new Point(776, 136);
            lblSchedule.Margin = new Padding(4, 0, 4, 0);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(83, 15);
            lblSchedule.TabIndex = 8;
            lblSchedule.Text = "תדירות בדיקות";
            // 
            // dgvSchedule
            // 
            dgvSchedule.ColumnHeadersHeight = 29;
            dgvSchedule.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2 });
            dgvSchedule.Location = new Point(525, 164);
            dgvSchedule.Margin = new Padding(4);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.RightToLeft = RightToLeft.Yes;
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.ScrollBars = ScrollBars.None;
            dgvSchedule.Size = new Size(331, 231);
            dgvSchedule.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewTextBoxColumn1.HeaderText = "שם הבדיקה";
            dataGridViewTextBoxColumn1.MinimumWidth = 180;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "תדירות";
            dataGridViewTextBoxColumn2.MinimumWidth = 80;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // lblTests
            // 
            lblTests.AutoSize = true;
            lblTests.Location = new Point(384, 29);
            lblTests.Margin = new Padding(4, 0, 4, 0);
            lblTests.Name = "lblTests";
            lblTests.Size = new Size(43, 15);
            lblTests.TabIndex = 10;
            lblTests.Text = "בדיקות";
            // 
            // treeTests
            // 
            treeTests.AllowDrop = true;
            treeTests.HideSelection = false;
            treeTests.Location = new Point(28, 59);
            treeTests.Margin = new Padding(4);
            treeTests.Name = "treeTests";
            treeTests.RightToLeft = RightToLeft.Yes;
            treeTests.RightToLeftLayout = true;
            treeTests.Size = new Size(407, 426);
            treeTests.TabIndex = 11;
            treeTests.ItemDrag += treeTests_ItemDrag;
            treeTests.DragDrop += treeTests_DragDrop;
            treeTests.DragEnter += treeTests_DragEnter;
            treeTests.DragOver += treeTests_DragOver;
            // 
            // btnAddTest
            // 
            btnAddTest.Location = new Point(330, 647);
            btnAddTest.Margin = new Padding(4);
            btnAddTest.Name = "btnAddTest";
            btnAddTest.Size = new Size(99, 26);
            btnAddTest.TabIndex = 12;
            btnAddTest.Text = "הוסף בדיקה";
            btnAddTest.Click += btnAddTest_Click;
            // 
            // btnEditTest
            // 
            btnEditTest.Location = new Point(108, 647);
            btnEditTest.Margin = new Padding(4);
            btnEditTest.Name = "btnEditTest";
            btnEditTest.Size = new Size(94, 26);
            btnEditTest.TabIndex = 13;
            btnEditTest.Text = "ערוך בדיקה";
            btnEditTest.Click += btnEditTest_Click;
            // 
            // btnDeleteTest
            // 
            btnDeleteTest.Location = new Point(224, 647);
            btnDeleteTest.Margin = new Padding(4);
            btnDeleteTest.Name = "btnDeleteTest";
            btnDeleteTest.Size = new Size(88, 26);
            btnDeleteTest.TabIndex = 14;
            btnDeleteTest.Text = "מחק בדיקה";
            btnDeleteTest.Click += btnDeleteTest_Click;
            // 
            // btnLoadJson
            // 
            btnLoadJson.Location = new Point(772, 474);
            btnLoadJson.Margin = new Padding(4);
            btnLoadJson.Name = "btnLoadJson";
            btnLoadJson.Size = new Size(88, 26);
            btnLoadJson.TabIndex = 15;
            btnLoadJson.Text = "טען נתונים";
            btnLoadJson.Visible = false;
            btnLoadJson.Click += btnLoadJson_Click;
            // 
            // btnSaveJson
            // 
            btnSaveJson.Location = new Point(298, 694);
            btnSaveJson.Margin = new Padding(4);
            btnSaveJson.Name = "btnSaveJson";
            btnSaveJson.Size = new Size(146, 26);
            btnSaveJson.TabIndex = 16;
            btnSaveJson.Text = "שמור נתונים";
            btnSaveJson.Click += btnSaveJson_Click;
            // 
            // lblSelectMachine
            // 
            lblSelectMachine.AutoSize = true;
            lblSelectMachine.Location = new Point(804, 59);
            lblSelectMachine.Margin = new Padding(4, 0, 4, 0);
            lblSelectMachine.Name = "lblSelectMachine";
            lblSelectMachine.RightToLeft = RightToLeft.Yes;
            lblSelectMachine.Size = new Size(63, 15);
            lblSelectMachine.TabIndex = 0;
            lblSelectMachine.Text = "בחר מכונה";
            // 
            // cmbMachines
            // 
            cmbMachines.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMachines.Location = new Point(490, 55);
            cmbMachines.Margin = new Padding(4);
            cmbMachines.Name = "cmbMachines";
            cmbMachines.Size = new Size(236, 23);
            cmbMachines.TabIndex = 1;
            cmbMachines.SelectedIndexChanged += cmbMachines_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(64, 628);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(398, 15);
            label1.TabIndex = 17;
            label1.Text = "            * בכדי להוסיף, למחוק, או לערוך בדיקה יש לעמוד על הענף בעץ             ";
            // 
            // btnAddInterval
            // 
            btnAddInterval.Location = new Point(346, 553);
            btnAddInterval.Name = "btnAddInterval";
            btnAddInterval.Size = new Size(88, 26);
            btnAddInterval.TabIndex = 0;
            btnAddInterval.Text = "הוסף מועד";
            btnAddInterval.Click += btnAddInterval_Click;
            // 
            // btnDeleteInterval
            // 
            btnDeleteInterval.Location = new Point(235, 553);
            btnDeleteInterval.Margin = new Padding(4);
            btnDeleteInterval.Name = "btnDeleteInterval";
            btnDeleteInterval.Size = new Size(88, 26);
            btnDeleteInterval.TabIndex = 18;
            btnDeleteInterval.Text = "מחק מועד";
            btnDeleteInterval.Click += btnDeleteInterval_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 530);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(299, 15);
            label2.TabIndex = 19;
            label2.Text = "* לאחר הוספת מועד ניתן לגרור אותו למקום הרצוי             ";
            // 
            // btnMachineInoperative
            // 
            btnMachineInoperative.Location = new Point(525, 423);
            btnMachineInoperative.Name = "btnMachineInoperative";
            btnMachineInoperative.Size = new Size(162, 22);
            btnMachineInoperative.TabIndex = 0;
            btnMachineInoperative.Text = "השבת מכונה";
            btnMachineInoperative.Click += OnDisableMachine;
            // 
            // lblMachineOperational
            // 
            lblMachineOperational.Location = new Point(637, 399);
            lblMachineOperational.Name = "lblMachineOperational";
            lblMachineOperational.Size = new Size(219, 22);
            lblMachineOperational.TabIndex = 0;
            // 
            // btnAddMachine
            // 
            btnAddMachine.Location = new Point(697, 423);
            btnAddMachine.Name = "btnAddMachine";
            btnAddMachine.Size = new Size(162, 22);
            btnAddMachine.TabIndex = 0;
            btnAddMachine.Text = "הוסף מכונה";
            btnAddMachine.Click += OnAddMachine;
            // 
            // grpIntervals
            // 
            grpIntervals.Location = new Point(44, 506);
            grpIntervals.Name = "grpIntervals";
            grpIntervals.RightToLeft = RightToLeft.Yes;
            grpIntervals.Size = new Size(402, 84);
            grpIntervals.TabIndex = 20;
            grpIntervals.TabStop = false;
            grpIntervals.Text = "מועדים";
            // 
            // grpTests
            // 
            grpTests.Location = new Point(44, 609);
            grpTests.Name = "grpTests";
            grpTests.RightToLeft = RightToLeft.Yes;
            grpTests.Size = new Size(402, 75);
            grpTests.TabIndex = 21;
            grpTests.TabStop = false;
            grpTests.Text = "בדיקות";
            // 
            // MachineMaintenenceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(921, 750);
            Controls.Add(btnAddMachine);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblSelectMachine);
            Controls.Add(cmbMachines);
            Controls.Add(lblSerial);
            Controls.Add(txtSerial);
            Controls.Add(lblSchedule);
            Controls.Add(dgvSchedule);
            Controls.Add(lblTests);
            Controls.Add(treeTests);
            Controls.Add(btnLoadJson);
            Controls.Add(btnMachineInoperative);
            Controls.Add(lblMachineOperational);
            Controls.Add(btnAddInterval);
            Controls.Add(btnDeleteInterval);
            Controls.Add(btnAddTest);
            Controls.Add(btnEditTest);
            Controls.Add(btnDeleteTest);
            Controls.Add(grpIntervals);
            Controls.Add(grpTests);
            Controls.Add(btnSaveJson);
            Margin = new Padding(4);
            Name = "MachineMaintenenceForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "טופס מכונות";
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }



        #endregion

        #region UI Controls
        private TextBox txtSerial;
        private DataGridView dgvSchedule;
        private TreeView treeTests;
        private Button btnAddTest;
        private Button btnEditTest;
        private Button btnDeleteTest;
        private Button btnLoadJson;
        private Button btnSaveJson;
        public Label lblSerial;
        private Label lblSchedule;
        private Label lblTests;
        private Button btnAddInterval;
        private Button btnAddMachine;
        private ComboBox cmbMachines;
        private Label lblSelectMachine;
        private Button btnDeleteInterval;
        private Button btnMachineInoperative;
        private Label lblMachineOperational;

        //load json


        #endregion
        public Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private GroupBox grpTests; private GroupBox grpIntervals;
        private void LoadMachineList()
        {

            _isLoadingMachine = true;
            var folder = GetSharedFolder();
            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"Shared folder not found: {folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isLoadingMachine = false;
                return;
            }


            //string folder = Path.Combine("..", "..", "..", @"SharedData\Machines");
            Directory.CreateDirectory(folder);

            cmbMachines.Items.Clear();
            cmbMachines.Items.Add("");

            foreach (var file in Directory.GetFiles(folder, "*.json"))
            {
                string machineName = Path.GetFileNameWithoutExtension(file);
                cmbMachines.Items.Add(machineName);
            }

            if (cmbMachines.Items.Count > 0)
                cmbMachines.SelectedIndex = 0;

            _isLoadingMachine = false;
        }

        private string GetSharedFolder()
        {

            string folder = FileOperationsNS.FileOperations.GetSharedFolder("Machines");

            return folder;

        }



        #region *** ****** Load/Save JSON *********

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "JSON Files|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(dlg.FileName, Encoding.UTF8);
                    var machine = JsonSerializer.Deserialize<MachineDefinition>(json, _jsonOptions);
                    if (machine == null)
                    {
                        MessageBox.Show("Failed to load machine definition from JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    _machine = machine;
                    PopulateUI();
                }
            }
        }

        private void UpdateMachineFromUI()
        {
            if (_machine == null)
                _machine = new MachineDefinition();

            _machine.MachineName = cmbMachines.SelectedItem?.ToString()?.Trim() ?? cmbMachines.Text.Trim();
            _machine.SerialNumber = txtSerial.Text.Trim();

            //_machine.MaintenanceSchedule = new Dictionary<string, int>();
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var interval = row.Cells[0].Value?.ToString()?.Trim();
                var daysValue = row.Cells[1].Value?.ToString()?.Trim();

                if (string.IsNullOrEmpty(interval) || string.IsNullOrEmpty(daysValue))
                    continue;

                if (int.TryParse(daysValue, out int days))
                {

                    if (_machine.MaintenanceSchedule.ContainsKey(interval))
                    {
                        _machine.MaintenanceSchedule[interval] = days;
                    }
                    else
                    {
                        _machine.MaintenanceSchedule.Add(interval, days);
                    }

                }
            }
        }

        private void PopulateUI()
        {
            if (_machine == null)
                return;

            txtSerial.Text = _machine.SerialNumber;

            dgvSchedule.Rows.Clear();
            if (_machine.MaintenanceSchedule != null)
            {
                foreach (var kv in _machine.MaintenanceSchedule)
                {
                    dgvSchedule.Rows.Add(kv.Key, kv.Value);
                }
            }

            treeTests.Nodes.Clear();
            if (_machine.MaintenanceDateToCodeDesc != null)
            {
                foreach (var kv in _machine.MaintenanceDateToCodeDesc)
                {
                    TreeNode intervalNode = new TreeNode(kv.Key);
                    if (kv.Value != null)
                    {
                        foreach (var test in kv.Value)
                        {
                            intervalNode.Nodes.Add($"{test.Code} - {test.Description}");
                        }
                    }
                    treeTests.Nodes.Add(intervalNode);
                }
            }

            if(_machine.IsOperational)
            {
                lblMachineOperational.Text = "המכונה תקינה";
                lblMachineOperational.ForeColor = Color.Green;
            }
            else
            {
                lblMachineOperational.Text =   "המכונה מושבתת";
                lblMachineOperational.Font = new Font(lblMachineOperational.Font, FontStyle.Bold);
                lblMachineOperational.ForeColor = Color.Red;



            }


        
            this.btnMachineInoperative.Text = _machine.IsOperational ? "השבת מכונה" : "מכונה תקינה";

            treeTests.ExpandAll();

        }

        #endregion *** ****** Load/Save JSON *********

        #region Event handlers for adding/editing/deleting intervals

        private void btnAddInterval_Click(object sender, EventArgs e)
        {
            if (_machine == null)
                return;

            using (var form = new IntervalEditorForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                string interval = form.IntervalName;


                if (_machine.MaintenanceDateToCodeDesc != null)
                {
                    if (_machine.MaintenanceDateToCodeDesc.ContainsKey(interval))
                    {

                        MessageBox.Show("This interval already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                _machine.MaintenanceDateToCodeDesc.Add(interval, new List<MaintenanceTest>());
                _machine.MaintenanceSchedule.Add(interval, form.IntervalDays);

                int insertIndex = treeTests.Nodes.Count;
                if (treeTests.SelectedNode != null)
                {
                    TreeNode selected = treeTests.SelectedNode;
                    if (selected.Parent != null)
                        selected = selected.Parent;

                    insertIndex = selected.Index + 1;
                }

                TreeNode newNode = new TreeNode(interval);
                treeTests.Nodes.Insert(insertIndex, newNode);
                dgvSchedule.Rows.Insert(insertIndex, interval, form.IntervalDays);
            }
        }

        private void btnDeleteInterval_Click(object sender, EventArgs e)
        {
            if (treeTests.SelectedNode == null || _machine == null)
                return;

            TreeNode node = treeTests.SelectedNode;

            if (node.Parent != null)
            {
                MessageBox.Show("ניתן למחוק רק מועד (לא בדיקה)", "התראה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string interval = node.Text;

            if (MessageBox.Show($"למחוק את המועד '{interval}'?", "אישור מחיקה",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            {
                return;
            }

            if (_machine.MaintenanceDateToCodeDesc.ContainsKey(interval))
                _machine.MaintenanceDateToCodeDesc.Remove(interval);

            if (_machine.MaintenanceSchedule.ContainsKey(interval))
                _machine.MaintenanceSchedule.Remove(interval);

            treeTests.Nodes.Remove(node);

            for (int i = dgvSchedule.Rows.Count - 1; i >= 0; i--)
            {
                if (dgvSchedule.Rows[i].Cells[0].Value?.ToString() == interval)
                {
                    dgvSchedule.Rows.RemoveAt(i);
                }
            }
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {
            if (treeTests.SelectedNode == null || _machine == null)
                return;

            TreeNode intervalNode = treeTests.SelectedNode;
            if (intervalNode.Parent != null)
                intervalNode = intervalNode.Parent;

            string interval = intervalNode.Text;

            using (var form = new AddInspectionEditorForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var test = new MaintenanceTest
                    {
                        Code = form.Code,
                        Description = form.Description
                    };

                    if (!_machine.MaintenanceDateToCodeDesc.ContainsKey(interval))
                        _machine.MaintenanceDateToCodeDesc[interval] = new List<MaintenanceTest>();

                    _machine.MaintenanceDateToCodeDesc[interval].Add(test);
                    intervalNode.Nodes.Add($"{test.Code} - {test.Description}");
                }
            }
        }

        private void btnEditTest_Click(object sender, EventArgs e)
        {
            if (treeTests.SelectedNode == null || treeTests.SelectedNode.Parent == null || _machine == null)
                return;

            string interval = treeTests.SelectedNode.Parent.Text;
            string code = treeTests.SelectedNode.Text.Split('-')[0].Trim();


            var test = _machine.MaintenanceDateToCodeDesc[interval].FirstOrDefault(t => t.Code == code);
            if (test == null)
                return;

            using (var form = new AddInspectionEditorForm(test.Code, test.Description))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    test.Code = form.Code;
                    test.Description = form.Description;

                    treeTests.SelectedNode.Text = $"{test.Code} - {test.Description}";
                }
            }
        }

        private void btnSaveJson_Click1(object sender, EventArgs e)
        {
            if (_machine == null)
                return;

            _machine.MachineName = cmbMachines.Text;
            _machine.SerialNumber = txtSerial.Text;

            _machine.MaintenanceSchedule.Clear();
            foreach (DataGridViewRow row in dgvSchedule.Rows)
            {
                if (row.Cells[0].Value == null || row.Cells[1].Value == null)
                    continue;

                string key = row.Cells[0].Value.ToString()!;
                int days = Convert.ToInt32(row.Cells[1].Value);
                _machine.MaintenanceSchedule[key] = days;
            }

            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "JSON Files|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string json = JsonSerializer.Serialize(_machine, _jsonOptions);
                    File.WriteAllText(dlg.FileName, json, Encoding.UTF8);
                    MessageBox.Show("JSON saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnDeleteTest_Click(object sender, EventArgs e)
        {
            if (treeTests.SelectedNode == null || treeTests.SelectedNode.Parent == null || _machine == null)
                return;

            string interval = treeTests.SelectedNode.Parent.Text;
            string code = treeTests.SelectedNode.Text.Split('-')[0].Trim();

            if (_machine.MaintenanceDateToCodeDesc != null)
            {
                if (_machine.MaintenanceDateToCodeDesc.ContainsKey(interval))
                {
                    _machine.MaintenanceDateToCodeDesc[interval].RemoveAll(t => t.Code == code);
                }
                treeTests.SelectedNode.Remove();
            }
        }

        private void cmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingMachine || cmbMachines.SelectedItem == null)
                return;

            string machineName = cmbMachines.SelectedItem.ToString()!;
            if (string.IsNullOrEmpty(machineName))
                return;

            var folder = GetSharedFolder();
            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"Shared folder not found: {folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isLoadingMachine = false;
                return;
            }

            string filePath = Path.Combine(folder, machineName + ".json");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Machine file not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string json = File.ReadAllText(filePath, Encoding.UTF8);
            var machine = JsonSerializer.Deserialize<MachineDefinition>(json, _jsonOptions);
            if (machine == null)
            {
                MessageBox.Show("Failed to load machine definition from JSON.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _machine = machine;

            PopulateUI();
        }

        private void btnSaveJson_Click(object sender, EventArgs e)
        {
            if (cmbMachines.SelectedItem == null)
            {
                MessageBox.Show("Select a machine first.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateMachineFromUI();

            string machineName = cmbMachines.SelectedItem.ToString()!;

            var folder = GetSharedFolder();
            if (!Directory.Exists(folder))
            {
                MessageBox.Show($"לא נמצאה תיקייה: {folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _isLoadingMachine = false;
                return;
            }

            string filePath = Path.Combine(folder, machineName + ".json");

            string json = JsonSerializer.Serialize(_machine, _jsonOptions);
            File.WriteAllText(filePath, json, Encoding.UTF8);

            MessageBox.Show("המכונה נרשמה במערכת", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnAddMachine(object sender, EventArgs e)
        {
            using (var form = new NewMachineForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                string newName = form.MachineName;
                var folder = GetSharedFolder();
                if (!Directory.Exists(folder))
                {
                    MessageBox.Show($"Shared folder not found: {folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingMachine = false;
                    return;
                }

                Directory.CreateDirectory(folder);

                string filePath = Path.Combine(folder, newName + ".json");
                if (File.Exists(filePath))
                {
                    MessageBox.Show("מכונה בשם זה כבר קיימת.", "התראה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _machine = new MachineDefinition
                {
                    MachineName = newName,
                    SerialNumber = "",
                    LastInspectionDate = DateTime.Now,
                    LastInspectionType = "",
                    MaintenanceDateToCodeDesc = new Dictionary<string, List<MaintenanceTest>>(),
                    MaintenanceSchedule = new Dictionary<string, int>()
                };

                string json = JsonSerializer.Serialize(_machine, _jsonOptions);
                File.WriteAllText(filePath, json, Encoding.UTF8);

                LoadMachineList();
                cmbMachines.SelectedItem = newName;

                MessageBox.Show("מכונה חדשה נוספה בהצלחה.", "הצלחה", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion Event handlers for adding/editing/deleting intervals

        #region ********* Allow dropping on the TreeView

        private void treeTests_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void treeTests_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void treeTests_DragOver(object sender, DragEventArgs e)
        {
            Point targetPoint = treeTests.PointToClient(new Point(e.X, e.Y));
            treeTests.SelectedNode = treeTests.GetNodeAt(targetPoint);
            e.Effect = DragDropEffects.Move;
        }

        private void treeTests_DragDrop(object sender, DragEventArgs e)
        {
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
            Point targetPoint = treeTests.PointToClient(new Point(e.X, e.Y));
            TreeNode targetNode = treeTests.GetNodeAt(targetPoint);

            if (draggedNode == null || targetNode == null || draggedNode == targetNode)
                return;

            if (draggedNode.Parent != null || targetNode.Parent != null)
            {
                MessageBox.Show("ניתן לגרור רק מועדים (לא בדיקות)", "מידע", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int oldIndex = draggedNode.Index;
            int newIndex = targetNode.Index;

            if (newIndex > oldIndex)
                newIndex++;

            treeTests.Nodes.Remove(draggedNode);
            treeTests.Nodes.Insert(newIndex, draggedNode);
            treeTests.SelectedNode = draggedNode;

            ReorderIntervalsToMatchTree();
        }


        private void OnDisableMachine(object sender, EventArgs e)
        {
            try
            {
                if (_machine == null)
                {
                    MessageBox.Show("לא נבחרה מכונה", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                _machine.IsOperational = !_machine.IsOperational;
                var folder = GetSharedFolder();
                if (!Directory.Exists(folder))
                {
                    MessageBox.Show($"לא נמצאה תיקייה: {folder}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _isLoadingMachine = false;
                    return;
                }

                string filePath = Path.Combine(folder, _machine.MachineName + ".json");

                string json = JsonSerializer.Serialize(_machine, _jsonOptions);
                File.WriteAllText(filePath, json, Encoding.UTF8);
                this.btnMachineInoperative.Text = _machine.IsOperational ? "השבת מכונה" : "מכונה תקינה";
                lblMachineOperational.Text = _machine.IsOperational ? "המכונה תקינה" : "המכונה מושבתת";



            }
            catch (Exception)
            {

                throw;
            }
        }


        private void ReorderIntervalsToMatchTree()
        {
            if (_machine == null)
                return;

            var newMaintenance = new Dictionary<string, List<MaintenanceTest>>();
            var newSchedule = new Dictionary<string, int>();

            foreach (TreeNode node in treeTests.Nodes)
            {
                string interval = node.Text;
                if (_machine.MaintenanceDateToCodeDesc.ContainsKey(interval))
                {
                    newMaintenance.Add(interval, _machine.MaintenanceDateToCodeDesc[interval]);
                }

                if (_machine.MaintenanceSchedule.ContainsKey(interval))
                    newSchedule.Add(interval, _machine.MaintenanceSchedule[interval]);
            }

            _machine.MaintenanceDateToCodeDesc = newMaintenance;
            _machine.MaintenanceSchedule = newSchedule;

            dgvSchedule.Rows.Clear();
            foreach (var kv in _machine.MaintenanceSchedule)
            {
                dgvSchedule.Rows.Add(kv.Key, kv.Value);
            }
        }

        #endregion ********* Allow dropping on the TreeView
    }
}