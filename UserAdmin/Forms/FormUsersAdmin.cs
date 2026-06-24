using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace UserAdmin
{
    public partial class FormUsersAdmin : Form
    {
        private readonly JsonSerializerOptions _jsonOptions;

        private UsersFile _users = new UsersFile();
        private string _usersFilePath;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnEdit;
        private Button btnSave;
        private DataGridView dgvUsers;
        private DataGridViewTextBoxColumn FirstName;
        private DataGridViewTextBoxColumn ID;
        private Label lblSearch;
        private DataGridViewTextBoxColumn Password;
        private DataGridViewTextBoxColumn SecondName;
        private TextBox txtSearch;

        public FormUsersAdmin()
        {
            _jsonOptions = new JsonSerializerOptions { WriteIndented = true, PropertyNameCaseInsensitive = true };

            InitializeComponent();
            LoadUsers();
        }

        private string GetSharedFolder()
        {
            return Path.Combine("..", "..", "..", "SharedData", "InspectionLogs");
        }

        // --------------------------------------------------------- ADD USER ---------------------------------------------------------
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new AddUserForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_users.Users.Any(x => x.ID == form.UserID))
                    {
                        MessageBox.Show("משתמש עם מס אישי זה כבר קיים.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var user = new UserRecord
                    {
                        FirstName = form.FirstName,
                        LastName = form.LastName,
                        ID = form.UserID,
                        Password = form.Password
                    };

                    _users.Users.Add(user);
                    SaveUsers();
                    PopulateGrid();
                }
            }
        }

        // --------------------------------------------------------- DELETE USER ---------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
                return;

            string id = dgvUsers.CurrentRow.Cells["ID"].Value?.ToString();
            var user = _users.Users.FirstOrDefault(u => u.ID == id);
            if (user == null)
                return;

            if (MessageBox.Show(
                    $"למחוק את המשתמש {user.FirstName} {user.LastName}?",
                    "אישור למחיקה",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button2,
                    MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading) != DialogResult.Yes)
            {
                return;
            }

            _users.Users.Remove(user);
            SaveUsers(); // Auto-save changes to file
            PopulateGrid();
        }

        // --------------------------------------------------------- EDIT USER ---------------------------------------------------------
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow == null)
                return;

            string id = dgvUsers.CurrentRow.Cells["ID"].Value?.ToString();
            var user = _users.Users.FirstOrDefault(u => u.ID == id);
            if (user == null)
                return;

            using (var form = new AddUserForm(user.FirstName, user.LastName, user.ID, user.Password))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.UserID != user.ID && _users.Users.Any(x => x.ID == form.UserID))
                    {
                        MessageBox.Show("משתמש עם מס אישי זה כבר קיים.", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    user.FirstName = form.FirstName;
                    user.LastName = form.LastName;
                    user.ID = form.UserID;
                    user.Password = form.Password;

                    SaveUsers();
                    PopulateGrid();
                }
            }
        }

        // --------------------------------------------------------- SAVE BUTTON ---------------------------------------------------------
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUsers();
            MessageBox.Show("המשתמשים נשמרו בהצלחה.", "שמירה", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --------------------------------------------------------- LOAD & SAVE JSON ---------------------------------------------------------
        private void LoadUsers()
        {
            _usersFilePath = Path.Combine("..", "..", "..", @"SharedData\Users", "users.json");

            if (!File.Exists(_usersFilePath))
            {
                _users = new UsersFile();
                SaveUsers();
                return;
            }

            try
            {
                string json = File.ReadAllText(_usersFilePath, Encoding.UTF8);
                _users = JsonSerializer.Deserialize<UsersFile>(json, _jsonOptions) ?? new UsersFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בטעינת קובץ משתמשים: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _users = new UsersFile();
            }

            PopulateGrid();
        }

        private void SaveUsers()
        {
            try
            {
                string directory = Path.GetDirectoryName(_usersFilePath);
                if (!string.IsNullOrEmpty(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string json = JsonSerializer.Serialize(_users, _jsonOptions);
                File.WriteAllText(_usersFilePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"שגיאה בשמירת קובץ משתמשים: {ex.Message}", "שגיאה", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --------------------------------------------------------- POPULATE GRID ---------------------------------------------------------
        private void PopulateGrid(IEnumerable<UserRecord> list = null)
        {
            dgvUsers.Rows.Clear();

            var usersToShow = list ?? _users.Users;
            if (usersToShow == null)
                return;

            foreach (var u in usersToShow)
            {
                dgvUsers.Rows.Add(u.FirstName, u.LastName, u.ID, u.Password);
            }
        }

        // --------------------------------------------------------- SEARCH / FILTER ---------------------------------------------------------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string term = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(term))
            {
                PopulateGrid();
                return;
            }

            var filtered = _users.Users
                .Where(u =>
                    (u.FirstName != null && u.FirstName.ToLower().Contains(term)) ||
                    (u.LastName != null && u.LastName.ToLower().Contains(term)) ||
                    (u.ID != null && u.ID.ToLower().Contains(term)));

            PopulateGrid(filtered);
        }
    }
}