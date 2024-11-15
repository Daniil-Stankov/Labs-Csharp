using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Task_6
{
    public partial class Task_4 : Form
    {
        public Task_4()
        {
            InitializeComponent();
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            // Збір даних із текстових полів
            string name = textBox1.Text;
            string phone = textBox2.Text;
            string email = textBox3.Text;
            string date = textBox4.Text;
            string dishes = richTextBox1.Text;

            // Збір даних із ComboBox
            string age = comboBox2.SelectedItem?.ToString() ?? "Не вибрано";
            string cuisine = comboBox1.SelectedItem?.ToString() ?? "Не вибрано";

            // Збір даних із RadioButton
            string reason = "";
            if (radioButton1.Checked) reason = radioButton1.Text;
            else if (radioButton2.Checked) reason = radioButton2.Text;
            else if (radioButton3.Checked) reason = radioButton3.Text;
            else if (radioButton4.Checked) reason = radioButton4.Text;

            string recommend = radioButton5.Checked ? "Так" : radioButton6.Checked ? "Ні" : "Не вибрано";

            // Формування повідомлення
            string message = $"Ім'я: {name}\nТелефон: {phone}\nПошта: {email}\nДата відвідування: {date}\n" +
                             $"Вік: {age}\nУлюблена кухня: {cuisine}\nСтрави: {dishes}\n" +
                             $"Чому обрали заклад: {reason}\nРекомендуватимете друзям: {recommend}";

            // Відображення повідомлення
            MessageBox.Show(message, "Відправлені дані", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void buttonReset_Click(object sender, EventArgs e)
        {
            // Очистка текстових полів
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();

            // Скидання ComboBox до початкового стану
            comboBox1.SelectedIndex = -1; // Повертає стан без вибору
            comboBox2.SelectedIndex = -1;

            // Скидання RadioButton до початкового стану
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
        }

    }
}
