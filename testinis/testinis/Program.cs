using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testinis
{
    class Program
    {
        static long Count(int[] C, int m, int n)
        {
            var table = new long[n + 1];
            table[0] = 1;
            for (int i = 0; i < m; i++)
                for (int j = C[i]; j <= n; j++)
                    table[j] += table[j - C[i]];
            return table[n];
        }
        static void Main(string[] args)
        {
            var C = new int[] { 1, 3, 4 };
            int m = C.Length;
            int n = 5;
            Console.WriteLine(Count(C, m, n));  //242
            Console.ReadLine();
        }
    }
}
