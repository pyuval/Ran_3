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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            lblSerial = new Label();
            this.txtSerial = new TextBox();
            this.lblSchedule = new Label();
            this.dgvSchedule = new DataGridView();
            this.dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            this.lblTests = new Label();
            this.treeTests = new TreeView();
            this.btnAddTest = new Button();
            this.btnEditTest = new Button();
            this.btnDeleteTest = new Button();
            this.btnLoadJson = new Button();
            this.btnSaveJson = new Button();
            this.lblSelectMachine = new Label();
            this.cmbMachines = new ComboBox();
            this.label1 = new Label();
            this.btnAddInterval = new Button();
            this.btnDeleteInterval = new Button();
            this.label2 = new Label();
            this.btnMachineInoperative = new Button();
            this.lblMachineOperational = new Label();

            this.btnAddMachine = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            //
            // lblSerial
            //
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(918, 98);
            this.lblSerial.Margin = new Padding(4, 0, 4, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(64, 16);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.Text = "מס סידורי";


            this.grpIntervals = new GroupBox();

            //this.grpIntervals.Margin = new Padding(0, 555, 0, 0);
            this.grpIntervals.Location = new Point(50, 540);
            this.grpIntervals.Size = new Size(460, 90);
            this.grpIntervals.RightToLeft = RightToLeft.Yes;
            this.grpIntervals.Text = "מועדים";


            this.grpTests = new GroupBox();
            this.grpTests.Text = "בדיקות";
            this.grpTests.RightToLeft = RightToLeft.Yes;
            //this.grpTests.Margin = new Padding(0, 5, 0, 0);
            this.grpTests.Location = new Point(50, 650);
            this.grpTests.Size = new Size(460, 80);

            //this.grpTests.BringToFront();
            //this.grpIntervals.BringToFront();

            //
            // txtSerial
            //
            this.txtSerial.Location = new System.Drawing.Point(564, 95);
            this.txtSerial.Margin = new Padding(4);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(265, 22);
            this.txtSerial.TabIndex = 3;
            //
            // lblSchedule
            //
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(887, 145);
            this.lblSchedule.Margin = new Padding(4, 0, 4, 0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(95, 16);
            this.lblSchedule.TabIndex = 8;
            this.lblSchedule.Text = "תדירות בדיקות";
            //
            // dgvSchedule
            //
            this.dgvSchedule.ColumnHeadersHeight = 29;
            this.dgvSchedule.Columns.AddRange(new DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSchedule.Location = new System.Drawing.Point(600, 175);
            this.dgvSchedule.Margin = new Padding(4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvSchedule.Size = new System.Drawing.Size(378, 246);
            this.dgvSchedule.TabIndex = 9;
            //
            // dataGridViewTextBoxColumn1
            //
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "שם הבדיקה";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            //
            // dataGridViewTextBoxColumn2
            //
            this.dataGridViewTextBoxColumn2.HeaderText = "תדירות";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            //
            // lblTests
            //
            this.lblTests.AutoSize = true;
            this.lblTests.Location = new System.Drawing.Point(439, 31);
            this.lblTests.Margin = new Padding(4, 0, 4, 0);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(49, 16);
            this.lblTests.TabIndex = 10;
            this.lblTests.Text = "בדיקות";
            //
            // treeTests
            //
            this.treeTests.AllowDrop = true;
            this.treeTests.HideSelection = false;
            this.treeTests.Location = new System.Drawing.Point(32, 63);
            this.treeTests.Margin = new Padding(4);
            this.treeTests.Name = "treeTests";
            this.treeTests.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeTests.RightToLeftLayout = true;
            this.treeTests.Size = new System.Drawing.Size(465, 454);
            this.treeTests.TabIndex = 11;
            this.treeTests.ItemDrag += new ItemDragEventHandler(this.treeTests_ItemDrag);
            this.treeTests.DragDrop += new DragEventHandler(this.treeTests_DragDrop);
            this.treeTests.DragEnter += new DragEventHandler(this.treeTests_DragEnter);
            this.treeTests.DragOver += new DragEventHandler(this.treeTests_DragOver);
            //

            // btnLoadJson
            //
            this.btnLoadJson.Location = new System.Drawing.Point(882, 506);
            this.btnLoadJson.Margin = new Padding(4);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(100, 28);
            this.btnLoadJson.TabIndex = 15;
            this.btnLoadJson.Text = "טען נתונים";
            this.btnLoadJson.Visible = false;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            //

            //
            // lblSelectMachine
            //
            this.lblSelectMachine.AutoSize = true;
            this.lblSelectMachine.Location = new System.Drawing.Point(919, 63);
            this.lblSelectMachine.Margin = new Padding(4, 0, 4, 0);
            this.lblSelectMachine.Name = "lblSelectMachine";
            this.lblSelectMachine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSelectMachine.Size = new System.Drawing.Size(66, 16);
            this.lblSelectMachine.TabIndex = 0;
            this.lblSelectMachine.Text = "בחר מכונה";
            //
            // cmbMachines
            //
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.Location = new System.Drawing.Point(560, 59);
            this.cmbMachines.Margin = new Padding(4);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(269, 24);
            this.cmbMachines.TabIndex = 1;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.cmbMachines_SelectedIndexChanged);

            // ------------- INTERVALS -------------
            //add interval label
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 565);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(285, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "* לאחר הוספת מועד ניתן לגרור אותו למקום הרצוי             ";

            // btnAddInterval
            //
            this.btnAddInterval.Location = new System.Drawing.Point(395, 590);
            //this.btnAddInterval.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddInterval.Name = "btnAddInterval";
            this.btnAddInterval.Size = new System.Drawing.Size(100, 28);
            this.btnAddInterval.TabIndex = 0;
            this.btnAddInterval.Text = "הוסף מועד";
            this.btnAddInterval.Click += new System.EventHandler(this.btnAddInterval_Click);
            //
            // btnDeleteInterval
            //
            this.btnDeleteInterval.Location = new System.Drawing.Point(269, 590);
            this.btnDeleteInterval.Margin = new Padding(4);
            this.btnDeleteInterval.Name = "btnDeleteInterval";
            this.btnDeleteInterval.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteInterval.TabIndex = 18;
            this.btnDeleteInterval.Text = "מחק מועד";
            this.btnDeleteInterval.Click += new System.EventHandler(this.btnDeleteInterval_Click);
            // --- ADD CONTROLS INTO GROUPBOXES ---

            this.grpIntervals.Controls.Add(this.label2);
            this.grpIntervals.Controls.Add(this.btnAddInterval);
            this.grpIntervals.Controls.Add(this.btnDeleteInterval);


            // ------------------ Test label ----------------
            //
            // add test label
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 670);
            this.label1.Margin = new Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "            * בכדי להוסיף, למחוק, או לערוך בדיקה יש לעמוד על הענף בעץ             ";
            //
            // btnAddTest
            //
            this.btnAddTest.Location = new System.Drawing.Point(377, 690);
            this.btnAddTest.Margin = new Padding(4);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(113, 28);
            this.btnAddTest.TabIndex = 12;
            this.btnAddTest.Text = "הוסף בדיקה";
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            //
            // btnEditTest
            //
            this.btnEditTest.Location = new System.Drawing.Point(124, 690);
            this.btnEditTest.Margin = new Padding(4);
            this.btnEditTest.Name = "btnEditTest";
            this.btnEditTest.Size = new System.Drawing.Size(107, 28);
            this.btnEditTest.TabIndex = 13;
            this.btnEditTest.Text = "ערוך בדיקה";
            this.btnEditTest.Click += new System.EventHandler(this.btnEditTest_Click);
            //
            // btnDeleteTest
            //
            this.btnDeleteTest.Location = new System.Drawing.Point(256, 690);
            this.btnDeleteTest.Margin = new Padding(4);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTest.TabIndex = 14;
            this.btnDeleteTest.Text = "מחק בדיקה";
            this.btnDeleteTest.Click += new System.EventHandler(this.btnDeleteTest_Click);

            this.grpTests.Controls.Add(this.label1);
            this.grpTests.Controls.Add(this.btnAddTest);
            this.grpTests.Controls.Add(this.btnEditTest);
            this.grpTests.Controls.Add(this.btnDeleteTest);

            //
            // btnSaveJson
            //
            this.btnSaveJson.Location = new System.Drawing.Point(340, 740);
            this.btnSaveJson.Margin = new Padding(4);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(167, 28);
            this.btnSaveJson.TabIndex = 16;
            this.btnSaveJson.Text = "שמור נתונים";
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);

            // ---- Add Machine button ----
            // btnAddMachine
            //
            this.btnAddMachine.Location = new System.Drawing.Point(797, 451);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(185, 23);
            this.btnAddMachine.TabIndex = 0;
            this.btnAddMachine.Text = "הוסף מכונה";
            this.btnAddMachine.Click += new System.EventHandler(this.OnAddMachine);

            this.btnMachineInoperative.Location = new System.Drawing.Point(600, 451);
            this.btnMachineInoperative.Name = "btnMachineInoperative";
            this.btnMachineInoperative.Size = new System.Drawing.Size(185, 23);
            this.btnMachineInoperative.TabIndex = 0;
            this.btnMachineInoperative.Text = "השבת מכונה";
            this.btnMachineInoperative.Click += new System.EventHandler(this.OnDisableMachine);

            this.lblMachineOperational.Location = new System.Drawing.Point(890, 425);
            this.lblMachineOperational.Name = "lblMachineOperational";
            this.lblMachineOperational.Size = new System.Drawing.Size(250, 23);
            this.lblMachineOperational.TabIndex = 0;
            this.lblMachineOperational.Text = "";

            //
            // MachineMaintenenceForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 800);


            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectMachine);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.treeTests);
            this.Controls.Add(this.btnLoadJson);
            this.Controls.Add(this.btnMachineInoperative);
            this.Controls.Add(this.lblMachineOperational);

            //Add Interval
            this.Controls.Add(this.btnAddInterval);
            this.Controls.Add(this.btnDeleteInterval);

            //Add Test
            this.Controls.Add(this.btnAddTest);
            this.Controls.Add(this.btnEditTest);
            this.Controls.Add(this.btnDeleteTest);


            this.Controls.Add(this.grpIntervals);
            this.Controls.Add(this.grpTests);
            this.Controls.Add(this.btnSaveJson);





            this.Margin = new Padding(4);
            this.Name = "MachineMaintenenceForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "טופס מכונות";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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


            lblMachineOperational.Text = _machine.IsOperational ? "המכונה תקינה" : "המכונה מושבתת";
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