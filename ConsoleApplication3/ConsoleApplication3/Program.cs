using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static int[] sk = { 1, 3, 4 };
        static void Main(string[] args)
        {
            int n = 5;
            Console.WriteLine(count(n));
        }
        static int count(int n)
        {

            int[] table= new int [n+1];
            //table[1] = 1;
            //table[3] = 1;
            //table[2] = 1;
            //table[5] = 2;
            //table[4] = 2;
            table[0] = 1;

            for (int i = sk[0]; i <= n; i++)
                table[i] = table[i] + table[i - sk[0]];
            for (int i = sk[1]; i <= n; i++)
                table[i] = table[i] + table[i - sk[1]];
            for (int i = sk[2]; i <= n; i++)
                table[i] = table[i] + table[i - sk[2]];

            return table[n];

        }
    }
  
}
