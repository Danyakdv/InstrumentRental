namespace InstrumentRental
{
    partial class ReportsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.GroupBox gbPeriod;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.GroupBox gbReports;
        private System.Windows.Forms.Button btnIncomeReport;
        private System.Windows.Forms.Button btnPopularInstruments;
        private System.Windows.Forms.Button btnDebtors;
        private System.Windows.Forms.Button btnClientActivity;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label lblTotal;

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
            this.gbPeriod = new System.Windows.Forms.GroupBox();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.gbReports = new System.Windows.Forms.GroupBox();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnClientActivity = new System.Windows.Forms.Button();
            this.btnDebtors = new System.Windows.Forms.Button();
            this.btnPopularInstruments = new System.Windows.Forms.Button();
            this.btnIncomeReport = new System.Windows.Forms.Button();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbPeriod.SuspendLayout();
            this.gbReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            // gbPeriod
            this.gbPeriod.Controls.Add(this.dtpTo);
            this.gbPeriod.Controls.Add(this.lblTo);
            this.gbPeriod.Controls.Add(this.dtpFrom);
            this.gbPeriod.Controls.Add(this.lblFrom);
            this.gbPeriod.Location = new System.Drawing.Point(12, 12);
            this.gbPeriod.Name = "gbPeriod";
            this.gbPeriod.Size = new System.Drawing.Size(400, 60);
            this.gbPeriod.TabIndex = 0;
            this.gbPeriod.TabStop = false;
            this.gbPeriod.Text = "Период";

            // lblFrom
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(20, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(49, 13);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "С даты:";

            // dtpFrom
            this.dtpFrom.Location = new System.Drawing.Point(75, 27);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(120, 20);
            this.dtpFrom.TabIndex = 1;

            // lblTo
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(210, 30);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(49, 13);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "По дату:";

            // dtpTo
            this.dtpTo.Location = new System.Drawing.Point(265, 27);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(120, 20);
            this.dtpTo.TabIndex = 3;

            // gbReports
            this.gbReports.Controls.Add(this.btnExportToExcel);
            this.gbReports.Controls.Add(this.btnClientActivity);
            this.gbReports.Controls.Add(this.btnDebtors);
            this.gbReports.Controls.Add(this.btnPopularInstruments);
            this.gbReports.Controls.Add(this.btnIncomeReport);
            this.gbReports.Location = new System.Drawing.Point(12, 80);
            this.gbReports.Name = "gbReports";
            this.gbReports.Size = new System.Drawing.Size(960, 80);
            this.gbReports.TabIndex = 1;
            this.gbReports.TabStop = false;
            this.gbReports.Text = "Отчеты";

            // btnIncomeReport
            this.btnIncomeReport.Location = new System.Drawing.Point(20, 30);
            this.btnIncomeReport.Name = "btnIncomeReport";
            this.btnIncomeReport.Size = new System.Drawing.Size(150, 30);
            this.btnIncomeReport.TabIndex = 0;
            this.btnIncomeReport.Text = "Доходы по дням";
            this.btnIncomeReport.UseVisualStyleBackColor = true;
            this.btnIncomeReport.Click += new System.EventHandler(this.btnIncomeReport_Click);

            // btnPopularInstruments
            this.btnPopularInstruments.Location = new System.Drawing.Point(180, 30);
            this.btnPopularInstruments.Name = "btnPopularInstruments";
            this.btnPopularInstruments.Size = new System.Drawing.Size(150, 30);
            this.btnPopularInstruments.TabIndex = 1;
            this.btnPopularInstruments.Text = "Популярные инструменты";
            this.btnPopularInstruments.Click += new System.EventHandler(this.btnPopularInstruments_Click);

            // btnDebtors
            this.btnDebtors.Location = new System.Drawing.Point(340, 30);
            this.btnDebtors.Name = "btnDebtors";
            this.btnDebtors.Size = new System.Drawing.Size(150, 30);
            this.btnDebtors.TabIndex = 2;
            this.btnDebtors.Text = "Список должников";
            this.btnDebtors.Click += new System.EventHandler(this.btnDebtors_Click);

            // btnClientActivity
            this.btnClientActivity.Location = new System.Drawing.Point(500, 30);
            this.btnClientActivity.Name = "btnClientActivity";
            this.btnClientActivity.Size = new System.Drawing.Size(150, 30);
            this.btnClientActivity.TabIndex = 3;
            this.btnClientActivity.Text = "Активность клиентов";
            this.btnClientActivity.Click += new System.EventHandler(this.btnClientActivity_Click);

            // btnExportToExcel
            this.btnExportToExcel.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnExportToExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportToExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportToExcel.Location = new System.Drawing.Point(750, 30);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(150, 30);
            this.btnExportToExcel.TabIndex = 4;
            this.btnExportToExcel.Text = "Экспорт в CSV";
            this.btnExportToExcel.UseVisualStyleBackColor = false;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);

            // dgvReport
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.Location = new System.Drawing.Point(12, 170);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.ReadOnly = true;
            this.dgvReport.Size = new System.Drawing.Size(960, 300);
            this.dgvReport.TabIndex = 2;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 480);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(57, 20);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Итого:";

            // ReportsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dgvReport);
            this.Controls.Add(this.gbReports);
            this.Controls.Add(this.gbPeriod);
            this.Name = "ReportsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Отчеты";
            this.gbPeriod.ResumeLayout(false);
            this.gbPeriod.PerformLayout();
            this.gbReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}