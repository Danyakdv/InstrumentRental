using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Xml.Linq;

namespace InstrumentRental
{
    public partial class InstrumentsForm : Form
    {
        private DataTable instrumentsTable;
        private bool isEditMode = false;
        private int currentInstrumentId = 0;

        public InstrumentsForm()
        {
            InitializeComponent();
            LoadInstruments();
            LoadTypes();
        }

        private void LoadInstruments()
        {
            string query = @"SELECT InstrumentID, Name, Type, Brand, Model, SerialNumber, 
                                    PurchasePrice, RentalPricePerDay, Status, 
                                    CASE Status 
                                        WHEN 'Available' THEN 'В наличии'
                                        WHEN 'Rented' THEN 'Арендован'
                                        WHEN 'UnderRepair' THEN 'На ремонте'
                                    END as StatusText
                             FROM Instruments ORDER BY Name";

            instrumentsTable = DatabaseHelper.ExecuteQuery(query);
            dgvInstruments.DataSource = instrumentsTable;

            // Настройка отображения колонок
            dgvInstruments.Columns["InstrumentID"].HeaderText = "ID";
            dgvInstruments.Columns["Name"].HeaderText = "Название";
            dgvInstruments.Columns["Type"].HeaderText = "Тип";
            dgvInstruments.Columns["Brand"].HeaderText = "Бренд";
            dgvInstruments.Columns["Model"].HeaderText = "Модель";
            dgvInstruments.Columns["SerialNumber"].HeaderText = "Серийный номер";
            dgvInstruments.Columns["PurchasePrice"].HeaderText = "Цена покупки";
            dgvInstruments.Columns["RentalPricePerDay"].HeaderText = "Цена аренды/день";
            dgvInstruments.Columns["Status"].Visible = false;
            dgvInstruments.Columns["StatusText"].HeaderText = "Статус";

            // Форматирование цен
            dgvInstruments.Columns["PurchasePrice"].DefaultCellStyle.Format = "C2";
            dgvInstruments.Columns["RentalPricePerDay"].DefaultCellStyle.Format = "C2";

            // Настройка цветовой индикации статусов
            dgvInstruments.CellFormatting += DgvInstruments_CellFormatting;
        }

        private void LoadTypes()
        {
            string query = "SELECT DISTINCT Type FROM Instruments ORDER BY Type";
            DataTable types = DatabaseHelper.ExecuteQuery(query);

            cmbType.Items.Clear();
            cmbType.Items.Add("Все типы");
            foreach (DataRow row in types.Rows)
            {
                cmbType.Items.Add(row["Type"].ToString());
            }
            cmbType.SelectedIndex = 0;
        }

