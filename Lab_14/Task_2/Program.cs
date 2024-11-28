using System;
using MySqlConnector;
using System.Data;
using System.Text;
using static System.Console;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            OutputEncoding = Encoding.UTF8;
            InputEncoding = Encoding.UTF8;

            string constring = "server=localhost;uid=root;pwd=2602;database=landmanagement";

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();

                    // Виведення інформації про всі підприємства
                    Console.WriteLine("Список підприємств:");
                    string sqlEnterprise = "SELECT * FROM Підприємство";
                    MySqlCommand cmd1 = new MySqlCommand(sqlEnterprise, con);
                    using (MySqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["id"]}, Назва: {reader["найменування"]}, Річний дохід: {reader["річний_дохід"]}");
                        }
                    }

                    // Виведення земельних ділянок, які використовуються певним підприємством
                    Console.WriteLine("\nВведіть ID підприємства для відбору земельних ділянок:");
                    int enterpriseId = int.Parse(Console.ReadLine());

                    string sqlLandUsage = @"SELECT ЗД.* FROM ЗемельнаДілянка ЗД
                                           JOIN ЗемлеВикористання ЗВ ON ЗД.id = ЗВ.земельна_ділянка_id
                                           WHERE ЗВ.підприємство_id = @enterpriseId";

                    MySqlCommand cmd2 = new MySqlCommand(sqlLandUsage, con);
                    cmd2.Parameters.AddWithValue("@enterpriseId", enterpriseId);

                    using (MySqlDataReader reader = cmd2.ExecuteReader())
                    {
                        Console.WriteLine("\nЗемельні ділянки, що належать підприємству:");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID ділянки: {reader["id"]}, Площа: {reader["площа"]}, Вартість: {reader["вартість"]}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }
        }
    }
}