using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_11
{
    public partial class FormB : Form
    {
        public Form PreviousForm { get; set; }
        public string TransitionInfo { get; set; }

        public FormB()
        {
            InitializeComponent();
        }

        private void FormB_Load(object sender, EventArgs e)
        {
            label1.Text = TransitionInfo;
        }

        private void formEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormE formE = new FormE();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formE.TransitionInfo = $"Перехід з форми B. {additionalInfo}";
            formE.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formE.ShowDialog();
        }

        private void formFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormF formF = new FormF();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formF.TransitionInfo = $"Перехід з форми B. {additionalInfo}";

            if (formF.ShowDialog() == DialogResult.OK)
            {
                // Тут можна обробити повернення, якщо потрібно
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PreviousForm is Form1 previousFormA)
            {
                string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
                previousFormA.TransitionInfo = $"Перехід з форми B. {additionalInfo}";
                previousFormA.label1.Text = previousFormA.TransitionInfo; // Оновлення тексту в label1
                previousFormA.Show();
                this.Close();
            }
        }
    }
}
