using System;
using System.Drawing;
using System.Windows.Forms;

namespace MachineInspections
{
    partial class MachineInspectionForm
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox lstMachines;
        private TabControl tabIntervals;
        private Label lblMachineName;
        private Label lblSerial;
        private Label lblNextInspection;
        private Label lblDate;
        private Label lblInspectionStatus;
        private Button btnSaveInspection;
        private Panel panelRight;
        private Panel scrollPanel;
        private Panel panelOuter;
        private Button btnBack;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lstMachines = new System.Windows.Forms.ListBox();
            this.panelRight = new System.Windows.Forms.Panel();
            this.scrollPanel = new System.Windows.Forms.Panel();
            this.lblMachineName = new System.Windows.Forms.Label();
            this.lblSerial = new System.Windows.Forms.Label();
            this.lblNextInspection = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.panelOuter = new System.Windows.Forms.Panel();

            this.tabIntervals = new System.Windows.Forms.TabControl();
            this.btnSaveInspection = new System.Windows.Forms.Button();
            this.lblInspectionStatus = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();

            this.lblDate.Location = new Point(0, 0);
          

            // panelOuter (LTR container)

            this.panelOuter.Dock = DockStyle.Fill;
            this.panelOuter.RightToLeft = RightToLeft.Yes;   // stops RTL flipping
            this.panelOuter.Padding = new Padding(0);

            this.panelOuter.Controls.Add(this.panelRight);

            // 
            // lstMachines
            // 
            this.lstMachines.Dock = DockStyle.Left;
            this.lstMachines.Font = new Font("Segoe UI", 11F);
            this.lstMachines.ItemHeight = 25;
            this.lstMachines.Width = 250;
            this.lstMachines.RightToLeft = RightToLeft.Yes;
            this.lstMachines.SelectedIndexChanged += new EventHandler(this.lstMachines_SelectedIndexChanged);

            // 
            // panelRight
            // 
            // panelRight
            this.panelRight.Dock = DockStyle.Fill;
            this.panelRight.Padding = new Padding(10, 20, 0, 0);

            // RTL FIX — must be BEFORE adding controls
            //this.panelRight.RightToLeft = RightToLeft.Yes;
            //this.panelRight.RightToLeftLayout = false;

            // Now add controls
            this.panelRight.Controls.Add(this.tabIntervals);
            this.panelRight.Controls.Add(this.scrollPanel);
            this.panelRight.Controls.Add(this.btnSaveInspection);
            //this.panelRight.Controls.Add(this.lblDate);


            

            // 
            // scrollPanel
            // 
            this.scrollPanel.Dock = DockStyle.Top;
            this.scrollPanel.Height = 100;           
            this.scrollPanel.AutoScroll = true;             
            //this.scrollPanel.Padding = new Padding(200, 20, 0, 0);
            this.scrollPanel.RightToLeft = RightToLeft.No;
           

           
            // Add labels to scrollPanel
            //this.scrollPanel.Controls.Add(this.lblMachineName);
            //this.scrollPanel.Controls.Add(this.lblSerial);
            //this.scrollPanel.Controls.Add(this.lblNextInspection);
            //this.scrollPanel.Controls.Add(this.lblDate);

            // 
            // lblMachineName
            // 
            this.lblMachineName.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblMachineName.AutoSize = true;
            this.lblMachineName.Location = new Point(10, 10);
            this.lblMachineName.RightToLeft = RightToLeft.Yes;

            // 
            // lblSerial
            // 
            this.lblSerial.Font = new Font("Segoe UI", 11F);
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new Point(10, 50);
            this.lblSerial.RightToLeft = RightToLeft.Yes;

            // 
            // lblNextInspection
            // 
            this.lblNextInspection.Font = new Font("Segoe UI", 11F);
            this.lblNextInspection.AutoSize = true;
            this.lblNextInspection.Location = new Point(10, 80);
            this.lblNextInspection.RightToLeft = RightToLeft.Yes;

            // 
            // lblDate
            // 
            this.lblDate.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(0, 0);
            this.lblDate.RightToLeft = RightToLeft.Yes;

            // 
            // tabIntervals
            // 
            this.tabIntervals.Dock = DockStyle.Fill;
            this.tabIntervals.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabIntervals.ItemSize = new Size(150, 40);
            this.tabIntervals.Font = new Font("Segoe UI", 11F);
            this.tabIntervals.RightToLeft = RightToLeft.Yes;
            this.tabIntervals.RightToLeftLayout = true;
            this.tabIntervals.DrawItem += new DrawItemEventHandler(this.tabIntervals_DrawItem);

            // 
            // btnSaveInspection
            // 
            this.btnSaveInspection.Dock = DockStyle.Bottom;
            this.btnSaveInspection.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.btnSaveInspection.Height = 50;
            this.btnSaveInspection.Text = "חתום בדיקה";
            this.btnSaveInspection.Click += new EventHandler(this.btnSaveInspection_Click);

            // 
            // lblInspectionStatus
            // 
            this.lblInspectionStatus.AutoSize = true;
            this.lblInspectionStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblInspectionStatus.BackColor = Color.WhiteSmoke;
            this.lblInspectionStatus.Padding = new Padding(10);
            this.lblInspectionStatus.Location = new Point(260, 10);
            this.lblInspectionStatus.RightToLeft = RightToLeft.Yes;

            this.btnBack.Location = new Point(1410, 10);
            this.btnBack.Size = new Size(75, 23);
            this.btnBack.Text = "חזור";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // 
            // MachineInspectionForm
            // 
            this.ClientSize = new Size(1500, 703);
            
            this.Controls.Add(this.lblInspectionStatus);
            this.Controls.Add(this.btnBack);
            //this.Controls.Add(this.panelRight);
            this.Controls.Add(this.panelOuter);
            this.Controls.Add(this.lstMachines);
            this.Font = new Font("Segoe UI", 10F);
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "מערכת בדיקות מכונות";
        }
    }
}
