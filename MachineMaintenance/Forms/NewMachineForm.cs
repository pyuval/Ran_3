using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace MachineMaintenance
{
    public partial class NewMachineForm : Form
    {
        public string MachineName => txtName.Text.Trim();

        public NewMachineForm()
        {
            InitializeComponent();
        }
        private Label lblName;
        private TextBox txtName;
        private Button btnOK;
        private Button btnCancel;


        private void InitializeComponent()
        {
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblName
            //
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(27, 24);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(63, 16);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "שם מכונה:";
            //
            // txtName
            //
            this.txtName.Location = new System.Drawing.Point(145, 18);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 22);
            this.txtName.TabIndex = 1;
            this.txtName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(30, 60);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 30);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "אישור";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(215, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // NewMachineForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 120);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "NewMachineForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "הוסף מכונה חדשה";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void btnOK_Click(object sender, EventArgs e)
        {if(string.IsNullOrWhiteSpace(MachineName))
            {
                MessageBox.Show("שם המכונה לא יכול להיות ריק");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
