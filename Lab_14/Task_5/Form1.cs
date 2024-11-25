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

namespace Task_5
{
    public partial class Form1 : Form
    {
        string constring = "server=localhost;uid=root;pwd=1234;database=landmanagement";
        DataTable currentTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
            LoadTables();
        }

        // Завантажуємо назви таблиць у ComboBox
        private void LoadTables()
        {
            comboBox1.Items.Add("Підприємство");
            comboBox1.Items.Add("ЗемельнаДілянка");
            comboBox1.Items.Add("ЗемлеВикористання");
            comboBox1.SelectedIndex = 0;  // Встановлюємо початковий вибір
        }

        // Завантажуємо дані з обраної таблиці
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                LoadData(comboBox1.SelectedItem.ToString());
            }
        }

        // Завантаження даних з БД
        private void LoadData(string tableName)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string sql = $"SELECT * FROM {tableName}";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    currentTable = new DataTable();
                    adapter.Fill(currentTable);

                    // Відображення даних у DataGridView
                    dataGridView1.DataSource = currentTable;

                    // Оновлюємо фільтри
                    UpdateFilters();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        // Оновлення фільтрів залежно від вибраної таблиці
        private void UpdateFilters()
        {
            // Очистити наявні фільтри
            panel1.Controls.Clear();

            // Перевірка на таблицю "Підприємство"
            if (comboBox1.SelectedItem.ToString() == "Підприємство")
            {
                AddSearchField("Найменування");
                AddSearchField("Розрахунковий_рахунок");
                AddSearchField("Річний_дохід");

                AddComboBoxFilter("Річний дохід", "SELECT DISTINCT річний_дохід FROM Підприємство");
            }
            // Перевірка на таблицю "ЗемельнаДілянка"
            else if (comboBox1.SelectedItem.ToString() == "ЗемельнаДілянка")
            {
                AddSearchField("Шифр_ділянки");
                AddSearchField("Площа");
                AddSearchField("Вартість");

                AddComboBoxFilter("Вид грунту", "SELECT DISTINCT вид_грунту FROM ЗемельнаДілянка");
            }
            // Перевірка на таблицю "ЗемлеВикористання"
            else if (comboBox1.SelectedItem.ToString() == "ЗемлеВикористання")
            {
                AddSearchField("Вид_використання");
                AddSearchField("Термін_від");

                AddComboBoxFilter("Термін до", "SELECT DISTINCT термін_до FROM ЗемлеВикористання");
            }
        }

        // Додаємо поле для пошуку
        private void AddSearchField(string columnName)
        {
            Label label = new Label
            {
                Text = $"Пошук по {columnName}:",
                Location = new Point(10, panel1.Controls.Count * 30 + 10)
            };
            TextBox searchBox = new TextBox
            {
                Name = $"{columnName}SearchBox",
                Location = new Point(120, panel1.Controls.Count * 30 + 10),
                Width = 150
            };
            searchBox.TextChanged += SearchBox_TextChanged;
            panel1.Controls.Add(label);
            panel1.Controls.Add(searchBox);
        }

        // Додаємо комбобокс для фільтрації по колонці
        private void AddComboBoxFilter(string columnName, string query)
        {
            Label label = new Label
            {
                Text = $"{columnName}:",
                Location = new Point(10, panel1.Controls.Count * 30 + 10)
            };
            ComboBox comboBox = new ComboBox
            {
                Name = $"{columnName}ComboBox",
                Location = new Point(120, panel1.Controls.Count * 30 + 10),
                Width = 150
            };

            // Завантажуємо значення для ComboBox
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    comboBox.Items.Add(reader[0].ToString());
                }
            }

            comboBox.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            panel1.Controls.Add(label);
            panel1.Controls.Add(comboBox);
        }

        // Обробка змін у текстовому полі пошуку
        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            string columnName = textBox.Name.Replace("SearchBox", "");

            // Перевірка, чи існує стовпець у таблиці
            if (!currentTable.Columns.Contains(columnName))
            {
                MessageBox.Show($"Стовпець '{columnName}' не знайдено в таблиці.");
                return;
            }

            // Логіка фільтрації (всі дані при порожньому полі)
            var filteredRows = string.IsNullOrEmpty(textBox.Text)
                ? currentTable.AsEnumerable()
                : currentTable.AsEnumerable().Where(row => row[columnName].ToString()
                    .IndexOf(textBox.Text, StringComparison.OrdinalIgnoreCase) >= 0);

            // Оновлення DataGridView з фільтрованими даними
            dataGridView1.DataSource = filteredRows.Any() ? filteredRows.CopyToDataTable() : currentTable.Clone();
        }

        // Обробка змін у комбобоксі фільтра
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            string columnName = comboBox.Name.Replace("ComboBox", "");

            var filteredRows = currentTable.AsEnumerable()
                .Where(row => row[columnName].ToString() == comboBox.SelectedItem.ToString())
                .ToArray();
            dataGridView1.DataSource = filteredRows.CopyToDataTable();
        }

        // Перемикання між режимами (Таблиця або Формуляр)
        //private void radioButton_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedItem != null)
        //    {
        //        LoadData(comboBox1.SelectedItem.ToString());
        //    }
        //}
        //private void radioButton2_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (comboBox1.SelectedItem == null)
        //    {
        //        LoadData(comboBox1.SelectedItem.ToString());
        //    }
        //}

        // Обробка події для radioButton1 (показати дані)
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                // Показуємо DataGridView з даними
                dataGridView1.Visible = true;
                if (comboBox1.SelectedItem != null)
                {
                    LoadData(comboBox1.SelectedItem.ToString());
                }
            }
        }

        // Обробка події для radioButton2 (приховати дані)
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                // Приховуємо DataGridView
                dataGridView1.Visible = false;
            }
        }


    }
}