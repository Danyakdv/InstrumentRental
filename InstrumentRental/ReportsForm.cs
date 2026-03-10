using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
            dtpFrom.Value = DateTime.Now.AddMonths(-1);
            dtpTo.Value = DateTime.Now;
        }

        private void btnIncomeReport_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    CONVERT(date, p.PaymentDate) as Date,
                    COUNT(DISTINCT p.RentalID) as RentalsCount,
                    COUNT(p.PaymentID) as PaymentsCount,
                    SUM(p.Amount) as TotalAmount,
                    SUM(CASE WHEN p.PaymentMethod = 'Cash' THEN p.Amount ELSE 0 END) as CashAmount,
                    SUM(CASE WHEN p.PaymentMethod = 'Card' THEN p.Amount ELSE 0 END) as CardAmount,
                    SUM(CASE WHEN p.PaymentMethod = 'Transfer' THEN p.Amount ELSE 0 END) as TransferAmount
                FROM Payments p
                WHERE p.PaymentDate BETWEEN @FromDate AND @ToDate
                GROUP BY CONVERT(date, p.PaymentDate)
                ORDER BY Date DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", dtpFrom.Value.Date),
                new SqlParameter("@ToDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
            };

            DataTable reportData = DatabaseHelper.ExecuteQuery(query, parameters);
            dgvReport.DataSource = reportData;

            // Настройка отображения
            dgvReport.Columns["Date"].HeaderText = "Дата";
            dgvReport.Columns["RentalsCount"].HeaderText = "Кол-во аренд";
            dgvReport.Columns["PaymentsCount"].HeaderText = "Кол-во платежей";
            dgvReport.Columns["TotalAmount"].HeaderText = "Общая сумма";
            dgvReport.Columns["CashAmount"].HeaderText = "Наличные";
            dgvReport.Columns["CardAmount"].HeaderText = "Карта";
            dgvReport.Columns["TransferAmount"].HeaderText = "Перевод";

            // Форматирование
            dgvReport.Columns["Date"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvReport.Columns["TotalAmount"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["CashAmount"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["CardAmount"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["TransferAmount"].DefaultCellStyle.Format = "C2";

            // Итоги
            decimal total = 0;
            foreach (DataRow row in reportData.Rows)
            {
                total += Convert.ToDecimal(row["TotalAmount"]);
            }
            lblTotal.Text = $"Итого: {total:C2}";
        }

        private void btnPopularInstruments_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT TOP 10
                    i.Name, i.Type, i.Brand, i.Model,
                    COUNT(r.RentalID) as RentalsCount,
                    SUM(DATEDIFF(day, r.StartDate, ISNULL(r.ActualReturnDate, r.EndDate)) + 1) as TotalDays,
                    SUM(r.TotalCost) as TotalIncome
                FROM Instruments i
                LEFT JOIN Rentals r ON i.InstrumentID = r.InstrumentID
                    AND r.StartDate BETWEEN @FromDate AND @ToDate
                GROUP BY i.InstrumentID, i.Name, i.Type, i.Brand, i.Model
                HAVING COUNT(r.RentalID) > 0
                ORDER BY RentalsCount DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", dtpFrom.Value.Date),
                new SqlParameter("@ToDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
            };

            DataTable reportData = DatabaseHelper.ExecuteQuery(query, parameters);
            dgvReport.DataSource = reportData;

            dgvReport.Columns["Name"].HeaderText = "Название";
            dgvReport.Columns["Type"].HeaderText = "Тип";
            dgvReport.Columns["Brand"].HeaderText = "Бренд";
            dgvReport.Columns["Model"].HeaderText = "Модель";
            dgvReport.Columns["RentalsCount"].HeaderText = "Кол-во аренд";
            dgvReport.Columns["TotalDays"].HeaderText = "Всего дней";
            dgvReport.Columns["TotalIncome"].HeaderText = "Доход";

            dgvReport.Columns["TotalIncome"].DefaultCellStyle.Format = "C2";
        }

        private void btnDebtors_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    c.FullName, c.Phone,
                    i.Name as InstrumentName,
                    r.RentalID, r.StartDate, r.EndDate,
                    DATEDIFF(day, r.EndDate, GETDATE()) as OverdueDays,
                    r.TotalCost,
                    ISNULL((SELECT SUM(Amount) FROM Payments WHERE RentalID = r.RentalID), 0) as PaidAmount,
                    r.TotalCost - ISNULL((SELECT SUM(Amount) FROM Payments WHERE RentalID = r.RentalID), 0) as Debt
                FROM Rentals r
                INNER JOIN Clients c ON r.ClientID = c.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                WHERE r.Status = 'Overdue' 
                   OR (r.Status = 'Active' AND r.EndDate < GETDATE())
                ORDER BY OverdueDays DESC";

            DataTable reportData = DatabaseHelper.ExecuteQuery(query);
            dgvReport.DataSource = reportData;

            dgvReport.Columns["FullName"].HeaderText = "Клиент";
            dgvReport.Columns["Phone"].HeaderText = "Телефон";
            dgvReport.Columns["InstrumentName"].HeaderText = "Инструмент";
            dgvReport.Columns["RentalID"].HeaderText = "ID аренды";
            dgvReport.Columns["StartDate"].HeaderText = "Дата начала";
            dgvReport.Columns["EndDate"].HeaderText = "Дата окончания";
            dgvReport.Columns["OverdueDays"].HeaderText = "Дней просрочки";
            dgvReport.Columns["TotalCost"].HeaderText = "Стоимость";
            dgvReport.Columns["PaidAmount"].HeaderText = "Оплачено";
            dgvReport.Columns["Debt"].HeaderText = "Долг";

            dgvReport.Columns["StartDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvReport.Columns["EndDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvReport.Columns["TotalCost"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["PaidAmount"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["Debt"].DefaultCellStyle.Format = "C2";

            // Подсветка должников
            dgvReport.CellFormatting += (s, e) =>
            {
                if (dgvReport.Columns[e.ColumnIndex].Name == "Debt" && e.Value != null)
                {
                    decimal debt = Convert.ToDecimal(e.Value);
                    if (debt > 0)
                    {
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            };
        }

        private void btnClientActivity_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT 
                    c.FullName, c.Phone, c.Email,
                    COUNT(DISTINCT r.RentalID) as RentalsCount,
                    COUNT(DISTINCT i.InstrumentID) as InstrumentsCount,
                    SUM(DATEDIFF(day, r.StartDate, ISNULL(r.ActualReturnDate, r.EndDate)) + 1) as TotalDays,
                    SUM(r.TotalCost) as TotalSpent,
                    MAX(r.StartDate) as LastRentalDate
                FROM Clients c
                LEFT JOIN Rentals r ON c.ClientID = r.ClientID
                    AND r.StartDate BETWEEN @FromDate AND @ToDate
                LEFT JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                GROUP BY c.ClientID, c.FullName, c.Phone, c.Email
                HAVING COUNT(r.RentalID) > 0
                ORDER BY TotalSpent DESC";

            SqlParameter[] parameters = {
                new SqlParameter("@FromDate", dtpFrom.Value.Date),
                new SqlParameter("@ToDate", dtpTo.Value.Date.AddDays(1).AddSeconds(-1))
            };

            DataTable reportData = DatabaseHelper.ExecuteQuery(query, parameters);
            dgvReport.DataSource = reportData;

            dgvReport.Columns["FullName"].HeaderText = "Клиент";
            dgvReport.Columns["Phone"].HeaderText = "Телефон";
            dgvReport.Columns["Email"].HeaderText = "Email";
            dgvReport.Columns["RentalsCount"].HeaderText = "Кол-во аренд";
            dgvReport.Columns["InstrumentsCount"].HeaderText = "Кол-во инструментов";
            dgvReport.Columns["TotalDays"].HeaderText = "Всего дней";
            dgvReport.Columns["TotalSpent"].HeaderText = "Потрачено";
            dgvReport.Columns["LastRentalDate"].HeaderText = "Последняя аренда";

            dgvReport.Columns["TotalSpent"].DefaultCellStyle.Format = "C2";
            dgvReport.Columns["LastRentalDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvReport.DataSource == null || dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для экспорта", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "CSV файлы (*.csv)|*.csv|Все файлы (*.*)|*.*";
            saveDialog.FileName = $"Отчет_{DateTime.Now:yyyyMMdd_HHmm}.csv";

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(saveDialog.FileName, false, System.Text.Encoding.UTF8))
                    {
                        // Заголовки
                        for (int i = 0; i < dgvReport.Columns.Count; i++)
                        {
                            sw.Write(dgvReport.Columns[i].HeaderText);
                            if (i < dgvReport.Columns.Count - 1) sw.Write(";");
                        }
                        sw.WriteLine();

                        // Данные
                        foreach (DataGridViewRow row in dgvReport.Rows)
                        {
                            for (int i = 0; i < dgvReport.Columns.Count; i++)
                            {
                                if (row.Cells[i].Value != null)
                                {
                                    string value = row.Cells[i].Value.ToString().Replace(";", ",");
                                    sw.Write(value);
                                }
                                if (i < dgvReport.Columns.Count - 1) sw.Write(";");
                            }
                            sw.WriteLine();
                        }
                    }

                    MessageBox.Show($"Отчет сохранен: {saveDialog.FileName}", "Успех",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении: {ex.Message}", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}