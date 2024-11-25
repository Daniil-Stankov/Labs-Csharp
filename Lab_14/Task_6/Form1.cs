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

namespace Task_6
{
    public partial class Form1 : Form
    {
        string constring = "server=localhost;uid=root;pwd=1234;database=LandManagement";
        DataTable currentTable = new DataTable();
        string selectedTable;

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
            comboBox1.SelectedIndex = 0;
        }

        // Завантаження даних з вибраної таблиці
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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

        // Додавання нового запису
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    string sql = "";

                    if (selectedTable == "Підприємство")
                    {
                        sql = $"INSERT INTO Підприємство (найменування, розрахунковий_рахунок, річний_дохід) " +
                              $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}')";
                    }
                    else if (selectedTable == "ЗемельнаДілянка")
                    {
                        sql = $"INSERT INTO ЗемельнаДілянка (шифр_ділянки, площа, вартість, вид_грунту) " +
                              $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}')";
                    }
                    else if (selectedTable == "ЗемлеВикористання")
                    {
                        sql = $"INSERT INTO ЗемлеВикористання (підприємство_id, земельна_ділянка_id, вид_використання, термін_від, термін_до) " +
                        $"VALUES ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}')";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    LoadData(selectedTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        // Видалення вибраного запису
        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string sql = $"DELETE FROM `{selectedTable}` WHERE id = {row.Cells["id"].Value}";
                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    LoadData(selectedTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        // Редагування вибраного запису
        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(constring))
            {
                try
                {
                    con.Open();
                    DataGridViewRow row = dataGridView1.CurrentRow;
                    string sql = "";

                    if (selectedTable == "Підприємство")
                    {
                        sql = $"UPDATE Підприємство SET найменування = '{textBox1.Text}', розрахунковий_рахунок = '{textBox2.Text}', річний_дохід = '{textBox3.Text}' WHERE id = {row.Cells["id"].Value}";
                    }
                    else if (selectedTable == "ЗемельнаДілянка")
                    {
                        sql = $"UPDATE ЗемельнаДілянка SET шифр_ділянки = '{textBox1.Text}', площа = '{textBox2.Text}', вартість = '{textBox3.Text}', вид_грунту = '{textBox4.Text}' WHERE id = {row.Cells["id"].Value}";
                    }
                    else if (selectedTable == "ЗемлеВикористання")
                    {
                        sql = $"UPDATE ЗемлеВикористання SET підприємство_id = '{textBox1.Text}', земельна_ділянка_id = '{textBox2.Text}', вид_використання = '{textBox3.Text}', термін_від = '{textBox4.Text}', термін_до = '{textBox5.Text}' WHERE id = {row.Cells["id"].Value}";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    LoadData(selectedTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Перевіряємо, яка кнопка активна
            if (radioButton1.Checked)
            {
                // Показуємо DataGridView і завантажуємо дані
                dataGridView1.Visible = true;
                if (!string.IsNullOrEmpty(selectedTable))
                {
                    LoadData(selectedTable); // Завантаження даних, якщо таблиця вибрана
                }
            }
            else if (radioButton2.Checked)
            {
                // Приховуємо DataGridView
                dataGridView1.Visible = false;
            }
        }
    }
}
