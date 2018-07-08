using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
namespace _10_Kopijavimas
{
    class Kopija
    {
        private string pav, formatas,Vp_Dp,funkcija,grupavimas;
        private int lapu_sk, kop_sk;
        public Kopija()
        {
            pav = " ";
            lapu_sk = 0;
            formatas = " ";
            Vp_Dp = " ";
            funkcija = " ";
            grupavimas = " ";
            kop_sk = 0;
        }
        public Kopija(string pav,string formatas,int lapu_sk,int kop_sk,string Vp_Dp,string grupavimas,string funkcija)
        {
            this.pav = pav;
            this.lapu_sk = lapu_sk;
            this.formatas = formatas;
            this.Vp_Dp = Vp_Dp;
            this.funkcija = funkcija;
            this.grupavimas = grupavimas;
            this.kop_sk = kop_sk;
        }
        public string imtpav() { return pav; }
        public string imtfr() { return formatas; }
        public int imtlap() { return lapu_sk; }
        public int imtkop() { return kop_sk; }
        public string imtpuse() { return Vp_Dp; }
        public string imtgrup() { return grupavimas; }
        public string imtfu() { return funkcija; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("|{0,-10} |{1,4} |{2,4} |{3,10} |{4,10} |{5,10} |{6,10}|",pav, formatas, lapu_sk, kop_sk, Vp_Dp, grupavimas,funkcija);
            return eilute;
        }
        public static bool operator >=(Kopija kp1, Kopija kp2)
        {
        int p = String.Compare(kp1.imtfr(), kp2.imtfr(), StringComparison.CurrentCulture);
             bool v = (kp1.imtkop() * kp1.imtlap() >= kp2.imtkop() * kp2.imtlap());
            
             return (p < 0 || (p == 0 && v));
           // return ( v);
        }
        public static bool operator <=(Kopija kp1, Kopija kp2)
        {
         int p = String.Compare(kp1.imtfr(), kp2.imtfr(), StringComparison.CurrentCulture);
            bool v =(kp1.imtkop()*kp1.imtlap() <= kp2.imtkop()*kp2.imtlap());
           return (p > 0 || (p == 0 && v ));
        }
      

    }
    class Kopijos
    {
        private Kopija[] K;
        private int kiek;
        public Kopijos()
        {
            kiek = 0;
            K = new Kopija[100];
        }
        public Kopija imtko(int i) { return K[i]; }
        public int imtkiek() { return kiek; }
        public void detikopija(Kopija kopzz)
        { K[kiek++] = kopzz; }
        
        public void Rikiuoti()
        {
            for (int i = 0; i <kiek -1; i++)
            {
                Kopija min = K[i];
                int im = i;
                for (int j = i + 1; j < kiek; j++)
                    if (K[j] >= min)
                    { // naudojamas užklotas operatorius <=
                        min = K[j];
                        im = j;
                    }
                K[im] = K[i];
                K[i] = min;
            }
        }

    }
    class atrinkt 
  
    {
        private Kopija[] A;
        private int kiek;
        public atrinkt()
        {
            A = new Kopija[100];
            kiek = 0;
        }
        public Kopija imtko(int i) { return A[i]; }
        public int imtkiek() { return kiek; }
        public void detikopija(Kopija atr)
        { A[kiek++] = atr; }
    }

