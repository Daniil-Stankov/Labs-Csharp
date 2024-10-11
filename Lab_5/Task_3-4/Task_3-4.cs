using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateTextBoxes();
        }

        private void CreateTextBoxes()
        {
            TextBox textBox1 = new TextBox();
            TextBox textBox2 = new TextBox();
            TextBox textBox3 = new TextBox();

            this.Controls.Add(textBox1);
            this.Controls.Add(textBox2);
            this.Controls.Add(textBox3);

            // Створення першого TextBox
            textBox1.Text = "Перший TextBox";
            textBox1.Font = new Font("Times new roman", 15, FontStyle.Italic | FontStyle.Underline);
            textBox1.ForeColor = Color.Yellow;
            textBox1.BackColor = Color.Green;
            textBox1.TextAlign = HorizontalAlignment.Right;
            textBox1.Size = new Size(200, 30);
            textBox1.Location = new Point(50, 50);

            // Створення другого TextBox
            textBox2.Text = "Другий TextBox";
            textBox2.Font = new Font("Times new roman", 17, FontStyle.Bold | FontStyle.Underline);
            textBox2.ForeColor = Color.Red;
            textBox2.BackColor = Color.Blue;
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.Size = new Size(200, 30);
            textBox2.Location = new Point(50, 100);

            // Створення третього TextBox
            textBox3.Text = "Третій TextBox";
            textBox3.Font = new Font("Times new roman", 13, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            textBox3.ForeColor = Color.Green;
            textBox3.BackColor = Color.LightBlue;
            textBox3.TextAlign = HorizontalAlignment.Right;
            textBox3.Size = new Size(200, 30);
            textBox3.Location = new Point(50, 150);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
