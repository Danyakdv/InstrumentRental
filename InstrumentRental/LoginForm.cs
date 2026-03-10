using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Введите логин и пароль!", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(password);

            try
            {
                string query = @"SELECT UserID, Username, FullName, Role 
                               FROM Users 
                               WHERE Username = @Username AND PasswordHash = @PasswordHash AND IsActive = 1";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@PasswordHash", hashedPassword)
                };

                DataTable result = DatabaseHelper.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0)
                {
                    DataRow row = result.Rows[0];
                    UserSession.UserID = Convert.ToInt32(row["UserID"]);
                    UserSession.Username = row["Username"].ToString();
                    UserSession.FullName = row["FullName"].ToString();
                    UserSession.Role = row["Role"].ToString();
                    UserSession.IsAuthenticated = true;

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Открываем форму регистрации клиента
            using (ClientRegistrationForm registerForm = new ClientRegistrationForm())
            {
                if (registerForm.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show("Регистрация успешно завершена!", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}