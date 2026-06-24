using System;
using System.Drawing;
using System.Windows.Forms;

namespace MachineMaintenance
{
    public class IntervalEditorForm : Form
    {
        private Label lblName;
        private Label lblDays;
        private TextBox txtName;
        private TextBox txtDays;
        private Button btnOK;
        private Button btnCancel;

        public string IntervalName => txtName.Text.Trim();
        public int IntervalDays => int.TryParse(txtDays.Text.Trim(), out int d) ? d : 0;

        public IntervalEditorForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lblName = new Label();
            this.lblDays = new Label();
            this.txtName = new TextBox();
            this.txtDays = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();

            // Form
            this.ClientSize = new Size(300, 160);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "הוסף מועד";
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            // Label: Name
            this.lblName.AutoSize = true;
            this.lblName.Location = new Point(20, 20);
            this.lblName.Text = "שם:";

            // TextBox: Name
            this.txtName.Location = new Point(100, 18);
            this.txtName.Size = new Size(160, 22);

            // Label: Days
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new Point(20, 60);
            this.lblDays.Text = "ימים:";

            // TextBox: Days
            this.txtDays.Location = new Point(100, 58);
            this.txtDays.Size = new Size(160, 22);

            // OK Button
            this.btnOK.Location = new Point(50, 110);
            this.btnOK.Size = new Size(80, 30);
            this.btnOK.Text = "אישור";
            this.btnOK.Click += new EventHandler(this.btnOK_Click);

            // Cancel Button
            this.btnCancel.Location = new Point(150, 110);
            this.btnCancel.Size = new Size(80, 30);
            this.btnCancel.Text = "ביטול";
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add controls
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {if(string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("שם המועד לא יכול להיות ריק");
                return;
            }if(!int.TryParse(txtDays.Text, out _))
            {
                MessageBox.Show("ימים חייבים להיות מספר");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
