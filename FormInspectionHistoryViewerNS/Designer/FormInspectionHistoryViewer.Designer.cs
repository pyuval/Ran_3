using System.Windows.Forms;

namespace FormInspectionHistoryViewerNS
{
    partial class FormInspectionHistoryViewer
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox lstFiles;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvPreview;
        private Button btnOpen;
        private Button btnRefresh;
        private Button btnOpenZipFolder;

        protected override void Dispose(bool disposing)
        {if(disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "טבלת הסטוריה של כל הבדיקות";
            this.ClientSize = new Size(1200, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.RightToLeft = RightToLeft.Yes;
            this.RightToLeftLayout = true;

            lblSearch = new Label { Text = "Search:", Location = new Point(20, 20), AutoSize = true };

            txtSearch = new TextBox { Location = new Point(80, 18), Width = 200 };
            txtSearch.TextChanged += (s, e) => FilterFiles();

            lstFiles = new ListBox { Location = new Point(20, 60), Size = new Size(260, 480) };
            lstFiles.SelectedIndexChanged += (s, e) => LoadCsvPreview();

            dgvPreview = new DataGridView
            {
                Location = new Point(300, 60),
                Size = new Size(900, 480),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false
            };

            btnOpen = new Button { Text = "Open File", Location = new Point(20, 550), Width = 120 };
            btnOpen.Click += (s, e) => OpenSelectedFile();

            btnRefresh = new Button { Text = "Refresh", Location = new Point(160, 550), Width = 120 };
            btnRefresh.Click += (s, e) => LoadFileList();

            btnOpenZipFolder = new Button { Text = "Open Archive", Location = new Point(300, 550), Width = 120 };
            btnOpenZipFolder.Click += (s, e) => OpenZipFolder();

            this.Controls.Add(lblSearch);
            this.Controls.Add(txtSearch);
            this.Controls.Add(lstFiles);
            this.Controls.Add(dgvPreview);
            this.Controls.Add(btnOpen);
            this.Controls.Add(btnRefresh);
            this.Controls.Add(btnOpenZipFolder);
        }
        private void InitializeComponent1()
        {
            this.components = new System.ComponentModel.Container();

            this.lstFiles = new ListBox();
            this.txtSearch = new TextBox();
            this.lblSearch = new Label();
            this.dgvPreview = new DataGridView();
            this.btnOpen = new Button();
            this.btnRefresh = new Button();
            this.btnOpenZipFolder = new Button();

            this.SuspendLayout();

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.lblSearch.Text = "Search:";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(80, 18);
            this.txtSearch.Size = new System.Drawing.Size(200, 22);

            // lstFiles
            this.lstFiles.Location = new System.Drawing.Point(20, 60);
            this.lstFiles.Size = new System.Drawing.Size(260, 480);

            // dgvPreview
            this.dgvPreview.Location = new System.Drawing.Point(300, 60);
            this.dgvPreview.Size = new System.Drawing.Size(900, 480);
            this.dgvPreview.ReadOnly = true;
            this.dgvPreview.AllowUserToAddRows = false;
            this.dgvPreview.AllowUserToDeleteRows = false;

            // btnOpen
            this.btnOpen.Location = new System.Drawing.Point(20, 550);
            this.btnOpen.Size = new System.Drawing.Size(120, 30);
            this.btnOpen.Text = "Open File";

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(160, 550);
            this.btnRefresh.Size = new System.Drawing.Size(120, 30);
            this.btnRefresh.Text = "Refresh";

            // btnOpenZipFolder
            this.btnOpenZipFolder.Location = new System.Drawing.Point(300, 550);
            this.btnOpenZipFolder.Size = new System.Drawing.Size(120, 30);
            this.btnOpenZipFolder.Text = "Open Archive";

            // FormInspectionHistoryViewer
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.dgvPreview);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnOpenZipFolder);
            this.Name = "FormInspectionHistoryViewer";
            this.Text = "טבלת הסטוריה של כל הבדיקות";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
