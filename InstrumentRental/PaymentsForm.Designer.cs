namespace InstrumentRental
{
    partial class PaymentsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbNewPayment;
        private System.Windows.Forms.Label lblRental;
        private System.Windows.Forms.ComboBox cmbRental;
        private System.Windows.Forms.Label lblRentalInfo;
        private System.Windows.Forms.Label lblTotalCost;
        private System.Windows.Forms.Label lblCurrentDebt;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.NumericUpDown nudAmount;
        private System.Windows.Forms.Label lblPaymentMethod;
        private System.Windows.Forms.ComboBox cmbPaymentMethod;
        private System.Windows.Forms.Button btnPay;

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
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbNewPayment = new System.Windows.Forms.GroupBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.cmbPaymentMethod = new System.Windows.Forms.ComboBox();
            this.lblPaymentMethod = new System.Windows.Forms.Label();
            this.nudAmount = new System.Windows.Forms.NumericUpDown();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblCurrentDebt = new System.Windows.Forms.Label();
            this.lblTotalCost = new System.Windows.Forms.Label();
            this.lblRentalInfo = new System.Windows.Forms.Label();
            this.cmbRental = new System.Windows.Forms.ComboBox();
            this.lblRental = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbNewPayment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            this.SuspendLayout();

            // dgvPayments
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.Location = new System.Drawing.Point(12, 100);
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size(1060, 250);
            this.dgvPayments.TabIndex = 0;

            // gbSearch
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.btnClearFilter);
            this.gbSearch.Controls.Add(this.dtpTo);
            this.gbSearch.Controls.Add(this.lblTo);
            this.gbSearch.Controls.Add(this.dtpFrom);
            this.gbSearch.Controls.Add(this.lblFrom);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(1060, 80);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск платежей";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(170, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Поиск по клиенту...";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(200, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
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
            this.dtpFrom.Value = DateTime.Now.AddMonths(-1);
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
            this.dtpTo.Value = DateTime.Now;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);

            // btnClearFilter
            this.btnClearFilter.Location = new System.Drawing.Point(710, 28);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(100, 23);
            this.btnClearFilter.TabIndex = 6;
            this.btnClearFilter.Text = "Сбросить фильтр";
            this.btnClearFilter.Click += new System.EventHandler(this.btnClearFilter_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(830, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // gbNewPayment
            this.gbNewPayment.Controls.Add(this.btnPay);
            this.gbNewPayment.Controls.Add(this.cmbPaymentMethod);
            this.gbNewPayment.Controls.Add(this.lblPaymentMethod);
            this.gbNewPayment.Controls.Add(this.nudAmount);
            this.gbNewPayment.Controls.Add(this.lblAmount);
            this.gbNewPayment.Controls.Add(this.lblCurrentDebt);
            this.gbNewPayment.Controls.Add(this.lblTotalCost);
            this.gbNewPayment.Controls.Add(this.lblRentalInfo);
            this.gbNewPayment.Controls.Add(this.cmbRental);
            this.gbNewPayment.Controls.Add(this.lblRental);
            this.gbNewPayment.Location = new System.Drawing.Point(12, 360);
            this.gbNewPayment.Name = "gbNewPayment";
            this.gbNewPayment.Size = new System.Drawing.Size(1060, 150);
            this.gbNewPayment.TabIndex = 2;
            this.gbNewPayment.TabStop = false;
            this.gbNewPayment.Text = "Новый платеж";

            // lblRental
            this.lblRental.AutoSize = true;
            this.lblRental.Location = new System.Drawing.Point(20, 30);
            this.lblRental.Name = "lblRental";
            this.lblRental.Size = new System.Drawing.Size(48, 13);
            this.lblRental.TabIndex = 0;
            this.lblRental.Text = "Аренда:";

            // cmbRental
            this.cmbRental.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRental.FormattingEnabled = true;
            this.cmbRental.Location = new System.Drawing.Point(80, 27);
            this.cmbRental.Name = "cmbRental";
            this.cmbRental.Size = new System.Drawing.Size(400, 21);
            this.cmbRental.TabIndex = 1;

            // lblRentalInfo
            this.lblRentalInfo.AutoSize = true;
            this.lblRentalInfo.Location = new System.Drawing.Point(20, 60);
            this.lblRentalInfo.Name = "lblRentalInfo";
            this.lblRentalInfo.Size = new System.Drawing.Size(112, 13);
            this.lblRentalInfo.TabIndex = 2;
            this.lblRentalInfo.Text = "Выберите аренду";

            // lblTotalCost
            this.lblTotalCost.AutoSize = true;
            this.lblTotalCost.Location = new System.Drawing.Point(20, 80);
            this.lblTotalCost.Name = "lblTotalCost";
            this.lblTotalCost.Size = new System.Drawing.Size(90, 13);
            this.lblTotalCost.TabIndex = 3;
            this.lblTotalCost.Text = "Общая стоимость:";

            // lblCurrentDebt
            this.lblCurrentDebt.AutoSize = true;
            this.lblCurrentDebt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblCurrentDebt.Location = new System.Drawing.Point(20, 100);
            this.lblCurrentDebt.Name = "lblCurrentDebt";
            this.lblCurrentDebt.Size = new System.Drawing.Size(100, 17);
            this.lblCurrentDebt.TabIndex = 4;
            this.lblCurrentDebt.Text = "Текущий долг:";

            // lblAmount
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(500, 60);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(44, 13);
            this.lblAmount.TabIndex = 5;
            this.lblAmount.Text = "Сумма:";

            // nudAmount
            this.nudAmount.DecimalPlaces = 2;
            this.nudAmount.Location = new System.Drawing.Point(550, 58);
            this.nudAmount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 20);
            this.nudAmount.TabIndex = 6;
            this.nudAmount.ThousandsSeparator = true;

            // lblPaymentMethod
            this.lblPaymentMethod.AutoSize = true;
            this.lblPaymentMethod.Location = new System.Drawing.Point(500, 90);
            this.lblPaymentMethod.Name = "lblPaymentMethod";
            this.lblPaymentMethod.Size = new System.Drawing.Size(81, 13);
            this.lblPaymentMethod.TabIndex = 7;
            this.lblPaymentMethod.Text = "Способ оплаты:";

            // cmbPaymentMethod
            this.cmbPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPaymentMethod.FormattingEnabled = true;
            this.cmbPaymentMethod.Items.AddRange(new object[] {
            "Наличные",
            "Карта",
            "Перевод"});
            this.cmbPaymentMethod.Location = new System.Drawing.Point(590, 87);
            this.cmbPaymentMethod.Name = "cmbPaymentMethod";
            this.cmbPaymentMethod.Size = new System.Drawing.Size(120, 21);
            this.cmbPaymentMethod.TabIndex = 8;

            // btnPay
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnPay.ForeColor = System.Drawing.Color.White;
            this.btnPay.Location = new System.Drawing.Point(750, 60);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(150, 40);
            this.btnPay.TabIndex = 9;
            this.btnPay.Text = "ПРИНЯТЬ ПЛАТЕЖ";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);

            // PaymentsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 521);
            this.Controls.Add(this.gbNewPayment);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvPayments);
            this.Name = "PaymentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление платежами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbNewPayment.ResumeLayout(false);
            this.gbNewPayment.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            this.ResumeLayout(false);
        }
    }
}