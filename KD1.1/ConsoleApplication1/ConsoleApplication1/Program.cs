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
        public string sal { get; set; }
        public int gyv { get; set; }
        public int plot { get; set; }
        public Miestas(string pav,string sal,int gyv,int plot)
        {
            this.pav = pav;
            this.sal = sal;
            this.gyv = gyv;
            this.plot = plot;
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0,-10}{1,-10}{2,5}{3,5}");
            return eil;
        }
        public static bool operator >(Miestas ms1, Miestas ms2)
        {
            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            bool v = ms1.gyv > ms2.gyv;
            return (p < 0 || (p == 0 && v));
        } 
        public static bool operator<(Miestas ms1,Miestas ms2)
        {

            int p = string.Compare(ms1.pav, ms2.pav, StringComparison.CurrentCulture);
            bool v = ms1.gyv > ms2.gyv;
            return (p > 0 || (p == 0 && v));
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
        public Miestas imtiMiesta(int i) { return Ms[i]; }
        public void DetiMiesta(Miestas mie) { Ms[Kiek++] = mie; }
        public void rast (out int didz)
        {
            int did = 0;
            didz = 0;
            for(int i=0;i<Kiek;i++)
            {
                if (did <Ms[i].plot )
                    didz = i;
            }
            
        }
        public void burb()
        {
            int i = 0;
            bool bk = true;
            while(bk)
            {
                bk = false;
                for(int j=Kiek-1;j> i;j--)
                    if(Ms[j]>Ms[j-1])
                    {
                        bk = true;
                        Miestas mies = Ms[j];
                        Ms[j] = Ms[j - i];
                        Ms[j - 1] = mies;
                    }
                i++;
            }
        }
    }
    class Program
    {
        const string duom = "..\\..\\Duom.txt";
        const string rez = "..\\..\\Rez.txt";
        static void Main(string[] args)
        {
            DaugMiestu M;
            DaugMiestu A;
            M = Skait(duom);
            string salis;
            Console.WriteLine("Iveskite salies pavadinima");
            salis=Console.ReadLine();
            A = Kont(salis,M);
            int didz;
            A.rast(out didz);
            Console.WriteLine(didz);
        }
        static DaugMiestu Skait(string duom)
        {
            DaugMiestu daug = new DaugMiestu();
            using (StreamReader skait = new StreamReader(duom))
            {
                string eil;
                while((eil=skait.ReadLine())!=null)
                {
                    string[] part = eil.Split(';');
                    string pav = part[0];
                    string sal = part[1];
                    int gyv = int.Parse(part[2]);
                    int plot = int.Parse(part[3]);
                    Miestas miest = new Miestas(pav, sal, gyv, plot);
                    daug.DetiMiesta(miest);
                }
            }
                return daug;
        }
        static DaugMiestu Kont(string salis, DaugMiestu M)
        {
            DaugMiestu sal = new DaugMiestu();
            
                for(int i=0;i<M.Kiek;i++)
            {
                if (M.imtiMiesta(i).sal == salis)
                    sal.DetiMiesta(M.imtiMiesta(i));
            }
            
            return sal;
        }
    }
}
