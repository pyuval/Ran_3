

using System;
using System.Windows.Forms;

namespace MachineInspections
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.FirstNameTB = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.IDLabel = new System.Windows.Forms.Label();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.LastNameTB = new System.Windows.Forms.TextBox();
            this.IDTB = new System.Windows.Forms.TextBox();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.SignINButton = new System.Windows.Forms.Button();
            this.SignUpButton = new System.Windows.Forms.Button();
            this.EntryFormLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // FirstNameTB
            //
            this.FirstNameTB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.FirstNameTB.Location = new System.Drawing.Point(89, 69);
            this.FirstNameTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.FirstNameTB.Name = "FirstNameTB";
            this.FirstNameTB.Size = new System.Drawing.Size(132, 22);
            this.FirstNameTB.TabIndex = 2;
            this.FirstNameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.FirstNameTB.Enter += new System.EventHandler(this.FirstNameTB_Enter);
            //
            // FirstNameLabel
            //
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(287, 69);
            this.FirstNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(54, 16);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "שם פרטי";
            //
            // PasswordLabel
            //
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(300, 217);
            this.PasswordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(44, 16);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "סיסמא";
            //
            // IDLabel
            //
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(287, 171);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(53, 16);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "מס אישי";
            //
            // LastNameLabel
            //
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(271, 118);
            this.LastNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(67, 16);
            this.LastNameLabel.TabIndex = 4;
            this.LastNameLabel.Text = "שם משפחה";
            //
            // LastNameTB
            //
            this.LastNameTB.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LastNameTB.Location = new System.Drawing.Point(89, 110);
            this.LastNameTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.Size = new System.Drawing.Size(132, 22);
            this.LastNameTB.TabIndex = 5;
            this.LastNameTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LastNameTB.Enter += new System.EventHandler(this.LastNameTB_Enter);
            //
            // IDTB
            //
            this.IDTB.Location = new System.Drawing.Point(89, 162);
            this.IDTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.IDTB.Name = "IDTB";
            this.IDTB.Size = new System.Drawing.Size(132, 22);
            this.IDTB.TabIndex = 6;
            //
            // PasswordTB
            //
            this.PasswordTB.Location = new System.Drawing.Point(89, 213);
            this.PasswordTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(132, 22);
            this.PasswordTB.TabIndex = 7;
            //
            // SignINButton
            //
            this.SignINButton.Location = new System.Drawing.Point(253, 300);
            this.SignINButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SignINButton.Name = "SignINButton";
            this.SignINButton.Size = new System.Drawing.Size(100, 28);
            this.SignINButton.TabIndex = 8;
            this.SignINButton.Text = "כנס";
            this.SignINButton.UseVisualStyleBackColor = true;
            this.SignINButton.Click += new System.EventHandler(this.SignIn);
            //
            // SignUpButton
            //
            this.SignUpButton.Location = new System.Drawing.Point(104, 300);
            this.SignUpButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(100, 28);
            this.SignUpButton.TabIndex = 9;
            this.SignUpButton.Text = "הירשם";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUp);
            //
            // EntryFormLabel
            //
            this.EntryFormLabel.AutoSize = true;
            this.EntryFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EntryFormLabel.Location = new System.Drawing.Point(124, 17);
            this.EntryFormLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EntryFormLabel.Name = "EntryFormLabel";
            this.EntryFormLabel.Size = new System.Drawing.Size(183, 36);
            this.EntryFormLabel.TabIndex = 10;
            this.EntryFormLabel.Text = "כניסה למערכת";
            this.EntryFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 359);
            this.Controls.Add(this.EntryFormLabel);
            this.Controls.Add(this.SignUpButton);
            this.Controls.Add(this.SignINButton);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.IDTB);
            this.Controls.Add(this.LastNameTB);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.IDLabel);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.FirstNameTB);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        private void FirstNameTB_Enter(object sender, EventArgs e)
        {

            // Force caret to the right even when empty
            BeginInvoke((MethodInvoker)(() =>
            {
                FirstNameTB.SelectionStart = FirstNameTB.Text.Length;
            }));
        }




        private void LastNameTB_Enter(object sender, EventArgs e)
        {

            // Force caret to the right even when empty
            BeginInvoke((MethodInvoker)(() =>
            {
                LastNameTB.SelectionStart = LastNameTB.Text.Length;
            }));
        }



        #endregion

        private System.Windows.Forms.TextBox FirstNameTB;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.TextBox LastNameTB;
        private System.Windows.Forms.TextBox IDTB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button SignINButton;
        private System.Windows.Forms.Button SignUpButton;
        private System.Windows.Forms.Label EntryFormLabel;
    }
}
