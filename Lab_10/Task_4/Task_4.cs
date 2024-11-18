using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class Task_4 : Form
    {
        public Task_4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double loanAmount) &&
                int.TryParse(textBox2.Text, out int termMonths) &&
                double.TryParse(textBox3.Text, out double annualInterestRate))
            {
                listView1.Items.Clear();

                // Щомісячна процентна ставка
                double monthlyInterestRate = annualInterestRate / 12 / 100;

                // Розрахунок щомісячного платежу (аннуїтетний платіж)
                double monthlyPayment = loanAmount *
                                        (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, termMonths)) /
                                        (Math.Pow(1 + monthlyInterestRate, termMonths) - 1);

                double remainingLoan = loanAmount;

                // Формування графіку виплат
                for (int month = 1; month <= termMonths; month++)
                {
                    // Відсотки за поточний місяць
                    double interest = remainingLoan * monthlyInterestRate;

                    // Основний борг
                    double principal = monthlyPayment - interest;

                    // Додавання рядка в ListView
                    ListViewItem item = new ListViewItem(month.ToString());
                    item.SubItems.Add(remainingLoan.ToString("F2")); // Залишок боргу
                    item.SubItems.Add(interest.ToString("F2"));      // Відсотки
                    item.SubItems.Add(monthlyPayment.ToString("F2")); // Платіж
                    listView1.Items.Add(item);

                    // Оновлення залишку боргу
                    remainingLoan -= principal;
                }
            }
            else
            {
                MessageBox.Show("Перевірте введені дані!", "Помилка");
            }
        }

    }
}
