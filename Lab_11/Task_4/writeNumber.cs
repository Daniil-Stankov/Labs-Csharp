using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Task_3
{
    public partial class writeNumber : Form
    {
        public string InputValueX { get; private set; }
        public string InputValueY { get; private set; }
        public string InputValueZ { get; private set; }
        public string InputValue { get; private set; }

        public writeNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputValueX = textBox1.Text; // Отримати значення з поля X
            InputValueY = textBox2.Text; // Отримати значення з поля Y
            InputValueZ = textBox3.Text; // Отримати значення з поля Z
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
