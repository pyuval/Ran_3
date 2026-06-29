using FileOperationsNS.Models;
using System.Configuration;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
namespace FileOperationsNS
{
    public class FileOperations
    {
        public static string GetSharedFolder(string folderName)
        {

            string folder = GetSetting(folderName, folderName);
            //string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string exePath = AppContext.BaseDirectory;

            folder = @Path.GetFullPath(Path.Combine(exePath, folder));
           

            return folder;

        }

        public static int GetSettingInt(string key, int defaultValue)
        {
            if (int.TryParse(ConfigurationManager.AppSettings[key], out int value))
                return value;
            return defaultValue;
        }


        public static string GetSetting(string key, string defaultValue)
        {
            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }

        public static string SaveToJsonResultFile(MachineDefinition machine, string folderPath)
        {
            try
            {

         
            string folder = GetSharedFolder(folderPath);
            Directory.CreateDirectory(folder);
            string filePath = Path.Combine(folder, $"{machine.MachineName}.json");
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
            };

            string json = JsonSerializer.Serialize(machine, options);
            File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                return  ex.Message;
                
            }

            return string.Empty;
            
        }

        public static void AppendInspectionToCsv(Inspector inspector, MachineDefinition machine, string intervalKey, List<(string Code, bool Done)> results)
        {
            try
            {
                string filePath = GetActiveCsvFile(machine);

                using (var writer = new StreamWriter(filePath, append: true, new UTF8Encoding(true)))
                {
                    foreach (var r in results)
                    {
                        string result = r.Done ? "עבר" : "נכשל";

                        writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}," +
                                         $"{inspector.FirstName} {inspector.LastName}," +
                                         $"{inspector.ID}," +
                                         $"{machine.MachineName}," +
                                         $"{machine.SerialNumber}," +
                                         $"{intervalKey}," +
                                         $"{r.Code}," +
                                         $"{result}");
                    }
                }
            }
            catch (Exception ex)
            {
               // MessageBox.Show("Error writing CSV: " + ex.Message, "IO Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        private static string GetActiveCsvFile(MachineDefinition machine)
        {
            string folder = FileOperationsNS.FileOperations.GetSharedFolder("Machines");
            Directory.CreateDirectory(folder);

            string baseName = FileOperationsNS.FileOperations.GetSetting("CsvBaseName", "Results");
            int maxSizeMB = FileOperationsNS.FileOperations.GetSettingInt("CsvMaxSizeMB", 2);
            int maxFiles = FileOperationsNS.FileOperations.GetSettingInt("CsvMaxFiles", 50);

            // Find existing target logs matching patterns
            var files = Directory.GetFiles(folder, $"{machine.MachineName}*.csv")
                                 .OrderBy(f => f)
                                 .ToList();

            if (files.Count == 0)
                return CreateNewCsvFile(machine, folder, baseName);

            string latest = files.Last();

            // Perform rolling-file dimension check limits
            long sizeMB = new FileInfo(latest).Length / (1024 * 1024);
            if (sizeMB >= maxSizeMB)
            {
                latest = CreateNewCsvFile(machine, folder, baseName);
                files.Add(latest);
            }

            // Evict overflow historical log sets if criteria bounds are exceeded
            if (files.Count > maxFiles)
            {
                int toDelete = files.Count - maxFiles;
                foreach (var old in files.Take(toDelete))
                {
                    try
                    {
                        File.Delete(old);
                    }
                    catch
                    {
                        // Fail silently or log background diagnostic details if file lock exists
                    }
                }
            }

            return latest;
        }

        private static string CreateNewCsvFile(MachineDefinition machine, string folder, string baseName)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = Path.Combine(folder, $"{machine.MachineName}.{baseName}_{timestamp}.csv");

            using (var writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                writer.WriteLine("תאריך,שם הבודק,מספר אישי,מכונה,מס סיריאלי,תדירות,סוג הבדיקה,תוצאות הבדיקה");
            }

            return filePath;
        }

    }
}
