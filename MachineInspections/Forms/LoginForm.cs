using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace MachineInspections
{
    public partial class LoginForm : Form
    {
        private List<Inspector> inspectors = new List<Inspector>();

        public class UserContainer
        {
            public List<Inspector> Users { get; set; }
        }

        public LoginForm()
        {
            InitializeComponent();
            LoadInspectors();
            DialogResult = DialogResult.None;
            FillSignIn();
        }

        private void FillSignIn()
        {
            this.FirstNameTB.Text = "יובל";
            this.LastNameTB.Text = "פארי";
            this.IDTB.Text = "3755839";
            this.PasswordTB.Text = "123456";
        }

        private void LoadInspectors()
        {
            string folder = GetSharedFolder();
            string file = Path.Combine(folder, "Users.json");

            if (!File.Exists(file))
                return;

            try
            {
                string jsonString = File.ReadAllText(file);
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var container = JsonSerializer.Deserialize<UserContainer>(jsonString, options);

                if (container?.Users != null)
                {
                    inspectors = container.Users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading JSON: {ex.Message}");
            }
        }

        private void LoadInspectors1()
        {
            string folder = GetSharedFolder();
            string file = Path.Combine(folder, "Users.json");

            if (!File.Exists(file))
            {
                return;
            }

            try
            {
                foreach (var line in File.ReadLines(file, Encoding.UTF8).Skip(1))
                {
                    var p = line.Split(',');

                    inspectors.Add(new Inspector
                    {
                        FirstName = p[0].Trim(),
                        LastName = p[1].Trim(),
                        ID = p[2].Trim(),
                        Password = p.Length > 3 ? p[3].Trim() : string.Empty
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        public static void CreateInspectorsCsv(string folderPath, List<Inspector> inspectors)
        {
            Directory.CreateDirectory(folderPath);

            string filePath = Path.Combine(folderPath, "Users.json");

            using (var sw = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                sw.WriteLine("FirstName,LastName,ID,Password");

                foreach (var i in inspectors)
                {
                    sw.WriteLine($"{i.FirstName},{i.LastName},{i.ID},{i.Password}");
                }
            }
        }

        public static void SaveInspectorsJson(string folderPath, List<Inspector> inspectors)
        {
            Directory.CreateDirectory(folderPath);
            string filePath = Path.Combine(folderPath, "Users.json");

            var container = new UserContainer { Users = inspectors };
            var options = new JsonSerializerOptions { WriteIndented = true };

            string jsonString = JsonSerializer.Serialize(container, options);
            File.WriteAllText(filePath, jsonString, Encoding.UTF8);
        }

        private void SaveInspectorsCsv()
        {
            string folder = GetSharedFolder();
            CreateInspectorsCsv(folder, inspectors);

            this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private void SignIn(object sender, EventArgs e)
        {
            string name = FirstNameTB.Text.Trim();
            string lastName = LastNameTB.Text.Trim();
            string id = IDTB.Text.Trim();
            string password = PasswordTB.Text.Trim();

            var inspector = inspectors.FirstOrDefault(inspect =>
                inspect.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                inspect.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) &&
                inspect.ID == id && inspect.Password == password);

            if (inspector == null)
            {
                MessageBox.Show("אף משתמש כזה לא קיים. פנה למנהל");
                return;
            }
            if (string.IsNullOrEmpty(inspector.Password))
            {
                MessageBox.Show("משתמש לא רשום. אנא הירשם תחילה");
                return;
            }
            if (inspector.Password != password)
            {
                MessageBox.Show("סיסמא שגויה.");
                return;
            }

            // SUCCESS
            LoggedInInspector = inspector;
            this.DialogResult = DialogResult.OK;
            // this.Close();
        }

        private void SignUp(object sender, EventArgs e)
        {
            string name = FirstNameTB.Text.Trim();
            string LastName = LastNameTB.Text.Trim();
            string id = IDTB.Text.Trim();
            string password = PasswordTB.Text.Trim();

            var inspector = inspectors.FirstOrDefault(i =>
                i.FirstName.Equals(name, StringComparison.OrdinalIgnoreCase) &&
                i.LastName.Equals(LastName, StringComparison.OrdinalIgnoreCase) &&
                i.ID == id);

            if (inspector == null)
            {
                MessageBox.Show("אף משתמש כזה לא קיים. פנה למנהל");
                return;
            }
            if (!string.IsNullOrEmpty(inspector.Password))
            {
                MessageBox.Show("משתמש כבר רשום. אנא התחבר");
                return;
            }

            // Save password
            inspector.Password = password;

            SaveInspectorsCsv();

            MessageBox.Show("הרשמה בוצעה בהצלחה. כעת ניתן להיכנס");
        }


        private string GetSharedFolder()
        {

            string folder = GetSetting("Users", "Users");
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            folder = @Path.GetFullPath(Path.Combine(baseDir, folder));

            return folder;

        }

        private string GetSetting(string key, string defaultValue)
        {

            return ConfigurationManager.AppSettings[key] ?? defaultValue;
        }
        public Inspector LoggedInInspector { get; private set; }
    }
}