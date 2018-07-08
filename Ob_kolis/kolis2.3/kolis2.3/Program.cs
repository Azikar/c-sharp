using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kolis2._3
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
    }
  public sealed class mazgas
    {
        public Autorius duomenys;
        public mazgas kitas;
        public mazgas(Autorius duomenys,mazgas kitas)
        {
            this.duomenys = duomenys;
            this.kitas = kitas;

        }

    }
    public sealed class autoriai
    {
        mazgas pr;
        mazgas pb;
        mazgas d;
        public autoriai()
        {
            this.pr = null;
            this.pb = null;
            this.d = null;
        }
        public void pradcia()
        {
            d = pr;
        }
        public void kitas()
        {
            d = d.kitas;

        }
        public bool yra()
        {
            return d != null;
        }
        public Autorius imti()
        {
            return d.duomenys;
        }
        public void detia(Autorius inf)
        {
            var d = new mazgas(inf, null);
            d.kitas = pr;
            pr = d;
        }
        public void detib(Autorius inf)
        {
            var d = new mazgas(inf, null);
                if(pr!=null)
            {
                pb.kitas = d;
                pb = d;
            }
            else
            {
                pr = d;
                pb = d;
            }
        }
        public void rikiuoti()
        {
            bool keist = true;
            mazgas d1, d2;
            while(keist)
            {
                keist = false;
                d1 = d2 = pr;
                while(d2!=null)
                {
                    if(d2.duomenys>=d1.duomenys)
                    {
                        Autorius a = d1.duomenys;
                        d1.duomenys = d2.duomenys;
                        d2.duomenys = a;
                    }
                    d1 = d2;d2 = d2.kitas;
                }
            }
        }
        public void naik()
        {
            while(pr!=null)
            {
                d=pr;
                pr = pr.kitas;
                d = null;

            }
            d = pr;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
