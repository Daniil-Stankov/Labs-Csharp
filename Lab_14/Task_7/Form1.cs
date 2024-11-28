using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Task_7
{
    public partial class Form1 : Form
    {
        string constring = "server=localhost;uid=root;pwd=2602;database=LandManagement";
        DataTable currentTable = new DataTable();
        string selectedTable;

        public Form1()
        {
            InitializeComponent();
            LoadTables();
        }

        // Завантаження назв таблиць у ComboBox
        private void LoadTables()
        {
            comboBox1.Items.Add("Підприємство");
            comboBox1.Items.Add("ЗемельнаДілянка");
            comboBox1.Items.Add("ЗемлеВикористання");
            comboBox1.SelectedIndex = 0;
        }

        // Подія вибору таблиці у ComboBox
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTable = comboBox1.SelectedItem.ToString();
            LoadData(selectedTable);
        }

        // Завантаження даних у DataGridView
        private void LoadData(string tableName)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string sql = $"SELECT * FROM `{tableName}`";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);
                    dataGridView1.DataSource = currentTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        // Обробка статистичних розрахунків
        private void btnStatistics_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string sql = "";

                    if (selectedTable == "Підприємство")
                    {
                        sql = "SELECT " +
                              "AVG(річний_дохід) AS 'Середній дохід', " +
                              "MIN(річний_дохід) AS 'Мінімальний дохід', " +
                              "MAX(річний_дохід) AS 'Максимальний дохід' " +
                              "FROM Підприємство";
                    }
                    else if (selectedTable == "ЗемельнаДілянка")
                    {
                        sql = "SELECT " +
                              "AVG(площа) AS 'Середня площа', " +
                              "MIN(вартість) AS 'Мінімальна вартість', " +
                              "MAX(вартість) AS 'Максимальна вартість' " +
                              "FROM ЗемельнаДілянка";
                    }
                    else if (selectedTable == "ЗемлеВикористання")
                    {
                        sql = "SELECT " +
                              "COUNT(*) AS 'Кількість записів', " +
                              "COUNT(CASE WHEN вид_використання = 'оренда' THEN 1 END) AS 'Кількість оренд', " +
                              "COUNT(CASE WHEN вид_використання = 'володіння' THEN 1 END) AS 'Кількість володінь' " +
                              "FROM ЗемлеВикористання";
                    }

                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataTable statsTable = new DataTable();
                    adapter.Fill(statsTable);

                    // Виведення результатів у DataGridView
                    dataGridView1.DataSource = statsTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        // Перемикання режимів за допомогою RadioButton
        private void radioButtonMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                LoadData(selectedTable);
            }
            else if (radioButton2.Checked)
            {
                btnStatistics_Click(sender, e);
            }
        }
    }
}