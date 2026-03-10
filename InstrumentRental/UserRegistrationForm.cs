using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class UserRegistrationForm : Form
    {
        private bool isEditMode = false;
        private int currentUserId = 0;

        public UserRegistrationForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            string query = @"SELECT UserID, Username, FullName, Email, Phone, Role, IsActive, CreatedAt 
                           FROM Users ORDER BY FullName";

            DataTable usersTable = DatabaseHelper.ExecuteQuery(query);
            dgvUsers.DataSource = usersTable;

            // Настройка колонок
            dgvUsers.Columns["UserID"].HeaderText = "ID";
            dgvUsers.Columns["Username"].HeaderText = "Логин";
            dgvUsers.Columns["FullName"].HeaderText = "ФИО";
            dgvUsers.Columns["Email"].HeaderText = "Email";
            dgvUsers.Columns["Phone"].HeaderText = "Телефон";
            dgvUsers.Columns["Role"].HeaderText = "Роль";
            dgvUsers.Columns["IsActive"].HeaderText = "Активен";
            dgvUsers.Columns["CreatedAt"].HeaderText = "Дата создания";

            // Форматирование
            dgvUsers.Columns["CreatedAt"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Преобразование булевых значений
            dgvUsers.Columns["IsActive"].CellTemplate.ValueType = typeof(bool);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditMode = false;
            currentUserId = 0;
            EnableForm(true);
            txtPassword.Enabled = true;
            txtConfirmPassword.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvUsers.SelectedRows[0];
                currentUserId = Convert.ToInt32(row.Cells["UserID"].Value);

                txtUsername.Text = row.Cells["Username"].Value.ToString();
                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                cmbRole.SelectedItem = row.Cells["Role"].Value.ToString();
                chkIsActive.Checked = Convert.ToBoolean(row.Cells["IsActive"].Value);

                isEditMode = true;
                EnableForm(true);
                txtPassword.Enabled = false;
                txtConfirmPassword.Enabled = false;
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            else
            {
                MessageBox.Show("Выберите пользователя для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["UserID"].Value);
                string username = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

                // Запрещаем удаление самого себя
                if (userId == UserSession.UserID)
                {
                    MessageBox.Show("Вы не можете удалить свою учетную запись", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Вы уверены, что хотите удалить пользователя {username}?",
                    "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string query = "DELETE FROM Users WHERE UserID = @UserID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@UserID", userId)
                    };

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(query, parameters);
                        LoadUsers();
                        MessageBox.Show("Пользователь успешно удален", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            // Проверка уникальности логина
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username";
            if (isEditMode)
                checkQuery += " AND UserID != @UserID";

            SqlParameter[] checkParams = {
                new SqlParameter("@Username", txtUsername.Text.Trim())
            };

            if (isEditMode)
            {
                Array.Resize(ref checkParams, checkParams.Length + 1);
                checkParams[checkParams.Length - 1] = new SqlParameter("@UserID", currentUserId);
            }

            int count = (int)DatabaseHelper.ExecuteScalar(checkQuery, checkParams);
            if (count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            SqlParameter[] parameters;

            if (isEditMode)
            {
                query = @"UPDATE Users SET Username = @Username, FullName = @FullName, 
                         Email = @Email, Phone = @Phone, Role = @Role, IsActive = @IsActive
                         WHERE UserID = @UserID";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", txtUsername.Text.Trim()),
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@Phone", txtPhone.Text.Trim()),
                    new SqlParameter("@Role", cmbRole.SelectedItem.ToString()),
                    new SqlParameter("@IsActive", chkIsActive.Checked),
                    new SqlParameter("@UserID", currentUserId)
                };
            }
            else
            {
                string hashedPassword = SecurityHelper.HashPassword(txtPassword.Text);

                query = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Phone, Role, IsActive) 
                         VALUES (@Username, @PasswordHash, @FullName, @Email, @Phone, @Role, @IsActive)";

                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", txtUsername.Text.Trim()),
                    new SqlParameter("@PasswordHash", hashedPassword),
                    new SqlParameter("@FullName", txtFullName.Text.Trim()),
                    new SqlParameter("@Email", txtEmail.Text.Trim()),
                    new SqlParameter("@Phone", txtPhone.Text.Trim()),
                    new SqlParameter("@Role", cmbRole.SelectedItem.ToString()),
                    new SqlParameter("@IsActive", true)
                };
            }

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                LoadUsers();
                ClearForm();
                EnableForm(false);
                MessageBox.Show(isEditMode ? "Данные обновлены" : "Пользователь создан", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                DataTable dt = (DataTable)dgvUsers.DataSource;
                dt.DefaultView.RowFilter = $"FullName LIKE '%{searchText}%' OR Username LIKE '%{searchText}%' OR Email LIKE '%{searchText}%'";
            }
            else
            {
                ((DataTable)dgvUsers.DataSource).DefaultView.RowFilter = "";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbRole.SelectedItem == null)
            {
                MessageBox.Show("Выберите роль", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!isEditMode)
            {
                if (string.IsNullOrEmpty(txtPassword.Text))
                {
                    MessageBox.Show("Введите пароль", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (txtPassword.Text.Length < 6)
                {
                    MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                if (txtPassword.Text != txtConfirmPassword.Text)
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                if (!Regex.IsMatch(txtEmail.Text, emailPattern))
                {
                    MessageBox.Show("Введите корректный email", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ClearForm()
        {
            txtUsername.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtPassword.Clear();
            txtConfirmPassword.Clear();
            cmbRole.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }

        private void EnableForm(bool enable)
        {
            gbUserDetails.Enabled = enable;
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable;
            btnDelete.Enabled = !enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            dgvUsers.Enabled = !enable;
            gbSearch.Enabled = !enable;
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}