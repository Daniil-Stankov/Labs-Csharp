using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_8
{
    public partial class Task_8 : Form
    {
        public Task_8()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int seconds = DateTime.Now.Second;
            toolStripStatusLabel1.Text = $"{seconds}";

            // Оновлення toolStripStatusLabel2 (лише букви з тексту)
            string inputText = textBox1.Text;
            string onlyLetters = new string(inputText.Where(char.IsLetter).ToArray());
            toolStripStatusLabel2.Text = $"{onlyLetters}";
        }

        private void показатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void сховатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void вихідToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
