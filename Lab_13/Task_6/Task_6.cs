using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_6
{
    public partial class Task_6 : Form
    {
        private Random random = new Random();
        private int numberOfPoints = 10; // Кількість точок
        private float[] values; // Масив значень курсу

        public Task_6()
        {
            InitializeComponent();
            GenerateRandomValues();
        }

        private void GenerateRandomValues()
        {
            values = new float[numberOfPoints];
            for (int i = 0; i < numberOfPoints; i++)
            {
                values[i] = (float)(random.NextDouble() * 2 + 30); // Випадкові значення 30-32
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            // Відступи
            int margin = 20;
            int graphWidth = width - 2 * margin;
            int graphHeight = height - 2 * margin;

            // Малюємо рамку графіка
            g.DrawRectangle(Pens.Black, margin, margin, graphWidth, graphHeight);

            // Визначаємо масштаб
            float xStep = (float)graphWidth / (numberOfPoints - 1);
            float yMax = 32;
            float yMin = 30;
            float yScale = graphHeight / (yMax - yMin);

            // Малюємо лінії
            Pen graphPen = new Pen(Color.Orange, 2)
            {
                DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot
            };

            for (int i = 0; i < numberOfPoints - 1; i++)
            {
                float x1 = margin + i * xStep;
                float y1 = margin + graphHeight - (values[i] - yMin) * yScale;
                float x2 = margin + (i + 1) * xStep;
                float y2 = margin + graphHeight - (values[i + 1] - yMin) * yScale;

                g.DrawLine(graphPen, x1, y1, x2, y2);
                g.FillEllipse(Brushes.Black, x1 - 2, y1 - 2, 4, 4);

                float xText = x1 - 10;
                float yText = y1 - 15;

                if (xText < margin) xText = margin;
                if (xText > margin + graphWidth - 30) xText = margin + graphWidth - 30;
                if (yText < margin) yText = margin + 10;

                g.DrawString(values[i].ToString("F2"), Font, Brushes.Black, xText, yText);
            }

            // Малювання останньої точки
            float lastX = margin + (numberOfPoints - 1) * xStep;
            float lastY = margin + graphHeight - (values[numberOfPoints - 1] - yMin) * yScale;
            g.FillEllipse(Brushes.Black, lastX - 2, lastY - 2, 4, 4);
            g.DrawString(values[numberOfPoints - 1].ToString("F2"), Font, Brushes.Black, lastX - 10, lastY - 15);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateRandomValues();
            pictureBox1.Invalidate();
        }
    }
}
