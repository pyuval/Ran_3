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
