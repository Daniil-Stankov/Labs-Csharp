using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Task_1 : Form
    {
        public Task_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);
            textBox3.Font = new Font(textBox3.Font, FontStyle.Italic);
            textBox4.Font = new Font(textBox4.Font, FontStyle.Italic);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;

            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
            textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
            textBox3.Font = new Font(textBox3.Font, FontStyle.Regular);
            textBox4.Font = new Font(textBox4.Font, FontStyle.Regular);
        }
    }
}
