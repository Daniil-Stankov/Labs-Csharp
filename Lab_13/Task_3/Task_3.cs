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
    public partial class Task_3 : Form
    {
        public Task_3()
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

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle rect = pictureBox1.ClientRectangle;

            int width = rect.Width;
            int height = rect.Height;

            Brush red = Brushes.Red;
            Brush blue = Brushes.Blue;
            Brush white = Brushes.White;

            int whiteThickness = width / 8;
            int blueThickness = whiteThickness / 2;

            int verticalShift = height / 15;
            int horizontalShift = width / -8;

            g.FillRectangle(red, 0, 0, width, height);
            g.FillRectangle(white, 0, height / 2 - whiteThickness / 2 + verticalShift, width, whiteThickness);
            g.FillRectangle(white, width / 2 - whiteThickness / 2 + horizontalShift, 0, whiteThickness, height);
            g.FillRectangle(blue, 0, height / 2 - blueThickness / 2 + verticalShift, width, blueThickness);
            g.FillRectangle(blue, width / 2 - blueThickness / 2 + horizontalShift, 0, blueThickness, height);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox2.Visible = true;
                pictureBox2.Refresh(); // Оновлення прапора
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                pictureBox2.Visible = false; // Приховуємо другий прапор
            }
        }
    }
}
