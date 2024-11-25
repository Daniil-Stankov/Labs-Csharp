using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;
using MySql.Data.MySqlClient;

namespace Task_8
{
    public partial class Login : Form
    {
        private string connectionString = "Server=localhost;Database=Users;User ID=root;Password=1234;"; // Заміни на свої дані для підключення

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearErrorMessages();

            string usernameOrEmail = textBox1.Text.Trim();
            string password = textBox3.Text.Trim();
            bool isValid = true;

            // Перевірка введення
            if (string.IsNullOrWhiteSpace(usernameOrEmail))
            {
                label3.Text = "Поле не може бути порожнім.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                label5.Text = "Поле пароля не може бути порожнім.";
                isValid = false;
            }

            if (isValid)
            {
                // Перевірка користувача та пароля в базі даних
                bool isAuthenticated = AuthenticateUser(usernameOrEmail, password);

                if (isAuthenticated)
                {
                    MessageBox.Show("Авторизація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Отримуємо дані користувача
                    string username = GetUsernameFromDatabase(usernameOrEmail);
                    string email = GetEmailFromDatabase(usernameOrEmail);

                    // Переходимо на форму профілю
                    Profile profileForm = new Profile(username, email, password);
                    profileForm.Show();
                    this.Hide();
                    profileForm.FormClosed += (s, args) => this.Show();
                }
                else
                {
                    label5.Text = "Неправильний пароль або ім'я користувача.";
                }
            }
        }

        private bool AuthenticateUser(string usernameOrEmail, string password)
        {
            bool isAuthenticated = false;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM userdatabase WHERE (username = @usernameOrEmail OR email = @usernameOrEmail) AND password = @password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        isAuthenticated = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при перевірці даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return isAuthenticated;
        }

        private string GetUsernameFromDatabase(string usernameOrEmail)
        {
            string username = string.Empty;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT username FROM userdatabase WHERE username = @usernameOrEmail OR email = @usernameOrEmail";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);

                    username = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні імені користувача: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return username;
        }

        private string GetEmailFromDatabase(string usernameOrEmail)
        {
            string email = string.Empty;
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT email FROM userdatabase WHERE username = @usernameOrEmail OR email = @usernameOrEmail";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@usernameOrEmail", usernameOrEmail);

                    email = Convert.ToString(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка при отриманні електронної пошти: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return email;
        }

        private void ClearErrorMessages()
        {
            label3.Text = "";
            label5.Text = "";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register regForm = new Register();
            regForm.Show();
            this.Hide();
            regForm.FormClosed += (s, args) => this.Show();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Закриває всі запущені форми
        }
    }
}