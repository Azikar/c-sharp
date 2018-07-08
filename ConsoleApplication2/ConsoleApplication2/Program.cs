using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Main(string [] args)
        {
            int [] arr = { 1, 3, 4 }; // galimi skaiciai

            int m = arr.Length; // masyvo ilgis, kad butu galima pasiimti skaicius

            int n = 4;// sumos reiksme
            Console.WriteLine(countWays(arr, m, n));
        }
        static long countWays(int [] S, int m, int n)
        {
            Boolean meh = false;
            for (int i = 0; i < m; i++)
            {
                if (n >= S[i])
                    meh = true;
            }
            if (meh == false)
                return 0;
            long[] ats = new long[n+1]; //laiko kiek sprendiniu yra i reiksmei n+1 reikalingas nes cikle naudojame j<=n
            ats[0] = 1; //kadangi ats uzpildytas 0 tai pirmoji reiksme turi buti 1
            for (int i = 0; i < m; i++)
                for (int j = S[i]; j <= n; j++)
                {
                    ats[j] =ats[j]+ (ats[j - S[i]]);
                    Console.WriteLine(ats[j] + " " + S[i]);
                }

            return ats[n];
           
        }
    }

    


    }
