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

namespace lab2_
{
    public partial class Form1 : Form
    {
       
        private List<Zaidejai> Kaunas;
        private List<Zaidejai> Klaipeda;
        private List<Zaidejai> Kauno;
        private List<Zaidejai> Klaipedos;
        private List<Zaidejai> Iterpti;
        string kom1;
        string kom2;
        string kom;
        public Form1()
        {
            InitializeComponent();
           
        }

        private void atidarytiToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                
                string fv = openFileDialog1.FileName;
                Kaunas = skaityti(fv, out kom1);
            }
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult results = openFileDialog2.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                
                string fv = openFileDialog2.FileName;
                Klaipeda = skaityti(fv, out kom2);

            }
            OpenFileDialog openFileDialog3 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult resultat = openFileDialog3.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
               
                string fv = openFileDialog3.FileName;
                Iterpti = skaityti(fv, out kom);
            }
            skaiciavimasToolStripMenuItem.Enabled = true;
            
        }
      
        /// <summary>
        /// Is atskiro failo papildo tam tikra lista
        /// </summary>
        /// <param name="komand"></param>
        /// <param name="Iterp"></param>
        static void Papild(List<Zaidejai> komand, List<Zaidejai> Iterp, int m, int k)
        {
            int q = 0;
            for (int i = 0; i < Iterp.Count; i++)
            {
                q =0;
                if (Iterp[i].age < m && Iterp[i].kl > k&&Iterp[i].lav!="neaukst")
                {
                    for (int j = 0; j < komand.Count; j++)
                    {

                        if (Iterp[i] > komand[j])
                        {
                            komand.Insert(j, Iterp[i]);
                            q++;
                            break;
                        }
                    }
                    if (q == 0)
                        komand.Insert(komand.Count, Iterp[i]);
                }
            }
        }
        /// <summary>
        /// Isvedama i csv faila
        /// </summary>
        /// <param name="kom"></param>
        /// <param name="fv"></param>
        /// <param name="pav"></param>
        static void isvest(List<Zaidejai> kom, string fv, string pav)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {

                fr.WriteLine(pav);
                if (kom.Count == 0)
                {
                    fr.WriteLine("Nera");
                }

                else
                {
                    fr.WriteLine("vardas pavarde,         Lytis,   amzius,  issilavinimas,  zaidimu skaicius,  Klausymai,");
                    for (int i = 0; i < kom.Count; i++)
                    {
                        Zaidejai zaid = kom[i];
                        fr.WriteLine(zaid);
                    }
                }
                fr.WriteLine(" ");
            }
        }
        /// <summary>
        /// salina netinkamus kandidatus
        /// </summary>
        /// <param name="kom"></param>
        static void Salinti(List<Zaidejai> kom)
        {
            bool ne = false;
            for (int i = 0; i < kom.Count; i++)
            {
                if (ne == true)
                {
                    i--;
                }
                ne = false;
                if (kom[i].lav == "neaukst")
                {
                    kom.RemoveAt(i);
                    ne = true;
                }

            }


        }
        /// <summary>
        /// atrenka 
        /// </summary>
        /// <param name="kom"></param>
        /// <param name="m"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        static List<Zaidejai> atrinkti(List<Zaidejai> kom, int m, int k)
        {
            List<Zaidejai> info = new List<Zaidejai>();
            for (int i = 0; i < kom.Count; i++)
            {
                if (kom[i].age < m && kom[i].kl > k)
                    info.Add(kom[i]);
            }
            return info;

        }
        /// <summary>
        /// skaito
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="kom"></param>
        /// <returns></returns>
        static List<Zaidejai> skaityti(string fv, out string kom)
        {
            List<Zaidejai> info = new List<Zaidejai>();
            using (StreamReader srautas = new StreamReader(fv))
            {
                string eilute;
                kom = srautas.ReadLine();
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] dalis = eilute.Split(';');
                    string pavVard = dalis[0];
                    string lyt = dalis[1];
                    int age = int.Parse(dalis[2]);
                    string lav = dalis[3];
                    int zaid_sk = int.Parse(dalis[4]);
                    int kl = int.Parse(dalis[5]);
                    Zaidejai zaid = new Zaidejai(pavVard, lyt, age, lav, zaid_sk, kl);
                    info.Add(zaid);
                }

            }
            return info;
        }

        //######################PATAISYTA###################################
        /// <summary>
        /// randa kuriame sarase yra daugiausiai su aukstuoju issilavinimu
        /// </summary>
        /// <param name="pirm"></param>
        /// <param name="antr"></param>
        /// <param name="daug"></param>
        static void Rasti(List<Zaidejai> pirm, List<Zaidejai> antr, out string daug)
        {
            daug = "Lygu";
            int kiek1 =kuris(pirm);
            int kiek2 =kuris(antr);
            if ( kiek1> kiek2)
                daug = "Kaunas";
            if (kiek1 < kiek2)
                daug = "Klaipeda";

        }
        static int kuris(List<Zaidejai> kom)
        {
            int kiekis=0;
            for (int i = 0; i < kom.Count; i++)
                if (kom[i].lav == "aukst")
                    kiekis++;
            return kiekis;
        }

        //#######################################################################
        /// <summary>
        /// spausdina i txt faila
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="info"></param>
        /// <param name="antr"></param>
        /// <param name="kom"></param>
        static void spaust(string fv, List<Zaidejai> info, string antr, string kom)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                if (info.Count == 0)
                {
                    fr.WriteLine(antr);
                    fr.WriteLine(kom);
                    fr.WriteLine("Nera");
                }
                else
                {
                    fr.WriteLine(antr);
                    fr.WriteLine(kom);
                    fr.WriteLine("vardas pavarde         Lytis   amzius  issilavinimas  zaidimu skaicius  Klausymai");
                    fr.WriteLine("____________________________________________________________________________________");
                    for (int i = 0; i < info.Count; i++)
                    {
                        Zaidejai zaid = info[i];
                        fr.WriteLine(zaid);
                    }
                }
                fr.WriteLine(" ");
            }
        }


        // BAIGTI
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// praso nurodyti kur saugoti csv faila
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kurSaugotiTxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string fv = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                if (File.Exists(fv))
                    File.Delete(fv);
                isvest(Kauno, fv, kom1);
                isvest(Klaipedos, fv, kom2);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

            int m = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            string daug;
            Rasti(Kaunas, Klaipeda, out daug);
            label3.Text = "Daugiausiai su aukstuoju yra " + daug;
            label3.Visible = true;
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
                // jeigu pasirinktas failas
                
            {
                string rez = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                if (File.Exists(rez))
                    File.Delete(rez);
                Kauno = atrinkti(Kaunas, m, k);
                Klaipedos = atrinkti(Klaipeda, m, k);

                string antr = "Atrinkti";
                spaust(rez, Kauno, antr, kom1);
                spaust(rez, Klaipedos, antr, kom2);
                spausdinti(daug,rez);
                rezultatai.LoadFile(rez, RichTextBoxStreamType.PlainText);
            }
            kurSaugotiTxtToolStripMenuItem.Enabled = true;

        }
        public void spausdinti(string daug,string fv)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                fr.WriteLine(" Daugiausiai su aukstuoju yra"+daug);
            }

    
        }

        private void rikiuotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            string daug;
            Rasti(Kaunas, Klaipeda, out daug);
            

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            // jeigu pasirinktas failas
            {
                string rez = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                

                Kauno.Sort();
                Klaipedos.Sort();
                Iterpti.Sort();
                string antr = "surikiuota";
                spaust(rez, Kauno, antr, kom1);
                spaust(rez, Klaipedos, antr, kom2);
                rezultatai.LoadFile(rez, RichTextBoxStreamType.PlainText);
            }
        }

        private void salintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            string daug;
            Rasti(Kaunas, Klaipeda, out daug);
            

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            // jeigu pasirinktas failas
            {
                string rez = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                
                Salinti(Kauno);
                Salinti(Klaipedos);

                string antr = "pasalinta";
                spaust(rez, Kauno, antr, kom1);
                spaust(rez, Klaipedos, antr, kom2);
                rezultatai.LoadFile(rez, RichTextBoxStreamType.PlainText);
            }
        }

        private void papildytiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int m = int.Parse(textBox1.Text);
            int k = int.Parse(textBox2.Text);
            string daug;
            Rasti(Kaunas, Klaipeda, out daug);
           

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // jeigu pasirinktas failas
            {
                string rez = saveFileDialog1.FileName;
                // Jeigu reikia rezultatų failas išvalomas
                

                if (kom == kom1)
                    Papild(Kauno, Iterpti,m,k);
                if (kom == kom2)
                    Papild(Klaipedos, Iterpti,m,k);


              string  antr = "Iterpta";

                spaust(rez, Kauno, antr, kom1);
                spaust(rez, Klaipedos, antr, kom2);
                rezultatai.LoadFile(rez, RichTextBoxStreamType.PlainText);
            }
        }
    }
}
