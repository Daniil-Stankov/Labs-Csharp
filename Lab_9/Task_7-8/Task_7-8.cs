using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const double BaseApartmentPriceUah = 136530.94; 
        private const double BaseApartmentPriceEur = 3125.0;    
        private const double RoomPrice = 500.0;                
        private const double FloorPrice = 1000.0;              
        private const double BalconyPrice = 200.0;             
        private const double DiscountRate = 0.1;               
        private const double ExchangeRate = 43.7;              

        private double CalculateAdditionalPrice()
        {

            int quantity = int.Parse(textBox1.Text);
            double additionalPrice = 0.0;

            if (radioButton1.Checked)
                additionalPrice = RoomPrice * quantity;
            else if (radioButton2.Checked)
                additionalPrice = FloorPrice * quantity;
            else if (radioButton3.Checked)
                additionalPrice = BalconyPrice * quantity;

            return additionalPrice;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double additionalPrice = CalculateAdditionalPrice();
            double totalPrice = CalculatePriceInUah(additionalPrice);
            label2.Text = $"Ціна у вибраній комплектації: {BaseApartmentPriceUah:F2} грн\n";
            label3.Text = $"Ціна додатків: {additionalPrice:F2} грн\n";
            label4.Text = $"Знижка на додатки (10%): {DiscountRate * additionalPrice:F2} грн\n";
            label5.Text = $"Разом: {totalPrice:F2} грн";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double additionalPrice = CalculateAdditionalPrice() / ExchangeRate; // Переводимо в євро
            double totalPrice = CalculatePriceInEur(additionalPrice);
            label9.Text = $"Ціна у вибраній комплектації: {BaseApartmentPriceEur:F2} євро\n";
            label8.Text = $"Ціна додатків: {additionalPrice:F2} євро\n";
            label7.Text = $"Знижка на додатки (10%): {DiscountRate * additionalPrice:F2} євро\n";
            label6.Text = $"Разом: {totalPrice:F2} євро";
        }

        private double CalculatePriceInUah(double additionalPrice)
        {
            double discount = additionalPrice * DiscountRate; // Розрахунок знижки
            return BaseApartmentPriceUah + additionalPrice - discount; // Загальна ціна
        }

        private double CalculatePriceInEur(double additionalPrice)
        {
            double discount = additionalPrice * DiscountRate; // Розрахунок знижки
            return BaseApartmentPriceEur + additionalPrice - discount; // Загальна ціна
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Введіть лише цифри від 1 до 3", "Помилка");
            }
            else
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }

            if (char.IsDigit(e.KeyChar))
            {
                int enteredValue = int.Parse(textBox1.Text + e.KeyChar);
                if (enteredValue < 1 || enteredValue > 3)
                {
                    e.Handled = true;
                    MessageBox.Show("Дозволені значення: 1, 2, 3", "Помилка");
                }
            }
        }
    }
}
