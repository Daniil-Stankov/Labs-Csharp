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

namespace Task_3
{
    public partial class Task_4 : Form
    {
        private double? sideLengthSeparateForms;
        private double? sideLengthSeparateFormsY;
        private double? sideLengthSeparateFormsZ;
        private double? sideLength;
        private double? sideLengthY;
        private double? sideLengthZ;

        public Task_4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double x) &&
            double.TryParse(textBox2.Text, out double y) &&
            double.TryParse(textBox4.Text, out double z) && x >= 0 && y > 0 && z > 0)
            {
                double sum = 0;
                for (int i = 0; i <= x * y * z; i++)
                {
                    if (i != z) // уникаємо ділення на нуль
                    {
                        sum += (i + x + y + z + 2) / (i - z);
                    }
                }
                label1.Text = $"Введені дані: x={x:F2}\ny={y:F2}\nz={z:F2}";
                label2.Text = $"Результат: {sum:F2}";
            }
            else
            {
                MessageBox.Show("Введіть коректні значення x, y та z!", "Помилка");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            writeNumber writeForm = new writeNumber();
            if (writeForm.ShowDialog() == DialogResult.OK)
            {
                // Отримуємо значення x, y, z із форми writeNumber
                if (double.TryParse(writeForm.InputValueX, out double x) &&
                    double.TryParse(writeForm.InputValueY, out double y) &&
                    double.TryParse(writeForm.InputValueZ, out double z) && x >= 0 && y > 0 && z > 0)
                {
                    // Зберігаємо введені значення у властивості
                    sideLength = x;
                    sideLengthY = y;
                    sideLengthZ = z;
                    MessageBox.Show($"Дані успішно введено: x={x}, y={y}, z={z}", "Успіх");
                }
                else
                {
                    MessageBox.Show("Введено некоректні значення. Повторіть спробу.", "Помилка");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sideLength.HasValue)
            {
                double x = sideLength.Value;
                double y = sideLengthY.Value; // Переконайтесь, що змінна sideLengthY існує
                double z = sideLengthZ.Value; // Переконайтесь, що змінна sideLengthZ існує

                double sum = 0;

                try
                {
                    for (int i = 0; i <= x * y * z; i++)
                    {
                        if (i != z) // уникаємо ділення на нуль
                        {
                            sum += (i + x + y + z + 2) / (i - z);
                        }
                    }
                    label4.Text = $"Введені дані: x={x:F2}\ny={y:F2}\nz={z:F2}";
                    label3.Text = $"Результат: {sum:F2}";
                }
                catch (DivideByZeroException ex)
                {
                    MessageBox.Show(ex.Message, "Помилка");
                }
            }
            else
            {
                MessageBox.Show("Спершу введіть дані через форму 'Ввести дані'.", "Помилка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox3.Text, out double x) &&
            double.TryParse(textBox6.Text, out double y) &&
            double.TryParse(textBox7.Text, out double z) && x >= 0 && y > 0 && z > 0)
            {
                double sum = 0;
                for (int i = 0; i <= x * y * z; i++)
                {
                    if (i != z) // уникаємо ділення на нуль
                    {
                        sum += (i + x + y + z + 2) / (i - z);
                    }
                }

                showResult resultForm = new showResult();
                resultForm.SetData($"Введені дані: x={x:F2}, y={y:F2}, z={z:F2}", $"Результат: {sum:F2}");
                resultForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введіть коректні значення x, y та z!", "Помилка");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            writeNumber writeForm = new writeNumber();
            if (writeForm.ShowDialog() == DialogResult.OK)
            {
                if (double.TryParse(writeForm.InputValueX, out double x) &&
                    double.TryParse(writeForm.InputValueY, out double y) &&
                    double.TryParse(writeForm.InputValueZ, out double z) && x >= 0 && y > 0 && z > 0)
                {
                    sideLengthSeparateForms = x;
                    sideLengthSeparateFormsY = y;
                    sideLengthSeparateFormsZ = z;
                    MessageBox.Show($"Дані успішно введено: x={x}, y={y}, z={z}", "Успіх");
                }
                else
                {
                    MessageBox.Show("Введено некоректні значення. Повторіть спробу.", "Помилка");
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (sideLengthSeparateForms.HasValue)
            {
                double x = sideLengthSeparateForms.Value;
                double y = sideLengthSeparateFormsY.Value;
                double z = sideLengthSeparateFormsZ.Value;
                double sum = 0;

                for (int i = 0; i <= x * y * z; i++)
                {
                    if (i != z)
                    {
                        sum += (i + x + y + z + 2) / (i - z);
                    }
                }

                showResult resultForm = new showResult();
                resultForm.SetData($"Введені дані: x={x:F2}, y={y:F2}, z={z:F2}", $"Результат: {sum:F2}");
                resultForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Спершу введіть дані через форму 'Ввести дані'.", "Помилка");
            }
        }
    }
}
