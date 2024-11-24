using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Task_5 : Form
    {
        public Task_5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int centerX = pictureBox1.Width / 2;
            int centerY = pictureBox1.Height / 2;

            int circleRadius = 50;
            int lineLength = 100;
            int lineThickness = 4;

            Pen orangePen = new Pen(Color.Orange, lineThickness);

            g.DrawLine(orangePen, centerX - circleRadius - lineLength, centerY - 10, centerX - circleRadius, centerY - 10);

            g.DrawEllipse(orangePen, centerX - circleRadius, centerY - circleRadius, circleRadius * 2, circleRadius * 2);

            g.DrawLine(orangePen, centerX - circleRadius - lineLength, centerY + 10, centerX - circleRadius, centerY + 10);

            g.DrawLine(orangePen, centerX + circleRadius + 1, centerY - circleRadius,
                centerX + circleRadius + 1, centerY + circleRadius);
        }

    }
}
