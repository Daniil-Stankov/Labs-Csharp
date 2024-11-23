using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_12
{
    public partial class RecievedMessages : Form
    {
        private string currentUser;

        public RecievedMessages(string username)
        {
            InitializeComponent();
            currentUser = username;
            LoadMessages();
        }

        private void LoadMessages()
        {
            string filePath = "messages.txt"; // Файл із повідомленнями
            if (File.Exists(filePath))
            {
                var messages = File.ReadAllLines(filePath);
                foreach (var message in messages)
                {
                    var parts = message.Split('|'); // Формат: TO|AUTHOR|THEME|TEXT
                    if (parts.Length == 4 && parts[0] == currentUser) // Фільтруємо повідомлення за полем "TO"
                    {
                        listBox1.Items.Add($"{parts[2]} (від {parts[1]})"); // Виводимо Тему та Автора
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string filePath = "messages.txt";
                if (File.Exists(filePath))
                {
                    string[] messages = File.ReadAllLines(filePath);
                    foreach (var message in messages)
                    {
                        var parts = message.Split('|'); // Формат: TO|AUTHOR|THEME|TEXT
                        if (parts.Length == 4 && $"{parts[2]} (від {parts[1]})" == selectedItem)
                        {
                            // Виводимо текст повідомлення у RichTextBox
                            richTextBox1.Text = $"Від: {parts[1]}\nДо: {parts[0]}\nТема: {parts[2]}\n\nТекст повідомлення:\n{parts[3]}";
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Файл із повідомленнями не знайдено.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, оберіть повідомлення для перегляду.", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
