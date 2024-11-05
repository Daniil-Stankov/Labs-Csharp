using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_10
{
    public partial class Task_10 : Form
    {
        public Task_10()
        {
            InitializeComponent();
        }

        private void textBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Font = new Font(textBox.Font, FontStyle.Italic);
        }

        private void textBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            textBox.Font = new Font(textBox.Font, FontStyle.Regular);
        }
    }
}
