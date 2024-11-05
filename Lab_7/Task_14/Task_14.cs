using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_14
{
    public partial class Task_14 : Form
    {
        public Task_14()
        {
            InitializeComponent();
        }

        private void Task_14_Load(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Завантажити форму проекту?", "Запит", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                this.Close();
            }
            else
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Height = Screen.PrimaryScreen.WorkingArea.Height / 2;
                this.Width = Screen.PrimaryScreen.WorkingArea.Width;
                this.Location = new System.Drawing.Point(0, Screen.PrimaryScreen.WorkingArea.Height / 2);
            }
        }
    }
}
