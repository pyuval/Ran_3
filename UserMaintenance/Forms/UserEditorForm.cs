using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserMaintenance
{
    public partial class UserEditorForm : Form
    {
        public UserEditorForm()
        {
            InitializeComponent();
        }

        public UserEditorForm(string firstName = "", string lastName = "", string id = "", string password = "")
        {
            InitializeComponent();

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtID.Text = id;
            txtPassword.Text = password;

            this.Text = string.IsNullOrEmpty(id) ? "טופס הוספת בודק" : "טופס עריכת בודק";
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFirstName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblFirstName
            //
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Location = new System.Drawing.Point(20, 20);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(54, 13);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "שם פרטי:";
            //
            // lblLastName
            //
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(20, 60);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(66, 13);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "שם משפחה:";
            //
            // lblID
            //
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(20, 100);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(54, 13);
            this.lblID.TabIndex = 4;
            this.lblID.Text = "מס אישי:";
            //
            // lblPassword
            //
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 140);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(44, 13);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "סיסמא:";
            //
            // txtFirstName
            //
            this.txtFirstName.Location = new System.Drawing.Point(120, 18);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(200, 20);
            this.txtFirstName.TabIndex = 1;
            //
            // txtLastName
            //
            this.txtLastName.Location = new System.Drawing.Point(120, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(200, 20);
            this.txtLastName.TabIndex = 3;
            //
            // txtID
            //
            this.txtID.Location = new System.Drawing.Point(120, 98);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(200, 20);
            this.txtID.TabIndex = 5;
            //
            // txtPassword
            //
            this.txtPassword.Location = new System.Drawing.Point(120, 138);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(200, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.UseSystemPasswordChar = true;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(23, 196);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "שמור";
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(131, 196);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "בטל";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
            //
            // UserEditorForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "טופס הוספת בודק ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private Label lblFirstName;
        private Label lblLastName;
        private Label lblID;
        private Label lblPassword;

        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtID;
        private TextBox txtPassword;

        private Button btnOK;
        private Button btnCancel;

        public string FirstName => txtFirstName.Text.Trim();
        public string LastName => txtLastName.Text.Trim();
        public string UserID => txtID.Text.Trim();
        public string Password => txtPassword.Text.Trim();
        #endregion
        #region event  handlers

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(FirstName) ||
                string.IsNullOrWhiteSpace(LastName) ||
                string.IsNullOrWhiteSpace(UserID))
            {
                MessageBox.Show("שם פרטי, שם משפחה ומס אישי הם שדות חובה.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion event  handlers
    }
}
