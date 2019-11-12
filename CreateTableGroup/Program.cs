using System;
using static System.Console;
using System.Data.SqlClient;

namespace CreateTableGroup
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=DESKTOP-NVDGPN3;Database=UniversityDb;Trusted_Connection=true;";
            var query =
            @"CREATE TABLE [dbo].[gruppa]
                (
                    [Id] [uniqueidentifier] NOT NULL PRIMARY KEY,
                    [Name] [nvarchar](max) NULL
                );";
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                try
                {
                    command.ExecuteNonQuery();
                    WriteLine("Таблица успешно создана!");
                }
                catch (SqlException exception)
                {
                    WriteLine("Ошибка создания таблицы: " + exception.ToString());
                }
            }
        }
    }
}
