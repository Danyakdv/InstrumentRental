using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Новый пароль и подтверждение не совпадают", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword.Length < 6)
            {
                MessageBox.Show("Пароль должен содержать минимум 6 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверяем старый пароль
            string oldHash = SecurityHelper.HashPassword(oldPassword);
            string checkQuery = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND PasswordHash = @PasswordHash";

            SqlParameter[] checkParams = {
                new SqlParameter("@UserID", UserSession.UserID),
                new SqlParameter("@PasswordHash", oldHash)
            };

            int count = (int)DatabaseHelper.ExecuteScalar(checkQuery, checkParams);

            if (count == 0)
            {
                MessageBox.Show("Неверный текущий пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Меняем пароль
            string newHash = SecurityHelper.HashPassword(newPassword);
            string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash WHERE UserID = @UserID";

            SqlParameter[] updateParams = {
                new SqlParameter("@PasswordHash", newHash),
                new SqlParameter("@UserID", UserSession.UserID)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(updateQuery, updateParams);
                MessageBox.Show("Пароль успешно изменен", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при смене пароля: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtOldPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtNewPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
            txtConfirmPassword.UseSystemPasswordChar = !chkShowPassword.Checked;
        }
    }
}