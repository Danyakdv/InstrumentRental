using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient; // Используем System.Data.SqlClient

namespace InstrumentRental
{
    public static class DatabaseHelper
    {
        private static string _connectionString;
        private static bool _isInitialized = false;
        private static readonly object _lock = new object();

        // Свойство для доступа к строке подключения
        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    InitializeConnectionString();
                }
                return _connectionString;
            }
        }

        // Инициализация строки подключения
        private static void InitializeConnectionString()
        {
            lock (_lock)
            {
                if (_isInitialized && !string.IsNullOrEmpty(_connectionString))
                    return;

                try
                {
                    // Пробуем прочитать из конфигурационного файла
                    var configConnectionString = ConfigurationManager.ConnectionStrings["InstrumentRentalDB"];
                    if (configConnectionString != null && !string.IsNullOrEmpty(configConnectionString.ConnectionString))
                    {
                        _connectionString = configConnectionString.ConnectionString;
                        _isInitialized = true;
                        return;
                    }
                }
                catch
                {
                    // Если не удалось прочитать из конфига, используем значения по умолчанию
                }

                // Строка подключения по умолчанию для вашей базы
                _connectionString = @"Server=localhost;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;";

                _isInitialized = true;
            }
        }

        // Установка своей строки подключения
        public static void SetConnectionString(string connectionString)
        {
            lock (_lock)
            {
                if (!string.IsNullOrEmpty(connectionString))
                {
                    _connectionString = connectionString;
                    _isInitialized = true;
                }
            }
        }

        // Тест подключения
        public static bool TestConnection()
        {
            return TestConnection(ConnectionString);
        }

        public static bool TestConnection(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return connection.State == ConnectionState.Open;
                }
            }
            catch
            {
                return false;
            }
        }

        // Детальный тест подключения
        public static (bool Success, string Message) TestConnectionDetailed()
        {
            return TestConnectionDetailed(ConnectionString);
        }

        public static (bool Success, string Message) TestConnectionDetailed(string connectionString)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("SELECT @@VERSION", connection))
                    {
                        var version = cmd.ExecuteScalar();
                        return (true, $"Подключение успешно!\nSQL Server версия: {version}\nСервер: {connection.DataSource}\nБаза данных: {connection.Database}");
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, $"Ошибка подключения: {ex.Message}\nИспользуемая строка подключения: {connectionString}");
            }
        }

        // Создание подключения
        public static SqlConnection CreateConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static SqlConnection CreateOpenConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        // Выполнение запроса с возвратом DataTable
        public static DataTable ExecuteQuery(string query, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        var dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        // Выполнение запроса без возврата данных (INSERT, UPDATE, DELETE)
        public static int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        // Выполнение запроса с возвратом одного значения
        public static object ExecuteScalar(string query, SqlParameter[] parameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        // Создание параметра
        public static SqlParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }

        // Сброс подключения
        public static void ResetConnection()
        {
            lock (_lock)
            {
                _connectionString = null;
                _isInitialized = false;
            }
        }

        // Поиск рабочей строки подключения
        public static string FindWorkingConnectionString()
        {
            string[] testStrings = new[]
            {
                @"Server=localhost;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=.;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Data Source=localhost;Initial Catalog=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=127.0.0.1;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=(local);Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=localhost\SQLEXPRESS;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=.\SQLEXPRESS;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
                @"Server=(localdb)\MSSQLLocalDB;Database=InstrumentRentalDB;Integrated Security=True;TrustServerCertificate=True;",
            };

            foreach (var connStr in testStrings)
            {
                if (TestConnection(connStr))
                {
                    return connStr;
                }
            }

            return null;
        }
    }
}