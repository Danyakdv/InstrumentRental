using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class ContractsForm : Form
    {
        private DataTable contractsTable;
        private int currentContractId = 0;

        public ContractsForm()
        {
            InitializeComponent();
            LoadContracts();
        }

        private void LoadContracts()
        {
            string query = @"
                SELECT c.ContractID, c.ContractNumber, c.ContractDate,
                       r.RentalID, cl.FullName as ClientName, 
                       i.Name as InstrumentName, r.StartDate, r.EndDate,
                       r.TotalCost, r.DepositAmount,
                       CASE r.Status
                           WHEN 'Active' THEN 'Активна'
                           WHEN 'Completed' THEN 'Завершена'
                           WHEN 'Overdue' THEN 'Просрочена'
                       END as StatusDisplay
                FROM Contracts c
                INNER JOIN Rentals r ON c.RentalID = r.RentalID
                INNER JOIN Clients cl ON r.ClientID = cl.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                ORDER BY c.ContractDate DESC";

            contractsTable = DatabaseHelper.ExecuteQuery(query);
            dgvContracts.DataSource = contractsTable;

            // Настройка колонок
            dgvContracts.Columns["ContractID"].HeaderText = "ID";
            dgvContracts.Columns["ContractNumber"].HeaderText = "Номер договора";
            dgvContracts.Columns["ContractDate"].HeaderText = "Дата договора";
            dgvContracts.Columns["RentalID"].HeaderText = "ID аренды";
            dgvContracts.Columns["ClientName"].HeaderText = "Клиент";
            dgvContracts.Columns["InstrumentName"].HeaderText = "Инструмент";
            dgvContracts.Columns["StartDate"].HeaderText = "Дата начала";
            dgvContracts.Columns["EndDate"].HeaderText = "Дата окончания";
            dgvContracts.Columns["TotalCost"].HeaderText = "Стоимость";
            dgvContracts.Columns["DepositAmount"].HeaderText = "Залог";
            dgvContracts.Columns["StatusDisplay"].HeaderText = "Статус аренды";

            // Форматирование
            dgvContracts.Columns["ContractDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvContracts.Columns["StartDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvContracts.Columns["EndDate"].DefaultCellStyle.Format = "dd.MM.yyyy";
            dgvContracts.Columns["TotalCost"].DefaultCellStyle.Format = "C2";
            dgvContracts.Columns["DepositAmount"].DefaultCellStyle.Format = "C2";
        }

        private void btnViewContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvContracts.SelectedRows[0];
                currentContractId = Convert.ToInt32(row.Cells["ContractID"].Value);

                ShowContractPreview();
            }
            else
            {
                MessageBox.Show("Выберите договор для просмотра", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnPrintContract_Click(object sender, EventArgs e)
        {
            if (dgvContracts.SelectedRows.Count > 0)
            {
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += PrintDocument_PrintPage;

                PrintPreviewDialog previewDialog = new PrintPreviewDialog();
                previewDialog.Document = printDocument;
                previewDialog.ShowDialog();
            }
        }

        private void ShowContractPreview()
        {
            // Получаем данные договора
            string query = @"
                SELECT c.ContractNumber, c.ContractDate, c.ContractText,
                       cl.FullName, cl.PassportData, cl.Phone, cl.Address,
                       i.Name, i.Type, i.Brand, i.Model, i.SerialNumber,
                       r.StartDate, r.EndDate, r.TotalCost, r.DepositAmount
                FROM Contracts c
                INNER JOIN Rentals r ON c.RentalID = r.RentalID
                INNER JOIN Clients cl ON r.ClientID = cl.ClientID
                INNER JOIN Instruments i ON r.InstrumentID = i.InstrumentID
                WHERE c.ContractID = @ContractID";

            SqlParameter[] parameters = {
                new SqlParameter("@ContractID", currentContractId)
            };

            DataRow row = DatabaseHelper.ExecuteQuery(query, parameters).Rows[0];

            // Формируем текст договора
            string contractText = $@"
                        ДОГОВОР АРЕНДЫ № {row["ContractNumber"]}
                        от {Convert.ToDateTime(row["ContractDate"]):dd.MM.yyyy}

            г. Москва                                          {Convert.ToDateTime(row["ContractDate"]):dd.MM.yyyy}

            ООО ""АрендаМузыки"", в лице {UserSession.FullName}, действующего на основании Устава, 
            именуемое в дальнейшем ""Арендодатель"", с одной стороны, и

            {row["FullName"]}, паспорт: {row["PassportData"]}, телефон: {row["Phone"]}, 
            проживающий по адресу: {row["Address"]}, именуемый в дальнейшем ""Арендатор"", 
            с другой стороны, заключили настоящий договор о нижеследующем:

            1. ПРЕДМЕТ ДОГОВОРА
            1.1. Арендодатель передает, а Арендатор принимает во временное владение и пользование 
            музыкальный инструмент: {row["Name"]} {row["Brand"]} {row["Model"]}
            Тип: {row["Type"]}, Серийный номер: {row["SerialNumber"]}

            2. СРОК АРЕНДЫ
            2.1. Срок аренды устанавливается с {Convert.ToDateTime(row["StartDate"]):dd.MM.yyyy} 
            по {Convert.ToDateTime(row["EndDate"]):dd.MM.yyyy}.

            3. ПЛАТЕЖИ И РАСЧЕТЫ
            3.1. Стоимость аренды составляет {Convert.ToDecimal(row["TotalCost"]):C2}.
            3.2. Залоговая сумма составляет {Convert.ToDecimal(row["DepositAmount"]):C2}.

            4. ПОДПИСИ СТОРОН

            Арендодатель: __________________ /{UserSession.FullName}/

            Арендатор: __________________ /{row["FullName"]}/
            ";

            // Показываем в текстовом поле
            txtContractPreview.Text = contractText;
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Печать договора
            e.Graphics.DrawString(txtContractPreview.Text,
                new Font("Courier New", 10),
                Brushes.Black,
                new RectangleF(50, 50, 700, 1000));
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                ((DataTable)dgvContracts.DataSource).DefaultView.RowFilter =
                    $"ContractNumber LIKE '%{searchText}%' OR ClientName LIKE '%{searchText}%' OR InstrumentName LIKE '%{searchText}%'";
            }
            else
            {
                ((DataTable)dgvContracts.DataSource).DefaultView.RowFilter = "";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadContracts();
        }
    }
}