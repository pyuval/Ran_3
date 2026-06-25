using MachineInspections.Designer;
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
        int colorIndex = 0;

        public MachineSelectionForm()
        {
        }

        public MachineSelectionForm(Inspector loggedInInspector, List<string> machines)
        {
            InitializeComponent();
            _machines = machines;
            this.BackColor = Color.Black;
            CreateMachineButtons(loggedInInspector);
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
                var btn = new MaterialCircleButton();
                btn.Text = machine;
                btn.BackColor = machineColors[colorIndex % machineColors.Length];
                //btn.HoverColor = ControlPaint.Light(btn.BackColor, 0.2f);
                btn.RightToLeft = RightToLeft.Yes;


                //btn.Text = machine;
                //btn.RightToLeft = RightToLeft.Yes;

                btn.Click += (s, e) =>
                {
                    var form = new MachineInspectionForm(loggedInInspector, machine);
                    form.Show();
                    this.Hide();
                };

                flowPanel.Controls.Add(btn);
                colorIndex++;
            }



            //foreach (var machine in _machines)
            //{
            //    var btn = new Button();
            //    btn.Text = machine;
            //    btn.Width = 350;
            //    btn.Height = 70;
            //    btn.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            //    btn.Margin = new Padding(10);
            //    btn.BackColor = Color.White;
            //    btn.FlatStyle = FlatStyle.Flat;
            //    btn.FlatAppearance.BorderSize = 2;
            //    btn.RightToLeft = RightToLeft.Yes;

            //    btn.Click += (s, e) =>
            //    {
            //        var form = new MachineInspectionForm(loggedInInspector, machine);
            //        form.Show();
            //        this.Hide();
            //    };

            //    flowPanel.Controls.Add(btn);
            //}
        }
    }
}
