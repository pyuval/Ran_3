namespace MachineInspections.Forms
{
    partial class MachineSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private FlowLayoutPanel flowPanel;


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
            flowPanel = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // flowPanel
            // 
            flowPanel.AutoScroll = true;
            flowPanel.BackColor = Color.Black;
            flowPanel.Dock = DockStyle.Fill;
            flowPanel.FlowDirection = FlowDirection.RightToLeft;
            flowPanel.Location = new Point(0, 0);
            flowPanel.Name = "flowPanel";
            flowPanel.Padding = new Padding(20);
            flowPanel.Size = new Size(977, 322);
            flowPanel.TabIndex = 0;
            // 
            // MachineSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(977, 322);
            Controls.Add(flowPanel);
            Name = "MachineSelectionForm";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "בחר מכונה";
            ResumeLayout(false);
        }

        #endregion
    }
}