using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ClientsForm : Form
    {
        private DataTable clientsTable;
        private bool isEditMode = false;
        private int currentClientId = 0;

        public ClientsForm()
        {
            InitializeComponent();
            LoadClients();
        }

        private void LoadClients()
        {
            string query = @"SELECT ClientID, FullName, Phone, Email, Address, 
                                    PassportData, RegistrationDate 
                             FROM Clients WHERE IsActive = 1 ORDER BY FullName";

            clientsTable = DatabaseHelper.ExecuteQuery(query);
            dgvClients.DataSource = clientsTable;

            // Настройка отображения колонок
            dgvClients.Columns["ClientID"].HeaderText = "ID";
            dgvClients.Columns["FullName"].HeaderText = "ФИО";
            dgvClients.Columns["Phone"].HeaderText = "Телефон";
            dgvClients.Columns["Email"].HeaderText = "Email";
            dgvClients.Columns["Address"].HeaderText = "Адрес";
            dgvClients.Columns["PassportData"].HeaderText = "Паспортные данные";
            dgvClients.Columns["RegistrationDate"].HeaderText = "Дата регистрации";

            // Форматирование даты
            dgvClients.Columns["RegistrationDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditMode = false;
            currentClientId = 0;
            EnableForm(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvClients.SelectedRows[0];
                currentClientId = Convert.ToInt32(row.Cells["ClientID"].Value);

                txtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtPassport.Text = row.Cells["PassportData"].Value.ToString();
                dtpRegistrationDate.Value = Convert.ToDateTime(row.Cells["RegistrationDate"].Value);

                isEditMode = true;
                EnableForm(true);
            }
            else
            {
                MessageBox.Show("Выберите клиента для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClients.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этого клиента?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int clientId = Convert.ToInt32(dgvClients.SelectedRows[0].Cells["ClientID"].Value);

                    // Soft delete - помечаем как неактивного
                    string query = "UPDATE Clients SET IsActive = 0 WHERE ClientID = @ClientID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@ClientID", clientId)
                    };

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(query, parameters);
                        LoadClients();
                        MessageBox.Show("Клиент успешно удален", "Успех",
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

            // Проверка уникальности телефона
            string checkQuery = "SELECT COUNT(*) FROM Clients WHERE Phone = @Phone AND IsActive = 1";
            if (isEditMode)
                checkQuery += " AND ClientID != @ClientID";

            SqlParameter[] checkParams = {
                new SqlParameter("@Phone", txtPhone.Text)
            };

            if (isEditMode)
            {
                Array.Resize(ref checkParams, checkParams.Length + 1);
                checkParams[checkParams.Length - 1] = new SqlParameter("@ClientID", currentClientId);
            }

            int count = (int)DatabaseHelper.ExecuteScalar(checkQuery, checkParams);
            if (count > 0)
            {
                MessageBox.Show("Клиент с таким телефоном уже существует", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query;
            SqlParameter[] parameters;

            if (isEditMode)
            {
                query = @"UPDATE Clients SET FullName = @FullName, Phone = @Phone, 
                         Email = @Email, Address = @Address, PassportData = @PassportData,
                         RegistrationDate = @RegistrationDate
                         WHERE ClientID = @ClientID";
            }
            else
            {
                query = @"INSERT INTO Clients (FullName, Phone, Email, Address, PassportData, RegistrationDate) 
                         VALUES (@FullName, @Phone, @Email, @Address, @PassportData, @RegistrationDate)";
            }

            parameters = new SqlParameter[]
            {
                new SqlParameter("@FullName", txtFullName.Text),
                new SqlParameter("@Phone", txtPhone.Text),
                new SqlParameter("@Email", txtEmail.Text),
                new SqlParameter("@Address", txtAddress.Text),
                new SqlParameter("@PassportData", txtPassport.Text),
                new SqlParameter("@RegistrationDate", dtpRegistrationDate.Value)
            };

            if (isEditMode)
            {
                Array.Resize(ref parameters, parameters.Length + 1);
                parameters[parameters.Length - 1] = new SqlParameter("@ClientID", currentClientId);
            }

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                LoadClients();
                ClearForm();
                EnableForm(false);
                MessageBox.Show("Данные успешно сохранены", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                clientsTable.DefaultView.RowFilter =
                    $"FullName LIKE '%{filter}%' OR Phone LIKE '%{filter}%' OR Email LIKE '%{filter}%'";
            }
            else
            {
                clientsTable.DefaultView.RowFilter = "";
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            ApplyDateFilter();
        }

        private void ApplyDateFilter()
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            string dateFilter = $"RegistrationDate >= #{fromDate:yyyy-MM-dd HH:mm:ss}# AND RegistrationDate <= #{toDate:yyyy-MM-dd HH:mm:ss}#";

            if (!string.IsNullOrEmpty(clientsTable.DefaultView.RowFilter))
            {
                clientsTable.DefaultView.RowFilter += " AND " + dateFilter;
            }
            else
            {
                clientsTable.DefaultView.RowFilter = dateFilter;
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            clientsTable.DefaultView.RowFilter = "";
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            txtSearch.Clear();
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtFullName.Text))
            {
                MessageBox.Show("Введите ФИО клиента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Введите телефон", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtPassport.Text))
            {
                MessageBox.Show("Введите паспортные данные", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPassport.Clear();
            dtpRegistrationDate.Value = DateTime.Now;
        }

        private void EnableForm(bool enable)
        {
            gbClientDetails.Enabled = enable;
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable;
            btnDelete.Enabled = !enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            dgvClients.Enabled = !enable;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }
    }
}