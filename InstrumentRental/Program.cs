using System;
using System.Windows.Forms;

namespace InstrumentRental
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Показываем форму авторизации как диалог
            LoginForm loginForm = new LoginForm();

            // Если авторизация успешна (нажали OK)
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Запускаем главную форму
                Application.Run(new MainForm());
            }
            else
            {
                // Если нажали Cancel или закрыли окно - выходим
                Application.Exit();
            }
        }
    }
}