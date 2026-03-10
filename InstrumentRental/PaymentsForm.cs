using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using InstrumentRental.Models;

namespace InstrumentRental
{
    public partial class PaymentsForm : Form
    {
        private DataTable paymentsTable;
        private int currentRentalId = 0;

        public PaymentsForm()
        {
            InitializeComponent();
            LoadPayments();
            LoadActiveRentals();
        }

        private void LoadPayments()
        {
            string query = @"
                SELECT p.PaymentID, p.RentalID, c.FullName as ClientName, 
                       i.Name as InstrumentName, p.Amount, p.PaymentDate, 
                       CASE p.PaymentMethod
                           WHEN 'Cash' THEN 'Наличные'
                           WHEN 'Card' THEN 'Карта'
                           WHEN 'Transfer' THEN 'Перевод'
                       END as PaymentMethodDisplay,
                       u.FullName as ReceivedByName,
                       p.PaymentMethod
                FROM Payments p
                INNER JOIN Rentals r ON p.RentalID = r.RentalID
                INNER JOIN Clients c ON r.ClientID = c.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                INNER JOIN Users u ON p.ReceivedBy = u.UserID
                ORDER BY p.PaymentDate DESC";

            paymentsTable = DatabaseHelper.ExecuteQuery(query);
            dgvPayments.DataSource = paymentsTable;

            // Настройка колонок
            dgvPayments.Columns["PaymentID"].HeaderText = "ID";
            dgvPayments.Columns["RentalID"].HeaderText = "ID аренды";
            dgvPayments.Columns["ClientName"].HeaderText = "Клиент";
            dgvPayments.Columns["InstrumentName"].HeaderText = "Инструмент";
            dgvPayments.Columns["Amount"].HeaderText = "Сумма";
            dgvPayments.Columns["PaymentDate"].HeaderText = "Дата платежа";
            dgvPayments.Columns["PaymentMethodDisplay"].HeaderText = "Способ оплаты";
            dgvPayments.Columns["ReceivedByName"].HeaderText = "Принял";
            dgvPayments.Columns["PaymentMethod"].Visible = false;

            // Форматирование
            dgvPayments.Columns["Amount"].DefaultCellStyle.Format = "C2";
            dgvPayments.Columns["PaymentDate"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Выравнивание
            dgvPayments.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void LoadActiveRentals()
        {
            string query = @"
                SELECT r.RentalID, c.FullName + ' - ' + i.Name as RentalInfo,
                       r.TotalCost - ISNULL((SELECT SUM(Amount) FROM Payments WHERE RentalID = r.RentalID), 0) as Debt
                FROM Rentals r
                INNER JOIN Clients c ON r.ClientID = c.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                WHERE r.Status IN ('Active', 'Overdue')
                ORDER BY c.FullName";

            DataTable rentals = DatabaseHelper.ExecuteQuery(query);

            cmbRental.DisplayMember = "RentalInfo";
            cmbRental.ValueMember = "RentalID";
            cmbRental.DataSource = rentals;

            cmbRental.SelectedIndexChanged += CmbRental_SelectedIndexChanged;
        }

        private void CmbRental_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRental.SelectedValue != null && cmbRental.SelectedValue is int)
            {
                currentRentalId = (int)cmbRental.SelectedValue;
                LoadRentalDebt();
            }
        }

        private void LoadRentalDebt()
        {
            string query = @"
                SELECT r.TotalCost - ISNULL((SELECT SUM(Amount) FROM Payments WHERE RentalID = r.RentalID), 0) as Debt,
                       r.TotalCost,
                       c.FullName as ClientName,
                       i.Name as InstrumentName
                FROM Rentals r
                INNER JOIN Clients c ON r.ClientID = c.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                WHERE r.RentalID = @RentalID";

            SqlParameter[] parameters = {
                new SqlParameter("@RentalID", currentRentalId)
            };

            DataRow row = DatabaseHelper.ExecuteQuery(query, parameters).Rows[0];

            decimal debt = Convert.ToDecimal(row["Debt"]);
            decimal totalCost = Convert.ToDecimal(row["TotalCost"]);
            string clientName = row["ClientName"].ToString();
            string instrumentName = row["InstrumentName"].ToString();

            lblRentalInfo.Text = $"Клиент: {clientName} | Инструмент: {instrumentName}";
            lblTotalCost.Text = $"Общая стоимость: {totalCost:C2}";
            lblCurrentDebt.Text = $"Текущий долг: {debt:C2}";

            if (debt > 0)
            {
                lblCurrentDebt.ForeColor = Color.Red;
                nudAmount.Maximum = debt;
                nudAmount.Value = debt;
            }
            else
            {
                lblCurrentDebt.ForeColor = Color.Green;
                nudAmount.Enabled = false;
                btnPay.Enabled = false;
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (currentRentalId == 0)
            {
                MessageBox.Show("Выберите аренду", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (nudAmount.Value <= 0)
            {
                MessageBox.Show("Введите сумму платежа", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbPaymentMethod.SelectedItem == null)
            {
                MessageBox.Show("Выберите способ оплаты", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string method = "";
            switch (cmbPaymentMethod.SelectedItem.ToString())
            {
                case "Наличные": method = "Cash"; break;
                case "Карта": method = "Card"; break;
                case "Перевод": method = "Transfer"; break;
            }

            string query = @"
                INSERT INTO Payments (RentalID, Amount, PaymentDate, PaymentMethod, ReceivedBy)
                VALUES (@RentalID, @Amount, GETDATE(), @PaymentMethod, @ReceivedBy)";

            SqlParameter[] parameters = {
                new SqlParameter("@RentalID", currentRentalId),
                new SqlParameter("@Amount", nudAmount.Value),
                new SqlParameter("@PaymentMethod", method),
                new SqlParameter("@ReceivedBy", UserSession.UserID)
            };

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);

                MessageBox.Show($"Платеж на сумму {nudAmount.Value:C2} успешно принят", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadPayments();
                LoadActiveRentals();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при приеме платежа: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            cmbRental.SelectedIndex = -1;
            nudAmount.Value = 0;
            cmbPaymentMethod.SelectedIndex = -1;
            lblRentalInfo.Text = "Выберите аренду";
            lblTotalCost.Text = "Общая стоимость:";
            lblCurrentDebt.Text = "Текущий долг:";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                ((DataTable)dgvPayments.DataSource).DefaultView.RowFilter =
                    $"ClientName LIKE '%{searchText}%' OR InstrumentName LIKE '%{searchText}%'";
            }
            else
            {
                ((DataTable)dgvPayments.DataSource).DefaultView.RowFilter = "";
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

            string dateFilter = $"PaymentDate >= #{fromDate:yyyy-MM-dd HH:mm:ss}# AND PaymentDate <= #{toDate:yyyy-MM-dd HH:mm:ss}#";

            DataTable dt = (DataTable)dgvPayments.DataSource;
            if (dt != null)
            {
                if (!string.IsNullOrEmpty(dt.DefaultView.RowFilter))
                {
                    dt.DefaultView.RowFilter += " AND " + dateFilter;
                }
                else
                {
                    dt.DefaultView.RowFilter = dateFilter;
                }
            }
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            ((DataTable)dgvPayments.DataSource).DefaultView.RowFilter = "";
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
            txtSearch.Clear();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPayments();
            LoadActiveRentals();
        }
    }
}