﻿using System;
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
            pictureBox1.Location = new Point(20, 60);  // Ліве зображення

            PictureBox pictureBox2 = new PictureBox();
            pictureBox2.Size = new Size(50, 100);
            pictureBox2.Location = new Point(240, 10); // Центральне зображення

            PictureBox pictureBox3 = new PictureBox();
            pictureBox3.Size = new Size(150, 50);
            pictureBox3.Location = new Point(300, 60); // Праве зображення

            this.Controls.Add(pictureBox1);
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox3);
 
            pictureBox1.Image = Image.FromFile("..\\..\\Resources\\image1.jpg");
            pictureBox2.Image = Image.FromFile("..\\..\\Resources\\image2.jpg");
            pictureBox3.Image = Image.FromFile("..\\..\\Resources\\image3.jpg");

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
