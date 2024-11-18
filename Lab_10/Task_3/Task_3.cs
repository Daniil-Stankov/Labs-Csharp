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

namespace Task_3
{
    public partial class Task_3 : Form
    {
        private List<string> imageFiles;

        public Task_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку с изображениями";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = dialog.SelectedPath;
                    label1.Text = selectedPath; // Отображение выбранного пути в label1

                    // Получение списка файлов с изображениями
                    imageFiles = Directory.GetFiles(selectedPath, "*.jpg")
                        .Concat(Directory.GetFiles(selectedPath, "*.png"))
                        .Concat(Directory.GetFiles(selectedPath, "*.bmp"))
                        .ToList();

                    // Заполнение ListBox с названиями файлов
                    listBox1.Items.Clear();
                    foreach (var file in imageFiles)
                    {
                        string fileName = Path.GetFileName(file);
                        listBox1.Items.Add(fileName);
                    }

                    if (imageFiles.Count == 0)
                    {
                        MessageBox.Show("В выбранной папке нет изображений!", "Ошибка");
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0 && imageFiles != null && imageFiles.Count > 0)
            {
                string selectedFile = imageFiles[listBox1.SelectedIndex];
                pictureBox1.Image = Image.FromFile(selectedFile);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
    }
}
