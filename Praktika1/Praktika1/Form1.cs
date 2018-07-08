using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Praktika1
{
    public partial class Form1 : Form
    {
        int a, b;
       // double c;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // c = a * b;
            label3.Text = "Plotas: " + Convert.ToString(Plotas(a,b));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox1.Text);
            b = Convert.ToInt32(textBox2.Text);
            button2.Enabled=true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        static int Plotas(int ilg,int plot)
        {
            return ilg * plot;
        }
    }
}
