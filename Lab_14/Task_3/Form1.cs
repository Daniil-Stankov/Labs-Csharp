using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Task_3
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

        private void LoadTables()
        {
            // Додаємо назви таблиць до ComboBox
            comboBox1.Items.Add("Підприємство");
            comboBox1.Items.Add("ЗемельнаДілянка");
            comboBox1.Items.Add("ЗемлеВикористання");
            comboBox1.SelectedIndex = 0;  // Встановлюємо початковий вибір
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData(comboBox1.SelectedItem.ToString());
        }

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

                    if (radioButton1.Checked)
                    {
                        dataGridView1.DataSource = currentTable; // Відображення у вигляді таблиці
                        dataGridView1.Visible = true;
                        panel1.Visible = false;
                    }
                    else
                    {
                        DisplayFormular();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Помилка: " + ex.Message);
                }
            }
        }

        private void DisplayFormular()
        {
            panel1.Controls.Clear();
            dataGridView1.Visible = false;
            panel1.Visible = true;

            int yPosition = 10;
            foreach (DataRow row in currentTable.Rows)
            {
                foreach (DataColumn col in currentTable.Columns)
                {
                    Label lbl = new Label
                    {
                        Text = $"{col.ColumnName}: {row[col]}",
                        Location = new Point(10, yPosition),
                        AutoSize = true
                    };
                    panel1.Controls.Add(lbl);
                    yPosition += 30;
                }
                yPosition += 20; // Відстань між об'єктами
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                LoadData(comboBox1.SelectedItem.ToString());
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                LoadData(comboBox1.SelectedItem.ToString());
            }
        }
    }
}
