using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_5
{
    public partial class CityInfoForm : Form
    {
        public CityInfoForm(string cityName)
        {
            InitializeComponent();
            switch (cityName)
            {
                case "Делі":
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Properties.Resources.DelhiImage));
                    label1.Text = "Делі – столиця Індії, відома своїми історичними пам'ятками.";
                    break;

                case "Мумбаї":
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Properties.Resources.MumbaiImage));
                    label1.Text = "Мумбаї – фінансова столиця Індії.";
                    break;

                case "Ченнаї":
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Properties.Resources.ChennaiImage));
                    label1.Text = "Ченнаї – центр культури та мистецтва півдня Індії.";
                    break;

                case "Бангалор":
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Properties.Resources.BangaloreImage));
                    label1.Text = "Бангалор – відомий як Індійська Кремнієва долина.";
                    break;

                case "Джайпур":
                    pictureBox1.Image = Image.FromStream(new MemoryStream(Properties.Resources.JaipurImage));
                    label1.Text = "Джайпур – рожеве місто Індії, популярне серед туристів.";
                    break;

                default:
                    label1.Text = "Інформація про місто недоступна.";
                    break;
            }
        }
    }
}
