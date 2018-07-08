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
namespace U1_12.Žaidimas
{
    public partial class Form1 : Form
    {
        const string Kaun = "..\\..\\Kaunas.txt";
        const string Kl = "..\\..\\Klaipeda.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        Komandos Klaipeda;
        Komandos Kaunas;
        Komandos kauno;
        Komandos klaipedos;
        int m, k;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists(CFr))
                File.Delete(CFr);
          //  string kom1;
          //  string kom2;
        }

        private void Vykdyti_Click(object sender, EventArgs e)
        {
            Vykdyti.Enabled = false;
            string kom1;
            string kom2;
            string daug;
            string ant1 = "Kaunas pradiniai duomenys";
            string ant2 = "Klaipeda pradiniai duomenys";
            m = int.Parse(textBox1.Text);
            k = int.Parse(textBox2.Text);

            Klaipeda = SkaitytiKom(Kl,out kom1);
            Kaunas= SkaitytiKom(Kaun, out kom2);
            
            Spausdinti(CFr, Kaunas ,ant1);
            Spausdinti(CFr, Klaipeda,ant2);

            Rasti(Klaipeda, Kaunas,out daug);

            kauno=komN(Kaunas,m,k);
            klaipedos=komN(Klaipeda, m, k);

            kauno.Rikiuoti();
            klaipedos.Rikiuoti();
            Spausdinti(CFr, kauno, kom2+ " surikiuota abc");
            Spausdinti(CFr, klaipedos, kom1 + " surikiuota abc");
            kauno.Salinti();
            klaipedos.Salinti();
            spaust(CFr, daug);
            Spausdinti(CFr,kauno,kom2+" Pasalinta");
            Spausdinti(CFr, klaipedos,kom1 + " Pasalinta");
            rez.LoadFile(CFr, RichTextBoxStreamType.PlainText);
        }
        /// <summary>
        /// skaito is failu ir deda i konteineri
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="kom"></param>
        /// <returns></returns>
        static Komandos SkaitytiKom(string fv, out string kom)
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
                    Komand.DetiZaideja(zaid);
                }
            }
            return Komand;
        }
        /// <summary>
        /// spausdina pirma rezultata
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="daug"></param>
        static void spaust(string fr, string daug)
        {
            using (var fv = new StreamWriter(File.Open(fr, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fv.WriteLine(" ");
                fv.WriteLine("daugiausiai turinciu aukstaji issilavinima yra {0} mieste", daug);

                }
            }
        /// <summary>
        /// spausdina pradinius doum ir rezultatu lenteles
        /// </summary>
        /// <param name="fr"></param>
        /// <param name="Komand"></param>
        /// <param name="name"></param>
        static void Spausdinti(string fr,Komandos Komand,string name)
        {
            using (var fv = new StreamWriter(File.Open(fr, FileMode.Append), Encoding.GetEncoding(1257)))
            {
                if (Komand.Kiek != 0)
                {
                    fv.WriteLine(" ");
                    fv.WriteLine(name);
                    fv.WriteLine("vardas  pavarde       Lytis   amzius   issilavinimas   zaidimu skaicius    Klausymai");
                    fv.WriteLine("____________________________________________________________________________________");
                    for (int i = 0; i < Komand.Kiek; i++)
                    {
                        Zaidejas zaid = Komand.ImtiZaideja(i);
                        fv.WriteLine(zaid);

                    }
                }
                else
                {
                    fv.WriteLine(" ");
                    fv.WriteLine(name);
                    fv.WriteLine(" Nera");
                }
            }
        }/// <summary>
        /// randa kuriam mieste yra daukiausiai aukstaji issilavinima turinciu kandidatu
        /// </summary>
        /// <param name="kom1"></param>
        /// <param name="kom2"></param>
        /// <param name="daug"></param>
        static void Rasti(Komandos kom1,Komandos kom2 ,out string daug)
        {
            daug = " Lygu ";
            int kiek=0;
            int kiek2=0;
            for (int i = 0; i < kom1.Kiek; i++)
            if(kom1.ImtiZaideja(i).lav=="aukst")
            {
                    kiek++;
            }
            for (int i = 0; i < kom2.Kiek; i++)
                if (kom2.ImtiZaideja(i).lav == "aukst")
                {
                    kiek2++;
                }
            if (kiek > kiek2)
                daug = "Klaipeda";
            if (kiek < kiek2)
                daug = "Kaunas";
            //else
               // daug = "abu lygu";
        }

        private void Baigti_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// sudaro komandas
        /// </summary>
        /// <param name="miest"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static Komandos komN(Komandos miest,int m,int k)
        {
            Komandos kom = new Komandos();
            for(int i=0;i<miest.Kiek;i++)
                if(miest.ImtiZaideja(i).age<m && miest.ImtiZaideja(i).kl>k)
                {

                    kom.DetiZaideja(miest.ImtiZaideja(i));
                }
            return kom;
        }
    }
}
