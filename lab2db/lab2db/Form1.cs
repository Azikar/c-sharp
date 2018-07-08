using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2db
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Closee()
        {
           // Form1[] child = Form1.FromChildHandle.MdiChildren
          //  foreach(Form childform in child)
          //  {
          //      childform.Close();
           // }
        }

        private void miestaiToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           // Closee();
          
            var myForm = new Miestai();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
            
        }

        private void gamintojaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new Gamintojai();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void kategorijosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new Kategorija();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void davikliaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new davikliai();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void parduotuveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new parduotuve();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }

        private void saskaitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var myForm = new saskaita();
            myForm.MdiParent = this;
            myForm.WindowState = FormWindowState.Maximized;
            myForm.Show();
        }
    }
}
