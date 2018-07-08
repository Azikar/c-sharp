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
namespace Lab5
{
    public partial class Form1 : Form
    {
        const string Stud = "...\\...\\U12a.txt";
        const string Mod = "...\\...\\U12b.txt";
        const string Rez = "...\\...\\Rez.txt";
        Sarasas<Studentas> A,stud;
        Sarasas<Modulis> M, parinkt, nepasi;

        private void ivestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A = Skaitytistud(Stud);
            M = Skaitytimod(Mod);
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void spaustToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (StreamWriter failas = File.AppendText(Rez))
            {
                failas.WriteLine("Pradiniai");
                A.Pradzia();M.Pradzia();
                failas.WriteLine("|Modulis              |Vardas   |Pavarde               |Grupe ");
                if(A.Yra()==false)
                {
                    failas.WriteLine("nera");
                }
                else
                for (A.Pradzia(); A.Yra(); A.Kitas())
                {
                    failas.WriteLine(A.imtiDuom());
                }
                failas.WriteLine(" ");
                failas.WriteLine("|Pavadinimas          |Vardas   |Kreditai  |");
                if (M.Yra()==false)
                {
                    failas.WriteLine("nera");
                }
                else
                for (M.Pradzia(); M.Yra(); M.Kitas())
                {
                    failas.WriteLine(M.imtiDuom());
                }
            }
            rezult.LoadFile(Rez, RichTextBoxStreamType.PlainText);
        }
        
        public Form1()
        {

            InitializeComponent();
            if (File.Exists(Rez))
                File.Delete(Rez);

        }

