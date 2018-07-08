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
        static public bool operator>(Miestas ms1,Miestas ms2)
        {
            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            return (p < 0 || p == 0);
        }
        static public bool operator<(Miestas ms1,Miestas ms2)
        {
            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            return (p > 0 || p == 0);
        }
    }
    class DaugMiestu
    {
        private Miestas[] ms;
        public int Kiek { get; set; }
        public DaugMiestu()
        {
            Kiek = 0;
            ms = new Miestas[100];
        }
        public Miestas imtMiesta(int i) { return ms[i]; }
        public void Deti(Miestas mie) { ms[Kiek++] = mie; }
    }
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";
        static void Main(string[] args)
        {
            DaugMiestu M;
            DaugMiestu A;
            M = Skait(duom);
            A = reik(M);
            spaust(A,rez);
        }
        static DaugMiestu Skait(string duom)
        {
            DaugMiestu daug = new DaugMiestu();
            using (StreamReader skait = new StreamReader(duom))
            {
                string eil;
                while((eil=skait.ReadLine())!=null)
                {
                    string[] part = eil.Split(':');
                    string pav = part[0];
                    Miestas miest = new Miestas(pav);
                    daug.Deti(miest);

                }
            }
                return daug;
        }
        static DaugMiestu reik(DaugMiestu M)
        {
            DaugMiestu miest = new DaugMiestu();
            for(int i=0;i<M.Kiek;i++)
            {
                miest.Deti(M.imtMiesta(i));
            }
            return miest;
        }
        static void spaust(DaugMiestu A,string rez)
        {
            using (var fv = new StreamWriter(File.Open(rez, FileMode.Append)))
            {
                fv.WriteLine(A.imtMiesta(0));
            }
        }

    }
}
