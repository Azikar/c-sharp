using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace kolis
{
    public class Autorius
    {
        public string pavVard { get; set; } // knygos autoriaus pavardė, vardas
        public string knyga { get; set; } // knygos pavadinimas
        public string leidykla { get; set; } // leidyklos, kuri išleidžia knygą, pavadinimas
        public double kaina { get; set; } // knygos kaina
                                          // Konstruktorius
        public Autorius(string pavVard = "", string knyga = "", string leidykla = "", double kaina = 0)
        {
            this.pavVard = pavVard;
            this.knyga = knyga;
            this.leidykla = leidykla;
            this.kaina = kaina;
        }
        // objekto naujos reikšmės
        // a – knygos autoriaus pavardė, vardas
        // b – knygos pavadinimas
        // c – leidyklos, kuri išleidžia knygą, pavadinimas
        // d – knygos kaina
        void Dėti(string a, string b, string c, double d)
        {
            pavVard = a;
            knyga = b;
            leidykla = c;
            kaina = d;
        }
        // Užklotas metodas ToString()
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0, -30}| {1, -20} | {2, -20} | {3, 8:f} |",
            pavVard, knyga, leidykla, kaina);
            return eilute;
        }
        // Užklotas metodas Equals()
        public override bool Equals(object objektas)
        {
            Autorius elem = objektas as Autorius;
            return elem.pavVard == pavVard && elem.knyga == knyga && elem.leidykla == leidykla
            && elem.kaina == kaina;
        }
        // Užklotas metodas GetHashCode()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public static bool operator >=(Autorius pirmas, Autorius antras)
        {
            int poz = String.Compare(pirmas.pavVard, antras.pavVard,
            StringComparison.CurrentCulture);
            return pirmas.kaina > antras.kaina || pirmas.kaina == antras.kaina && poz > 0;
        }
        // Užklotas operatorius <= (dviejų autorių palyginimui pagal knygos kainą ir knygos autorių)
        public static bool operator <=(Autorius pirmas, Autorius antras)
        {
            int poz = String.Compare(pirmas.pavVard, antras.pavVard,
            StringComparison.CurrentCulture);
            return pirmas.kaina < antras.kaina || pirmas.kaina == antras.kaina && poz < 0;
        }
    }
    public sealed class Mazgas
    {
        public int Duomenys { get; set; }
        public Mazgas kitas { get; set; }
        public Mazgas(int duomenys,Mazgas adresas)
        {
            this.Duomenys = duomenys;
            this.kitas = adresas;
        }
        public sealed class autor
        {
            public string pv { get; set; }
            Mazgas pr;
            Mazgas d;
            public autor()
            {
                this.pr = null;
                this.d = null;
            }
                public void Pradzia()
            {
                d = pr;
            }
            public void Kitas()
            {
                d = d.kitas;
            }
                        
        }
    }
    class Autoriai
    {
        const int Cn = 500;
        private Autorius[] Aut;
        public int Kiek { get; set; }
        public Autoriai()
        {
            Kiek = 0;
            Aut = new Autorius[Cn];
        }
        public Autorius ImtiAutoriu(int i) { return Aut[i]; }
        public void DetiAut(Autorius autor) { Aut[Kiek++] = autor; }
        //Burbulas.
        
        public void Rikiuoti()
        {
            int i = 0;
            bool bk = true;
            while(bk)
            {
                bk = false;
                for(int j=Kiek-1;j> i;j--)
                    if(Aut[j]<=Aut[j-1])
                    {
                        bk = true;
                        Autorius autor = Aut[j];
                        Aut[j] = Aut[j - 1];
                        Aut[j - 1] = autor;
                    }
                i++;
            }
        }
         
        class Autor
        {
            const int Cn = 500;
            private Autorius[] Au;
            public int kiek { get; set; }
            public Autor()
            {
                kiek = 0;
                Au = new Autorius[Cn];
            }
            public Autorius imti(int i) { return Au[i]; }
            public void deti(Autorius aut) { Au[kiek] = aut; }
    }
    class Program
    {
        const string duom="..\\..\\duom.txt";
       
        static void Main(string[] args)
        {
            Autoriai A;
            A = Skaityti(duom);
            A.Rikiuoti();
            Spausdinti(A);
            Autoriai naujas;
            naujas = sutampa(A);
            int kuri_brang=-1;
            
            Console.Write("Autorius");
            string auto = Console.ReadLine();
            Brangiausia(naujas, out kuri_brang,auto);
            
            Spausdinti(naujas);
            Spaus_brang(naujas,kuri_brang);
            naujas = valyt(naujas);
            Spausdinti(naujas);
        }
        static Autoriai Skaityti(string fv)
        {
            Autoriai aut = new Autoriai();
            string eil;
            using (StreamReader duom = new StreamReader(fv))
            {
                while ((eil = duom.ReadLine()) != null)
                {
                    string[] part = eil.Split(';');
                    string vardas = part[0];
                    string pav = part[1];
                    string leid = part[2];
                    int kaina = int.Parse(part[3]);
                    Autorius autor = new Autorius(vardas, pav, leid, kaina);
                    aut.DetiAut(autor);
                }
            }
                return aut;
        }
        static Autoriai sutampa(Autoriai A)
        {
            Autoriai aut = new Autoriai();

            // string leid = A.ImtiAutoriu(A.Kiek).leidykla;
          //  A.ImtiAutoriu(A.Kiek).leidykla;
            for(int i=0;i<A.Kiek;i++)
            if (A.ImtiAutoriu(i).leidykla== A.ImtiAutoriu(A.Kiek-1).leidykla)
                {
                    aut.DetiAut(A.ImtiAutoriu(i));
                }
            return aut;
        }
        static void Brangiausia(Autoriai naujas,out int  kuri_brang,string auto)
        {
            kuri_brang = -1;
            for (int i = 0; i < naujas.Kiek; i++)
                if (naujas.ImtiAutoriu(i).pavVard == auto)
                    kuri_brang = i;
        }
        static void Spausdinti(Autoriai mas)
        {
            Console.WriteLine("Vardas                        |Knyga               |Leidykla            |Kaina");
            for (int i = 0; i < mas.Kiek; i++)
                Console.WriteLine(mas.ImtiAutoriu(i));
        }
        static void Spaus_brang(Autoriai mas,int kuri)
        {
            Console.WriteLine("Vardas                        |Knyga               |Leidykla            |Kaina");
            if (kuri != -1)
                Console.WriteLine(mas.ImtiAutoriu(kuri));
            else
                Console.WriteLine("nera");
        }
        static Autoriai valyt(Autoriai naujas)
        {
            Autoriai aut = new Autoriai();
            return aut;
            
        }
    }
}
