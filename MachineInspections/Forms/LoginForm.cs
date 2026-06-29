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

        private void InitializeComponent()
        {
            FirstNameTB = new TextBox();
            this.FirstNameLabel = new Label();
            this.PasswordLabel = new Label();
            this.IDLabel = new Label();
            this.LastNameLabel = new Label();
            this.LastNameTB = new TextBox();
            this.IDTB = new TextBox();
            this.PasswordTB = new TextBox();
            this.SignINButton = new Button();
            this.SignUpButton = new Button();
            this.EntryFormLabel = new Label();
            this.SuspendLayout();
            //
            // FirstNameTB
            //
            this.FirstNameTB.ImeMode = ImeMode.NoControl;
            this.FirstNameTB.Location = new System.Drawing.Point(89, 69);
            this.FirstNameTB.Margin = new Padding(4, 4, 4, 4);
            this.FirstNameTB.Name = "FirstNameTB";
            this.FirstNameTB.Size = new System.Drawing.Size(132, 22);
            this.FirstNameTB.TabIndex = 2;
            this.FirstNameTB.TextAlign = HorizontalAlignment.Right;
            this.FirstNameTB.Enter += new System.EventHandler(this.FirstNameTB_Enter);
            //
            // FirstNameLabel
            //
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Location = new System.Drawing.Point(287, 69);
            this.FirstNameLabel.Margin = new Padding(4, 0, 4, 0);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(54, 16);
            this.FirstNameLabel.TabIndex = 1;
            this.FirstNameLabel.Text = "שם פרטי";
            //
            // PasswordLabel
            //
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(300, 217);
            this.PasswordLabel.Margin = new Padding(4, 0, 4, 0);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(44, 16);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "סיסמא";
            //
            // IDLabel
            //
            this.IDLabel.AutoSize = true;
            this.IDLabel.Location = new System.Drawing.Point(287, 171);
            this.IDLabel.Margin = new Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(53, 16);
            this.IDLabel.TabIndex = 3;
            this.IDLabel.Text = "מס אישי";
            //
            // LastNameLabel
            //
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Location = new System.Drawing.Point(271, 118);
            this.LastNameLabel.Margin = new Padding(4, 0, 4, 0);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(67, 16);
            this.LastNameLabel.TabIndex = 4;
            this.LastNameLabel.Text = "שם משפחה";
            //
            // LastNameTB
            //
            this.LastNameTB.ImeMode = ImeMode.NoControl;
            this.LastNameTB.Location = new System.Drawing.Point(89, 110);
            this.LastNameTB.Margin = new Padding(4, 4, 4, 4);
            this.LastNameTB.Name = "LastNameTB";
            this.LastNameTB.Size = new System.Drawing.Size(132, 22);
            this.LastNameTB.TabIndex = 5;
            this.LastNameTB.TextAlign = HorizontalAlignment.Right;
            this.LastNameTB.Enter += new System.EventHandler(this.LastNameTB_Enter);
            //
            // IDTB
            //
            this.IDTB.Location = new System.Drawing.Point(89, 162);
            this.IDTB.Margin = new Padding(4, 4, 4, 4);
            this.IDTB.Name = "IDTB";
            this.IDTB.Size = new System.Drawing.Size(132, 22);
            this.IDTB.TabIndex = 6;
            //
            // PasswordTB
            //
            this.PasswordTB.Location = new System.Drawing.Point(89, 213);
            this.PasswordTB.Margin = new Padding(4, 4, 4, 4);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(132, 22);
            this.PasswordTB.TabIndex = 7;
            //
            // SignINButton
            //
            this.SignINButton.Location = new System.Drawing.Point(253, 300);
            this.SignINButton.Margin = new Padding(4, 4, 4, 4);
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
            this.SignUpButton.Margin = new Padding(4, 4, 4, 4);
            this.SignUpButton.Name = "SignUpButton";
            this.SignUpButton.Size = new System.Drawing.Size(100, 28);
            this.SignUpButton.TabIndex = 9;
            this.SignUpButton.Text = "הירשם";
            this.SignUpButton.UseVisualStyleBackColor = true;
            this.SignUpButton.Click += new System.EventHandler(this.SignUp);
            this.SignUpButton.Visible = false;

            //
            // EntryFormLabel
            //
            this.EntryFormLabel.AutoSize = true;
            this.EntryFormLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.EntryFormLabel.Location = new System.Drawing.Point(124, 17);
            this.EntryFormLabel.Margin = new Padding(4, 0, 4, 0);
            this.EntryFormLabel.Name = "EntryFormLabel";
            this.EntryFormLabel.Size = new System.Drawing.Size(183, 36);
            this.EntryFormLabel.TabIndex = 10;
            this.EntryFormLabel.Text = "כניסה למערכת";
            this.EntryFormLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // LoginForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
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
            this.Margin = new Padding(4, 4, 4, 4);
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
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



 

        private TextBox FirstNameTB;
        private Label FirstNameLabel;
        private Label PasswordLabel;
        private Label IDLabel;
        private Label LastNameLabel;
        private TextBox LastNameTB;
        private TextBox IDTB;
        private TextBox PasswordTB;
        private Button SignINButton;
        private Button SignUpButton;
        private Label EntryFormLabel;
    
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