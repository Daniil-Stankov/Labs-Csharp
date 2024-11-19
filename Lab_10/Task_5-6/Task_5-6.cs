using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5_6
{
    public partial class Form1 : Form
    {
        private int elapsedMinutes = 0;
        private int elapsedSeconds = 0;
        private bool isRunning = false;
        private int changeInterval; // Інтервал для зміни кнопки
        private int elapsedForChange = 0; // Лічильник для зміни кнопки

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                timer1.Stop();
                button1.Text = "Старт";
                isRunning = false;
            }
            else
            {
                changeInterval = (int)(numericUpDown1.Value * 60 + numericUpDown2.Value); // Інтервал у секундах

                if (changeInterval > 0)
                {
                    timer1.Interval = 1000; // Таймер працює кожну секунду
                    elapsedMinutes = 0;
                    elapsedSeconds = 0;
                    elapsedForChange = 0; // Скидаємо лічильник для зміни кнопки
                    label1.Text = "00 : 00"; // Скидання часу
                    timer1.Start();
                    button1.Text = "Стоп";
                    isRunning = true;
                }
                else
                {
                    MessageBox.Show("Інтервал має бути більше 0 секунд!", "Помилка");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Логіка секундоміра
            elapsedSeconds++;
            elapsedForChange++;

            if (elapsedSeconds == 60)
            {
                elapsedSeconds = 0;
                elapsedMinutes++;
            }

            // Оновлення тексту Label1
            label1.Text = $"{elapsedMinutes:D2} : {elapsedSeconds:D2}";

            // Зміна кнопки кожен раз, коли минув встановлений інтервал
            if (elapsedForChange >= changeInterval)
            {
                elapsedForChange = 0; // Скидаємо лічильник для зміни кнопки
                ChangeButtonSize(); // Викликаємо функцію зміни кнопки
            }
        }

        private void ChangeButtonSize()
        {
            button1.Width += 10;
            button1.Height += 10;

            // Щоб кнопка не ставала занадто великою
            if (button1.Width > 81) button1.Width = 61;
            if (button1.Height > 43) button1.Height = 23; 
        }
    }
}
