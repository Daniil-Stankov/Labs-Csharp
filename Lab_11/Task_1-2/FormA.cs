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
    public partial class Form1 : Form
    {
        public string TransitionInfo { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void formBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormB formB = new FormB();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formB.TransitionInfo = $"Перехід з форми A. {additionalInfo}";
            formB.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formB.ShowDialog();
        }

        private void formCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormC formC = new FormC();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formC.TransitionInfo = $"Перехід з форми A. {additionalInfo}";
            formC.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formC.ShowDialog();
        }

        private void formDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormD formD = new FormD();
            string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
            formD.TransitionInfo = $"Перехід з форми A. {additionalInfo}";
            formD.PreviousForm = this;
            this.Hide(); // Приховуємо поточну форму
            formD.ShowDialog();
        }
    }
}
