using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Leidiniai
{
    /// <summary>
    /// Saugomi leidiniu failai
    /// </summary>
    class Leidinys
    {
        private string pavad;
        private int kaina;
        private string bankas;
        private int kodas, procentai, Kiekis = 0;
        public void Deti(string pav, int kaina, string bankas, int kodas, int procentai)
        {
            this.pavad = pav;
            this.kaina = kaina;
            this.bankas = bankas;
            this.kodas = kodas;
            this.procentai = procentai;
        }
        public void DetiKiek(int Kiek) { Kiekis = Kiek; }
        public string imtpav() { return pavad; }
        public int imtkaina() { return kaina; }
        public string imtbank() { return bankas; }
        public int imtkoda() { return kodas; }
        public int imtproc() { return procentai; }
        public int imtKiek() { return Kiekis; }
    }
    class leidykla
    {
        private Leidinys[] Leidiniai;
        public int n { get; set; }
        private int[,] A;
        public int m { get; set; }
        public leidykla()
        {
            n = 0;
            Leidiniai = new Leidinys[100];
            m = 0;
            A = new int[100, 30];
        }
        public Leidinys imti(int nr) { return Leidiniai[nr]; }
        public void Deti(Leidinys ob) { Leidiniai[n++] = ob; }
        public void DetiA(int i,int j,int r) {A[i, j] = r; }
        public int imtiA(int i,int j) { return A[i, j]; }
        public void pakeistleid(int nr,Leidinys lei) { Leidiniai[nr] = lei; }
        public void papild()
        {
            int suma;
            Leidinys lei;
            for (int i=0;i< n;i++)
            {
                suma = 0;
                for (int j = 0; j < m; j++)
                    suma = suma + A[i, j];
                lei = imti(i);
                lei.DetiKiek(suma);
                pakeistleid(i, lei);     
            }
        }
    }  
    class Program
    {
        const string duom = "...\\...\\duom.txt";
      //  const string duom2 = "...\\...\\duom1.txt";
        const string rez = "...\\...\\rez.txt";
        static void Main(string[] args)
        {
            if (File.Exists(rez))
                File.Delete(rez);
            int n, m;
           // string[] bankai= { "SEB", "DNB", "Swedbank", "Medicinos bankas", "Danske Bank" };
            
            leidykla leid1 = new leidykla();
            Skaityti(duom, ref leid1, out n, out m);
          //Spaustinti(rez, leid1);
            Skaitytkiek(duom, ref leid1, ref n, ref m);
          //Spausdintikiek(rez, leid1);
          //Console.WriteLine(leid1.m);
            int[] kiek;
            kiek = new int[n];
            kuris(leid1,kiek);
            Spaustinti(rez, leid1,kiek);
          //Spausdintikiek(rez, leid1);
        }
        /// <summary>
        /// perskaitoma leidiniu informacija
        /// </summary>
        /// <param name="fd"></param>
        /// <param name="leid1"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        static void Skaityti(string fd, ref leidykla leid1, out int n, out int m)
        {
            string pav, bankas; int kaina, kodas, procentai;
            string line;

            using (StreamReader reader = new StreamReader(fd))
            {
                line = reader.ReadLine();
                string[] parts;
                parts = line.Split(' ');
                n = int.Parse(parts[0]);
                m = int.Parse(parts[1]);
                leid1.m = m;
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    pav = parts[0];
                    kaina = int.Parse(parts[1]);
                    bankas = parts[2];
                    kodas = int.Parse(parts[3]);
                    procentai = int.Parse(parts[4]);
                    Leidinys lei;
                    lei = new Leidinys();
                    lei.Deti(pav, kaina, bankas, kodas, procentai);
                    leid1.Deti(lei);
                }
            }
        }
        /// <summary>
        /// skitoma matrica
        /// </summary>
        /// <param name="duom"></param>
        /// <param name="leid1"></param>
        /// <param name="n"></param>
        /// <param name="m"></param>
        static void Skaitytkiek(string duom, ref leidykla leid1, ref int n, ref int m)
        {
            int kiekis;
            string line;
            using (StreamReader reader = new StreamReader(duom))
            {
                line = reader.ReadLine();
                for(int i=0;i<leid1.n;i++)
                {
                    line = reader.ReadLine();
                }
                string[] parts;

                for (int i = 0; i < leid1.n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    for (int j = 0; j < leid1.m; j++)
                    {
                        kiekis = int.Parse(parts[j]);
                        leid1.DetiA(i, j, kiekis);

                    }
                }
            }
        }
        /// <summary>
        /// isvedami atsakymai
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="leid1"></param>
        /// <param name="kiek"></param>
        static void Spaustinti(string fv, leidykla leid1, int[] kiek)
        {
            string blog;
            string daug;
            using (var fr = File.AppendText(fv))
            {
                blog = leid1.imti(0).imtpav();
                daug = leid1.imti(0).imtpav();
                fr.WriteLine("Pavadinimas  Kiekis ");
                fr.WriteLine("____________________");
                for (int i = 0; i < leid1.n; i++)
                {
                    fr.WriteLine("{0,-10} {1,7}", leid1.imti(i).imtpav(), kiek[i]);
                }
                fr.WriteLine("____________________");
                for (int i = 0; i < leid1.n; i++)
                    for (int j = 0; j < leid1.n; j++)
                        if (kiek[i] > kiek[j])
                            blog = leid1.imti(j).imtpav();
                fr.WriteLine("Blogiausiai sekas '{0}' zurnalui", blog);
                for (int i = 0; i < leid1.n-1; i++)
                    for (int j = 0; j < leid1.n; j++)
                        if (kiek[i] * leid1.imti(i).imtkaina() < kiek[j] * leid1.imti(j).imtkaina())
                            daug = leid1.imti(j).imtpav();
                fr.WriteLine("daugiausiai uzdirbs {0}", daug);
                fr.WriteLine("____________________");
                fr.WriteLine(bankas(leid1,kiek));
            }
        }
        static void Spausdintikiek(string fv, leidykla leid1)
        {
            using (var fr = File.AppendText(fv))
            {
                for (int i = 0; i < leid1.n; i++)
                {
                    for (int j = 0; j < leid1.m; j++)
                        fr.Write("{0,3:d}", leid1.imtiA(i, j));
                    fr.WriteLine(" ");
                }
            }
        }
        static int kuris(leidykla leid1,int[] kiek)
            {
            int suma;
            for(int i=0;i<leid1.n;i++)
            {
                suma = 0;
                for(int j=0;j<leid1.m;j++)
                {
                    suma = suma + leid1.imtiA(i, j);
                }
                kiek[i] = suma;
            }
            
            return 0;
            }
        /// <summary>
        /// pervedimu info
        /// </summary>
        /// <param name="leid1"></param>
        /// <param name="kiek"></param>
        /// <returns></returns>
        static string bankas(leidykla leid1,int []kiek)
        {
            string[] mas = new string[100];
            string Q = "";
            int n=0;
            for(int i=0;i<leid1.n;i++)
            {
                int z = 0;
                for (int j = 0; j < n; j++)
                    if (leid1.imti(i).imtbank() == mas[j])
                        z++;
                if(z==0)
                {
                    mas[n] = leid1.imti(i).imtbank();
                    n++;
                }
            }
            for(int i=0;i< n;i++)
            {
                Q = Q + mas[i]+":\r\n";
                for(int j=0;j<leid1.n;j++)
                    if(leid1.imti(j).imtbank()==mas[i])
                {
                    Q = Q + leid1.imti(j).imtpav()+" "+leid1.imti(j).imtkoda()+" " +kiek[j]*leid1.imti(j) 
                            .imtkaina()+"Eu" ;
                    Q = Q + "\r\n";
                }
            }
            return Q;
        }
    }
}