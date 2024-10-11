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
            CreatePictureBox();
        }

        private void CreatePictureBox()
        {
            // Задаем размеры и положение PictureBox'ов
            PictureBox pictureBox1 = new PictureBox();
            pictureBox1.Size = new Size(210, 50);
            pictureBox1.Location = new Point(20, 60);  // Левое изображение

            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Size = new Size(50, 100);
            pictureBox2.Location = new Point(240, 10); // Центральное изображение

            PictureBox pictureBox3 = new PictureBox();
            pictureBox3.Size = new Size(200, 100);
            pictureBox3.Location = new Point(300, 10); // Правое изображение

            // Добавляем их на форму
            this.Controls.Add(pictureBox1);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox3);

            // Для примера можно загрузить изображения
            pictureBox1.Image = Image.FromFile("D:\\учеба\\DOtNet (3 курс)\\Repos\\Lab_5\\Task_5-6\\image1.jpg");
            pictureBox2.Image = Image.FromFile("D:\\учеба\\DOtNet (3 курс)\\Repos\\Lab_5\\Task_5-6\\image2.jpg");
            pictureBox3.Image = Image.FromFile("D:\\учеба\\DOtNet (3 курс)\\Repos\\Lab_5\\Task_5-6\\image3.jpg");

            // Настройка режима отображения изображения
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
