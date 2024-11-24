using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_9
{
    public partial class Settings : Form
    {
        public event Action<int, int, int, Color> SettingsConfirmed;
        private Color selectedColor = Color.Black; // Початковий колір

        public Settings()
        {
            InitializeComponent();
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
                MessageBox.Show($"Обраний колір: {selectedColor}", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                int count = (int)numericUpDown1.Value; // Замість numericUpDownCount
                int speed = (int)numericUpDown2.Value; // Замість numericUpDownSpeed
                int diameter = (int)numericUpDown3.Value; // Замість numericUpDownDiameter

                // Передаємо параметри, включаючи обраний колір
                SettingsConfirmed?.Invoke(count, speed, diameter, selectedColor);

                this.Close(); // Закриваємо форму
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