        private void DgvInstruments_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInstruments.Columns[e.ColumnIndex].Name == "StatusText")
            {
                if (e.Value != null)
                {
                    string status = e.Value.ToString();
                    switch (status)
                    {
                        case "В наличии":
                            e.CellStyle.BackColor = Color.LightGreen;
                            break;
                        case "Арендован":
                            e.CellStyle.BackColor = Color.LightYellow;
                            break;
                        case "На ремонте":
                            e.CellStyle.BackColor = Color.LightCoral;
                            break;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            isEditMode = false;
            currentInstrumentId = 0;
            EnableForm(true);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvInstruments.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvInstruments.SelectedRows[0];
                currentInstrumentId = Convert.ToInt32(row.Cells["InstrumentID"].Value);

                txtName.Text = row.Cells["Name"].Value.ToString();
                txtType.Text = row.Cells["Type"].Value.ToString();
                txtBrand.Text = row.Cells["Brand"].Value.ToString();
                txtModel.Text = row.Cells["Model"].Value.ToString();
                txtSerialNumber.Text = row.Cells["SerialNumber"].Value.ToString();
                txtPurchasePrice.Text = row.Cells["PurchasePrice"].Value.ToString();
                txtRentalPrice.Text = row.Cells["RentalPricePerDay"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["StatusText"].Value.ToString();

                isEditMode = true;
                EnableForm(true);
            }
            else
            {
                MessageBox.Show("Выберите инструмент для редактирования", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvInstruments.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить этот инструмент?", "Подтверждение",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int instrumentId = Convert.ToInt32(dgvInstruments.SelectedRows[0].Cells["InstrumentID"].Value);

                    string query = "DELETE FROM Instruments WHERE InstrumentID = @InstrumentID";
                    SqlParameter[] parameters = {
                        new SqlParameter("@InstrumentID", instrumentId)
                    };

                    try
                    {
                        DatabaseHelper.ExecuteNonQuery(query, parameters);
                        LoadInstruments();
                        MessageBox.Show("Инструмент успешно удален", "Успех",
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

            string query;
            SqlParameter[] parameters;

            string status = "";
            switch (cmbStatus.SelectedItem?.ToString())
            {
                case "В наличии": status = "Available"; break;
                case "Арендован": status = "Rented"; break;
                case "На ремонте": status = "UnderRepair"; break;
            }

            if (isEditMode)
            {
                query = @"UPDATE Instruments SET Name = @Name, Type = @Type, Brand = @Brand, 
                         Model = @Model, SerialNumber = @SerialNumber, PurchasePrice = @PurchasePrice,
                         RentalPricePerDay = @RentalPricePerDay, Status = @Status
                         WHERE InstrumentID = @InstrumentID";
            }
            else
            {
                query = @"INSERT INTO Instruments (Name, Type, Brand, Model, SerialNumber, 
                         PurchasePrice, RentalPricePerDay, Status) 
                         VALUES (@Name, @Type, @Brand, @Model, @SerialNumber, 
                         @PurchasePrice, @RentalPricePerDay, @Status)";
            }

            parameters = new SqlParameter[]
            {
                new SqlParameter("@Name", txtName.Text),
                new SqlParameter("@Type", txtType.Text),
                new SqlParameter("@Brand", txtBrand.Text),
                new SqlParameter("@Model", txtModel.Text),
                new SqlParameter("@SerialNumber", txtSerialNumber.Text),
                new SqlParameter("@PurchasePrice", Convert.ToDecimal(txtPurchasePrice.Text)),
                new SqlParameter("@RentalPricePerDay", Convert.ToDecimal(txtRentalPrice.Text)),
                new SqlParameter("@Status", status)
            };

            if (isEditMode)
            {
                Array.Resize(ref parameters, parameters.Length + 1);
                parameters[parameters.Length - 1] = new SqlParameter("@InstrumentID", currentInstrumentId);
            }

            try
            {
                DatabaseHelper.ExecuteNonQuery(query, parameters);
                LoadInstruments();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            EnableForm(false);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(filter))
            {
                instrumentsTable.DefaultView.RowFilter =
                    $"Name LIKE '%{filter}%' OR Brand LIKE '%{filter}%' OR Model LIKE '%{filter}%' OR SerialNumber LIKE '%{filter}%'";
            }
            else
            {
                instrumentsTable.DefaultView.RowFilter = "";
            }
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbType.SelectedIndex > 0)
            {
                instrumentsTable.DefaultView.RowFilter = $"Type = '{cmbType.SelectedItem}'";
            }
            else
            {
                instrumentsTable.DefaultView.RowFilter = "";
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
                    case "В наличии": dbStatus = "Available"; break;
                    case "Арендован": dbStatus = "Rented"; break;
                    case "На ремонте": dbStatus = "UnderRepair"; break;
                }
                instrumentsTable.DefaultView.RowFilter = $"Status = '{dbStatus}'";
            }
            else
            {
                instrumentsTable.DefaultView.RowFilter = "";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Введите название инструмента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtType.Text))
            {
                MessageBox.Show("Введите тип инструмента", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(txtSerialNumber.Text))
            {
                MessageBox.Show("Введите серийный номер", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtPurchasePrice.Text, out _))
            {
                MessageBox.Show("Введите корректную цену покупки", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtRentalPrice.Text, out _))
            {
                MessageBox.Show("Введите корректную цену аренды", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbStatus.SelectedItem == null)
            {
                MessageBox.Show("Выберите статус", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtType.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtSerialNumber.Clear();
            txtPurchasePrice.Clear();
            txtRentalPrice.Clear();
            cmbStatus.SelectedIndex = -1;
        }

        private void EnableForm(bool enable)
        {
            gbInstrumentDetails.Enabled = enable;
            btnAdd.Enabled = !enable;
            btnEdit.Enabled = !enable;
            btnDelete.Enabled = !enable;
            btnSave.Enabled = enable;
            btnCancel.Enabled = enable;
            dgvInstruments.Enabled = !enable;
        }
    }
}