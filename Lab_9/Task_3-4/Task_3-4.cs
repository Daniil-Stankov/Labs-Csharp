using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_3_4
{
    public partial class Form1 : Form
    {
        public Form1()
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
            else if (e.KeyChar == ',' && textBox2.Text.Contains(","))
            {
                e.Handled = true; // Забороняємо більше однієї крапки
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
            else if (e.KeyChar == ',' && textBox2.Text.Contains(","))
            {
                e.Handled = true; // Забороняємо більше однієї крапки
            }
            else
            {
                button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertKmToZoll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConvertZollToKm();
        }

        private void ConvertKmToZoll()
        {
            if (double.TryParse(textBox1.Text, out double kilometers))
            {
                double zoll = kilometers * 39370.1; // 1 км = 39370.1 цаль
                label2.Text = $"Цаль: {zoll:F2}";
            }
            else
            {
                MessageBox.Show("Невірний формат числа", "Помилка");
            }
        }

        private void ConvertZollToKm()
        {
            if (double.TryParse(textBox2.Text, out double zoll))
            {
                double kilometers = zoll / 39370.1; // Зворотний перехід
                label3.Text = $"Кілометри: {kilometers:F6}";
            }
            else
            {
                MessageBox.Show("Невірний формат числа", "Помилка");
            }
        }

    }
}
