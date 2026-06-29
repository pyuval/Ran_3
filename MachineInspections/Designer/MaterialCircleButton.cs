using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineInspections.Designer
{
    public class MaterialCircleButton : Button
    {
        public Color HoverColor { get; set; } = Color.FromArgb(230, 230, 230);
        private Color _originalColor;

        public MaterialCircleButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.ForeColor = Color.White;
            this.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.Width = 120;
            this.Height = 120;
            this.Cursor = Cursors.Hand;

            this._originalColor = this.BackColor;

           

            this.Paint += MaterialCircleButton_Paint;
        }

        private void MaterialCircleButton_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath g = new System.Drawing.Drawing2D.GraphicsPath();
            g.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(g);
        }
    }

}
