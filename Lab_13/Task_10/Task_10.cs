using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Task_9
{
    public partial class Task_9 : Form
    {
        private List<Ball> balls;

        public Task_9()
        {
            InitializeComponent();
            InitializeBalls();
        }

        private void InitializeBalls()
        {
            balls = new List<Ball>
            {
                new Ball(20, 20, 30, Color.Red, 5, 3),  // Кулька 1
                new Ball(100, 50, 30, Color.Red, -4, 2), // Кулька 2
                new Ball(150, 150, 40, Color.Blue, 3, -5) // Кулька 3
            };
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Move(ClientRectangle);
            }

            CheckCollisions();
            Invalidate(); // Оновлення форми
        }

        private void CheckCollisions()
        {
            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    Ball ball1 = balls[i];
                    Ball ball2 = balls[j];

                    // Відстань між центрами кульок
                    double distance = Math.Sqrt(Math.Pow(ball1.X - ball2.X, 2) + Math.Pow(ball1.Y - ball2.Y, 2));

                    if (distance <= (ball1.Diameter + ball2.Diameter) / 2)
                    {
                        // Зміна напрямку руху при зіткненні
                        int tempVelocityX = ball1.VelocityX;
                        int tempVelocityY = ball1.VelocityY;

                        ball1.VelocityX = ball2.VelocityX;
                        ball1.VelocityY = ball2.VelocityY;

                        ball2.VelocityX = tempVelocityX;
                        ball2.VelocityY = tempVelocityY;
                    }
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            foreach (var ball in balls)
            {
                ball.Draw(g);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Відкриваємо форму налаштувань
            Settings settingsForm = new Settings();
            settingsForm.SettingsConfirmed += (count, speed, diameter, color) =>
            {
                UpdateBalls(count, speed, diameter, color);
            };
            settingsForm.ShowDialog();
        }

        private void UpdateBalls(int count, int speed, int diameter, Color color)
        {
            balls.Clear();
            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                int x = random.Next(0, ClientRectangle.Width - diameter);
                int y = random.Next(0, ClientRectangle.Height - diameter);

                int velocityX = random.Next(-speed, speed + 1);
                int velocityY = random.Next(-speed, speed + 1);

                balls.Add(new Ball(x, y, diameter, color, velocityX, velocityY));
            }

            Invalidate(); // Перемалювання форми
        }
    }

    public class Ball
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Diameter { get; }
        public Color Color { get; }
        public int VelocityX { get; set; }
        public int VelocityY { get; set; }

        public Ball(int x, int y, int diameter, Color color, int velocityX, int velocityY)
        {
            X = x;
            Y = y;
            Diameter = diameter;
            Color = color;
            VelocityX = velocityX;
            VelocityY = velocityY;
        }

        public void Move(Rectangle bounds)
        {
            X += VelocityX;
            Y += VelocityY;

            // Відбиття від стінок
            if (X <= bounds.Left || X + Diameter >= bounds.Right)
            {
                VelocityX = -VelocityX;
            }

            if (Y <= bounds.Top || Y + Diameter >= bounds.Bottom)
            {
                VelocityY = -VelocityY;
            }
        }

        public void Draw(Graphics g)
        {
            using (Brush brush = new SolidBrush(Color))
            {
                g.FillEllipse(brush, X, Y, Diameter, Diameter);
            }
        }
    }
}
