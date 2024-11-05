using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Task_12 : Form
    {
        public Task_12()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCity = comboBox1.SelectedItem.ToString();

            MessageBox.Show($"Вибране місто: {selectedCity}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
