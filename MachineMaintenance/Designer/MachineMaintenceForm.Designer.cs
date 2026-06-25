using System;
using System.Drawing;
using System.Windows.Forms;

namespace MachineMaintenance
{

    partial class MachineMaintenenceForm
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
        {
            if (disposing && (components != null))
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtSerial = new System.Windows.Forms.TextBox();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTests = new System.Windows.Forms.Label();
            this.treeTests = new System.Windows.Forms.TreeView();
            this.btnAddTest = new System.Windows.Forms.Button();
            this.btnEditTest = new System.Windows.Forms.Button();
            this.btnDeleteTest = new System.Windows.Forms.Button();
            this.btnLoadJson = new System.Windows.Forms.Button();
            this.btnSaveJson = new System.Windows.Forms.Button();
            this.lblSelectMachine = new System.Windows.Forms.Label();
            this.cmbMachines = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddInterval = new System.Windows.Forms.Button();
            this.btnDeleteInterval = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();




            this.btnAddMachine = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            //
            // lblSerial
            //
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(918, 98);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(64, 16);
            this.lblSerial.TabIndex = 2;
            this.lblSerial.Text = "מס סידורי";


            this.grpIntervals = new GroupBox();

            //this.grpIntervals.Margin = new Padding(0, 555, 0, 0);
            this.grpIntervals.Location = new Point(50, 540);
            this.grpIntervals.Size = new Size(460, 90);
            this.grpIntervals.RightToLeft = RightToLeft.Yes;
            this.grpIntervals.Text = "מועדים";


            this.grpTests = new GroupBox();
            this.grpTests.Text = "בדיקות";
            this.grpTests.RightToLeft = RightToLeft.Yes;
            //this.grpTests.Margin = new Padding(0, 5, 0, 0);
            this.grpTests.Location = new Point(50, 650);
            this.grpTests.Size = new Size(460, 80);

            //this.grpTests.BringToFront();
            //this.grpIntervals.BringToFront();

            //
            // txtSerial
            //
            this.txtSerial.Location = new System.Drawing.Point(564, 95);
            this.txtSerial.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Size = new System.Drawing.Size(265, 22);
            this.txtSerial.TabIndex = 3;
            //
            // lblSchedule
            //
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Location = new System.Drawing.Point(887, 145);
            this.lblSchedule.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(95, 16);
            this.lblSchedule.TabIndex = 8;
            this.lblSchedule.Text = "תדירות בדיקות";
            //
            // dgvSchedule
            //
            this.dgvSchedule.ColumnHeadersHeight = 29;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.dgvSchedule.Location = new System.Drawing.Point(542, 175);
            this.dgvSchedule.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSchedule.RowHeadersWidth = 51;
            this.dgvSchedule.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgvSchedule.Size = new System.Drawing.Size(378, 246);
            this.dgvSchedule.TabIndex = 9;
            //
            // dataGridViewTextBoxColumn1
            //
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.HeaderText = "שם הבדיקה";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 180;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            //
            // dataGridViewTextBoxColumn2
            //
            this.dataGridViewTextBoxColumn2.HeaderText = "תדירות";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 80;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            //
            // lblTests
            //
            this.lblTests.AutoSize = true;
            this.lblTests.Location = new System.Drawing.Point(439, 31);
            this.lblTests.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTests.Name = "lblTests";
            this.lblTests.Size = new System.Drawing.Size(49, 16);
            this.lblTests.TabIndex = 10;
            this.lblTests.Text = "בדיקות";
            //
            // treeTests
            //
            this.treeTests.AllowDrop = true;
            this.treeTests.HideSelection = false;
            this.treeTests.Location = new System.Drawing.Point(32, 63);
            this.treeTests.Margin = new System.Windows.Forms.Padding(4);
            this.treeTests.Name = "treeTests";
            this.treeTests.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.treeTests.RightToLeftLayout = true;
            this.treeTests.Size = new System.Drawing.Size(465, 454);
            this.treeTests.TabIndex = 11;
            this.treeTests.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeTests_ItemDrag);
            this.treeTests.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeTests_DragDrop);
            this.treeTests.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeTests_DragEnter);
            this.treeTests.DragOver += new System.Windows.Forms.DragEventHandler(this.treeTests_DragOver);
            //

            // btnLoadJson
            //
            this.btnLoadJson.Location = new System.Drawing.Point(882, 506);
            this.btnLoadJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadJson.Name = "btnLoadJson";
            this.btnLoadJson.Size = new System.Drawing.Size(100, 28);
            this.btnLoadJson.TabIndex = 15;
            this.btnLoadJson.Text = "טען נתונים";
            this.btnLoadJson.Visible = false;
            this.btnLoadJson.Click += new System.EventHandler(this.btnLoadJson_Click);
            //
           
            //
            // lblSelectMachine
            //
            this.lblSelectMachine.AutoSize = true;
            this.lblSelectMachine.Location = new System.Drawing.Point(919, 63);
            this.lblSelectMachine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelectMachine.Name = "lblSelectMachine";
            this.lblSelectMachine.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSelectMachine.Size = new System.Drawing.Size(66, 16);
            this.lblSelectMachine.TabIndex = 0;
            this.lblSelectMachine.Text = "בחר מכונה";
            //
            // cmbMachines
            //
            this.cmbMachines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMachines.Location = new System.Drawing.Point(560, 59);
            this.cmbMachines.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMachines.Name = "cmbMachines";
            this.cmbMachines.Size = new System.Drawing.Size(269, 24);
            this.cmbMachines.TabIndex = 1;
            this.cmbMachines.SelectedIndexChanged += new System.EventHandler(this.cmbMachines_SelectedIndexChanged);

            // ------------- INTERVALS -------------
            //add interval label
            //
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 565);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(285, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "* לאחר הוספת מועד ניתן לגרור אותו למקום הרצוי             ";

            // btnAddInterval
            //
            this.btnAddInterval.Location = new System.Drawing.Point(395, 590);
            //this.btnAddInterval.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddInterval.Name = "btnAddInterval";
            this.btnAddInterval.Size = new System.Drawing.Size(100, 28);
            this.btnAddInterval.TabIndex = 0;
            this.btnAddInterval.Text = "הוסף מועד";
            this.btnAddInterval.Click += new System.EventHandler(this.btnAddInterval_Click);
            //
            // btnDeleteInterval
            //
            this.btnDeleteInterval.Location = new System.Drawing.Point(269, 590);
            this.btnDeleteInterval.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteInterval.Name = "btnDeleteInterval";
            this.btnDeleteInterval.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteInterval.TabIndex = 18;
            this.btnDeleteInterval.Text = "מחק מועד";
            this.btnDeleteInterval.Click += new System.EventHandler(this.btnDeleteInterval_Click);
            // --- ADD CONTROLS INTO GROUPBOXES ---

            this.grpIntervals.Controls.Add(this.label2);
            this.grpIntervals.Controls.Add(this.btnAddInterval);
            this.grpIntervals.Controls.Add(this.btnDeleteInterval);


            // ------------------ Test label ----------------
            //
            // add test label
            //
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 670);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(362, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "            * בכדי להוסיף, למחוק, או לערוך בדיקה יש לעמוד על הענף בעץ             ";
            //
            // btnAddTest
            //
            this.btnAddTest.Location = new System.Drawing.Point(377, 690);
            this.btnAddTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTest.Name = "btnAddTest";
            this.btnAddTest.Size = new System.Drawing.Size(113, 28);
            this.btnAddTest.TabIndex = 12;
            this.btnAddTest.Text = "הוסף בדיקה";
            this.btnAddTest.Click += new System.EventHandler(this.btnAddTest_Click);
            //
            // btnEditTest
            //
            this.btnEditTest.Location = new System.Drawing.Point(124, 690);
            this.btnEditTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditTest.Name = "btnEditTest";
            this.btnEditTest.Size = new System.Drawing.Size(107, 28);
            this.btnEditTest.TabIndex = 13;
            this.btnEditTest.Text = "ערוך בדיקה";
            this.btnEditTest.Click += new System.EventHandler(this.btnEditTest_Click);
            //
            // btnDeleteTest
            //
            this.btnDeleteTest.Location = new System.Drawing.Point(256, 690);
            this.btnDeleteTest.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteTest.Name = "btnDeleteTest";
            this.btnDeleteTest.Size = new System.Drawing.Size(100, 28);
            this.btnDeleteTest.TabIndex = 14;
            this.btnDeleteTest.Text = "מחק בדיקה";
            this.btnDeleteTest.Click += new System.EventHandler(this.btnDeleteTest_Click);

            this.grpTests.Controls.Add(this.label1);
            this.grpTests.Controls.Add(this.btnAddTest);
            this.grpTests.Controls.Add(this.btnEditTest);
            this.grpTests.Controls.Add(this.btnDeleteTest);

            //
            // btnSaveJson
            //
            this.btnSaveJson.Location = new System.Drawing.Point(340, 740);
            this.btnSaveJson.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveJson.Name = "btnSaveJson";
            this.btnSaveJson.Size = new System.Drawing.Size(167, 28);
            this.btnSaveJson.TabIndex = 16;
            this.btnSaveJson.Text = "שמור נתונים";
            this.btnSaveJson.Click += new System.EventHandler(this.btnSaveJson_Click);

            // ---- Add Machine button ----
            // btnAddMachine
            //
            this.btnAddMachine.Location = new System.Drawing.Point(797, 451);
            this.btnAddMachine.Name = "btnAddMachine";
            this.btnAddMachine.Size = new System.Drawing.Size(185, 23);
            this.btnAddMachine.TabIndex = 0;
            this.btnAddMachine.Text = "הוסף מכונה";
            this.btnAddMachine.Click += new System.EventHandler(this.OnAddMachine);
            //
            // MachineMaintenenceForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 800);


            this.Controls.Add(this.btnAddMachine);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectMachine);
            this.Controls.Add(this.cmbMachines);
            this.Controls.Add(this.lblSerial);
            this.Controls.Add(this.txtSerial);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.dgvSchedule);
            this.Controls.Add(this.lblTests);
            this.Controls.Add(this.treeTests);
            this.Controls.Add(this.btnLoadJson);

            //Add Interval
            this.Controls.Add(this.btnAddInterval);
            this.Controls.Add(this.btnDeleteInterval);

            //Add Test
            this.Controls.Add(this.btnAddTest);
            this.Controls.Add(this.btnEditTest);
            this.Controls.Add(this.btnDeleteTest);


            this.Controls.Add(this.grpIntervals);
            this.Controls.Add(this.grpTests);
            this.Controls.Add(this.btnSaveJson);





            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MachineMaintenenceForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "טופס מכונות";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        #region UI Controls
        private System.Windows.Forms.TextBox txtSerial;

        private System.Windows.Forms.DataGridView dgvSchedule;

        private System.Windows.Forms.TreeView treeTests;

        private System.Windows.Forms.Button btnAddTest;
        private System.Windows.Forms.Button btnEditTest;
        private System.Windows.Forms.Button btnDeleteTest;

        private System.Windows.Forms.Button btnLoadJson;
        private System.Windows.Forms.Button btnSaveJson;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblTests;
        private Button btnAddInterval;
        private Button btnAddMachine;


        private ComboBox cmbMachines;
        private Label lblSelectMachine;
        private Button btnDeleteInterval;


        //load json


        #endregion
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private GroupBox grpTests; private GroupBox grpIntervals;

    }
}
