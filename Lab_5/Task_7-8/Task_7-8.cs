using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_7_8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeTableLayoutPanel();
        }

        private void InitializeTableLayoutPanel()
        {
            // Створюємо TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.Dock = DockStyle.Fill;

            // Додаємо кнопки за вашою схемою
            Button button1 = new Button { Text = "but1" };
            Button button2 = new Button { Text = "but2" };
            Button button3 = new Button { Text = "but3" };
            Button button4 = new Button { Text = "but4" };
            Button button5 = new Button { Text = "but5" };

            // Розміщуємо кнопки на панелі відповідно до вашої схеми
            tableLayoutPanel.Controls.Add(button1, 0, 0); // but1 в (0,0)
            tableLayoutPanel.Controls.Add(button5, 0, 1); // but5 в (0,1)
            tableLayoutPanel.Controls.Add(button3, 1, 2); // but3 в (1,2)
            tableLayoutPanel.Controls.Add(button4, 2, 0); // but4 в (2,0)
            tableLayoutPanel.Controls.Add(button2, 2, 1); // but2 в (2,1)

            // Додаємо TableLayoutPanel на форму
            this.Controls.Add(tableLayoutPanel);
        }
    }
}
