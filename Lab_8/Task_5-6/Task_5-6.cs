﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7
{
    public partial class Task_5 : Form
    {
        public Task_5()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                // Виводимо назву пункту в MessageBox
                MessageBox.Show($"Вибрано пункт меню: {menuItem.Text}", "Обробка меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
