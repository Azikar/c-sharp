using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace kolis_normal
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
        // Užklotas operatorius >= (dviejų autorių palyginimui pagal knygos kainą ir knygos autorių)
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
    }    public sealed class Mazgas
    {
        public Autorius Duomenys { get; set; }
        public Mazgas Kitas { get; set; }
        public Mazgas() { }
        public Mazgas(Autorius Duomenys, Mazgas Kitas)
        {
            this.Duomenys = Duomenys;
            this.Kitas = Kitas;
        }
    }
    public sealed class Autoriai
    {
        Mazgas pr;
        Mazgas pb;
        Mazgas d;
        public Autoriai()
        {
            this.pr = null;
            this.pb = null;
            this.d = null;
        }
        public void Pradzia()
        {
            d = pr;
        }
        public void Kitas()
        {
            d = d.Kitas;
        }
        public bool Yra()
        { return d != null; }
        public Autorius imtiduom()
        {
            return d.Duomenys;
        }
        public void detiduom(Autorius inf)
        {
            var d = new Mazgas(inf, null);
            d.Kitas = pr;
            pr = d;
        }
        public void rikiuot()
        {
            bool keist = true;
            Mazgas d1, d2;
            while(keist)
            {
                keist = false;
                d1 = d2 = pr;
                while (d2 != null)
                {
                    if(d2.Duomenys>=d1.Duomenys)
                    {
                        Autorius a = d1.Duomenys;
                        d1.Duomenys = d2.Duomenys;
                        d2.Duomenys = a;
                    }
                    d1 = d2;d2 = d2.Kitas;
                }
            }

        }
    }

    class Program
    {
        const string duom = "...\\...\\Duom.txt";
        static void Main(string[] args)
        {
            
            Autoriai A = Skaityti(duom);
            A.Pradzia();
            Spausdint(A);
           // A.Pradzia();
            A.rikiuot();        
            Spausdint(A);
            Autoriai Naujas=atrinkt(A);
           // Naujas.Pradzia();
            Spausdint(Naujas);
        }
        static Autoriai Skaityti(string duom)
        {
            Autoriai A = new Autoriai();
            using (StreamReader reader = new StreamReader(duom))
            {
                string eil;
                while((eil=reader.ReadLine())!= null)
                {
                    string[] parts = eil.Split(';');
                    string vardas = parts[0];
                    string knyga = parts[1];
                    string leid = parts[2];
                    int kaina = int.Parse(parts[3]);
                    Autorius elem = new Autorius(vardas, knyga, leid, kaina);
                    A.detiduom(elem);
                }
            }
                return A;
        }
      static void Spausdint(Autoriai A)
        {
            for (A.Pradzia(); A.Yra();A.Kitas())
            Console.WriteLine(A.imtiduom().ToString());
            Console.WriteLine(" ");
        }
        static Autoriai atrinkt(Autoriai A)
        {
            Autoriai N = new Autoriai();
            string leid=" ";
            for(A.Pradzia();A.Yra();A.Kitas())
            {
                leid = A.imtiduom().leidykla;
            }
            for(A.Pradzia();A.Yra();A.Kitas())
                if(A.imtiduom().leidykla==leid)
                {
                    N.detiduom(A.imtiduom());
                }
            return N;
        }

    }
}
