using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MachineInspections.Forms
{
    public partial class MachineSelectionForm : Form
    {

        private List<string> _machines;

        public MachineSelectionForm(Inspector loggedInInspector, List<string> machines)
        {
            InitializeComponent();
            _machines = machines;
            CreateMachineButtons(loggedInInspector);
        }

        private void CreateMachineButtons(Inspector loggedInInspector)
        {
            flowPanel.Controls.Clear();

            foreach (var machine in _machines)
            {
                var btn = new Button();
                btn.Text = machine;
                btn.Width = 350;
                btn.Height = 70;
                btn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
                btn.Margin = new Padding(10);
                btn.BackColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 2;
                btn.RightToLeft = RightToLeft.Yes;

                btn.Click += (s, e) =>
                {
                    var form = new MachineInspectionForm(loggedInInspector, machine);
                    form.Show();
                    this.Hide();
                };

                flowPanel.Controls.Add(btn);
            }
        }
    }
}
