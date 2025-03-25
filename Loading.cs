using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Dictionary
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        int count = 0;// đếm số lần tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left += 80;
            pictureBox2.Left -= 80;
            count++;
            if (count >= 5) 
            {
                timer1.Stop();
                this.Close();
            }
        }

        private void Loading_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (count < 5)
            {
                Application.Exit();
            }
        }

        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    timer2.Stop();
        //    MainFrm form1 = new MainFrm();
        //    form1.FormClosed += (s, args) => this.Close(); // Khi đóng Form1, đóng luôn Loading
        //    form1.Show();
        //    this.Hide();
        //}
    }
}
