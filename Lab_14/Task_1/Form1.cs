using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySqlConnector;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData(); // Викликаємо метод завантаження даних при ініціалізації форми
        }

        private void LoadData()
        {
            string constring = "server=localhost;uid=root;pwd=1234;database=landmanagement";

            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();

                    // Завантаження даних для першої таблиці
                    string sql1 = "SELECT * FROM Підприємство";
                    MySqlDataAdapter adapter1 = new MySqlDataAdapter(sql1, con);
                    DataTable dataTable1 = new DataTable();
                    adapter1.Fill(dataTable1);
                    dataGridView1.DataSource = dataTable1;

                    // Завантаження даних для другої таблиці
                    string sql2 = "SELECT * FROM ЗемельнаДілянка";
                    MySqlDataAdapter adapter2 = new MySqlDataAdapter(sql2, con);
                    DataTable dataTable2 = new DataTable();
                    adapter2.Fill(dataTable2);
                    dataGridView2.DataSource = dataTable2;

                    // Завантаження даних для третьої таблиці
                    string sql3 = "SELECT * FROM ЗемлеВикористання";
                    MySqlDataAdapter adapter3 = new MySqlDataAdapter(sql3, con);
                    DataTable dataTable3 = new DataTable();
                    adapter3.Fill(dataTable3);
                    dataGridView3.DataSource = dataTable3;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }
    }
}