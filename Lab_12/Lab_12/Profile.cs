using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_12
{
    public partial class Profile : Form
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public Profile(string username, string email, string password)
        {
            InitializeComponent();
            Username = username;
            Email = email;
            Password = password;
            UpdateLabels();
        }

        private void UpdateLabels()
        {
            label2.Text = $"Username: {Username}";
            label3.Text = $"Email: {Email}";
            label4.Text = $"Password: {Password}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Redact redactForm = new Redact(Username, Email, Password);
            redactForm.ShowDialog();

            if (redactForm.IsUpdated)
            {
                Username = redactForm.UpdatedUsername ?? Username;
                Email = redactForm.UpdatedEmail ?? Email;
                Password = redactForm.UpdatedPassword ?? Password;
                UpdateLabels(); // Оновлення тексту міток
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SendMessage sendMessageForm = new SendMessage(Username);
            sendMessageForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RecievedMessages recievedMessagesForm = new RecievedMessages(Username); // Передаємо поточний Username
            recievedMessagesForm.Show();
            this.Hide();
            recievedMessagesForm.FormClosed += (s, args) => this.Show();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // Закриває всі запущені форми
        }
    }
}
