using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_8
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private Timer timer;

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 3000; // Час показу заставки (в мілісекундах)
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Dispose();

            // Переходимо до основної форми
            var mainForm = new Login();
            mainForm.Show();
            this.Hide();
        }
    }
}
