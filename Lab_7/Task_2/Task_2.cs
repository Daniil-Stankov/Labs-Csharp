using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Task_2 : Form
    {
        public Task_2()
        {
            InitializeComponent();

            button1.Click += Button_Click;
            button2.Click += Button_Click;
            button3.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Перевіряємо, яка кнопка була натиснута
            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                label1.Text = "Ви натиснули " + clickedButton.Text;
            }
        }
    }
}
