using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

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
            AllowTrailingCommas = true
        };

        public MachineMaintenenceForm()
        {
            InitializeComponent();
            LoadMachineList();
        }

        private void LoadMachineList()
        {
            _isLoadingMachine = true;
            string folder = Path.Combine("..", "..", "..", @"SharedData\Machines");
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

        #region *** ****** Load/Save JSON *********

        private void btnLoadJson_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "JSON Files|*.json";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string json = File.ReadAllText(dlg.FileName, Encoding.UTF8);
                    _machine = JsonSerializer.Deserialize<MachineDefinition>(json, _jsonOptions);

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

            _machine.MaintenanceSchedule = new Dictionary<string, int>();
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
                    _machine.MaintenanceSchedule[interval] = days;
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
            if (_machine.Maintenance != null)
            {
                foreach (var kv in _machine.Maintenance)
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

                if (_machine.Maintenance.ContainsKey(interval))
                {
                    MessageBox.Show("This interval already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _machine.Maintenance.Add(interval, new List<MaintenanceTest>());
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

            if (_machine.Maintenance.ContainsKey(interval))
                _machine.Maintenance.Remove(interval);

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

                    if (!_machine.Maintenance.ContainsKey(interval))
                        _machine.Maintenance[interval] = new List<MaintenanceTest>();

                    _machine.Maintenance[interval].Add(test);
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

            var test = _machine.Maintenance[interval].FirstOrDefault(t => t.Code == code);
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
                if (row.Cells[0].Value == null)
                    continue;

                string key = row.Cells[0].Value.ToString();
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

            if (_machine.Maintenance.ContainsKey(interval))
            {
                _machine.Maintenance[interval].RemoveAll(t => t.Code == code);
            }
            treeTests.SelectedNode.Remove();
        }

        private void cmbMachines_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoadingMachine || cmbMachines.SelectedItem == null)
                return;

            string machineName = cmbMachines.SelectedItem.ToString();
            if (string.IsNullOrEmpty(machineName))
                return;

            string folder = Path.Combine("..", "..", "..", @"SharedData\Machines");
            string filePath = Path.Combine(folder, machineName + ".json");

            if (!File.Exists(filePath))
            {
                MessageBox.Show("Machine file not found: " + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string json = File.ReadAllText(filePath, Encoding.UTF8);
            _machine = JsonSerializer.Deserialize<MachineDefinition>(json, _jsonOptions);

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

            string machineName = cmbMachines.SelectedItem.ToString();
            string folder = Path.Combine("..", "..", "..", @"SharedData\Machines");
            string filePath = Path.Combine(folder, machineName + ".json");

            string json = JsonSerializer.Serialize(_machine, _jsonOptions);
            File.WriteAllText(filePath, json, Encoding.UTF8);

            MessageBox.Show("Machine JSON saved.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnAddMachine(object sender, EventArgs e)
        {
            using (var form = new NewMachineForm())
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return;

                string newName = form.MachineName;
                string folder = Path.Combine("..", "..", "..", @"SharedData\Machines");
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
                    Maintenance = new Dictionary<string, List<MaintenanceTest>>(),
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

        private void ReorderIntervalsToMatchTree()
        {
            if (_machine == null)
                return;

            var newMaintenance = new Dictionary<string, List<MaintenanceTest>>();
            var newSchedule = new Dictionary<string, int>();

            foreach (TreeNode node in treeTests.Nodes)
            {
                string interval = node.Text;
                if (_machine.Maintenance.ContainsKey(interval))
                    newMaintenance.Add(interval, _machine.Maintenance[interval]);

                if (_machine.MaintenanceSchedule.ContainsKey(interval))
                    newSchedule.Add(interval, _machine.MaintenanceSchedule[interval]);
            }

            _machine.Maintenance = newMaintenance;
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