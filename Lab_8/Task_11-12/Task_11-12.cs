using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_11_12
{
    public partial class Form1 : Form
    {
        private bool togglePosition = true;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (togglePosition)
            {
                button1.Location = new Point(50, 50);
            }
            else
            {
                button1.Location = new Point(150, 150);
            }

            togglePosition = !togglePosition;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled) 
            {
                timer1.Enabled = true;
                timer1.Start();
                SetTimerInterval();
            }

            if (!textBox1.Enabled) 
            {
                timer1.Enabled = true;
                timer1.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            textBox1.Enabled = true;
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                SetTimerInterval();
            }
        }

        private void SetTimerInterval()
        {
            if (int.TryParse(textBox1.Text, out int interval) && interval > 0)
            {
                timer1.Interval = interval;
                MessageBox.Show($"Новий інтервал встановлено: {interval} мс", "Успішно");
                textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Введіть коректне число більше 0!", "Помилка");
            }
        }
    }
}
