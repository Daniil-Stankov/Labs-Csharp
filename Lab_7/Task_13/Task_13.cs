using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_13
{
    public partial class Task_13 : Form
    {
        public Task_13()
        {
            InitializeComponent();
        }

        private void Task_13_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                ComboBox comboBox = new ComboBox();
                comboBox.Items.AddRange(new object[] { "Option 1", "Option 2", "Option 3", "Option 4" });
                comboBox.Location = new Point(50, 50);
                comboBox.Name = "dynamicComboBox";
                this.Controls.Add(comboBox);
            }

            else if (e.Control && e.KeyCode == Keys.D)
            {
                Control comboBox = this.Controls["dynamicComboBox"];
                if (comboBox != null)
                {
                    this.Controls.Remove(comboBox);
                    comboBox.Dispose();
                }
            }
        }
    }
}
