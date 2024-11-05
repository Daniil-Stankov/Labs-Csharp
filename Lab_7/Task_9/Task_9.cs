using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_9
{
    public partial class Task_9 : Form
    {
        public Task_9()
        {
            InitializeComponent();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font, FontStyle.Italic);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Font = new Font(textBox1.Font, FontStyle.Regular);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Font = new Font(textBox2.Font, FontStyle.Italic);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Font = new Font(textBox2.Font, FontStyle.Regular);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.Font = new Font(textBox3.Font, FontStyle.Italic);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            textBox3.Font = new Font(textBox3.Font, FontStyle.Regular);
        }
    }
}
