namespace InstrumentRental
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUserInfo;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button btnInstruments;
        private System.Windows.Forms.Button btnClients;
        private System.Windows.Forms.Button btnRentals;
        private System.Windows.Forms.Button btnPayments;
        private System.Windows.Forms.Button btnContracts;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tsslStatus;

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
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblUserInfo = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnContracts = new System.Windows.Forms.Button();
            this.btnPayments = new System.Windows.Forms.Button();
            this.btnRentals = new System.Windows.Forms.Button();
            this.btnClients = new System.Windows.Forms.Button();
            this.btnInstruments = new System.Windows.Forms.Button();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tsslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.panelBottom.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();

            // panelTop
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelTop.Controls.Add(this.lblUserInfo);
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 60);
            this.panelTop.TabIndex = 0;

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(380, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Аренда музыкальных инструментов";

            // lblUserInfo
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblUserInfo.ForeColor = System.Drawing.Color.FromArgb(255, 255, 128);
            this.lblUserInfo.Location = new System.Drawing.Point(700, 22);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Size = new System.Drawing.Size(88, 17);
            this.lblUserInfo.TabIndex = 1;
            this.lblUserInfo.Text = "Пользователь:";

            // panelButtons
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(236, 240, 241);
            this.panelButtons.Controls.Add(this.btnExit);
            this.panelButtons.Controls.Add(this.btnAbout);
            this.panelButtons.Controls.Add(this.btnChangePassword);
            this.panelButtons.Controls.Add(this.btnUsers);
            this.panelButtons.Controls.Add(this.btnReports);
            this.panelButtons.Controls.Add(this.btnContracts);
            this.panelButtons.Controls.Add(this.btnPayments);
            this.panelButtons.Controls.Add(this.btnRentals);
            this.panelButtons.Controls.Add(this.btnClients);
            this.panelButtons.Controls.Add(this.btnInstruments);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 60);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1000, 420);
            this.panelButtons.TabIndex = 1;

            // btnInstruments
            this.btnInstruments.BackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            this.btnInstruments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInstruments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnInstruments.ForeColor = System.Drawing.Color.White;
            this.btnInstruments.Location = new System.Drawing.Point(50, 50);
            this.btnInstruments.Name = "btnInstruments";
            this.btnInstruments.Size = new System.Drawing.Size(180, 80);
            this.btnInstruments.TabIndex = 0;
            this.btnInstruments.Text = "Инструменты";
            this.btnInstruments.UseVisualStyleBackColor = false;
            this.btnInstruments.Click += new System.EventHandler(this.btnInstruments_Click);

            // btnClients
            this.btnClients.BackColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnClients.ForeColor = System.Drawing.Color.White;
            this.btnClients.Location = new System.Drawing.Point(280, 50);
            this.btnClients.Name = "btnClients";
            this.btnClients.Size = new System.Drawing.Size(180, 80);
            this.btnClients.TabIndex = 1;
            this.btnClients.Text = "Клиенты";
            this.btnClients.UseVisualStyleBackColor = false;
            this.btnClients.Click += new System.EventHandler(this.btnClients_Click);

            // btnRentals
            this.btnRentals.BackColor = System.Drawing.Color.FromArgb(155, 89, 182);
            this.btnRentals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRentals.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnRentals.ForeColor = System.Drawing.Color.White;
            this.btnRentals.Location = new System.Drawing.Point(510, 50);
            this.btnRentals.Name = "btnRentals";
            this.btnRentals.Size = new System.Drawing.Size(180, 80);
            this.btnRentals.TabIndex = 2;
            this.btnRentals.Text = "Аренда";
            this.btnRentals.UseVisualStyleBackColor = false;
            this.btnRentals.Click += new System.EventHandler(this.btnRentals_Click);

            // btnPayments
            this.btnPayments.BackColor = System.Drawing.Color.FromArgb(241, 196, 15);
            this.btnPayments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnPayments.ForeColor = System.Drawing.Color.White;
            this.btnPayments.Location = new System.Drawing.Point(740, 50);
            this.btnPayments.Name = "btnPayments";
            this.btnPayments.Size = new System.Drawing.Size(180, 80);
            this.btnPayments.TabIndex = 3;
            this.btnPayments.Text = "Платежи";
            this.btnPayments.UseVisualStyleBackColor = false;
            this.btnPayments.Click += new System.EventHandler(this.btnPayments_Click);

            // btnContracts
            this.btnContracts.BackColor = System.Drawing.Color.FromArgb(230, 126, 34);
            this.btnContracts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContracts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnContracts.ForeColor = System.Drawing.Color.White;
            this.btnContracts.Location = new System.Drawing.Point(50, 160);
            this.btnContracts.Name = "btnContracts";
            this.btnContracts.Size = new System.Drawing.Size(180, 80);
            this.btnContracts.TabIndex = 4;
            this.btnContracts.Text = "Договоры";
            this.btnContracts.UseVisualStyleBackColor = false;
            this.btnContracts.Click += new System.EventHandler(this.btnContracts_Click);

            // btnReports
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.White;
            this.btnReports.Location = new System.Drawing.Point(280, 160);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(180, 80);
            this.btnReports.TabIndex = 5;
            this.btnReports.Text = "Отчеты";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);

            // btnUsers
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(149, 165, 166);
            this.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Location = new System.Drawing.Point(510, 160);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(180, 80);
            this.btnUsers.TabIndex = 6;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);

            // btnChangePassword
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(740, 160);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(180, 80);
            this.btnChangePassword.TabIndex = 7;
            this.btnChangePassword.Text = "Сменить пароль";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);

            // btnAbout
            this.btnAbout.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAbout.ForeColor = System.Drawing.Color.White;
            this.btnAbout.Location = new System.Drawing.Point(50, 270);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(180, 60);
            this.btnAbout.TabIndex = 8;
            this.btnAbout.Text = "О программе";
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);

            // btnExit
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(740, 270);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(180, 60);
            this.btnExit.TabIndex = 9;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);

            // panelBottom
            this.panelBottom.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            this.panelBottom.Controls.Add(this.statusStrip);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 480);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1000, 30);
            this.panelBottom.TabIndex = 2;

            // statusStrip
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 8);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1000, 22);
            this.statusStrip.TabIndex = 0;

            // tsslStatus
            this.tsslStatus.Name = "tsslStatus";
            this.tsslStatus.Size = new System.Drawing.Size(250, 17);
            this.tsslStatus.Text = "Готов к работе. Выберите раздел";

            // MainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 510);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelTop);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аренда музыкальных инструментов";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}