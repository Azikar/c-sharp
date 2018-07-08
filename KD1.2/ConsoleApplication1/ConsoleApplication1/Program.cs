using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApplication1
{
    class Miestas
    {
        public string pav { get; set; }
        public Miestas(string pav)
        {
            this.pav = pav;

        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0}", pav);
            return eil;
        }
         public static bool operator>(Miestas ms1,Miestas ms2)
        {
            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            return (p == 0 || p > 0);
        }
        public static bool operator <(Miestas ms1, Miestas ms2)
        {
            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            return (p == 0 || p < 0);
        }
    }
    class DaugMiestu
    {
        private Miestas[] Ms;
        public int Kiek { get; set; }
        public DaugMiestu()
        {
            Kiek = 0;
            Ms = new Miestas[100];
        }
public Miestas imtimiesta(int i) { return Ms[i]; }
        public void detiMiesta(Miestas miest) { Ms[Kiek++] = miest; }
    }
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        static void Main(string[] args)
        {
            DaugMiestu M;
            DaugMiestu A;
            M = skait(duom);
            A = sud(M);
        }
        static DaugMiestu skait(string duom)
        {
            DaugMiestu daug = new DaugMiestu();
            using (StreamReader skai = new StreamReader(duom))
            {
                string eil;
                while((eil=skai.ReadLine())!=null)
                {
                    string[] part = eil.Split(';');
                    string pav = part[0];
                    Miestas miest = new Miestas(pav);
                    daug.detiMiesta(miest);   
                }
            }
            return daug;
        }
        static DaugMiestu sud(DaugMiestu M)
        {
            DaugMiestu sudet = new DaugMiestu();
            for (int i = 0; i < M.Kiek; i++) 
            {
                sudet.detiMiesta(M.imtimiesta(i));
            }
            return sudet;
        }
    }
   
}
