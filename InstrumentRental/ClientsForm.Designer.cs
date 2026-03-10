namespace InstrumentRental
{
    partial class ClientsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbClientDetails;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblPassport;
        private System.Windows.Forms.TextBox txtPassport;
        private System.Windows.Forms.Label lblRegistrationDate;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDate;
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
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbClientDetails = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dtpRegistrationDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegistrationDate = new System.Windows.Forms.Label();
            this.txtPassport = new System.Windows.Forms.TextBox();
            this.lblPassport = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.gbClientDetails.SuspendLayout();
            this.SuspendLayout();

            // dgvClients
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClients.Location = new System.Drawing.Point(12, 100);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(960, 200);
            this.dgvClients.TabIndex = 0;

            // gbSearch
            this.gbSearch.Controls.Add(this.btnClearFilter);
            this.gbSearch.Controls.Add(this.dtpTo);
            this.gbSearch.Controls.Add(this.lblTo);
            this.gbSearch.Controls.Add(this.dtpFrom);
            this.gbSearch.Controls.Add(this.lblFrom);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(960, 80);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск и фильтрация";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Поиск по ФИО, телефону, email...";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(200, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lblFrom
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(300, 33);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(49, 13);
            this.lblFrom.TabIndex = 2;
            this.lblFrom.Text = "С даты:";

            // dtpFrom
            this.dtpFrom.Location = new System.Drawing.Point(355, 30);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(130, 20);
            this.dtpFrom.TabIndex = 3;
            this.dtpFrom.Value = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);

            // lblTo
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(500, 33);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(49, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "По дату:";

            // dtpTo
            this.dtpTo.Location = new System.Drawing.Point(555, 30);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(130, 20);
            this.dtpTo.TabIndex = 5;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            // btnClearFilter
            this.btnClearFilter.Location = new System.Drawing.Point(710, 28);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(100, 23);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Text = "Сбросить фильтр";
            this.btnClearFilter.UseVisualStyleBackColor = true;
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

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

            // btnAdd
            this.btnAdd.Location = new System.Drawing.Point(20, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Добавить";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.Location = new System.Drawing.Point(110, 30);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(85, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Изменить";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(200, 30);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // gbClientDetails
            this.gbClientDetails.Controls.Add(this.btnCancel);
            this.gbClientDetails.Controls.Add(this.btnSave);
            this.gbClientDetails.Controls.Add(this.dtpRegistrationDate);
            this.gbClientDetails.Controls.Add(this.lblRegistrationDate);
            this.gbClientDetails.Controls.Add(this.txtPassport);
            this.gbClientDetails.Controls.Add(this.lblPassport);
            this.gbClientDetails.Controls.Add(this.txtAddress);
            this.gbClientDetails.Controls.Add(this.lblAddress);
            this.gbClientDetails.Controls.Add(this.txtEmail);
            this.gbClientDetails.Controls.Add(this.lblEmail);
            this.gbClientDetails.Controls.Add(this.txtPhone);
            this.gbClientDetails.Controls.Add(this.lblPhone);
            this.gbClientDetails.Controls.Add(this.txtFullName);
            this.gbClientDetails.Controls.Add(this.lblFullName);
            this.gbClientDetails.Enabled = false;
            this.gbClientDetails.Location = new System.Drawing.Point(330, 310);
            this.gbClientDetails.Name = "gbClientDetails";
            this.gbClientDetails.Size = new System.Drawing.Size(640, 200);
            this.gbClientDetails.TabIndex = 3;
            this.gbClientDetails.TabStop = false;
            this.gbClientDetails.Text = "Детали клиента";

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Location = new System.Drawing.Point(20, 30);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(37, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "ФИО:";

            // txtFullName
            this.txtFullName.Location = new System.Drawing.Point(100, 27);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(200, 20);
            this.txtFullName.TabIndex = 1;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(320, 30);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(55, 13);
            this.lblPhone.TabIndex = 2;
            this.lblPhone.Text = "Телефон:";

            // txtPhone
            this.txtPhone.Location = new System.Drawing.Point(380, 27);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(120, 20);
            this.txtPhone.TabIndex = 3;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(20, 60);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";

            // txtEmail
            this.txtEmail.Location = new System.Drawing.Point(100, 57);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(150, 20);
            this.txtEmail.TabIndex = 5;

            // lblAddress
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(270, 60);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(41, 13);
            this.lblAddress.TabIndex = 6;
            this.lblAddress.Text = "Адрес:";

            // txtAddress
            this.txtAddress.Location = new System.Drawing.Point(320, 57);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(200, 20);
            this.txtAddress.TabIndex = 7;

            // lblPassport
            this.lblPassport.AutoSize = true;
            this.lblPassport.Location = new System.Drawing.Point(20, 90);
            this.lblPassport.Name = "lblPassport";
            this.lblPassport.Size = new System.Drawing.Size(74, 13);
            this.lblPassport.TabIndex = 8;
            this.lblPassport.Text = "Паспортные данные:";

            // txtPassport
            this.txtPassport.Location = new System.Drawing.Point(100, 87);
            this.txtPassport.Name = "txtPassport";
            this.txtPassport.Size = new System.Drawing.Size(150, 20);
            this.txtPassport.TabIndex = 9;

            // lblRegistrationDate
            this.lblRegistrationDate.AutoSize = true;
            this.lblRegistrationDate.Location = new System.Drawing.Point(270, 90);
            this.lblRegistrationDate.Name = "lblRegistrationDate";
            this.lblRegistrationDate.Size = new System.Drawing.Size(93, 13);
            this.lblRegistrationDate.TabIndex = 10;
            this.lblRegistrationDate.Text = "Дата регистрации:";

            // dtpRegistrationDate
            this.dtpRegistrationDate.Location = new System.Drawing.Point(370, 87);
            this.dtpRegistrationDate.Name = "dtpRegistrationDate";
            this.dtpRegistrationDate.Size = new System.Drawing.Size(150, 20);
            this.dtpRegistrationDate.TabIndex = 11;

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(450, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 30);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(540, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // ClientsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.gbClientDetails);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvClients);
            this.Name = "ClientsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление клиентами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbClientDetails.ResumeLayout(false);
            this.gbClientDetails.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}