﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class writeNumber : Form
    {
        public string InputValue { get; private set; }

        public writeNumber()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InputValue = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
