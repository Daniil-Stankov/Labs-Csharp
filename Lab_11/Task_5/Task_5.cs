using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Task_5 : Form
    {
        public Task_5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Оберіть місто для відображення інформації.", "Помилка");
                return;
            }

            string selectedCity = comboBox1.SelectedItem.ToString();
            CityInfoForm infoForm = new CityInfoForm(selectedCity);
            infoForm.ShowDialog();
        }
    }
}
