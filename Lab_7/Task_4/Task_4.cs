using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_4
{
    public partial class Task_4 : Form
    {
        public Task_4()
        {
            InitializeComponent();


        }

        private void label_DoubleClick(object sender, EventArgs e)
        {
            Label label = sender as Label;

            if (label != null)
            {
                if (label.Font.Italic)
                {
                    label.Font = new Font(label.Font, FontStyle.Regular);
                }
                else
                {
                    label.Font = new Font(label.Font, FontStyle.Italic);
                }
            }
        }

    }
}
