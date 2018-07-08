using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _2
{
    abstract class Kandidatas : Object
    {
        protected const double BazinisDydis = 800.00; // Bazinis atlyginimo dydis
        protected string PavVrd { get; set; } // Pavardė ir vardas
        protected int Amzius { get; set; } // Amžius
        protected double Stažas { get; set; } // Darbo stažas (metais)
                                              // Klasės konstruktorius
        public Kandidatas(string PavVrd = "", int Amzius = 0, double Stažas = 0.0)
        {
            this.PavVrd = PavVrd;
            this.Amzius = Amzius;
            this.Stažas = Stažas;
        }
        // Abstraktus metodas
        public abstract double Atlyginimas();
        public override string ToString()
        {
            string eil;0
            eil = string.Format("{0} {1} {2}", PavVrd, Amzius, Stažas);
            return eil;
            // ATLIKITE: Užklokite kandidato spausdinimo eilute metodą
        }
        public static bool operator>(Kandidatas a,Kandidatas b)
        {
            return a.Amzius > b.Amzius;
        }
        public static bool operator<(Kandidatas a,Kandidatas b)
        {
            return a.Amzius < b.Amzius;
        }
        public void Rikiuot()
        {
          
        }
    }
    class Programuotojas : Kandidatas
    {
        protected double patirtis;
        protected int nusisk;
        public Programuotojas(string PavVrd = "", int Amzius = 0, double Stažas = 0.0,double patirtis=0,int nusisk=0)
            :base(PavVrd,Amzius,Stažas)
        {
            this.patirtis = patirtis;
            this.nusisk = nusisk;
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0} {1} {2}", base.ToString(), patirtis, nusisk);
            return eil;
        }
        public override double Atlyginimas()
        {
            return BazinisDydis + 0.2 * BazinisDydis * 1.1 * patirtis + 0.1 * BazinisDydis * (-1 * nusisk);
        }
        // ATLIKITE: Aprašykite klasės savybes ir konstruktorių
        // ATLIKITE: Užklokite programuotojo atlyginimo skaičiavimo metodą
        // ATLIKITE: Užklokite programuotojo spausdinimo eilute metodą
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Programuotojų objektų masyvas P(n)
            int n = 3; Programuotojas[] P = new Programuotojas[n];
            // P(n) objektų užpildymas reikšmėmis
            P[0] = new Programuotojas("Programuotojas1", 29, 1.1, 1.5, 0);
            P[1] = new Programuotojas("Programuotojas2", 39, 11.5, 2.2, 3);
            P[2] = new Programuotojas("Programuotojas3", 30, 3.0, 3.6, 0);
            Rikiuot(n, P);
            Spausdinti(P, n);
            // ATLIKITE: Papildykite Main metodą reikiamais veiksmais
        }
        public static void Spausdinti(Kandidatas[] K, int kn)
        {
            for(int i=0;i< kn;i++)
            {
                Console.WriteLine("{0,-40} |{1,10} Pinigo", K[i], K[i].Atlyginimas());
            }
            // ATLIKITE: Spausdinkite kiekvieno kandidato atlyginimą ekrane
        }
         static void Rikiuot(int n,Kandidatas[] K)
        {
            int j=0;
            bool keist = true;
            while(keist)
            {
                keist = false;
                for (int i = n-1; i >=j; i--)
                {
                    if (K[i] > K[i - 1])
                    {
                        keist = true;
                        Kandidatas knd = K[i];
                        K[i] = K[i - 1];
                        K[i - 1] = knd;

                    }
                    j++;
                }
            }
        }
    }
}
