using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace testas
{
    
    public partial class Form2 : Form
    {
        public static string text;
       
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            text = textBox1.Text;
            
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            text = textBox1.Text;
        }
    }
}
