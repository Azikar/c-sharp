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
namespace Lab3
{
    public partial class Form1 : Form
    {
        private List<Herojei> HerojuList;
        private List<Rases> rases;
        private List<Herojei> atrinkti;
        const string help = "//..//..info.txt";
        //int pirmas;
        //int antras;
        string fv;
        string info;
        public Form1()
        {
            
            InitializeComponent();
        }

        private void uždaryt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void įvesti_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fr = openFileDialog1.FileName;
                
               HerojuList=Skaityti(fr); 
            }
        }
        static List<Herojei> Skaityti(string fv)
        {
            List<Herojei> HerojuList = new List<Herojei>();
            using (StreamReader reader = new StreamReader(fv,Encoding.GetEncoding(1257)) )
            {
                string eil;
                while((eil=reader.ReadLine())!=null)
                {
                    string[] parts = eil.Split(' ');
                    string vard = parts[0].Trim();
                    string  rase= parts[1].Trim();
                    string klase = parts[2].Trim();
                    int HP = int.Parse(parts[3]);
                    int MP = int.Parse(parts[4]);
                    int def = int.Parse(parts[5]);
                    int st = int.Parse(parts[6]);
                    int agi = int.Parse(parts[7]);
                    int intel = int.Parse(parts[8]);
                    string power = parts[9].Trim();
                    Herojei hr = new Herojei(vard, rase, klase, HP, MP, def, st, agi, intel, power);
                    HerojuList.Add(hr);
                }

            }
            return HerojuList;
        }

        private void spausdinti_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                fv = saveFileDialog1.FileName;
                if (File.Exists(fv)) File.Delete(fv);
                info = "Pradiniai";
                Spausdinti(fv, HerojuList,info);
                rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);
            }
        }
        static void Spausdinti(string fv, List<Herojei> HerojuList,string info)
        {
            using (var fr =new StreamWriter(File.Open(fv,FileMode.Append)))
            {
                fr.WriteLine(info);
                if (HerojuList.Count != 0)
                {
                    fr.WriteLine("|Vardas          |rase             |Klase           |HP  |MP  |DEF |Jega |AGI |Inte|     Power|");
                    for (int i = 0; i < HerojuList.Count; i++)
                    {
                        fr.WriteLine(HerojuList[i]);
                    }
                }
                else
                    fr.WriteLine("nera");
                fr.WriteLine(" ");
                

            }
            
        }
        /// <summary>
        /// Randa daugiausia HP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void daugiausiaiHP_Click(object sender, EventArgs e)
        {
            int pirmas=-1 , antras=-1;
            int daug = 0;
            //daug = 0;
            int nekreipt = -1;
            pirmas = rasti(HerojuList, daug, nekreipt);
            nekreipt = pirmas;
            antras = rasti(HerojuList, daug, nekreipt);
            //MessageBox.Show(pirmas.ToString(),"tarpas");
           // DaugiausiaiHP(HerojuList, daug,pirmas,antras);
            DaugiausiaiHPspaust(fv ,pirmas, antras,HerojuList);
            rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);
        }
        static void DaugiausiaiHPspaust(string fv, int pirmas, int antras, List<Herojei> HerojuList)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                fr.WriteLine("Daugiausiai HP");
                if (HerojuList.Count != 0)
                {
                   
                    
                        fr.WriteLine("  |Vardas          |rase             |Klase           |HP  |MP  |DEF |Jega |AGI |Inte|     Power|");
                        fr.WriteLine("1 {0}", HerojuList[pirmas]); 
                    
                  if(antras>-1)
                        fr.WriteLine("2 {0}", HerojuList[antras]);
                    
                }
                else
                    fr.WriteLine("Nera"); 
                fr.WriteLine(" ");
            }
        }
        //static void DaugiausiaiHP(List<Herojei> HerojuList,int daug,int pirmas,int antras)
        //{
        //    daug = 0;
        //    int nekreipt = -1;
        //    pirmas = rasti(HerojuList, daug, nekreipt);
        //    nekreipt = pirmas;
        //    antras= rasti(HerojuList, daug, nekreipt);
        //}
        static int rasti(List<Herojei> HerojuList, int daug, int nekreipt)
        {
            int kelintas=-1;
            daug = 0;
            for(int i=0;i<HerojuList.Count;i++)
            {
                if(HerojuList[i].HP>=daug)
                {
                    if (i != nekreipt)
                    {
                        daug = HerojuList[i].HP;

                        kelintas = i;
                    }
                }
            }
            return kelintas;
        }
        //#######################################################################################
        /// <summary>
        /// sudaro rasiu sarasa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atrinktRases_Click(object sender, EventArgs e)
        {
           rases = Atrinkt(HerojuList);
           
            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            //saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files(*.*)|*.*";
            //saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            //DialogResult result = saveFileDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    string fv = saveFileDialog1.FileName;
                //if (File.Exists(fv)) File.Delete(fv);
                Spausdint(fv,rases);
            rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);
            //}

        }
      static List<Rases> Atrinkt(List<Herojei> HerojuList)
        {
            int keli = 0;
            List<Rases> rases = new List<Rases>();
            for(int i=0;i<HerojuList.Count;i++)
            {
                keli = 0;
                for(int j=0;j<rases.Count;j++)
                {
                    if(HerojuList[i].rase==rases[j].rase)
                    {
                        keli++;
                    }
                }
                if(keli==0)
                {
                    string rase = HerojuList[i].rase;
                    int kiek = kiekRS(rase, HerojuList);
                    Rases rs = new Rases(rase, kiek);
                    rases.Add(rs);
                }
            }
            return rases;
        }
        static int kiekRS(string rase, List<Herojei> HerojuList)
        {
            int keli=0;
            for (int i=0;i<HerojuList.Count;i++)
            {
                if (HerojuList[i].rase == rase)
                    keli++;
            }
            return keli;
        }
        static void Spausdint(string fv,List<Rases>rases)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                fr.WriteLine("Rases");
                if (rases.Count != 0)
                {
                    fr.WriteLine("rase         Skaicius");
                    for (int i = 0; i < rases.Count; i++)
                    {
                        fr.WriteLine(rases[i]);
                    }
                }
                else
                    fr.WriteLine("nera");
                fr.WriteLine(" ");
            }
        }
        //#######################################################################################
        /// <summary>
        /// atrenka herojus pagal kriterijus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void atrinktiHerojusPagalDuom_Click(object sender, EventArgs e)
        {
            int HP = int.Parse(textBox1.Text);
            int DEF = int.Parse(textBox2.Text);
            atrinkti = atrinktiDuom(HerojuList, HP, DEF);
            info = "Atrinkta";
            Spausdinti(fv, atrinkti,info);
            rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);
        }
        static List<Herojei> atrinktiDuom(List<Herojei> HerojuList,int HP,int DEF)
        {
            List<Herojei> Duom = new List<Herojei>();
            for(int i=0;i<HerojuList.Count;i++)
            {
                if (HerojuList[i].HP > HP && HerojuList[i].def >= DEF)
                    Duom.Add(HerojuList[i]);

            }
            return Duom;
        }

        private void rikiuot_Click(object sender, EventArgs e)
        {
            atrinkti.Sort();
            info = "Surikiuota";
            Spausdinti(fv, atrinkti,info);
            rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);

        }
        //#######################################################################################
        /// <summary>
        /// randa geriausia
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rastiGeriausia_Click(object sender, EventArgs e)
        {
           
            string rase = textBox3.Text;
            int indeksas = suma(HerojuList,rase);
            geriau(fv,HerojuList, indeksas);
            rezult.LoadFile(fv, RichTextBoxStreamType.PlainText);
        }
        static int suma(List<Herojei>HerojuList,string rase)
        {
            double max = 0;
            double sk=0;
            int indeksas = -1;
            for (int i = 0; i < HerojuList.Count; i++)
                if (HerojuList[i].rase == rase)
                {
                    sk = HerojuList[i].Suma();
                    if (max < sk)
                    {
                        max = sk;
                        indeksas = i;
                    }
                            }
            return indeksas;
        }
        static void geriau(string fv,List<Herojei>HerojuList, int indeksas )
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append)))
            {
                fr.WriteLine("Geriausias nurodytos rasės herojus (pirmas jei yra daugiau vienoda statistika turinciu) ");
                if (indeksas != -1)
                    fr.WriteLine(HerojuList[indeksas]);
                else
                    fr.WriteLine(" Nera ");
                fr.WriteLine(" ");

            }
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rezult.LoadFile(help, RichTextBoxStreamType.PlainText);
        }
        //#######################################################################################

    }
}
