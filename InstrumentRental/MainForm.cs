using System;
using System.Windows.Forms;

namespace InstrumentRental
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer; // Явно указываем Windows.Forms.Timer

        public MainForm()
        {
            InitializeComponent();
            this.Load += MainForm_Load;
            this.FormClosing += MainForm_FormClosing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Отображение информации о пользователе
            lblUserInfo.Text = $"Пользователь: {UserSession.FullName} ({UserSession.Role})";

            // Инициализация таймера
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();

            // Настройка доступа в зависимости от роли
            if (UserSession.Role != "Admin")
            {
                btnUsers.Visible = false; // Кнопка управления пользователями только для админа
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Обновляем время в статусной строке, если она есть
            if (tsslStatus != null)
            {
                tsslStatus.Text = $"Текущее время: {DateTime.Now:dd.MM.yyyy HH:mm:ss} | {UserSession.FullName} ({UserSession.Role})";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Подтверждение выхода
            DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти из системы?",
                "Подтверждение выхода", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnInstruments_Click(object sender, EventArgs e)
        {
            InstrumentsForm form = new InstrumentsForm();
            form.ShowDialog();
        }

        private void btnClients_Click(object sender, EventArgs e)
        {
            ClientsForm form = new ClientsForm();
            form.ShowDialog();
        }

        private void btnRentals_Click(object sender, EventArgs e)
        {
            RentalsForm form = new RentalsForm();
            form.ShowDialog();
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            PaymentsForm form = new PaymentsForm();
            form.ShowDialog();
        }

        private void btnContracts_Click(object sender, EventArgs e)
        {
            ContractsForm form = new ContractsForm();
            form.ShowDialog();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ReportsForm form = new ReportsForm();
            form.ShowDialog();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            if (UserSession.Role == "Admin")
            {
                UserRegistrationForm form = new UserRegistrationForm();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Доступ запрещен. Требуются права администратора.", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePasswordForm form = new ChangePasswordForm();
            form.ShowDialog();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Аренда музыкальных инструментов\nВерсия 1.0\n\nРазработано для автоматизации процессов аренды",
                "О программе", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}