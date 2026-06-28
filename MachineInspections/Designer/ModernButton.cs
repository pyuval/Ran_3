using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineInspections.Designer
{
    public class ModernButton : Button
    {
       private Color _defaultColor = Color.White;
        private Color _hoverColor = Color.FromArgb(240, 240, 240);
        private Color _borderColor = Color.FromArgb(33, 150, 243); // Material Blue 500

        public ModernButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 2;
            this.FlatAppearance.BorderColor = _borderColor;

            this.BackColor = _defaultColor;
            this.ForeColor = Color.Black;

            this.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.Height = 80;
            this.Width = 350;
            this.Margin = new Padding(15);
            this.Cursor = Cursors.Hand;

            this.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, Width, Height, 20, 20)
            );

            this.MouseEnter += (s, e) => this.BackColor = _hoverColor;
            this.MouseLeave += (s, e) => this.BackColor = _defaultColor;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }


}
