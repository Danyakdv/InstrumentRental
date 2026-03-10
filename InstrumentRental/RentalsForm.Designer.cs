namespace InstrumentRental
{
    partial class RentalsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvRentals;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cmbStatusFilter;
        private System.Windows.Forms.Label lblStatusFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbNewRental;
        private System.Windows.Forms.Label lblClient;
        private System.Windows.Forms.ComboBox cmbClient;
        private System.Windows.Forms.Label lblInstrument;
        private System.Windows.Forms.ComboBox cmbInstrument;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblDeposit;
        private System.Windows.Forms.TextBox txtDeposit;
        private System.Windows.Forms.Label lblCalculatedCost;
        private System.Windows.Forms.Button btnCreateRental;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnReturnInstrument;
        private System.Windows.Forms.Button btnExtendRental;
        private System.Windows.Forms.Button btnViewContract;

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
            this.dgvRentals = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cmbStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblStatusFilter = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbNewRental = new System.Windows.Forms.GroupBox();
            this.btnCreateRental = new System.Windows.Forms.Button();
            this.lblCalculatedCost = new System.Windows.Forms.Label();
            this.txtDeposit = new System.Windows.Forms.TextBox();
            this.lblDeposit = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.cmbInstrument = new System.Windows.Forms.ComboBox();
            this.lblInstrument = new System.Windows.Forms.Label();
            this.cmbClient = new System.Windows.Forms.ComboBox();
            this.lblClient = new System.Windows.Forms.Label();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnViewContract = new System.Windows.Forms.Button();
            this.btnExtendRental = new System.Windows.Forms.Button();
            this.btnReturnInstrument = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbNewRental.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.SuspendLayout();

            // dgvRentals
            this.dgvRentals.AllowUserToAddRows = false;
            this.dgvRentals.AllowUserToDeleteRows = false;
            this.dgvRentals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRentals.Location = new System.Drawing.Point(12, 100);
            this.dgvRentals.Name = "dgvRentals";
            this.dgvRentals.ReadOnly = true;
            this.dgvRentals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRentals.Size = new System.Drawing.Size(1060, 250);
            this.dgvRentals.TabIndex = 0;

            // gbSearch
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.cmbStatusFilter);
            this.gbSearch.Controls.Add(this.lblStatusFilter);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1060, 80);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск и фильтрация";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Поиск по клиенту или инструменту...";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(230, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lblStatusFilter
            this.lblStatusFilter.AutoSize = true;
            this.lblStatusFilter.Location = new System.Drawing.Point(330, 33);
            this.lblStatusFilter.Name = "lblStatusFilter";
            this.lblStatusFilter.Size = new System.Drawing.Size(44, 13);
            this.lblStatusFilter.TabIndex = 2;
            this.lblStatusFilter.Text = "Статус:";

            // cmbStatusFilter
            this.cmbStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatusFilter.FormattingEnabled = true;
            this.cmbStatusFilter.Items.AddRange(new object[] {
            "Все статусы",
            "Активна",
            "Завершена",
            "Просрочена"});
            this.cmbStatusFilter.Location = new System.Drawing.Point(380, 30);
            this.cmbStatusFilter.Name = "cmbStatusFilter";
            this.cmbStatusFilter.Size = new System.Drawing.Size(120, 21);
            this.cmbStatusFilter.TabIndex = 3;
            this.cmbStatusFilter.SelectedIndexChanged += new System.EventHandler(this.cmbStatusFilter_SelectedIndexChanged);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(520, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // gbNewRental
            this.gbNewRental.Controls.Add(this.btnCreateRental);
            this.gbNewRental.Controls.Add(this.lblCalculatedCost);
            this.gbNewRental.Controls.Add(this.txtDeposit);
            this.gbNewRental.Controls.Add(this.lblDeposit);
            this.gbNewRental.Controls.Add(this.dtpEndDate);
            this.gbNewRental.Controls.Add(this.lblEndDate);
            this.gbNewRental.Controls.Add(this.dtpStartDate);
            this.gbNewRental.Controls.Add(this.lblStartDate);
            this.gbNewRental.Controls.Add(this.cmbInstrument);
            this.gbNewRental.Controls.Add(this.lblInstrument);
            this.gbNewRental.Controls.Add(this.cmbClient);
            this.gbNewRental.Controls.Add(this.lblClient);
            this.gbNewRental.Location = new System.Drawing.Point(12, 360);
            this.gbNewRental.Name = "gbNewRental";
            this.gbNewRental.Size = new System.Drawing.Size(700, 150);
            this.gbNewRental.TabIndex = 2;
            this.gbNewRental.TabStop = false;
            this.gbNewRental.Text = "Новая аренда";

            // lblClient
            this.lblClient.AutoSize = true;
            this.lblClient.Location = new System.Drawing.Point(20, 30);
            this.lblClient.Name = "lblClient";
            this.lblClient.Size = new System.Drawing.Size(46, 13);
            this.lblClient.TabIndex = 0;
            this.lblClient.Text = "Клиент:";

            // cmbClient
            this.cmbClient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClient.FormattingEnabled = true;
            this.cmbClient.Location = new System.Drawing.Point(80, 27);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Size = new System.Drawing.Size(200, 21);
            this.cmbClient.TabIndex = 1;

            // lblInstrument
            this.lblInstrument.AutoSize = true;
            this.lblInstrument.Location = new System.Drawing.Point(300, 30);
            this.lblInstrument.Name = "lblInstrument";
            this.lblInstrument.Size = new System.Drawing.Size(69, 13);
            this.lblInstrument.TabIndex = 2;
            this.lblInstrument.Text = "Инструмент:";

            // cmbInstrument
            this.cmbInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstrument.FormattingEnabled = true;
            this.cmbInstrument.Location = new System.Drawing.Point(380, 27);
            this.cmbInstrument.Name = "cmbInstrument";
            this.cmbInstrument.Size = new System.Drawing.Size(250, 21);
            this.cmbInstrument.TabIndex = 3;
            this.cmbInstrument.SelectedIndexChanged += new System.EventHandler(this.cmbInstrument_SelectedIndexChanged);

            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 60);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(76, 13);
            this.lblStartDate.TabIndex = 4;
            this.lblStartDate.Text = "Дата начала:";

            // dtpStartDate
            this.dtpStartDate.Location = new System.Drawing.Point(100, 57);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(130, 20);
            this.dtpStartDate.TabIndex = 5;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);

            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(250, 60);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(84, 13);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "Дата окончания:";

            // dtpEndDate
            this.dtpEndDate.Location = new System.Drawing.Point(340, 57);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(130, 20);
            this.dtpEndDate.TabIndex = 7;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);

            // lblDeposit
            this.lblDeposit.AutoSize = true;
            this.lblDeposit.Location = new System.Drawing.Point(490, 60);
            this.lblDeposit.Name = "lblDeposit";
            this.lblDeposit.Size = new System.Drawing.Size(40, 13);
            this.lblDeposit.TabIndex = 8;
            this.lblDeposit.Text = "Залог:";

            // txtDeposit
            this.txtDeposit.Location = new System.Drawing.Point(540, 57);
            this.txtDeposit.Name = "txtDeposit";
            this.txtDeposit.Size = new System.Drawing.Size(90, 20);
            this.txtDeposit.TabIndex = 9;

            // lblCalculatedCost
            this.lblCalculatedCost.AutoSize = true;
            this.lblCalculatedCost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCalculatedCost.Location = new System.Drawing.Point(20, 100);
            this.lblCalculatedCost.Name = "lblCalculatedCost";
            this.lblCalculatedCost.Size = new System.Drawing.Size(137, 17);
            this.lblCalculatedCost.TabIndex = 10;
            this.lblCalculatedCost.Text = "Общая стоимость:";

            // btnCreateRental
            this.btnCreateRental.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnCreateRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateRental.ForeColor = System.Drawing.Color.White;
            this.btnCreateRental.Location = new System.Drawing.Point(540, 100);
            this.btnCreateRental.Name = "btnCreateRental";
            this.btnCreateRental.Size = new System.Drawing.Size(140, 30);
            this.btnCreateRental.TabIndex = 11;
            this.btnCreateRental.Text = "Создать аренду";
            this.btnCreateRental.UseVisualStyleBackColor = false;
            this.btnCreateRental.Click += new System.EventHandler(this.btnCreateRental_Click);

            // gbActions
            this.gbActions.Controls.Add(this.btnViewContract);
            this.gbActions.Controls.Add(this.btnExtendRental);
            this.gbActions.Controls.Add(this.btnReturnInstrument);
            this.gbActions.Location = new System.Drawing.Point(730, 360);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(340, 150);
            this.gbActions.TabIndex = 3;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия с арендой";

            // btnReturnInstrument
            this.btnReturnInstrument.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnReturnInstrument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnInstrument.ForeColor = System.Drawing.Color.White;
            this.btnReturnInstrument.Location = new System.Drawing.Point(20, 30);
            this.btnReturnInstrument.Name = "btnReturnInstrument";
            this.btnReturnInstrument.Size = new System.Drawing.Size(140, 30);
            this.btnReturnInstrument.TabIndex = 0;
            this.btnReturnInstrument.Text = "Возврат инструмента";
            this.btnReturnInstrument.UseVisualStyleBackColor = false;
            this.btnReturnInstrument.Click += new System.EventHandler(this.btnReturnInstrument_Click);

            // btnExtendRental
            this.btnExtendRental.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnExtendRental.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtendRental.ForeColor = System.Drawing.Color.White;
            this.btnExtendRental.Location = new System.Drawing.Point(180, 30);
            this.btnExtendRental.Name = "btnExtendRental";
            this.btnExtendRental.Size = new System.Drawing.Size(140, 30);
            this.btnExtendRental.TabIndex = 1;
            this.btnExtendRental.Text = "Продлить аренду";
            this.btnExtendRental.UseVisualStyleBackColor = false;
            this.btnExtendRental.Click += new System.EventHandler(this.btnExtendRental_Click);

            // btnViewContract
            this.btnViewContract.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnViewContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewContract.ForeColor = System.Drawing.Color.White;
            this.btnViewContract.Location = new System.Drawing.Point(100, 80);
            this.btnViewContract.Name = "btnViewContract";
            this.btnViewContract.Size = new System.Drawing.Size(140, 30);
            this.btnViewContract.TabIndex = 2;
            this.btnViewContract.Text = "Просмотр договора";
            this.btnViewContract.UseVisualStyleBackColor = false;

            // RentalsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 521);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbNewRental);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvRentals);
            this.Name = "RentalsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление арендой";
            ((System.ComponentModel.ISupportInitialize)(this.dgvRentals)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbNewRental.ResumeLayout(false);
            this.gbNewRental.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}