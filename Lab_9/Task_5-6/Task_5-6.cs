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
        public Form1()
        {
            InitializeComponent();
        }

        private const double BaseApartmentPriceUah = 136530.94; 
        private const double BaseApartmentPriceEur = 3125.0;    
        private const double PanoramaPrice = 50.0;             
        private const double FurniturePrice = 100.0;           
        private const double BeddingPrice = 30.0;              
        private const double AppliancesPrice = 70.0;           
        private const double DiscountRate = 0.1;               
        private const double ExchangeRate = 43.7; // Курс гривні до євро (1 € = 43.7 грн)

        private void button1_Click(object sender, EventArgs e)
        {
            double additionalPrice = CalculateAdditionalPrice();
            double discount = additionalPrice * DiscountRate; 
            double finalPrice = BaseApartmentPriceUah + additionalPrice - discount;

            label2.Text = $"Ціна у вибраній комплектації: {BaseApartmentPriceUah + additionalPrice:F2} грн";
            label3.Text = $"Ціна обладнання: {additionalPrice:F2} грн";
            label4.Text = $"Знижка на обладнання (10%): {discount:F2} грн";
            label5.Text = $"Разом: {finalPrice:F2} грн";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double additionalPriceEur = CalculateAdditionalPrice() / ExchangeRate;
            double discountEur = (CalculateAdditionalPrice() * DiscountRate) / ExchangeRate;
            double finalPriceEur = BaseApartmentPriceEur + additionalPriceEur - discountEur;

            label9.Text = $"Ціна у вибраній комплектації: {BaseApartmentPriceEur + additionalPriceEur:F2} €";
            label8.Text = $"Ціна обладнання: {additionalPriceEur:F2} €";
            label7.Text = $"Знижка на обладнання (10%): {discountEur:F2} €";
            label6.Text = $"Разом: {finalPriceEur:F2} €";
        }

        private double CalculateAdditionalPrice()
        {
            double additionalPrice = 0.0;

            if (checkBox1.Checked)
                additionalPrice += PanoramaPrice;
            if (checkBox2.Checked)
                additionalPrice += FurniturePrice;
            if (checkBox3.Checked)
                additionalPrice += BeddingPrice;
            if (checkBox4.Checked)
                additionalPrice += AppliancesPrice;

            return additionalPrice;
        }
    }
}
