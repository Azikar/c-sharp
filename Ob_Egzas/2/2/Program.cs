using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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
            string eil;
            eil = string.Format("{0,-20} {1,2} {2,3}", PavVrd, Amzius, Stažas);
            return eil;
            // ATLIKITE: Užklokite kandidato spausdinimo eilute metodą
        }
    }
    class Programuotojas : Kandidatas
    {
        public double kom_pat
        {
            get; set;
        }
        public int nusiskund { get; set; }
        public Programuotojas(string PavVrd = "", int Amzius = 0, double Stažas = 0.0,double kom_pat=0, int nusiskund=0)
            :base(PavVrd,Amzius,Stažas)
        {
            this.nusiskund = nusiskund;
            this.kom_pat = kom_pat;
        }
        public override string ToString()
        {
            string eilu;
            eilu = string.Format("{0} {1,3} {2,4}", base.ToString(), kom_pat, nusiskund);
            return eilu;
        }
        public override double Atlyginimas()
        {
            return BazinisDydis+0.2*BazinisDydis*1.1*kom_pat+0.1*BazinisDydis*(-1*nusiskund);
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
            // Console.WriteLine(P[0].ToString());
            Spausdinti(P, n);
            // ATLIKITE: Papildykite Main metodą reikiamais veiksmais
        }
        public static void Spausdinti(Kandidatas[] K, int kn)
        {
            for (int i = 0; i < kn; i++)
            {
                Console.WriteLine(K[i].Atlyginimas());

                
            }
            // ATLIKITE: Spausdinkite kiekvieno kandidato atlyginimą ekrane
        }
    }
}
