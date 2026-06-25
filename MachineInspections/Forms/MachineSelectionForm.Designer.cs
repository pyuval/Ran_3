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
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "MachineSelectionForm";

            this.flowPanel = new FlowLayoutPanel();
            this.flowPanel.Dock = DockStyle.Fill;
            this.flowPanel.AutoScroll = true;
            this.flowPanel.FlowDirection = FlowDirection.RightToLeft;
            this.flowPanel.WrapContents = true; // 2–3 כפתורים בשורה
            this.flowPanel.Padding = new Padding(20);
            this.flowPanel.BackColor = Color.Black;

            this.Controls.Add(this.flowPanel);

            this.Text = "בחר מכונה";
            this.RightToLeftLayout = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new Size(600, 800);
        }

        #endregion
    }
}