    class Program
    {
        const string Failas = "...//...//Duom.txt";
        static void Main(string[] args)
        {
            Kopijos K = new Kopijos();
            atrinkt A = new atrinkt();
            int kiek,sus_sk,ism_sk;
            skaitymas(Failas, ref K, out kiek);
            Kopija[] mas = new Kopija[K.imtkiek()];
            Kopija[] mas1 = new Kopija[K.imtkiek()];
            Kopija[] mas2 = new Kopija[K.imtkiek()];
            Kopija[] mas3 = new Kopija[K.imtkiek()];
            veiksmai(ref K, mas,mas2, out kiek,out sus_sk,out ism_sk);
            K.Rikiuoti();
            string pav, formatas, Vp_Dp, funkcija, grupavimas, line;
            int lapu_sk, kop_sk;
            //  Array.Sort(mas2, mas2);
            int  kiek1 = 0;
           for (int i = 0; i < kiek; i++)
            {
               
                if (K.imtko(i).imtpuse() == "vienpusis")
                {
                    pav = K.imtko(i).imtpav();
                    formatas= K.imtko(i).imtfr();
                    lapu_sk= K.imtko(i).imtlap();
                    kop_sk = K.imtko(i).imtkop();
                    Vp_Dp = K.imtko(i).imtpuse();
                    grupavimas = K.imtko(i).imtgrup();
                    funkcija = K.imtko(i).imtfu();
                    Kopija atr = new Kopija(K.imtko(i).imtpav(), formatas, lapu_sk, kop_sk, Vp_Dp, grupavimas, funkcija);
                    A.detikopija(atr);


                    kiek1++;
                }
                
            }
           // rasymas(ref K, mas, mas1,mas2, ref kiek,ref kiek1);
            Console.WriteLine("ismusimo funkcija");
            Console.WriteLine(ism_sk);
            Console.WriteLine("susegimo funkcija");
            Console.WriteLine(sus_sk);
            // Console.WriteLine(mas2[0].ToString());
            //  int min = K.imtkop(0).imtkop() * K.imtkop(0).imtlap();
            int end = kiek1;
            //----------------------------------------------------------

            
          //  for (int i=0;i<kiek1-1;i++)
         //   {
          //      for(int j=i+1;j<kiek1;j++)
             //   {
               //     if (mas2[i].imtkop()*mas2[i].imtlap()< mas2[j].imtkop() * mas2[j].imtlap())
               //     {
                //       mas3[0] = mas2[i];
                //        mas2[i] = mas2[j];
               //         mas2[j] = mas3[0];
                       
               //     }
             //   }
                
//}
           
            rasymas(ref K, mas, mas1, mas2, ref kiek, ref kiek1,ref A);
        }
     
        static void skaitymas(string Failas,ref Kopijos K,out int kiek)
        {
             string pav, formatas, Vp_Dp, funkcija, grupavimas,line;
             int lapu_sk,kop_sk ;
            kiek = 0;
            using (StreamReader reader = new StreamReader(Failas))
            {
                string[] parts;
                while((line=reader.ReadLine())!=null)
                {
                    
                    parts = line.Split(' ');
                    pav = parts[0];
                    formatas = parts[1];
                    lapu_sk = int.Parse(parts[2]);
                    kop_sk = int.Parse(parts[3]);
                    Vp_Dp = parts[4];
                    grupavimas = parts[5];
                    funkcija = parts[6];
                    Kopija kop = new Kopija(pav,formatas, lapu_sk, kop_sk, Vp_Dp, grupavimas, funkcija);
                    K.detikopija(kop);
                   
                    kiek++;
                          
                }
            }
    }
     static void veiksmai(ref Kopijos K,Kopija[] mas,Kopija[] mas2,out int kiek,out int sus_sk,out int ism_sk )
        {
            sus_sk = 0;
            kiek = 0;
            ism_sk = 0;
           
            for(int i=0;i<K.imtkiek();i++)
            {
                mas[i] = K.imtko(i);
                kiek++;
                if (K.imtko(i).imtfu() == "susegimas")
                    sus_sk++;
                if (K.imtko(i).imtfu() == "ismusimas")
                    ism_sk++;
               }
           
        }
        static void rasymas(ref Kopijos K,Kopija[] mas,Kopija[] mas1,Kopija[] mas2, ref int kiek,ref int kiek1,ref atrinkt A)
        {
            int cik = 0;
           // Console.WriteLine(kiek1);
            Console.WriteLine("________________________________________________________________________");
            Console.WriteLine("|                   Kopijos                                            |");
            Console.WriteLine("|______________________________________________________________________|");

            for(int i=0;i<kiek; i++)
            {
                Console.WriteLine("{0}",mas[i].ToString());
                
                
            }
            for (int i = 0; i < kiek; i++)
            {
                if (cik < K.imtko(i).imtkop() * K.imtko(i).imtlap())
                {
                    cik = K.imtko(i).imtkop() * K.imtko(i).imtlap();
                    mas1[0] = K.imtko(i);
                }
                //Console.WriteLine("{0}", mas1[0].ToString());
            }
            Console.WriteLine("|______________________________________________________________________|");
            Console.WriteLine("|                   vienpuses kopijos  pagal kopiju skaiciu maz tvarka |");
            Console.WriteLine("|______________________________________________________________________|");
            for (int i=0;i<kiek1;i++)
            {
              Console.WriteLine("{0}", A.imtko(i).ToString());
                
            }
            Console.WriteLine("|______________________________________________________________________|");
            Console.WriteLine("daugiausiai ciklu");
            Console.WriteLine("{0}", mas1[0].ToString());
            
        }
    }
}
