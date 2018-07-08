using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Butai
{
    class Butas
    {
        private int nr;
        private int kambariai;
        private double plotas,kaina;
        private string numeris;

        public Butas(int nr, double plotas, int kambariai, double kaina, string numeris)
        {
            this.nr = nr;
            this.plotas = plotas;
            this.kambariai = kambariai;
            this.kaina = kaina;
            this.numeris = numeris;
        }

        public int imtnr() { return nr; }
        public double imtplota() { return plotas; }
        public int imtkamb() { return kambariai; }
        public double imtkaina() { return kaina; }
        public string imtnumeri() { return numeris; }

        public override string ToString() 
        {   string eil;
            eil = string.Format("{0} {1} {2} {3} {4} ",nr , plotas, kambariai, kaina, numeris); 
            return eil; 
        }   
    }
    class Butai
    {
      
        private Butas[] B;
        private int kiek;

        public Butai()
        {
            kiek = 0;
            B = new Butas[100];
        }
        public Butas imtbuta(int i) {return B[i];}
        public int imtkiek() { return kiek; }
        public void detibuta(Butas obj)
                { B[kiek++] = obj;}
    }
    class Program
    {
        const string failas = "...//...//Duom.txt";

        static void Main(string[] args)
        {
            Butai B = new Butai();
            int sk1;
            int kiek;
            double sk2;
            Console.Write("iveskite norima kambariu skaiciu ");
            sk1 = int.Parse(Console.ReadLine());
            Console.Write("maksimali kaina ");
            sk2 = double.Parse(Console.ReadLine());
            skaitymas(failas, ref B);
            Butas [] mas = new Butas[B.imtkiek()];                    
            Console.Clear();

            tikrina(ref B, mas, ref sk1, ref sk2, out kiek);
            rasymas(mas,ref kiek);
        }
        static void skaitymas(string failas, ref Butai B)
        {
            int but_nr, kambariu_sk;
            double plotas, kaina;
            string tel_nr,line;

            using (StreamReader skaito = new StreamReader(failas))
            {
                string[] parts;
                while ((line = skaito.ReadLine()) != null)
                {
                    parts = line.Split(' ');
                    but_nr = int.Parse(parts[0]);
                    plotas = double.Parse(parts[1]);
                    kambariu_sk = int.Parse(parts[2]);
                    kaina = double.Parse(parts[3]);
                    tel_nr = parts[4];
                    Butas but = new Butas(but_nr, plotas, kambariu_sk, kaina,tel_nr);
                    B.detibuta(but);
                }
            }
        }
        static void tikrina(ref Butai B,Butas[] mas, ref int sk, ref double sk1, out int kiek)
        {
            kiek = 0;
          
            for (int i = 0; i < B.imtkiek(); i++)
                if ((B.imtbuta(i).imtkamb() == sk) && (B.imtbuta(i).imtkaina() <= sk1))
                {
                    
                    mas[kiek] = B.imtbuta(i);
                    kiek++;
                }
        }
        static void rasymas(Butas[] mas, ref int kiek)
        {
            if (kiek == 0)
                Console.WriteLine("nera");
            else
                for (int i = 0; i < kiek; i++)
                    Console.WriteLine("{0}", mas[i].ToString());
        }
    }
}
