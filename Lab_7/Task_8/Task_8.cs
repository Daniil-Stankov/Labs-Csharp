using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_8
{
    public partial class Task_8 : Form
    {
        public Task_8()
        {
            InitializeComponent();
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;

            if (e.Button == MouseButtons.Left)
                label.Font = new Font(label.Font, FontStyle.Regular);
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            Label label = sender as Label;

            if (e.Button == MouseButtons.Left)
                label.Font = new Font(label.Font, FontStyle.Italic);
        }
    }
}
