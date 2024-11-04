using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_7
{
    public partial class Task_1 : Form
    {
        public Task_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Ви натиснули кнопку 1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Ви натиснули кнопку 2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Ви натиснули кнопку 3";
        }
    }
}
