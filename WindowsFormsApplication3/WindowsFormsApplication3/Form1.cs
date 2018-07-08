using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //string date = dateTimePicker1.Value.ToString();
            // label2.Text = date;
            timer1.Start();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            string date = dateTimePicker3.Value.ToString();
            label2.Text = date;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString();
            dateTimePicker3.Update();
        }
    }
}
