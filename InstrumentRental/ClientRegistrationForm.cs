using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ClientRegistrationForm : Form
    {
        public ClientRegistrationForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            // Проверка уникальности телефона
            string checkPhoneQuery = "SELECT COUNT(*) FROM Clients WHERE Phone = @Phone AND IsActive = 1";
            SqlParameter[] checkPhoneParams = {
                new SqlParameter("@Phone", txtPhone.Text.Trim())
            };

            int phoneCount = (int)DatabaseHelper.ExecuteScalar(checkPhoneQuery, checkPhoneParams);
            if (phoneCount > 0)
            {
                MessageBox.Show("Клиент с таким телефоном уже зарегистрирован", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Проверка уникальности email (если указан)
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                string checkEmailQuery = "SELECT COUNT(*) FROM Clients WHERE Email = @Email AND IsActive = 1";
                SqlParameter[] checkEmailParams = {
                    new SqlParameter("@Email", txtEmail.Text.Trim())
                };

                int emailCount = (int)DatabaseHelper.ExecuteScalar(checkEmailQuery, checkEmailParams);
                if (emailCount > 0)
                {
                    MessageBox.Show("Клиент с таким email уже зарегистрирован", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Сохраняем клиента
            string query = @"INSERT INTO Clients (FullName, Phone, Email, Address, PassportData, RegistrationDate, IsActive) 
                           VALUES (@FullName, @Phone, @Email, @Address, @PassportData, @RegistrationDate, 1);
                           SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@FullName", txtFullName.Text.Trim()),
                new SqlParameter("@Phone", txtPhone.Text.Trim()),
                new SqlParameter("@Email", string.IsNullOrEmpty(txtEmail.Text) ? DBNull.Value : (object)txtEmail.Text.Trim()),
                new SqlParameter("@Address", string.IsNullOrEmpty(txtAddress.Text) ? DBNull.Value : (object)txtAddress.Text.Trim()),
                new SqlParameter("@PassportData", txtPassport.Text.Trim()),
                new SqlParameter("@RegistrationDate", DateTime.Now)
            };

            try
            {
                int clientId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));

                MessageBox.Show($"Регистрация успешно завершена!\nВаш ID клиента: {clientId}", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при регистрации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Введите номер телефона", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка формата телефона (простая)
            string phonePattern = @"^\+?[0-9\s\-\(\)]+$";
            if (!Regex.IsMatch(txtPhone.Text, phonePattern))
            {
                MessageBox.Show("Введите корректный номер телефона", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassport.Text))
            {
                MessageBox.Show("Введите паспортные данные", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка паспортных данных (пример: серия и номер)
            string passportPattern = @"^\d{4}\s?\d{6}$";
            if (!Regex.IsMatch(txtPassport.Text.Replace(" ", ""), passportPattern))
            {
                MessageBox.Show("Введите паспортные данные в формате: 1234 567890", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем цифры, управляющие клавиши и некоторые специальные символы
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '(' &&
                e.KeyChar != ')' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPassport_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Для паспорта разрешаем только цифры и пробел
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}