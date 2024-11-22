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
    public partial class FormD : Form
    {
        public Form PreviousForm { get; set; }
        public string TransitionInfo { get; set; }

        public FormD()
        {
            InitializeComponent();
        }

        private void FormD_Load(object sender, EventArgs e)
        {
            label1.Text = TransitionInfo;
        }

        private void formGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormG formG = new FormG();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formG.TransitionInfo = $"Перехід з форми B. {additionalInfo}";
            formG.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formG.ShowDialog();
        }

        private void formHToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormH formH = new FormH();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formH.TransitionInfo = $"Перехід з форми B. {additionalInfo}";
            formH.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formH.ShowDialog();
        }

        private void formIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormI formI = new FormI();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formI.TransitionInfo = $"Перехід з форми B. {additionalInfo}";
            formI.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formI.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PreviousForm is Form1 previousFormA)
            {
                string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
                previousFormA.TransitionInfo = $"Перехід з форми D. {additionalInfo}";
                previousFormA.label1.Text = previousFormA.TransitionInfo; // Оновлення тексту в label1
                previousFormA.Show();
                this.Close();
            }
        }
    }
}
