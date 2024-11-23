using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_12
{
    public partial class SendMessage : Form
    {
        private string SenderUsername;

        public SendMessage(string username)
        {
            InitializeComponent();
            SenderUsername = username;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string to = textBox1.Text.Trim();
            string theme = textBox2.Text.Trim();
            string messageText = richTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Поле 'To' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(theme))
            {
                MessageBox.Show("Поле 'Theme' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(messageText))
            {
                MessageBox.Show("Поле 'Text' не може бути порожнім.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveMessageToFile(to, theme, messageText);
            MessageBox.Show("Повідомлення успішно відправлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void SaveMessageToFile(string to, string theme, string messageText)
        {
            string filePath = "messages.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                // Зберігаємо повідомлення в форматі TO|AUTHOR|THEME|TEXT
                writer.WriteLine($"{to}|{SenderUsername}|{theme}|{messageText}");
            }
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
        }
    }
}
