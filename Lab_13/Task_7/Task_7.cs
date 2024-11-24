using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_7
{
    public partial class Task_7 : Form
    {
        public Task_7()
        {
            InitializeComponent();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double xStart = double.Parse(textBox1.Text); // Початкове значення x
                double y = double.Parse(textBox2.Text);     // Значення y
                double step = 1;                            // Крок по x
                int pointsCount = 10;                       // Кількість точок

                DrawGraph(xStart, y, step, pointsCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DrawGraph(double xStart, double y, double step, int pointsCount)
        {
            if (y <= 0)
            {
                MessageBox.Show("Значення y повинно бути більшим за 0.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);

            int width = pictureBox1.Width;
            int height = pictureBox1.Height;

            Pen graphPenT1 = new Pen(Color.Blue, 2);
            Pen graphPenT2 = new Pen(Color.Red, 2);

            int margin = 20;
            int graphWidth = width - 2 * margin;
            int graphHeight = height - 2 * margin;

            int x0 = margin;
            int y0 = height - margin;

            double scaleX = graphWidth / (pointsCount - 1.0);
            double yMin = double.MaxValue;
            double yMax = double.MinValue;

            double[] t1Values = new double[pointsCount];
            double[] t2Values = new double[pointsCount];
            double a = 120, b = 1;

            for (int i = 0; i < pointsCount; i++)
            {
                double x = xStart + i * step;

                try
                {
                    // Обчислення t1
                    if (x < 0)
                        throw new ArgumentException("Значення x не може бути від'ємним.");

                    double t1 = (2 / (Math.Pow(a, 2) * y * Math.Sqrt(x))) + ((3 * Math.Pow(b, 2) * Math.Sqrt(x)) / (y * Math.Pow(a, 4)));

                    // Обчислення t2
                    double ax = a * x;
                    if (Math.Sin(ax) == 0 || Math.Tan(ax / 2) <= 0)
                    {
                        t1Values[i] = double.NaN;
                        t2Values[i] = double.NaN;
                        continue;
                    }

                    double t2 = (1 / a) * (Math.Log(Math.Tan(ax / 2)) - (1 / Math.Sin(ax)));

                    t1Values[i] = t1;
                    t2Values[i] = t2;

                    // Оновлення мінімального та максимального значення
                    yMin = Math.Min(yMin, Math.Min(t1, t2));
                    yMax = Math.Max(yMax, Math.Max(t1, t2));
                }
                catch
                {
                    t1Values[i] = double.NaN;
                    t2Values[i] = double.NaN;
                }
            }

            if (yMin >= yMax || double.IsInfinity(yMin) || double.IsInfinity(yMax))
            {
                MessageBox.Show("Некоректний діапазон для побудови графіка.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double yScale = graphHeight / (yMax - yMin);

            for (int i = 0; i < pointsCount - 1; i++)
            {
                if (!double.IsNaN(t1Values[i]) && !double.IsNaN(t1Values[i + 1]))
                {
                    double x1 = x0 + i * scaleX;
                    double x2 = x0 + (i + 1) * scaleX;

                    double y1T1 = y0 - (t1Values[i] - yMin) * yScale;
                    double y2T1 = y0 - (t1Values[i + 1] - yMin) * yScale;

                    g.DrawLine(graphPenT1, (float)x1, (float)y1T1, (float)x2, (float)y2T1);
                    g.FillEllipse(Brushes.Blue, (float)x1 - 2, (float)y1T1 - 2, 4, 4);
                }

                if (!double.IsNaN(t2Values[i]) && !double.IsNaN(t2Values[i + 1]))
                {
                    double x1 = x0 + i * scaleX;
                    double x2 = x0 + (i + 1) * scaleX;

                    double y1T2 = y0 - (t2Values[i] - yMin) * yScale;
                    double y2T2 = y0 - (t2Values[i + 1] - yMin) * yScale;

                    g.DrawLine(graphPenT2, (float)x1, (float)y1T2, (float)x2, (float)y2T2);
                    g.FillEllipse(Brushes.Red, (float)x1 - 2, (float)y1T2 - 2, 4, 4);
                }
            }
        }



    }
}
