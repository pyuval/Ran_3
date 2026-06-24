 
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    namespace MachineInspections
{
    partial class MachineInspectionForm
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
            this.lstMachines = new System.Windows.Forms.ListBox();
            this.tabIntervals = new System.Windows.Forms.TabControl();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblNextInspection = new System.Windows.Forms.Label();
            this.btnSaveInspection = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.Date = new System.Windows.Forms.Label();
            this.lblInspectionStatus = new System.Windows.Forms.Label();
            this.panelRight.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            //
            // lstMachines
            //
            this.lstMachines.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstMachines.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lstMachines.ItemHeight = 25;
            this.lstMachines.Location = new System.Drawing.Point(0, 0);
            this.lstMachines.Name = "lstMachines";
            this.lstMachines.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lstMachines.Size = new System.Drawing.Size(250, 703);
            this.lstMachines.TabIndex = 2;
            this.lstMachines.SelectedIndexChanged += new System.EventHandler(this.lstMachines_SelectedIndexChanged);
            //
            // tabIntervals
            //
            this.tabIntervals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabIntervals.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabIntervals.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.tabIntervals.ItemSize = new System.Drawing.Size(150, 40);
            this.tabIntervals.Location = new System.Drawing.Point(10, 110);
            this.tabIntervals.Name = "tabIntervals";
            this.tabIntervals.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabIntervals.RightToLeftLayout = true;
            this.tabIntervals.SelectedIndex = 0;
            this.tabIntervals.Size = new System.Drawing.Size(930, 533);
            this.tabIntervals.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabIntervals.TabIndex = 0;
            this.tabIntervals.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabIntervals.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabIntervals_DrawItem);
            //
            // lblMachineName
            //
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMachineName.Location = new System.Drawing.Point(10, 10);
            this.lblMachineName.Name = "lblMachineName";
            this.lblMachineName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblMachineName.Size = new System.Drawing.Size(0, 32);
            this.lblMachineName.TabIndex = 0;
            //
            // lblSerial
            //
            this.lblSerial.AutoSize = true;
            this.lblSerial.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSerial.Location = new System.Drawing.Point(10, 45);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSerial.Size = new System.Drawing.Size(0, 25);
            this.lblSerial.TabIndex = 1;
            //
            // lblNextInspection
            //
            this.lblNextInspection.AutoSize = true;
            this.lblNextInspection.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNextInspection.Location = new System.Drawing.Point(10, 70);
            this.lblNextInspection.Name = "lblNextInspection";
            this.lblNextInspection.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblNextInspection.Size = new System.Drawing.Size(0, 25);
            this.lblNextInspection.TabIndex = 3;
            //
            // btnSaveInspection
            //
            this.btnSaveInspection.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSaveInspection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnSaveInspection.Location = new System.Drawing.Point(10, 643);
            this.btnSaveInspection.Name = "btnSaveInspection";
            this.btnSaveInspection.Size = new System.Drawing.Size(930, 50);
            this.btnSaveInspection.TabIndex = 2;
            this.btnSaveInspection.Text = "חתום בדיקה";
            this.btnSaveInspection.Click += new System.EventHandler(this.btnSaveInspection_Click);
            //
            // panelRight
            //
            this.panelRight.Controls.Add(this.tabIntervals);
            this.panelRight.Controls.Add(this.panelTop);
            this.panelRight.Controls.Add(this.btnSaveInspection);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(250, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Padding = new System.Windows.Forms.Padding(10);
            this.panelRight.Size = new System.Drawing.Size(950, 703);
            this.panelRight.TabIndex = 1;
            //
            // panelTop
            //
            this.panelTop.Controls.Add(this.lblMachineName);
            this.panelTop.Controls.Add(this.lblSerial);
            this.panelTop.Controls.Add(this.Date);
            this.panelTop.Controls.Add(this.lblNextInspection);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(10, 2);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(5);
            this.panelTop.Size = new System.Drawing.Size(930, 100);
            this.panelTop.TabIndex = 1;
            //
            // Date
            //
            this.Date.Location = new System.Drawing.Point(0, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(150, 40);
            this.Date.TabIndex = 2;
            this.Date.Text = "17/05/2026";
            //
            // lblInspectionStatus
            //
            this.lblInspectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInspectionStatus.AutoSize = true;
            this.lblInspectionStatus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblInspectionStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblInspectionStatus.Location = new System.Drawing.Point(260, 10);
            this.lblInspectionStatus.Name = "lblInspectionStatus";
            this.lblInspectionStatus.Padding = new System.Windows.Forms.Padding(10);
            this.lblInspectionStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblInspectionStatus.Size = new System.Drawing.Size(20, 48);
            this.lblInspectionStatus.TabIndex = 0;
            this.lblInspectionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // MachineInspectionForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1500, 703);
            this.Controls.Add(this.lblInspectionStatus);
            this.Controls.Add(this.panelRight);
            this.Controls.Add(this.lstMachines);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Name = "MachineInspectionForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "מערכת בדיקות מכונות";
            this.panelRight.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }





        #endregion

        #region class members
        private System.Windows.Forms.ListBox lstMachines;
        private System.Windows.Forms.TabControl tabIntervals;
        private System.Windows.Forms.Label lblMachineName;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblNextInspection;
        private System.Windows.Forms.Button btnSaveInspection;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblInspectionStatus;
        private System.Windows.Forms.Label Date;


        #endregion
    }
}
