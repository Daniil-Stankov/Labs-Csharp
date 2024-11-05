using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7
{
    public partial class Task_7 : Form
    {
        public Task_7()
        {
            InitializeComponent();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label1.Font = new Font(label1.Font, FontStyle.Italic);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label1.Font = new Font(label1.Font, FontStyle.Regular);
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label2.Font = new Font(label2.Font, FontStyle.Italic);
        }

        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label2.Font = new Font(label2.Font, FontStyle.Regular);
        }

        private void label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label3.Font = new Font(label3.Font, FontStyle.Italic);
        }

        private void label3_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                label3.Font = new Font(label3.Font, FontStyle.Regular);
        }
    }
}
