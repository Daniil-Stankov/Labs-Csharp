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
    public partial class SettingsForm : Form
    {
        private Task_6 mainForm;

        public SettingsForm(Task_6 form)
        {
            InitializeComponent();
            mainForm = form;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mainForm.BackColor = colorDialog.Color;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                mainForm.ForeColor = colorDialog.Color;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                mainForm.Font = fontDialog.Font;
            }
        }
    }
}
