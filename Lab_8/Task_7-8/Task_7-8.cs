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
    public partial class Task_7 : Form
    {
        public Task_7()
        {
            InitializeComponent();
        }

        private void MenuStrip_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem clickedItem)
            {
                label1.BackColor = Color.Red;
            }
        }

    }
}
