using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Lab_12
{
    public partial class Redact : Form
    {
        private string oldUsername;
        private string oldEmail;
        private string oldPassword;

        public string UpdatedUsername { get; private set; }
        public string UpdatedEmail { get; private set; }
        public string UpdatedPassword { get; private set; }
        public bool IsUpdated { get; private set; } = false;

        public Redact(string currentUsername, string currentEmail, string currentPassword)
        {
            InitializeComponent();

            // Зберігаємо старі дані
            oldUsername = currentUsername;
            oldEmail = currentEmail;
            oldPassword = currentPassword;

            // Заповнюємо текстові поля
            textBox1.Text = currentUsername;
            textBox2.Text = currentEmail;
            textBox3.Text = currentPassword;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newUsername = textBox1.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newUsername) && newUsername.Length <= 15)
            {
                UpdatedUsername = newUsername;
                UpdateUserData(oldUsername, newUsername, oldEmail, oldPassword);
                oldUsername = newUsername; // Оновлюємо старе значення
                IsUpdated = true;
                MessageBox.Show("Username оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Некоректний Username!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newEmail = textBox2.Text.Trim();
            if (Regex.IsMatch(newEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                UpdatedEmail = newEmail;
                UpdateUserData(oldUsername, oldUsername, newEmail, oldPassword);
                oldEmail = newEmail; // Оновлюємо старе значення
                IsUpdated = true;
                MessageBox.Show("Email оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Некоректний Email!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newPassword = textBox3.Text.Trim();
            if (!string.IsNullOrWhiteSpace(newPassword) && newPassword.Length >= 12)
            {
                UpdatedPassword = newPassword;
                UpdateUserData(oldUsername, oldUsername, oldEmail, newPassword);
                oldPassword = newPassword; // Оновлюємо старе значення
                IsUpdated = true;
                MessageBox.Show("Password оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Пароль має бути не менше 12 символів!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Повертаємося до форми профілю
            this.Close();
        }

        private void UpdateUserData(string oldUsername, string newUsername, string newEmail, string newPassword)
        {
            string filePath = "users.txt";
            var lines = File.ReadAllLines(filePath).ToList();

            for (int i = 0; i < lines.Count; i++)
            {
                var parts = lines[i].Split('|');
                if (parts.Length == 3 && parts[0] == oldUsername) // Знаходимо користувача за username
                {
                    lines[i] = $"{newUsername}|{newEmail}|{newPassword}"; // Оновлюємо рядок
                    break;
                }
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}
