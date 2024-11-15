using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Task_5
{
    public partial class Task_3 : Form
    {
        public Task_3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                checkBox1.Font = new Font(checkBox1.Font, FontStyle.Italic);
            if (checkBox2.Checked)
                checkBox2.Font = new Font(checkBox2.Font, FontStyle.Italic);
            if (checkBox3.Checked)
                checkBox3.Font = new Font(checkBox3.Font, FontStyle.Italic);
            if (checkBox4.Checked)
                checkBox4.Font = new Font(checkBox4.Font, FontStyle.Italic);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Скидаємо вибір checkBox
            checkBox1.Checked = false;
            checkBox2.Checked = true; // За замовчуванням
            checkBox3.Checked = true; // За замовчуванням
            checkBox4.Checked = false;

            Reset();
        }

        private void Reset()
        {
            checkBox1.Font = new Font(checkBox1.Font, FontStyle.Regular);
            checkBox2.Font = new Font(checkBox2.Font, FontStyle.Regular);
            checkBox3.Font = new Font(checkBox3.Font, FontStyle.Regular);
            checkBox4.Font = new Font(checkBox4.Font, FontStyle.Regular);
        }
    }
}
