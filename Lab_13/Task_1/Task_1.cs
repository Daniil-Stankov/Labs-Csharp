using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab13
{
    public partial class Task_1 : Form
    {
        public Task_1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            // Отримуємо графіку для PictureBox
            Graphics g = e.Graphics;

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            int stripeHeight = height / 2;

            // Малюємо синю
            g.FillRectangle(Brushes.Blue, 0, 0, width, stripeHeight);
            // Малюємо жовту
            g.FillRectangle(Brushes.Yellow, 0, stripeHeight, width, stripeHeight);
            // Малюємо контур 
            g.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
        }
    }
}
