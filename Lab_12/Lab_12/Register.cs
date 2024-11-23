using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_12
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Очищення повідомлень про помилки
            ClearErrorMessages();

            // Отримання введених значень
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string password = textBox3.Text.Trim();
            string confirmPassword = textBox4.Text.Trim();

            // Перевірка полів
            bool isValid = true;

            // Перевірка імені користувача
            if (!Regex.IsMatch(username, "^[a-zA-Z0-9]{1,15}$"))
            {
                label7.Text = "Ім'я користувача має містити лише латинські літери та цифри (до 15 символів).";
                isValid = false;
            }

            // Перевірка електронної пошти
            if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                label8.Text = "Некоректна електронна адреса.";
                isValid = false;
            }

            // Перевірка пароля
            if (!Regex.IsMatch(password, @"^(?=.*[a-zA-Z])(?=.*\d)(?=.*[@$!%*?&])[a-zA-Z\d@$!%*?&]{12,}$"))
            {
                label9.Text = "Пароль має містити щонайменше 12 символів,\nвключаючи літери, цифри та спеціальні символи.";
                isValid = false;
            }

            // Перевірка підтвердження пароля
            if (password != confirmPassword)
            {
                label10.Text = "Паролі не співпадають.";
                isValid = false;
            }

            // Якщо всі перевірки пройдені
            if (isValid)
            {
                SaveUserData(username, email, password);
                MessageBox.Show("Реєстрація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();

                // Переход на форму логіну
                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
                loginForm.FormClosed += (s, args) => this.Show();
            }
        }

        private void ClearErrorMessages()
        {
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void SaveUserData(string username, string email, string password)
        {
            string filePath = "users.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true)) // Додаємо нові дані у файл
            {
                writer.WriteLine($"{username}|{email}|{password}");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login loginForm = new Login();
            loginForm.Show();
            this.Hide();
            loginForm.FormClosed += (s, args) => this.Show();
        }

    }
}
