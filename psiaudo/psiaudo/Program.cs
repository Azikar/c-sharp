using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace psiaudo
{
    class CustomData
    {
        public int TNum;
        public int TResult;
    }

    class Program
    {
        static int[] S = new int[100000];
        static int[] P = new int[100000];
        static int kiekis = 0;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10000; i++)
            {
                S[i] = i;
                P[i] = i;

            }
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            int meh = F1(39, 39);
            stopWatch.Stop();
            Console.WriteLine(meh);
            Console.WriteLine("op kiekis: {0}  Laikas : {1}", kiekis, stopWatch.Elapsed);
            kiekis = 0;
            Stopwatch sstopWatch = new Stopwatch();
           // sstopWatch.Start();
           // int mah = F2(40, 40);
           // sstopWatch.Stop();
           // Console.WriteLine("op kiekis: {0}  Laikas : {1}", kiekis, sstopWatch.Elapsed);

            sstopWatch = new Stopwatch();
            sstopWatch.Start();
            int c=F11(39, 39);
            sstopWatch.Stop();
            Console.WriteLine("sk: {0}  Laikas : {1}", c, sstopWatch.Elapsed);

        }

        static int F1(int k, int r)
        {
            int a, b;
            if (k == 0 || r == 0)
            {
                kiekis = kiekis + 1;
                return 0;

            }


            kiekis = kiekis + 3;

            if (S[k] > r) { kiekis = kiekis + 2; return F1(k - 1, r); }


            else
            {
                kiekis = kiekis + 1;
                a = F1(k - 1, r);
                b = P[k] + F1(k - 1, r - S[k]);
                kiekis = kiekis + 2;
                int c = Math.Max(a, b);
                return c;
            }



        }
        static int F11(int k,int r)
            {
            int c = 0;
            if (k == 0 || r == 0)
            {
                kiekis = kiekis + 1;
                return 0;

            }
            if (S[k] > r) { kiekis = kiekis + 2; return F1(k - 1, r); }            else
            {
                int countCPU = 2;
                Task[] tasks = new Task[countCPU];

                tasks[0] = Task.Factory.StartNew(
                (Object p) =>
                {
                    var data = p as CustomData; if (data == null) return;
                    data.TResult = F1(k - 1, r);

                },
                new CustomData() { TNum = 0 });
                tasks[1] = Task.Factory.StartNew(
                    (Object p) =>
                    {
                        var data = p as CustomData; if (data == null) return;
                        data.TResult = F1(k - 1, r - S[k]);

                    },
                    new CustomData() { TNum = 1 });
                Task.WaitAll(tasks);
                c = Math.Max((tasks[0].AsyncState as CustomData).TResult, P[k]+(tasks[1].AsyncState as CustomData).TResult);

            }
            return c;


        }
       static int F2(int n,int w)
        {
            
            int k = 0, r = 0;
            int[,] x = new int[n,w];
            kiekis = kiekis + 3;
            for(r=1;r<w;r++)
            {
                for(k=1;k<n;k++)
                {
                    kiekis = kiekis + 1;
                    if (S[k] > r)
                    {
                        x[k, r] = x[k - 1, r];
                        kiekis = kiekis + 2;
                    }
                    else
                    {
                        x[k, r] = Math.Max(x[k - 1, r], P[k] + x[k - 1, r - S[k]]);
                        kiekis = kiekis + 2;
                    }
                }
            }
            int rowLength = x.GetLength(0);
            int colLength = x.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", x[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
            return 0;
        }
    }
}
