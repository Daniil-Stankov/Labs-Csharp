using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_3
{
    public partial class showResult : Form
    {
        public showResult()
        {
            InitializeComponent();
        }
        public void SetData(string inputData, string resultData)
        {
            label4.Text = inputData;
            label3.Text = resultData;
        }
    }
}
