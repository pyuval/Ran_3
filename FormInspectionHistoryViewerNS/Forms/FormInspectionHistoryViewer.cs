using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormInspectionHistoryViewerNS
{
    public partial class FormInspectionHistoryViewer : Form
    {
        public FormInspectionHistoryViewer()
        {
            InitializeComponent();
            LoadFileList();
        }

        private List<string> _allFiles = new List<string>();

        private string GetSharedFolder()
        {
            string folder = FileOperationsNS.FileOperations.GetSharedFolder("InspectionLogs");

            return folder;
        }

        private void LoadFileList()
        {
            string folder = GetSharedFolder();

            Directory.CreateDirectory(folder);

            _allFiles = Directory.GetFiles(folder, "*.csv")
                                 .OrderByDescending(f => f)
                                 .ToList();

            lstFiles.Items.Clear();
            lstFiles.Items.AddRange(_allFiles.Select(Path.GetFileName).ToArray());
        }

        private void FilterFiles()
        {
            string term = (txtSearch.Text ?? string.Empty).Trim().ToLowerInvariant();

            var filtered = _allFiles.Where(f => Path.GetFileName(f).ToLower().Contains(term)).ToList();

            lstFiles.Items.Clear();
            lstFiles.Items.AddRange(filtered.Select(Path.GetFileName).ToArray()!);
        }

        private void LoadCsvPreview()
        {
            try
            {
                if (lstFiles.SelectedItem == null)
                    return;


                string folder = FileOperationsNS.FileOperations.GetSharedFolder("InspectionLogs");


                string? fileName = lstFiles.SelectedItem as string;
                if (string.IsNullOrEmpty(fileName))
                    return;

                string filePath = Path.Combine(folder, fileName);

                dgvPreview.Columns.Clear();
                dgvPreview.Rows.Clear();

                var lines = File.ReadAllLines(filePath, Encoding.UTF8);
                if (lines.Length == 0) return;

                var headers = lines[0].Split(',');
                foreach (var h in headers)
                    dgvPreview.Columns.Add(h, h);

                for (int i = 1; i < lines.Length; i++)
                    dgvPreview.Rows.Add(lines[i].Split(','));
            }
            catch (Exception e)
            {
                MessageBox.Show($"{e.Message}");
            }
        }


        private void OpenSelectedFile()
        {
            try
            {

                if (lstFiles.SelectedItem == null)
                    return;

                string? selectedFile = lstFiles.SelectedItem as string;
                if (string.IsNullOrEmpty(selectedFile))
                    return;

                string folder = GetSharedFolder();
                string filePath = Path.Combine(folder, selectedFile);
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                folder = @Path.GetFullPath(Path.Combine(baseDir, folder));



                var startInfo = new ProcessStartInfo
                {
                    FileName = selectedFile,
                    WorkingDirectory = folder,
                    UseShellExecute = true // Crucial for non-executable files in .NET Core+
                };


                using Process? process = Process.Start(startInfo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the selected file: {ex.Message}");
            }
        }

        private void OpenZipFolder()
        {
            string zipFolder = GetSharedFolder();
            Directory.CreateDirectory(zipFolder);
            using var _ = Process.Start(zipFolder);
        }

        //private string GetSetting(string key, string defaultValue)
        //{

        //    return ConfigurationManager.AppSettings[key] ?? defaultValue;
        //}
    }
}
