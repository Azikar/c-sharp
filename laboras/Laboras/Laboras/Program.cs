using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _u10lab
{
    class Program
    {
        const string CFd = "..\\..\\Duomenys.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        static void Main(string[] args)
        {
            Apdoroti(CFd, CFr);
            Console.WriteLine("Programa baigė darbą!");
        }
        /// <summary>
        /// Skaitymas ir apdorojimas
        /// </summary>
        /// <param name="fv"></Duomenu failas>
        /// <param name="fvr"></ Rezultatu failas>
        static void Apdoroti(string fv, string fvr)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            using (var fr = File.CreateText(fvr))
            {                       
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            string nauja = line;
                            Redagavimas(line, out nauja);
                            if (nauja.Length > 0)
                                fr.WriteLine(nauja);
                        }
                    }
            }
        }
        /// <summary>
        /// Redagavimas
        /// </summary>
        /// <param name="line"></perskaityta eilute>
        /// <param name="nauja"></naujai kuriama eilute kuria graziname>
        /// <returns></returns>
        static bool Redagavimas(string line, out string nauja)
        {
            char[] mass = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] mass2 = { ',', '.', '-', ';', ':', '?', '!' };
            string eil;
            eil = line;
          //  string[] parts = eil.Split(mass2, StringSplitOptions. RemoveEmptyEntries);
            nauja = eil;         
            int a = 0;
            int yra = 0;
            int ilgis = 0;
        //    foreach (string line in lines)
          {
                for (int i = 0; i < eil.Length; i++)
                {
                   
            }
            }
            
            for (int i = 0; i < line.Length ; i++)
            {
                    for (int j = 0; j <= 9; j++)
                    {
                        if (line[i] == mass[j] && line[i + 1]!=' ')
                    {
                       
                       eil = nauja.Insert(a, line[i].ToString());
                       nauja = eil.Remove(i+1,1);                      
                       a++;
                       yra++;
                   }               
                }                
                if(yra>0)
                {
                    for(int b=0;b<=5;b++)
                    {
                        if (line[i] == mass2[b])
                        {
                            eil = nauja.Insert(a, line[i].ToString());
                            nauja = eil.Remove(i+1 ,1) ;
                           a++;
                        }
                    }
                }
            } 
            return false;
        }
    }
}

