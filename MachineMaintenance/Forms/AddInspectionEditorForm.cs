namespace MachineMaintenance
{
    using System;
    using System.Windows.Forms;

    public class AddInspectionEditorForm : Form
    {
        private Label lblCode;
        private Label lblDescription;
        private TextBox txtCode;
        private TextBox txtDescription;
        private Button btnOK;
        private Button btnCancel;

        public string Code => txtCode.Text.Trim();
        public string Description => txtDescription.Text.Trim();

        public AddInspectionEditorForm(string code = "", string description = "")
        {
            InitializeComponent();

            txtCode.Text = code;
            txtDescription.Text = description;if(!string.IsNullOrEmpty(code))
                this.Text = "Edit Test";
            else
                this.Text = "Add Test";
        }

        private void InitializeComponent()
        {
            this.lblCode = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            //
            // lblCode
            //
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(20, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(77, 16);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "קוד לבדיקה:";
            //
            // lblDescription
            //
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 60);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(39, 16);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "תאור:";
            //
            // txtCode
            //
            this.txtCode.Location = new System.Drawing.Point(120, 18);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(220, 22);
            this.txtCode.TabIndex = 1;
            //
            // txtDescription
            //
            this.txtDescription.Location = new System.Drawing.Point(120, 58);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(220, 60);
            this.txtDescription.TabIndex = 3;
            //
            // btnOK
            //
            this.btnOK.Location = new System.Drawing.Point(120, 140);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "שמור";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            //
            // btnCancel
            //
            this.btnCancel.Location = new System.Drawing.Point(220, 140);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "בטל";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // AddInspectionEditorForm
            //
            this.ClientSize = new System.Drawing.Size(380, 200);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddInspectionEditorForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "הוסף בדיקה";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {if(string.IsNullOrWhiteSpace(txtCode.Text))
            {
                MessageBox.Show("Test code cannot be empty.");
                return;
            }if(string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description cannot be empty.");
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
