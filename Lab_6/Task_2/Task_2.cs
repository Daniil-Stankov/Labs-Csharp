using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Task_2 : Form
    {
        private ComboBox comboBox1;
        private ListBox listBox1;

        public Task_2()
        {
            InitializeComponent();
            CreateControls();
            this.Load += new EventHandler(Task_2_Load);
        }

        private void CreateControls()
        {
            // Створення ComboBox
            comboBox1 = new ComboBox();
            comboBox1.Location = new System.Drawing.Point(50, 50);
            comboBox1.Size = new System.Drawing.Size(150, 30);
            this.Controls.Add(comboBox1);

            // Створення ListBox
            listBox1 = new ListBox();
            listBox1.Location = new System.Drawing.Point(50, 100);
            listBox1.Size = new System.Drawing.Size(150, 80);
            this.Controls.Add(listBox1);
        }

        private void Task_2_Load(object sender, EventArgs e)
        {
            // Додавання країн у ComboBox програмним шляхом
            comboBox1.Items.AddRange(new string[] { "Mangalore", "Gaya"});

            // Додавання міст у ListBox програмним шляхом
            listBox1.Items.AddRange(new string[] { "Mumbai", "Delhi", "Jammu"});
        }
    }
}
