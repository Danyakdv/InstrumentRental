using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class RentalsForm : Form
    {
        private DataTable rentalsTable;
        private DataTable availableInstruments;
        private DataTable clients;

        public RentalsForm()
        {
            InitializeComponent();
            LoadRentals();
            LoadClients();
            LoadAvailableInstruments();
            UpdateOverdueStatus();
        }

        private void LoadRentals()
        {
            string query = @"
                SELECT r.RentalID, c.FullName as ClientName, i.Name as InstrumentName,
                       r.StartDate, r.EndDate, r.ActualReturnDate, r.DepositAmount,
                       r.TotalCost, 
                       CASE r.Status
                           WHEN 'Active' THEN 'Активна'
                           WHEN 'Completed' THEN 'Завершена'
                           WHEN 'Overdue' THEN 'Просрочена'
                       END as StatusText,
                       r.Status
                FROM Rentals r
                INNER JOIN Clients c ON r.ClientID = c.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                ORDER BY r.StartDate DESC";

            rentalsTable = DatabaseHelper.ExecuteQuery(query);
            dgvRentals.DataSource = rentalsTable;

            // Настройка колонок
            dgvRentals.Columns["RentalID"].HeaderText = "ID";
            dgvRentals.Columns["ClientName"].HeaderText = "Клиент";
            dgvRentals.Columns["InstrumentName"].HeaderText = "Инструмент";
            dgvRentals.Columns["StartDate"].HeaderText = "Дата начала";
            dgvRentals.Columns["EndDate"].HeaderText = "Дата окончания";
            dgvRentals.Columns["ActualReturnDate"].HeaderText = "Фактический возврат";
            dgvRentals.Columns["DepositAmount"].HeaderText = "Залог";
            dgvRentals.Columns["TotalCost"].HeaderText = "Общая стоимость";
            dgvRentals.Columns["StatusText"].HeaderText = "Статус";
            dgvRentals.Columns["Status"].Visible = false;

            // Форматирование
            dgvRentals.Columns["StartDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvRentals.Columns["EndDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvRentals.Columns["ActualReturnDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvRentals.Columns["DepositAmount"].DefaultCellStyle.Format = "C2";
            dgvRentals.Columns["TotalCost"].DefaultCellStyle.Format = "C2";

            // Цветовая индикация
            dgvRentals.CellFormatting += DgvRentals_CellFormatting;
        }

        private void DgvRentals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRentals.Columns[e.ColumnIndex].Name == "StatusText")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    switch (status)
                    {
                        case "Активна":
                            e.CellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Завершена":
                            e.CellStyle.BackColor = Color.LightGray;
                            break;
                        case "Просрочена":
                            e.CellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void LoadClients()
        {
            string query = "SELECT ClientID, FullName FROM Clients WHERE IsActive = 1 ORDER BY FullName";
            clients = DatabaseHelper.ExecuteQuery(query);

            cmbClient.DisplayMember = "FullName";
            cmbClient.ValueMember = "ClientID";
            cmbClient.DataSource = clients;
        }

        private void LoadAvailableInstruments()
        {
            string query = @"SELECT InstrumentID, Name + ' (' + Brand + ' ' + Model + ')' as InstrumentInfo 
                           FROM Instruments 
                           WHERE Status = 'Available' 
                           ORDER BY Name";
            availableInstruments = DatabaseHelper.ExecuteQuery(query);

            cmbInstrument.DisplayMember = "InstrumentInfo";
            cmbInstrument.ValueMember = "InstrumentID";
            cmbInstrument.DataSource = availableInstruments;
        }

        private void UpdateOverdueStatus()
        {
            string query = @"UPDATE Rentals 
                           SET Status = 'Overdue' 
                           WHERE Status = 'Active' AND EndDate < GETDATE()";
            DatabaseHelper.ExecuteNonQuery(query);
        }

        private void btnCreateRental_Click(object sender, EventArgs e)
        {
            if (!ValidateRentalForm())
                return;

            // Расчет стоимости
            int days = (int)(dtpEndDate.Value.Date - dtpStartDate.Value.Date).TotalDays + 1;
            if (days < 1) days = 1;

            // Получаем цену аренды инструмента
            string priceQuery = "SELECT RentalPricePerDay FROM Instruments WHERE InstrumentID = @InstrumentID";
            SqlParameter[] priceParams = {
                new SqlParameter("@InstrumentID", cmbInstrument.SelectedValue)
            };
            decimal pricePerDay = Convert.ToDecimal(DatabaseHelper.ExecuteScalar(priceQuery, priceParams));
            decimal totalCost = days * pricePerDay;
            decimal deposit = 0;

            if (!string.IsNullOrEmpty(txtDeposit.Text))
                deposit = Convert.ToDecimal(txtDeposit.Text);

            // Создание аренды
            string query = @"INSERT INTO Rentals (ClientID, InstrumentID, StartDate, EndDate, 
                           DepositAmount, TotalCost, Status, CreatedBy)
                           VALUES (@ClientID, @InstrumentID, @StartDate, @EndDate, 
                           @DepositAmount, @TotalCost, 'Active', @CreatedBy);
                           SELECT SCOPE_IDENTITY();";

            SqlParameter[] parameters = {
                new SqlParameter("@ClientID", cmbClient.SelectedValue),
                new SqlParameter("@InstrumentID", cmbInstrument.SelectedValue),
                new SqlParameter("@StartDate", dtpStartDate.Value),
                new SqlParameter("@EndDate", dtpEndDate.Value),
                new SqlParameter("@DepositAmount", deposit),
                new SqlParameter("@TotalCost", totalCost),
                new SqlParameter("@CreatedBy", UserSession.UserID)
            };

            try
            {
                int rentalId = Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));

                // Обновляем статус инструмента
                string updateInstrument = "UPDATE Instruments SET Status = 'Rented' WHERE InstrumentID = @InstrumentID";
                SqlParameter[] instParams = {
                    new SqlParameter("@InstrumentID", cmbInstrument.SelectedValue)
                };
                DatabaseHelper.ExecuteNonQuery(updateInstrument, instParams);

                // Создаем договор
                CreateContract(rentalId);

                MessageBox.Show("Аренда успешно создана", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadRentals();
                LoadAvailableInstruments();
                ClearRentalForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании аренды: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreateContract(int rentalId)
        {
            string contractNumber = $"ДОГ-{DateTime.Now:yyyyMMdd}-{rentalId}";

            string query = @"INSERT INTO Contracts (RentalID, ContractNumber, ContractDate)
                           VALUES (@RentalID, @ContractNumber, GETDATE())";

            SqlParameter[] parameters = {
                new SqlParameter("@RentalID", rentalId),
                new SqlParameter("@ContractNumber", contractNumber)
            };

            DatabaseHelper.ExecuteNonQuery(query, parameters);
        }

        private void btnReturnInstrument_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRentals.SelectedRows[0];
                string status = row.Cells["Status"].Value.ToString();

                if (status == "Completed")
                {
                    MessageBox.Show("Эта аренда уже завершена", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (MessageBox.Show("Подтвердите возврат инструмента", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rentalId = Convert.ToInt32(row.Cells["RentalID"].Value);
                    int instrumentId = GetInstrumentIdByRental(rentalId);

                    string query = @"UPDATE Rentals 
                                   SET ActualReturnDate = GETDATE(), Status = 'Completed'
                                   WHERE RentalID = @RentalID";

                    SqlParameter[] parameters = {
                        new SqlParameter("@RentalID", rentalId)
                    };

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(query, parameters);

                        // Обновляем статус инструмента
                        string updateInstrument = "UPDATE Instruments SET Status = 'Available' WHERE InstrumentID = @InstrumentID";
                        SqlParameter[] instParams = {
                            new SqlParameter("@InstrumentID", instrumentId)
                        };
                        DatabaseHelper.ExecuteNonQuery(updateInstrument, instParams);

                        LoadRentals();
                        LoadAvailableInstruments();

                        MessageBox.Show("Инструмент возвращен", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при возврате: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private int GetInstrumentIdByRental(int rentalId)
        {
            string query = "SELECT InstrumentID FROM Rentals WHERE RentalID = @RentalID";
            SqlParameter[] parameters = {
                new SqlParameter("@RentalID", rentalId)
            };
            return Convert.ToInt32(DatabaseHelper.ExecuteScalar(query, parameters));
        }

        private void btnExtendRental_Click(object sender, EventArgs e)
        {
            if (dgvRentals.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvRentals.SelectedRows[0];
                string status = row.Cells["Status"].Value.ToString();

                if (status != "Active")
                {
                    MessageBox.Show("Продлить можно только активную аренду", "Информация",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DateTime currentEndDate = Convert.ToDateTime(row.Cells["EndDate"].Value);

                using (ExtendRentalForm extendForm = new ExtendRentalForm(currentEndDate))
                {
                    if (extendForm.ShowDialog() == DialogResult.OK)
                    {
                        int rentalId = Convert.ToInt32(row.Cells["RentalID"].Value);
                        DateTime newEndDate = extendForm.NewEndDate;

                        string query = @"UPDATE Rentals SET EndDate = @EndDate 
                                       WHERE RentalID = @RentalID";

                        SqlParameter[] parameters = {
                            new SqlParameter("@RentalID", rentalId),
                            new SqlParameter("@EndDate", newEndDate)
                        };

                        try
                        {
                            DatabaseHelper.ExecuteNonQuery(query, parameters);
                            LoadRentals();
                            MessageBox.Show("Аренда успешно продлена", "Успех",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при продлении: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalCost();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            CalculateTotalCost();
        }

        private void cmbInstrument_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotalCost();
        }

        private void CalculateTotalCost()
        {
            if (cmbInstrument.SelectedValue != null && cmbInstrument.SelectedValue is int)
            {
                try
                {
                    int days = (int)(dtpEndDate.Value.Date - dtpStartDate.Value.Date).TotalDays + 1;
                    if (days < 1) days = 1;

                    string query = "SELECT RentalPricePerDay FROM Instruments WHERE InstrumentID = @InstrumentID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@InstrumentID", cmbInstrument.SelectedValue)
                    };

                    object result = DatabaseHelper.ExecuteScalar(query, parameters);
                    if (result != null)
                    {
                        decimal pricePerDay = Convert.ToDecimal(result);
                        decimal totalCost = days * pricePerDay;
                        lblCalculatedCost.Text = $"Общая стоимость: {totalCost:C2}";
                    }
                }
                catch
                {
                    lblCalculatedCost.Text = "Общая стоимость: выберите инструмент";
                }
            }
        }

        private bool ValidateRentalForm()
        {
            if (cmbClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbInstrument.SelectedValue == null)
            {
                MessageBox.Show("Выберите инструмент", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpStartDate.Value > dtpEndDate.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpStartDate.Value < DateTime.Today)
            {
                MessageBox.Show("Дата начала не может быть в прошлом", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!string.IsNullOrEmpty(txtDeposit.Text))
            {
                if (!decimal.TryParse(txtDeposit.Text, out _))
                {
                    MessageBox.Show("Введите корректную сумму залога", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        private void ClearRentalForm()
        {
            cmbClient.SelectedIndex = -1;
            cmbInstrument.SelectedIndex = -1;
            dtpStartDate.Value = DateTime.Now;
            dtpEndDate.Value = DateTime.Now.AddDays(7);
            txtDeposit.Clear();
            lblCalculatedCost.Text = "Общая стоимость:";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadRentals();
            LoadAvailableInstruments();
            UpdateOverdueStatus();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                rentalsTable.DefaultView.RowFilter =
                    $"ClientName LIKE '%{filter}%' OR InstrumentName LIKE '%{filter}%'";
            }
            else
            {
                rentalsTable.DefaultView.RowFilter = "";
            }
        }

        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = cmbStatusFilter.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(status) && status != "Все статусы")
            {
                string dbStatus = "";
                switch (status)
                {
                    case "Активна": dbStatus = "Active"; break;
                    case "Завершена": dbStatus = "Completed"; break;
                    case "Просрочена": dbStatus = "Overdue"; break;
                }
                rentalsTable.DefaultView.RowFilter = $"Status = '{dbStatus}'";
            }
            else
            {
                rentalsTable.DefaultView.RowFilter = "";
            }
        }
    }
}