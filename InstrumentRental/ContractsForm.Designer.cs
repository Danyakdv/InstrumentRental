namespace InstrumentRental
{
    partial class ContractsForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvContracts;
        private System.Windows.Forms.GroupBox gbSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox gbActions;
        private System.Windows.Forms.Button btnViewContract;
        private System.Windows.Forms.Button btnPrintContract;
        private System.Windows.Forms.GroupBox gbPreview;
        private System.Windows.Forms.TextBox txtContractPreview;

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
            this.dgvContracts = new System.Windows.Forms.DataGridView();
            this.gbSearch = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.gbActions = new System.Windows.Forms.GroupBox();
            this.btnPrintContract = new System.Windows.Forms.Button();
            this.btnViewContract = new System.Windows.Forms.Button();
            this.gbPreview = new System.Windows.Forms.GroupBox();
            this.txtContractPreview = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).BeginInit();
            this.gbSearch.SuspendLayout();
            this.gbActions.SuspendLayout();
            this.gbPreview.SuspendLayout();
            this.SuspendLayout();

            // dgvContracts
            this.dgvContracts.AllowUserToAddRows = false;
            this.dgvContracts.AllowUserToDeleteRows = false;
            this.dgvContracts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvContracts.Location = new System.Drawing.Point(12, 100);
            this.dgvContracts.Name = "dgvContracts";
            this.dgvContracts.ReadOnly = true;
            this.dgvContracts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvContracts.Size = new System.Drawing.Size(960, 200);
            this.dgvContracts.TabIndex = 0;

            // gbSearch
            this.gbSearch.Controls.Add(this.btnRefresh);
            this.gbSearch.Controls.Add(this.btnSearch);
            this.gbSearch.Controls.Add(this.txtSearch);
            this.gbSearch.Location = new System.Drawing.Point(12, 12);
            this.gbSearch.Name = "gbSearch";
            this.gbSearch.Size = new System.Drawing.Size(960, 80);
            this.gbSearch.TabIndex = 1;
            this.gbSearch.TabStop = false;
            this.gbSearch.Text = "Поиск договоров";

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(20, 30);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "Поиск по номеру или клиенту...";

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(230, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Найти";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnRefresh
            this.btnRefresh.Location = new System.Drawing.Point(320, 28);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // gbActions
            this.gbActions.Controls.Add(this.btnPrintContract);
            this.gbActions.Controls.Add(this.btnViewContract);
            this.gbActions.Location = new System.Drawing.Point(12, 310);
            this.gbActions.Name = "gbActions";
            this.gbActions.Size = new System.Drawing.Size(300, 80);
            this.gbActions.TabIndex = 2;
            this.gbActions.TabStop = false;
            this.gbActions.Text = "Действия";

            // btnViewContract
            this.btnViewContract.Location = new System.Drawing.Point(20, 30);
            this.btnViewContract.Name = "btnViewContract";
            this.btnViewContract.Size = new System.Drawing.Size(120, 30);
            this.btnViewContract.TabIndex = 0;
            this.btnViewContract.Text = "Просмотр";
            this.btnViewContract.UseVisualStyleBackColor = true;
            this.btnViewContract.Click += new System.EventHandler(this.btnViewContract_Click);

            // btnPrintContract
            this.btnPrintContract.Location = new System.Drawing.Point(160, 30);
            this.btnPrintContract.Name = "btnPrintContract";
            this.btnPrintContract.Size = new System.Drawing.Size(120, 30);
            this.btnPrintContract.TabIndex = 1;
            this.btnPrintContract.Text = "Печать";
            this.btnPrintContract.UseVisualStyleBackColor = true;
            this.btnPrintContract.Click += new System.EventHandler(this.btnPrintContract_Click);

            // gbPreview
            this.gbPreview.Controls.Add(this.txtContractPreview);
            this.gbPreview.Location = new System.Drawing.Point(330, 310);
            this.gbPreview.Name = "gbPreview";
            this.gbPreview.Size = new System.Drawing.Size(640, 200);
            this.gbPreview.TabIndex = 3;
            this.gbPreview.TabStop = false;
            this.gbPreview.Text = "Предпросмотр договора";

            // txtContractPreview
            this.txtContractPreview.Location = new System.Drawing.Point(10, 20);
            this.txtContractPreview.Multiline = true;
            this.txtContractPreview.Name = "txtContractPreview";
            this.txtContractPreview.ReadOnly = true;
            this.txtContractPreview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContractPreview.Size = new System.Drawing.Size(620, 170);
            this.txtContractPreview.TabIndex = 0;
            this.txtContractPreview.Font = new System.Drawing.Font("Courier New", 9F);

            // ContractsForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 521);
            this.Controls.Add(this.gbPreview);
            this.Controls.Add(this.gbActions);
            this.Controls.Add(this.gbSearch);
            this.Controls.Add(this.dgvContracts);
            this.Name = "ContractsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Управление договорами";
            ((System.ComponentModel.ISupportInitialize)(this.dgvContracts)).EndInit();
            this.gbSearch.ResumeLayout(false);
            this.gbSearch.PerformLayout();
            this.gbActions.ResumeLayout(false);
            this.gbPreview.ResumeLayout(false);
            this.gbPreview.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}