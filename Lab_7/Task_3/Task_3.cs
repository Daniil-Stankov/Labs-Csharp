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
    public partial class Task_3 : Form
    {
        public Task_3()
        {
            InitializeComponent();
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            if (label1.Font.Italic)
            {
                label1.Font = new Font(label1.Font, FontStyle.Regular);
            }
            else
            {
                label1.Font = new Font(label1.Font, FontStyle.Italic);
            }
        }

        private void label2_DoubleClick(object sender, EventArgs e)
        {
            if (label2.Font.Italic)
            {
                label2.Font = new Font(label2.Font, FontStyle.Regular);
            }
            else
            {
                label2.Font = new Font(label2.Font, FontStyle.Italic);
            }
        }

        private void label3_DoubleClick(object sender, EventArgs e)
        {
            if (label3.Font.Italic)
            {
                label3.Font = new Font(label3.Font, FontStyle.Regular);
            }
            else
            {
                label3.Font = new Font(label3.Font, FontStyle.Italic);
            }
        }
    }
}
