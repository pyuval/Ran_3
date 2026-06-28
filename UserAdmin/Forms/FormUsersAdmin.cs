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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(815, 27);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(34, 16);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "חפש:";
            //
            // txtSearch
            //
            this.txtSearch.Location = new System.Drawing.Point(591, 24);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.Click += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            //
            // dgvUsers
            //
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.ColumnHeadersHeight = 29;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FirstName,
            this.SecondName,
            this.ID,
            this.Password});
            this.dgvUsers.Location = new System.Drawing.Point(40, 60);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(806, 350);
            this.dgvUsers.TabIndex = 2;
            //
            // FirstName
            //
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "שם";
            this.FirstName.MinimumWidth = 100;
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            this.FirstName.Width = 125;
            //
            // SecondName
            //
            this.SecondName.DataPropertyName = "SecondName";
            this.SecondName.HeaderText = "משפחה";
            this.SecondName.MinimumWidth = 150;
            this.SecondName.Name = "SecondName";
            this.SecondName.ReadOnly = true;
            this.SecondName.Width = 150;
            //
            // ID
            //
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "מס אישי";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 125;
            //
            // Password
            //
            this.Password.DataPropertyName = "Password";
            this.Password.HeaderText = "סיסמא";
            this.Password.MinimumWidth = 6;
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Width = 125;
            //
            // btnAdd
            //
            this.btnAdd.Location = new System.Drawing.Point(538, 430);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "הוסף בודק";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnEdit
            //
            this.btnEdit.Location = new System.Drawing.Point(424, 430);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "ערוך בודק";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            //
            // btnDelete
            //
            this.btnDelete.Location = new System.Drawing.Point(330, 430);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "מחק בודק";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnSave
            //
            this.btnSave.Location = new System.Drawing.Point(218, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "שמור";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // FormUsersAdmin
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 500);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Name = "FormUsersAdmin";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ניהול בודקים";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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