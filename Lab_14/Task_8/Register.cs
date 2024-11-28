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
using MySql.Data.MySqlClient;

namespace Task_8
{
    public partial class Register : Form
    {
        // Параметри підключення до бази даних
        private string connectionString = "Server=localhost;Database=Users;User ID=root;Password=2602;";

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

            // Перевірка наявності email у базі даних
            if (isValid && EmailExists(email))
            {
                label8.Text = "Ця електронна адреса вже зареєстрована.";
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

        // Метод для перевірки наявності email у базі даних
        private bool EmailExists(string email)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string checkEmailQuery = "SELECT COUNT(*) FROM userdatabase WHERE email = @email";
                    using (MySqlCommand command = new MySqlCommand(checkEmailQuery, connection))
                    {
                        command.Parameters.AddWithValue("@email", email);
                        int count = Convert.ToInt32(command.ExecuteScalar()); // Повертає кількість збігів
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при перевірці email: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Вважаємо, що email існує для безпеки, якщо сталася помилка
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

        // Збереження даних користувача в базу даних MySQL
        private void SaveUserData(string username, string email, string password)
        {
            try
            {
                // Створення з'єднання з базою даних
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open(); // Відкриваємо з'єднання

                    // SQL-запит для вставки нового користувача
                    string query = "INSERT INTO userdatabase (username, email, password) VALUES (@username, @email, @password)";

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Додавання параметрів до запиту
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);

                        // Виконання запиту
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Сталася помилка при збереженні користувача: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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