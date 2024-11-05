using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Task_5 : Form
    {
        public Task_5()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font, FontStyle.Italic);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Font = new Font(button1.Font, FontStyle.Regular);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font, FontStyle.Italic);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.Font = new Font(button2.Font, FontStyle.Regular);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font, FontStyle.Italic);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.Font = new Font(button3.Font, FontStyle.Regular);
        }
    }
}
