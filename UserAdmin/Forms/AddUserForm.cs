using System;
using System.Windows.Forms;

namespace UserAdmin
{
    public partial class AddUserForm : Form
    {
        public AddUserForm() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }

        public AddUserForm(string firstName, string lastName, string id, string password)
        {
            InitializeComponent();

            txtFirstName.Text = firstName;
            txtLastName.Text = lastName;
            txtID.Text = id;
            txtPassword.Text = password;

            this.Text = string.IsNullOrEmpty(id) ? "טופס הוספת בודק" : "טופס עריכת בודק";
        }

        #region event  handlers

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnOK_Click(object sender, System.EventArgs e)
        {if(string.IsNullOrWhiteSpace(FirstName) ||
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
