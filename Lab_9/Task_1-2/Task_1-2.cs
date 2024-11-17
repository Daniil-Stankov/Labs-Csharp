using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_9
{
    public partial class Task_1 : Form
    {
        public Task_1()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Введіть число", "Помилка");
                button1.Enabled = false;
            }
            else if (e.KeyChar == ',' && (textBox1.Text.Contains(",") || textBox1.Text.Length == 0))
            {
                e.Handled = true;
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
                MessageBox.Show("Введіть число", "Помилка");
                button2.Enabled = false;
            }
            else if (e.KeyChar == ',' && (textBox2.Text.Contains(",") || textBox2.Text.Length == 0))
            {
                e.Handled = true;
                button2.Enabled = false;
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UahToLei();
        }

        private void UahToLei()
        {
            if (double.TryParse(textBox1.Text, out double amount))
            {
                double rate = 0.44;
                double result = amount * rate;
                label2.Text = $"Сума у молдавських леях: {result:F2}"; // Вивід з двома знаками після коми
            }
            else
            {
                MessageBox.Show("Невірний формат числа", "Помилка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LeiToUah();
        }

        private void LeiToUah()
        {
            if (double.TryParse(textBox2.Text, out double amount))
            {
                double rate = 1 / 0.44; // Зворотний курс
                double result = amount * rate;
                label4.Text = $"Сума у гривнях: {result:F2}"; // Вивід з двома знаками після коми
            }
            else
            {
                MessageBox.Show("Невірний формат числа", "Помилка");
            }
        }
    }
}
