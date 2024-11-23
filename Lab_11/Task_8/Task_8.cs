using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Task_8
{
    public partial class Task_8 : Form
    {
        public Task_8()
        {
            InitializeComponent();
        }

        private void newFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви хочете зберегти зміни?", "Підтвердити", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                saveFileToolStripMenuItem_Click(sender, e); // Виклик функції збереження
            }
            richTextBox1.Clear(); // Очищення текстового поля
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Зберегти файл"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text); // Збереження тексту у файл
            }
        }

        // Завантаження файлу
        private void loadFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                Title = "Відкрити файл"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFileDialog.FileName); // Завантаження тексту з файлу
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Текстовий редактор\nРозробник: Станков Д.М.", "Про програму", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var words = richTextBox1.Text.Split(' ');
            var invertedWords = words.Select(word => new string(word.Reverse().ToArray()));
            richTextBox1.Text = string.Join(" ", invertedWords);
        }
    }
}
