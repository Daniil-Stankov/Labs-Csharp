using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_8
{
    public partial class Task_8 : Form
    {
        public Task_8()
        {
            InitializeComponent();
        }

        private void Task_8_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            float[] percentages = { 5, 25, 30, 5, 20, 15 };
            string[] labels = { "Туніс", "Єгипет", "Туреччина", "Марокко", "Яремче", "Моршин" };
            Color[] colors = { Color.Yellow, Color.Blue, Color.Green, Color.Orange, Color.Red, Color.Purple };

            // Параметри кругової діаграми
            Rectangle chartArea = new Rectangle(50, 50, 200, 200);
            float startAngle = 0;

            for (int i = 0; i < percentages.Length; i++)
            {
                float sweepAngle = percentages[i] * 360 / 100; // Розрахунок кута сектору
                using (Brush brush = new SolidBrush(colors[i]))
                {
                    g.FillPie(brush, chartArea, startAngle, sweepAngle);
                }
                startAngle += sweepAngle;
            }

            int legendX = 270;
            int legendY = 50;
            for (int i = 0; i < labels.Length; i++)
            {
                using (Brush brush = new SolidBrush(colors[i]))
                {
                    g.FillRectangle(brush, legendX, legendY + i * 20, 15, 15);
                }

                g.DrawString($"{labels[i]} - {percentages[i]}%", this.Font, Brushes.Black, legendX + 20, legendY + i * 20);
            }
        }
    }
}
