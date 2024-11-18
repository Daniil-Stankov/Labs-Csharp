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

namespace Lab_10
{
    public partial class Task_2 : Form
    {
        private List<string> imageFiles = new List<string>(); // Список зображень
        private int currentIndex = 0; // Індекс поточного зображення
        private int slideInterval;

        public Task_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;
                    imageFiles = Directory.GetFiles(selectedPath, "*.jpg")
                        .Concat(Directory.GetFiles(selectedPath, "*.png"))
                        .Concat(Directory.GetFiles(selectedPath, "*.bmp"))
                        .ToList();

                    if (imageFiles.Count > 0)
                    {
                        currentIndex = 0;
                        ShowImage();
                    }
                    else
                    {
                        MessageBox.Show("У папці немає зображень!", "Помилка");
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (imageFiles.Count > 0)
            {
                currentIndex--;
                if (currentIndex < 0) currentIndex = imageFiles.Count - 1; // Переходимо в кінець
                ShowImage();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imageFiles.Count > 0)
            {
                currentIndex++;
                if (currentIndex >= imageFiles.Count) currentIndex = 0; // Повертаємось на початок
                ShowImage();
            }
        }

        private void ShowImage()
        {
            if (imageFiles != null && imageFiles.Count > 0 && currentIndex >= 0 && currentIndex < imageFiles.Count)
            {
                pictureBox1.Image = Image.FromFile(imageFiles[currentIndex]);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (imageFiles != null && imageFiles.Count > 0)
            {
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (imageFiles != null && imageFiles.Count > 0)
            {
                currentIndex = (currentIndex + 1) % imageFiles.Count;
                ShowImage();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                string speed = comboBox1.SelectedItem.ToString();
                switch (speed)
                {
                    case "x1":
                        slideInterval = 10000; // 10 секунда
                        break;
                    case "x2":
                        slideInterval = 5000;  // 5 секунди
                        break;
                    case "x3":
                        slideInterval = 3000;  // 3 секунди
                        break;
                }

                timer1.Interval = slideInterval;
            }
        }
    }
}
