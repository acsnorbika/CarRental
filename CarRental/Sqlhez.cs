using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental
{
    internal class MysqlHelper
    {
        private static string connectionString = "Server=localhost;Database=CarRental;User id=root;password=;";
        private static MySqlConnection connection = new MySqlConnection(connectionString);

        public static void DataBaseConnect()
        {
            try
            {
                connection.Open();
                Console.WriteLine("Kesz ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba: " + ex.Message);
            }
        }
        public static void CreateTable(string tableName)
        {
            string tableFormat = $"CREATE TABLE `{tableName}` (`Nev` varchar(50) CHARACTER SET utf8 COLLATE utf8_hungarian_ci NOT NULL, `Marka` varchar(50) CHARACTER SET utf8 COLLATE utf8_hungarian_ci NOT NULL, `Tipus` varchar(50) NOT NULL, `Evjarat` int(11) NOT NULL, `Ar` DECIMAL(10,2) NOT NULL)";
            try
            {
                using (MySqlCommand command = new MySqlCommand(tableFormat, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Letrehoztad a tablat");
                }
            }
            catch (Exception error)
            {
                Console.WriteLine($"Hiba: {error.Message}");
            }
        }

        public static void TableInsert(string tableName, string values)
        {
            try
            {
                using (MySqlCommand command = new MySqlCommand($"INSERT INTO {tableName} VALUES ({values})", connection))
                {
                    command.ExecuteNonQuery();
                }
                Console.WriteLine("kesz!");
            }
            catch (Exception error)
            {
                Console.WriteLine($"Hiba: {error.Message}");
            }
        }
        public static string LegnepszerubbAuto()
        {
            string query = "SELECT Marka, Tipus, COUNT(*) as Count FROM autokolcsonzo GROUP BY Marka, Tipus ORDER BY Count DESC LIMIT 1";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                return reader.Read() ? $"{reader["Marka"]} {reader["Tipus"]}" : "Nincs adat";
            }
        }

        public static string LegdragabbAuto()
        {
            string query = "SELECT Marka, Tipus, Ar FROM autokolcsonzo ORDER BY Ar DESC LIMIT 1";
            using (MySqlCommand command = new MySqlCommand(query, connection))
            using (MySqlDataReader reader = command.ExecuteReader())
            {
                return reader.Read() ? $"{reader["Marka"]} {reader["Tipus"]} - {reader["Ar"]} Ft/nap" : "Nincs adat";
            }
        }


    }
}
