namespace InstrumentRental
{
    partial class InstrumentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvInstruments;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbInstrumentDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblType2;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label lblSerialNumber;
        private System.Windows.Forms.TextBox txtSerialNumber;
        private System.Windows.Forms.Label lblPurchasePrice;
        private System.Windows.Forms.TextBox txtPurchasePrice;
        private System.Windows.Forms.Label lblRentalPrice;
        private System.Windows.Forms.TextBox txtRentalPrice;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvInstruments = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbInstrumentDetails = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtRentalPrice = new System.Windows.Forms.TextBox();
            this.lblRentalPrice = new System.Windows.Forms.Label();
            this.txtPurchasePrice = new System.Windows.Forms.TextBox();
            this.lblPurchasePrice = new System.Windows.Forms.Label();
            this.txtSerialNumber = new System.Windows.Forms.TextBox();
            this.lblSerialNumber = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.txtType = new System.Windows.Forms.TextBox();
            this.lblType2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstruments)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.gbInstrumentDetails.SuspendLayout();
            this.SuspendLayout();

            // dgvInstruments
            this.dgvInstruments.AllowUserToAddRows = false;
            this.dgvInstruments.AllowUserToDeleteRows = false;
            this.dgvInstruments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInstruments.Location = new System.Drawing.Point(12, 100);
            this.dgvInstruments.Name = "dgvInstruments";
            this.dgvInstruments.ReadOnly = true;
            this.dgvInstruments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInstruments.Size = new System.Drawing.Size(960, 200);
            this.dgvInstruments.TabIndex = 0;

            // gbSearch
            this.gbSearch.Controls.Add(this.cmbStatusFilter);
            this.gbSearch.Controls.Add(this.lblStatusFilter);
            this.gbSearch.Controls.Add(this.cmbType);
            this.gbSearch.Controls.Add(this.lblType);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(960, 80);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск и фильтрация";

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Все статусы",
            "В наличии",
            "Арендован",
            "На ремонте"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(550, 30);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(150, 21);
            this.cmbStatusFilter.TabIndex = 5;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            // lblStatusFilter
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(500, 33);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(44, 13);
            this.lblStatusFilter.TabIndex = 4;
            this.lblStatusFilter.Text = "Статус:";

            // cmbType
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(340, 30);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(150, 21);
            this.cmbType.TabIndex = 3;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);

            // lblType
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(300, 33);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(29, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Тип:";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(200, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Поиск...";

            // gbActions
            this.gbActions.Controls.Add(this.btnDelete);
            this.gbActions.Controls.Add(this.btnEdit);
            this.gbActions.Controls.Add(this.btnAdd);
            this.gbActions.Location = new System.Drawing.Point(12, 310);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(300, 80);
            this.gbActions.TabIndex = 2;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия";

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(200, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(110, 30);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // gbInstrumentDetails
            this.gbInstrumentDetails.Controls.Add(this.btnCancel);
            this.gbInstrumentDetails.Controls.Add(this.btnSave);
            this.gbInstrumentDetails.Controls.Add(this.cmbStatus);
            this.gbInstrumentDetails.Controls.Add(this.lblStatus);
            this.gbInstrumentDetails.Controls.Add(this.txtRentalPrice);
            this.gbInstrumentDetails.Controls.Add(this.lblRentalPrice);
            this.gbInstrumentDetails.Controls.Add(this.txtPurchasePrice);
            this.gbInstrumentDetails.Controls.Add(this.lblPurchasePrice);
            this.gbInstrumentDetails.Controls.Add(this.txtSerialNumber);
            this.gbInstrumentDetails.Controls.Add(this.lblSerialNumber);
            this.gbInstrumentDetails.Controls.Add(this.txtModel);
            this.gbInstrumentDetails.Controls.Add(this.lblModel);
            this.gbInstrumentDetails.Controls.Add(this.txtBrand);
            this.gbInstrumentDetails.Controls.Add(this.lblBrand);
            this.gbInstrumentDetails.Controls.Add(this.txtType);
            this.gbInstrumentDetails.Controls.Add(this.lblType2);
            this.gbInstrumentDetails.Controls.Add(this.txtName);
            this.gbInstrumentDetails.Controls.Add(this.lblName);
            this.gbInstrumentDetails.Enabled = false;
            this.gbInstrumentDetails.Location = new System.Drawing.Point(330, 310);
            this.gbInstrumentDetails.Name = "gbInstrumentDetails";
            this.gbInstrumentDetails.Size = new System.Drawing.Size(640, 200);
            this.gbInstrumentDetails.TabIndex = 3;
            this.gbInstrumentDetails.TabStop = false;
            this.gbInstrumentDetails.Text = "Детали инструмента";

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 30);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(60, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Название:";

            // txtName
            this.txtName.Location = new System.Drawing.Point(100, 27);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(150, 20);
            this.txtName.TabIndex = 1;

            // lblType2
            this.lblType2.AutoSize = true;
            this.lblType2.Location = new System.Drawing.Point(270, 30);
            this.lblType2.Name = "lblType2";
            this.lblType2.Size = new System.Drawing.Size(29, 13);
            this.lblType2.TabIndex = 2;
            this.lblType2.Text = "Тип:";

            // txtType
            this.txtType.Location = new System.Drawing.Point(320, 27);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(150, 20);
            this.txtType.TabIndex = 3;

            // lblBrand
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(490, 30);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(41, 13);
            this.lblBrand.TabIndex = 4;
            this.lblBrand.Text = "Бренд:";

            // txtBrand
            this.txtBrand.Location = new System.Drawing.Point(540, 27);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(80, 20);
            this.txtBrand.TabIndex = 5;

            // lblModel
            this.lblModel.AutoSize = true;
            this.lblModel.Location = new System.Drawing.Point(20, 60);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(49, 13);
            this.lblModel.TabIndex = 6;
            this.lblModel.Text = "Модель:";

            // txtModel
            this.txtModel.Location = new System.Drawing.Point(100, 57);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(150, 20);
            this.txtModel.TabIndex = 7;

            // lblSerialNumber
            this.lblSerialNumber.AutoSize = true;
            this.lblSerialNumber.Location = new System.Drawing.Point(270, 60);
            this.lblSerialNumber.Name = "lblSerialNumber";
            this.lblSerialNumber.Size = new System.Drawing.Size(44, 13);
            this.lblSerialNumber.TabIndex = 8;
            this.lblSerialNumber.Text = "Серийный номер:";

            // txtSerialNumber
            this.txtSerialNumber.Location = new System.Drawing.Point(320, 57);
            this.txtSerialNumber.Name = "txtSerialNumber";
            this.txtSerialNumber.Size = new System.Drawing.Size(150, 20);
            this.txtSerialNumber.TabIndex = 9;

            // lblPurchasePrice
            this.lblPurchasePrice.AutoSize = true;
            this.lblPurchasePrice.Location = new System.Drawing.Point(490, 60);
            this.lblPurchasePrice.Name = "lblPurchasePrice";
            this.lblPurchasePrice.Size = new System.Drawing.Size(75, 13);
            this.lblPurchasePrice.TabIndex = 10;
            this.lblPurchasePrice.Text = "Цена покупки:";

            // txtPurchasePrice
            this.txtPurchasePrice.Location = new System.Drawing.Point(570, 57);
            this.txtPurchasePrice.Name = "txtPurchasePrice";
            this.txtPurchasePrice.Size = new System.Drawing.Size(50, 20);
            this.txtPurchasePrice.TabIndex = 11;

            // lblRentalPrice
            this.lblRentalPrice.AutoSize = true;
            this.lblRentalPrice.Location = new System.Drawing.Point(20, 90);
            this.lblRentalPrice.Name = "lblRentalPrice";
            this.lblRentalPrice.Size = new System.Drawing.Size(86, 13);
            this.lblRentalPrice.TabIndex = 12;
            this.lblRentalPrice.Text = "Цена аренды/день:";

            // txtRentalPrice
            this.txtRentalPrice.Location = new System.Drawing.Point(110, 87);
            this.txtRentalPrice.Name = "txtRentalPrice";
            this.txtRentalPrice.Size = new System.Drawing.Size(60, 20);
            this.txtRentalPrice.TabIndex = 13;

            // lblStatus
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(200, 90);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(44, 13);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Статус:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "В наличии",
            "Арендован",
            "На ремонте"});
            this.cmbStatus.Location = new System.Drawing.Point(250, 87);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(100, 21);
            this.cmbStatus.TabIndex = 15;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(450, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(540, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // InstrumentsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.gbInstrumentDetails);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvInstruments);
            this.Name = "InstrumentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление инструментами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvInstruments)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbInstrumentDetails.ResumeLayout(false);
            this.gbInstrumentDetails.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}