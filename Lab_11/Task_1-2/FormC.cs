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
    public partial class FormC : Form
    {
        public Form PreviousForm { get; set; }
        public string TransitionInfo { get; set; }

        public FormC()
        {
            InitializeComponent();
        }

        private void FormC_Load(object sender, EventArgs e)
        {
            label1.Text = TransitionInfo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (PreviousForm is Form1 previousFormA)
            {
                string additionalInfo = textBox1.Text; // Отримуємо текст із textBox1
                previousFormA.TransitionInfo = $"Перехід з форми C. {additionalInfo}";
                previousFormA.label1.Text = previousFormA.TransitionInfo; // Оновлення тексту в label1
                previousFormA.Show();
                this.Close();
            }
        }
    }
}
