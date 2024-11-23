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

namespace Lab_12
{
    public partial class Login : Form
    {
        private Dictionary<string, (string Email, string Password)> registeredUsers;

        public Login()
        {
            InitializeComponent();
            registeredUsers = new Dictionary<string, (string Email, string Password)>();
            LoadUserData();
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
            else if (!registeredUsers.ContainsKey(usernameOrEmail))
            {
                label3.Text = "Користувача з таким іменем або email не знайдено.";
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                label5.Text = "Поле пароля не може бути порожнім.";
                isValid = false;
            }
            else if (registeredUsers.ContainsKey(usernameOrEmail) && registeredUsers[usernameOrEmail].Password != password)
            {
                label5.Text = "Неправильний пароль.";
                isValid = false;
            }

            if (isValid)
            {
                MessageBox.Show("Авторизація успішна!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Отримуємо дані користувача
                string username = registeredUsers.FirstOrDefault(u => u.Key == usernameOrEmail || u.Value.Email == usernameOrEmail).Key;
                string email = registeredUsers[username].Email;

                // Переходимо на форму профілю
                Profile profileForm = new Profile(username, email, password);
                profileForm.Show();
                this.Hide();
                profileForm.FormClosed += (s, args) => this.Show();
            }
        }

        private void ClearErrorMessages()
        {
            label3.Text = "";
            label5.Text = "";
        }

        private void LoadUserData()
        {
            string filePath = "users.txt";
            registeredUsers.Clear();
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        string username = parts[0];
                        string email = parts[1];
                        string password = parts[2];
                        registeredUsers[username] = (email, password); // Зберігаємо username
                        registeredUsers[email] = (username, password); // Зберігаємо email
                    }
                }
            }
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
