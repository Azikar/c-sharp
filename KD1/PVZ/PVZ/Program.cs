using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace PVZ
{
    class Miestas
    {
        public string miestas { get; set; }
        public string valstybe { get; set; }
        public int gyv_sk { get; set; }
        public int plot { get; set; }
        public Miestas(string miestas,string valstybe,int gyv_sk,int plot)
        {
            this.miestas = miestas;
            this.valstybe = valstybe;
            this.gyv_sk = gyv_sk;
            this.plot = plot;
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0,-10}{1,-10}{2,10}{3,10}", miestas, valstybe, gyv_sk, plot);
            return eil;
        }


    }
    class DaugMiestu
    {
        private Miestas[] daug;
        public int kiek { get; set; }
        public DaugMiestu()
            {
            kiek = 0;
            daug = new Miestas[100];
            }
        public Miestas imtMiest(int i) { return daug[i]; }
        public void DetiMiesta(Miestas miest) { daug[kiek++] = miest; }
    }
    class Program
    {
        const string duom = "..\\..\\duom.txt";
        const string rez = "..\\..\\rez.txt";
      
        static void Main(string[] args)
        {
            DaugMiestu M;
            DaugMiestu A;
            if (File.Exists(rez))
                File.Delete(rez);
            M = skait(duom);
            spausdinti(M,rez);

        }
        static DaugMiestu skait(string fv)
        {
            DaugMiestu miest = new DaugMiestu();
            using (StreamReader duom = new StreamReader(fv))
            {
                string eil;
                while((eil=duom.ReadLine())!=null)
                {
                    string[] part = eil.Split(';');
                    string miestas = part[0];
                    string valst = part[1];
                    int gyv = int.Parse(part[2]);
                    int plot = int.Parse(part[3]);
                    Miestas miesta = new Miestas(miestas, valst, gyv, plot);
                    miest.DetiMiesta(miesta);
                }
            }
            return miest;
        }
        static DaugMiestu skait(string duom)
        {
            DaugMiestu miest = new DaugMiestu();
            using (StreamReader dum = new StreamReader(duom))
            {
                string eil;
                while((eil=dum.ReadLine())!=null)
                {
                    string[] part = eil.Split(';');
                    Miestas miesta = new Miestas();
                    miest.DetiMiesta(miesta);
                }
            }
                return miest;
        }
        static void spausdinti(DaugMiestu M,string rez)
        {
            using (var rz = new StreamWriter(File.Open(rez, FileMode.Append)))
            {
                for(int i=0;i<M.kiek;i++)
                {
                    rz.WriteLine(M.imtMiest(i));
                }
            }
            using (var fm = new StreamWriter(File.Open(rez, FileMode.Append)))
            {

            }
           
        }

    }
}
