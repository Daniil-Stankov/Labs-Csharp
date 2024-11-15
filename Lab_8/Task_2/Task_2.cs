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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Task_4
{
    public partial class Task_2 : Form
    {
        public Task_2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Скидаємо вибір RadioButton
            radioButton1.Checked = false;
            radioButton2.Checked = true; // За замовчуванням
            radioButton3.Checked = false;

            radioButton4.Checked = false;
            radioButton5.Checked = true; // За замовчуванням
            radioButton6.Checked = false;
            radioButton7.Checked = false;

            Reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton1.Font = new Font(radioButton1.Font, FontStyle.Italic);
            if (radioButton2.Checked)
                radioButton2.Font = new Font(radioButton2.Font, FontStyle.Italic);
            if (radioButton3.Checked)
                radioButton3.Font = new Font(radioButton3.Font, FontStyle.Italic);
            if (radioButton4.Checked)
                radioButton4.Font = new Font(radioButton4.Font, FontStyle.Italic);
            if (radioButton5.Checked)
                radioButton5.Font = new Font(radioButton5.Font, FontStyle.Italic);
            if (radioButton6.Checked)
                radioButton6.Font = new Font(radioButton6.Font, FontStyle.Italic);
            if (radioButton7.Checked)
                radioButton7.Font = new Font(radioButton7.Font, FontStyle.Italic);
        }

        private void Reset()
        {
            radioButton1.Font = new Font(radioButton1.Font, FontStyle.Regular);
            radioButton2.Font = new Font(radioButton2.Font, FontStyle.Regular);
            radioButton3.Font = new Font(radioButton3.Font, FontStyle.Regular);
            radioButton4.Font = new Font(radioButton4.Font, FontStyle.Regular);
            radioButton5.Font = new Font(radioButton5.Font, FontStyle.Regular);
            radioButton6.Font = new Font(radioButton6.Font, FontStyle.Regular);
            radioButton7.Font = new Font(radioButton7.Font, FontStyle.Regular);
        }
    }
}
