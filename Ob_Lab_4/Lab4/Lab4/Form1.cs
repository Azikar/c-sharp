using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Lab4
{
    public partial class Form1 : Form
    {
        const string Kaun = "..\\..\\Kaunas.txt";
        const string Kl = "..\\..\\Klaipeda.txt";
        const string rez = "..\\..\\Rezultatai.txt";
        const string pag = "..\\..\\Help.txt";
        Komandos Klaipeda;
        Komandos Kaunas;
        Komandos kauno;
        Komandos klaipedos;
        int m, k;
        int index = 0;
        string kom1;//Klaipedos
        string kom2;//Kauno
        string daug="Lygu";
        public Form1()
        {
            InitializeComponent();

            if (File.Exists(rez))
                File.Delete(rez);
        }

        private void ikeltiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            //string kom1;//Klaipedos
            //string kom2;//Kauno
            //string daug;
            string ant1 = "Kaunas pradiniai duomenys";
            string ant2 = "Klaipeda pradiniai duomenys";
            m = int.Parse(textBox1.Text);
            k = int.Parse(textBox2.Text);

            Klaipeda = SkaitytiKom(Kl, out kom1,index);
            Kaunas = SkaitytiKom(Kaun, out kom2, index);
           // Klaipeda.Pradzia();
           // Kaunas.Pradzia();
            Spausdinti(ant1, Kaunas,rez);
            Spausdinti(ant2, Klaipeda,rez);
            richTextBox1.LoadFile(rez, RichTextBoxStreamType.PlainText);
            index++;
        }

        static Komandos SkaitytiKom(string fv, out string kom,int index)
        {
            Komandos Komand = new Komandos();

            using (StreamReader duom = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute = duom.ReadLine();
                kom = eilute;
                while ((eilute = duom.ReadLine()) != null)
                {
                    string[] part = eilute.Split(';');
                    string pavVard = part[0];
                    string lyt = part[1];
                    int age = int.Parse(part[2]);
                    string lav = part[3];
                    int zaid_sk = int.Parse(part[4]);
                    int kl = int.Parse(part[5]);
                    Zaidejas zaid = new Zaidejas(pavVard, lyt, age, lav, zaid_sk, kl);
                    if(index==0)
                    Komand.DetiB(zaid);
                    if(index==1)
                    Komand.DetiA(zaid);

                }
            }
            return Komand;
        }
        static string Daugiausia(Komandos Klaipeda,Komandos Kaunas)
        {
            
            int KL_daug = rasti(Klaipeda);
            int KA_daug = rasti(Kaunas);
            if (KL_daug > KA_daug)
                return "Klaipeda";
            if (KL_daug < KA_daug)
                return "Kaunas";
            else
                return "Lygu";
        }

        private void daugiausiaSuAukstToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //daug = "Lygu";
            daug = Daugiausia( Klaipeda, Kaunas);
            using (var fv =File.AppendText(rez))
            {
                fv.WriteLine("Daugiausia su aukstuoju yra: {0}",daug);
            }
            richTextBox1.LoadFile(rez, RichTextBoxStreamType.PlainText);
        }

        static int rasti(Komandos kom)
        {
            int daug = 0;
            for (kom.Pradzia(); kom.Yra(); kom.Kitas())
            {
                if (kom.imti().lav == "aukst")
                    daug++;
            }
            return daug;
        }

        private void atrinktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kauno = atrinkt(Kaunas,m,k);
            klaipedos = atrinkt(Klaipeda,m,k);
            string ant1 = "Atrinkta Kauno komanda";
            string ant2 = "Atrinkta Klaipedos komanda";
            Spausdinti(ant1, kauno, rez);
            klaipedos.Pradzia();
          //  klaipedos.Salinti();
            Spausdinti(ant2, klaipedos, rez);
            richTextBox1.LoadFile(rez, RichTextBoxStreamType.PlainText);

        }
        static Komandos atrinkt (Komandos kom,int m,int k)
        {
            Komandos komand = new Komandos();
            for(kom.Pradzia();kom.Yra();kom.Kitas())
            if(kom.imti().age<=m&&kom.imti().kl>k)
                {
                    komand.DetiB(kom.imti());
                }
            return komand;
        }

        private void rikiuotToolStripMenuItem_Click(object sender, EventArgs e)
        {

            kauno.Pradzia();
            klaipedos.Pradzia();
            if(kauno.Yra())
            kauno.Rikiuoti();
            if(klaipedos.Yra())
            klaipedos.Rikiuoti();
            string ant1 = "surikiuota Kauno komanda";
            string ant2 = "surikiuota Klaipedos komanda";
            Spausdinti(ant1, kauno, rez);
            //klaipedos.Pradzia();
            //klaipedos.Salinti();
            Spausdinti(ant2, klaipedos, rez);
            richTextBox1.LoadFile(rez, RichTextBoxStreamType.PlainText);
        }

        private void salintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //kauno.Salinti();
            // klaipedos.Salinti();
            salinti(kauno);
            salinti(klaipedos);
            string ant1 = "pasalinta Kauno komanda";
            string ant2 = "Pasalinta Klaipedos komanda";
            Spausdinti(ant1, kauno, rez);
            //klaipedos.Pradzia();
            //klaipedos.Salinti();
            Spausdinti(ant2, klaipedos, rez);
            richTextBox1.LoadFile(rez, RichTextBoxStreamType.PlainText);
        }

        static void Spausdinti(string antr,Komandos kom,string rez)
        {
            using (var fv = File.AppendText(rez))
            {
                fv.WriteLine(antr);
                kom.Pradzia();
                if (kom.Yra())
                {
                    fv.WriteLine("vardas  pavarde       Lytis   amzius   issilavinimas   zaidimu skaicius    Klausymai");
                    fv.WriteLine("____________________________________________________________________________________");

                    for (kom.Pradzia(); kom.Yra(); kom.Kitas())
                        fv.WriteLine(kom.imti().ToString());
                }
                else
                    fv.WriteLine("Nera");
                fv.WriteLine(" ");
                


            }
        }

        private void baidtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.LoadFile(pag, RichTextBoxStreamType.PlainText);
        }

        static void salinti(Komandos A)
        {
            for (A.Pradzia(); A.Yra(); A.Kitas())
            {
                Zaidejas zaid = A.imti();
                if (zaid.lav != "aukst")
                {
                    A.Naikint(zaid);
                    salinti(A);
                    break;

                }
            }
        }
        //static void SkaitytiAtv(string fv,out Mazgas pr)
        //{
        //    using (var failas = new StreamReader(fv))
        //    {
                
        //        pr = null;
        //        string eilute = duom.ReadLine();
        //        kom = eilute;
        //        while ((eilute = duom.ReadLine()) != null)
        //        {
        //            string[] part = eilute.Split(';');
        //            string pavVard = part[0];
        //            string lyt = part[1];
        //            int age = int.Parse(part[2]);
        //            string lav = part[3];
        //            int zaid_sk = int.Parse(part[4]);
        //            int kl = int.Parse(part[5]);
        //            Zaidejas zaid = new Zaidejas(pavVard, lyt, age, lav, zaid_sk, kl);
        //            Komand.DetiB(zaid);
        //        }

        //    }
        //    }
        //}
    }
}
