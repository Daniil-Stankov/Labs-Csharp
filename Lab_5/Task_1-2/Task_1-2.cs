using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CustomizeLabels();
            
        }

        private void CustomizeLabels()
        {
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(label3);

            // Налаштування label1
            label1.Text = "Перший Label";
            label1.Font = new Font("Times new roman", 15, FontStyle.Italic | FontStyle.Underline);
            label1.ForeColor = Color.Yellow;
            label1.BackColor = Color.Green;
            label1.TextAlign = ContentAlignment.MiddleRight;
            label1.AutoSize = false;
            label1.Size = new Size(200, 30);
            label1.Location = new Point(50, 50);


            // Налаштування label2
            label2.Text = "Другий Label";
            label2.Font = new Font("Times new roman", 17, FontStyle.Bold | FontStyle.Underline);
            label2.ForeColor = Color.Red;
            label2.BackColor = Color.Blue;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            label2.AutoSize = false;
            label2.Size = new Size(200, 30);
            label2.Location = new Point(250, 80);

            // Налаштування label3
            label3.Text = "Третій Label";
            label3.Font = new Font("Times new roman", 13, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
            label3.ForeColor = Color.Green;
            label3.BackColor = Color.LightBlue;
            label3.TextAlign = ContentAlignment.MiddleRight;
            label3.AutoSize = false;
            label3.Size = new Size(200, 30);
            label3.Location = new Point(450, 110);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