        private void atrinktPasirinktusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parinkt = Atrinkt(A, M);
            parinkt.Pradzia();
            using (StreamWriter failas =File.AppendText(Rez))
            {

                failas.WriteLine("Pasirinkti");
                if (parinkt.Yra() == false)
                {
                    failas.WriteLine("Nera");
                }
                else
                {
                    failas.WriteLine("|Pavadinimas          |Vardas   |Kreditai  |");
                    for (parinkt.Pradzia(); parinkt.Yra(); parinkt.Kitas())
                    {
                        failas.WriteLine(parinkt.imtiDuom());
                    }
                } 
            }
            rezult.LoadFile(Rez, RichTextBoxStreamType.PlainText);
            }
        static Sarasas<Modulis> Atrinkt(Sarasas<Studentas> A,Sarasas<Modulis>M)
        {
            int keli = 0;
            int pas = 0;
            var atr = new Sarasas<Modulis>();
            for(M.Pradzia(); M.Yra(); M.Kitas())
            {
                keli = 0;
                pas = 0;
                for(A.Pradzia();A.Yra();A.Kitas())
                {
                    if (M.imtiDuom().pavad == A.imtiDuom().mod)
                    {
                        pas++;
                        for (atr.Pradzia(); atr.Yra(); atr.Kitas())
                        {
                            if (M.imtiDuom().pavad == atr.imtiDuom().pavad)
                                keli++;
                        }
                    }
                }
                if(keli==0&&pas!=0)
                {
                    Modulis mod = new Modulis(M.imtiDuom().pavad,M.imtiDuom().vardpav,M.imtiDuom().krd);
                    atr.DetiDuom(mod);
                }
            }
            return atr;
        }

        private void atrinktNepasirinktusToolStripMenuItem_Click(object sender, EventArgs e)
        {

            nepasi = Atrinktnepasi(M, parinkt);
            parinkt.Pradzia();
            
            using (StreamWriter failas = File.AppendText(Rez))
            {
                failas.WriteLine("nepasirinkti");
                if (nepasi.Yra() == false)
                {
                    failas.WriteLine(" Nera ");
                }
                else
                {
                    failas.WriteLine("|Pavadinimas          |Vardas   |Kreditai  |");
                    for (nepasi.Pradzia(); nepasi.Yra(); nepasi.Kitas())
                    {
                        failas.WriteLine(nepasi.imtiDuom());
                    }
                }
            }
            rezult.LoadFile(Rez, RichTextBoxStreamType.PlainText);
        }
        static Sarasas<Modulis> Atrinktnepasi(Sarasas<Modulis> M, Sarasas<Modulis> parinkt)
        {
            int keli = 0;
            var nepasirinkti = new Sarasas<Modulis>();
            for(M.Pradzia();M.Yra();M.Kitas())
            {
                keli = 0;
                for(parinkt.Pradzia(); parinkt.Yra(); parinkt.Kitas())
                {
                    if(M.imtiDuom().pavad==parinkt.imtiDuom().pavad)
                    {
                        keli++;
                    }
                }
                if(keli==0)
                {
                    Modulis mod = new Modulis(M.imtiDuom().pavad, M.imtiDuom().vardpav, M.imtiDuom().krd);
                    nepasirinkti.DetiDuom(mod);

                }
            }
            return nepasirinkti;
        }

        private void studentasSuDaugiausiaiModuliuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           stud= Rasti(A);
            stud.Pradzia();
           // int kiek = 0;
            string st="nera";
           if(stud.Yra()==false)
            {
                using (var failas = File.AppendText(Rez))
                {
                    failas.WriteLine("Daugiausiai moduliu turi");
                    failas.WriteLine("Nera");
                }
            }
           else
            {
                //for (stud.Pradzia(); stud.Yra(); stud.Kitas())
                //{
                    //string vardas = stud.imtiDuom().vard;
                    //string pav = stud.imtiDuom().pav;
                     st = student(stud, A);
                    //if (keli > kiek)
                    //{
                    //    kiek = keli;
                    //    Studentas studentas = new Studentas(A.imtiDuom().mod, A.imtiDuom().vard, A.imtiDuom().pav, A.imtiDuom().grupe);
                    //    st = studentas.ToString();
                        
                    //}
                //}
                using (var failas = File.AppendText(Rez))
                {
                    failas.WriteLine("Daugiausiai moduliu turi");
                    failas.WriteLine(st); 
                }
               
            }
            rezult.LoadFile(Rez, RichTextBoxStreamType.PlainText);


        }
        static Sarasas<Studentas> Rasti(Sarasas<Studentas> A)
        {
            var stu = new Sarasas<Studentas>();
            A.Pradzia();
           
            for (A.Pradzia();A.Yra();A.Kitas())
            {
                int keli = 0;
                for(stu.Pradzia();stu.Yra();stu.Kitas())
                {
                    if(A.imtiDuom().vard==stu.imtiDuom().vard&&A.imtiDuom().pav==stu.imtiDuom().pav&&A.imtiDuom().grupe==stu.imtiDuom().grupe)
                    {
                        keli++;
                    }
                }
                if(keli==0)
                {
                  
                    var studentas = new Studentas(A.imtiDuom().mod, A.imtiDuom().vard, A.imtiDuom().pav, A.imtiDuom().grupe);
                    stu.DetiDuom(studentas);


                }
            }
          
            return stu;
        }
        static string student(Sarasas<Studentas> stud,Sarasas<Studentas> A)
        {
            int keli=0;
            int kiek = 0;
            string st="Nera";
            for(stud.Pradzia();stud.Yra();stud.Kitas())
            {
                keli=0;
                for(A.Pradzia();A.Yra();A.Kitas())
                {
                    if(stud.imtiDuom().pav==A.imtiDuom().pav)
                        keli++;
                }
                if(kiek<keli)
                {
                    st = stud.imtiDuom().ToString();
                    kiek++;
                }
            }
            return st ;
        }

        static Sarasas<Studentas> Skaitytistud(string fv)
        {
            var A = new Sarasas<Studentas>();
            using (var failas = new StreamReader(fv))
            {
                string eilute;
                while((eilute=failas.ReadLine())!=null)
                {
                    string[] part = eilute.Split(';');
                    string mod = part[0];
                    string vard = part[1];
                    string pav = part[2];
                    string grupe = part[3];
                    Studentas S = new Studentas(mod, vard, pav, grupe);
                    A.DetiDuom(S);
                }
            }
                return A;
        }
        static Sarasas<Modulis> Skaitytimod(string fv)
        {
            var M = new Sarasas<Modulis>();
            using (var failas = new StreamReader(fv))
            {
                string eilute;
                while((eilute=failas.ReadLine())!=null)
                {
                    string[] part = eilute.Split(';');
                    string pavad = part[0];
                    string vardpav = part[1];
                    int krd = int.Parse(part[2]);
                    Modulis m = new Modulis(pavad, vardpav, krd);
                    M.DetiDuom(m);

                }
            }
            return M;
        }
    }
}
