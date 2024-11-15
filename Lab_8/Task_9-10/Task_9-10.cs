using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task__
{
    public partial class Task_9 : Form
    {
        public Task_9()
        {
            InitializeComponent();
        }

        private void toolStripButton_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton button)
            {
                string toolTipText = button.ToolTipText;
                MessageBox.Show(toolTipText, "Підказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
