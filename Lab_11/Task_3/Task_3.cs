using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class Task_3 : Form
    {
        private double? sideLengthSeparateForms;
        private double? sideLength;

        public Task_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double side) && side > 0)
            {
                double perimeter = 3 * side;
                double area = (Math.Sqrt(3) / 4) * side * side;
                label1.Text = $"Введені дані: {side:F2}";
                label2.Text = $"Периметр: {perimeter:F2}\nПлоща: {area:F2}";
            }
            else
            {
                MessageBox.Show("Введіть коректне значення сторони!", "Помилка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeNumber writeForm = new writeNumber();
            if (writeForm.ShowDialog() == DialogResult.OK)
            {
                if (double.TryParse(writeForm.InputValue, out double result) && result > 0)
                {
                    sideLength = result;
                    MessageBox.Show($"Дані успішно введено: {sideLength}", "Успіх");
                }
                else
                {
                    MessageBox.Show("Введено некоректне значення. Повторіть спробу.", "Помилка");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sideLength.HasValue)
            {
                // Розрахунок периметра і площі
                double side = sideLength.Value;
                double perimeter = 3 * side;
                double area = (Math.Sqrt(3) / 4) * side * side;

                // Вивід результатів
                label4.Text = $"Введені дані: {side:F2}";
                label3.Text = $"Периметр: {perimeter:F2}\nПлоща: {area:F2}";
            }
            else
            {
                MessageBox.Show("Спершу введіть дані через форму 'Ввести дані'.", "Помилка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out double side) && side > 0)
            {
                double perimeter = 3 * side;
                double area = (Math.Sqrt(3) / 4) * side * side;

                // Створюємо нову форму showResult
                showResult resultForm = new showResult();

                // Встановлюємо текст у мітках нової форми
                resultForm.SetData($"Введені дані: {side:F2}", $"Периметр: {perimeter:F2}, Площа: {area:F2}");

                // Показуємо форму
                resultForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введіть коректне значення сторони!", "Помилка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Відкрити форму writeNumber для введення даних
            writeNumber writeForm = new writeNumber();
            if (writeForm.ShowDialog() == DialogResult.OK)
            {
                // Отримати введене значення
                if (double.TryParse(writeForm.InputValue, out double result) && result > 0)
                {
                    sideLengthSeparateForms = result;
                    MessageBox.Show($"Дані успішно введено: {sideLengthSeparateForms}", "Успіх");
                }
                else
                {
                    MessageBox.Show("Введено некоректне значення. Повторіть спробу.", "Помилка");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sideLengthSeparateForms.HasValue)
            {
                // Розрахувати периметр і площу
                double side = sideLengthSeparateForms.Value;
                double perimeter = 3 * side;
                double area = (Math.Sqrt(3) / 4) * side * side;

                // Відкрити форму showResult для відображення результатів
                showResult resultForm = new showResult();
                resultForm.SetData($"Введені дані: {side:F2}", $"Периметр: {perimeter:F2}, Площа: {area:F2}");
                resultForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Спершу введіть дані через форму 'Ввести дані'.", "Помилка");
            }
        }
    }
}
