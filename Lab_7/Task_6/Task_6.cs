using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6
{
    public partial class Task_6 : Form
    {
        public Task_6()
        {
            InitializeComponent();
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            Button button = sender as Button;

            button.Font = new Font(button.Font, FontStyle.Italic);
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            Button button = sender as Button;

            button.Font = new Font(button.Font, FontStyle.Regular);
        }
    }
}
