using FileOperationsNS.Models;
using MachineInspections.Designer;
using System.Text;
using System.Text.Json;

namespace MachineInspections.Forms
{
    public partial class MachineSelectionForm : Form
    {

        private List<MachineDefinition> _machines = new List<MachineDefinition>();

        int colorIndex = 0;

        public MachineSelectionForm()
        {
        }

        public MachineSelectionForm(Inspector loggedInInspector)
        {
            InitializeComponent();
            LoadMachines();
            this.BackColor = Color.Black;
            CreateMachineButtons(loggedInInspector);
        }

        private void LoadMachines()
        {
            var folder = FileOperationsNS.FileOperations.GetSharedFolder("Machines");

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

         

        private readonly Color[] machineColors = new Color[]
        {
            Color.FromArgb(244, 67, 54),   // אדום Material
            Color.FromArgb(33, 150, 243),  // כחול Material
            Color.FromArgb(76, 175, 80),   // ירוק Material
            Color.FromArgb(255, 193, 7),   // צהוב Material
            Color.FromArgb(156, 39, 176),  // סגול Material
            Color.FromArgb(255, 87, 34),   // כתום Material
        };


        private void CreateMachineButtons(Inspector loggedInInspector)
        {
            flowPanel.Controls.Clear();

            foreach (var machine in _machines)
            {
                var btn = new ModernButton();// MaterialCircleButton();
                btn.Text = machine.MachineName;
                btn.BackColor = machineColors[colorIndex % machineColors.Length];
                btn.RightToLeft = RightToLeft.Yes;
 
                btn.Click += (s, e) =>
                {
                    var form = new MachineInspectionForm(loggedInInspector, machine.MachineName);
                    form.Show();
                    this.Hide();
                };

                flowPanel.Controls.Add(btn);
                colorIndex++;
            }
             
        }
    }
}
