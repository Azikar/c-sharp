using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace date_time
{
    public class Asmuo
    {
        public string pavVard { get; set; } // pavardė, vardas
        public int amžius { get; set; } // amžius
        public TimeSpan laikas { get; set; } // atvykimo laikas
        public Asmuo(string pavVard, int amžius, TimeSpan laikas)
        {
            this.pavVard = pavVard;
            this.amžius = amžius;
            this.laikas = laikas;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -17} {1} {2}", pavVard, amžius, laikas);
            return eilute;
        }

        // Užklotas metodas GetHashCode()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    class Program
    {
        const string CFd1 = "..\\..\\Asmenys.txt"; // asmenų duomenų failo vardas
        static void Main(string[] args)
        {
            // Asmenų sąrašo sudarymas ir spausdinimas
            List<Asmuo> AsmenuList = SkaitytiAsmuoList(CFd1);
            SpausdintiAsmenuList(AsmenuList, "Pradiniai duomenys");
            Queue<Asmuo> Eile = new Queue<Asmuo>();
            TimeSpan atvykimoPradzia = new TimeSpan(7, 0, 0); // tikrinamo laiko intervalo pradžia
            TimeSpan atvykimoPabaiga = new TimeSpan(10, 0, 0); // tikrinamo laiko intervalo pabaiga
            TimeSpan žingsnis = new TimeSpan(0, 10, 0); // laiko intervalo peržiūros žingsnis
            int[] Raktai = { 7, 9, 4, 1, 6, 2, 3 }; // žodyno raktai
            Atrinkti(AsmenuList, Eile, atvykimoPradzia, atvykimoPabaiga, žingsnis);
            Console.WriteLine(" Kiekis:{0}", Eile.Count);
            Console.WriteLine("Pirmas elem{0}", Eile.Peek());
            SortedDictionary<int, Asmuo> Zodynas = new SortedDictionary<int, Asmuo>();
          int  amzius = Eile.Peek().amžius;
            Formuoti(AsmenuList, Zodynas, amzius, Raktai);
            Console.WriteLine("spausdina zodyna");
            Spausdinti(Zodynas);
                                                    // ATLIKITE: visus nurodytus skaičiavimus
        }
        // spausdina asmenų duomenų lentelę
        static void SpausdintiAsmenuList(List<Asmuo> AsmuoList, string antraste)
        {
            const string virsus =
            "------------------------------------------------- \r\n"
            + " Nr. Pavardė, vardas Amžius Atvykimo laikas \r\n"
            + "-------------------------------------------------";
            Console.WriteLine("\n " + antraste);
            Console.WriteLine(virsus);
            for (int i = 0; i < AsmuoList.Count; i++)
            {
                Asmuo zmog = AsmuoList[i];
                Console.WriteLine("{0, 3} {1}", i + 1, zmog);
            }
            Console.WriteLine("--------------------------------------------------\n");
        }

        // skaito asmenų duomenų failą
        static List<Asmuo> SkaitytiAsmuoList(string fv)
        {
            // asmenų dinaminis masyvas
            List<Asmuo> AsmuoList = new List<Asmuo>();
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string pav = eilDalis[0];
                    int amžius = int.Parse(eilDalis[1]);
                    TimeSpan laikas = TimeSpan.Parse(eilDalis[2]);
                    Asmuo naujas = new Asmuo(pav, amžius, laikas);
                    AsmuoList.Add(naujas);
                }
            }
            return AsmuoList;
        }
        // spausdina žodyno reikšmes
        // naudoja ENumerator
        public static void Spausdinti(SortedDictionary<int, Asmuo> zodynas)
        {
            var enumerator = zodynas.GetEnumerator();
            while (enumerator.MoveNext())
            {
                object item = enumerator.Current;
                Console.WriteLine(" {0} ", item);
            }
            Console.WriteLine();
        }
        // Formuoja eilę
        static void Atrinkti(List<Asmuo> AsmenuList, Queue<Asmuo> Eile,
        TimeSpan atvykimoPradzia, TimeSpan atvykimoPabaiga,
        TimeSpan žingsnis)
        {
            // ATLIKITE: Dinaminio masyvo asmenys, kurių atvykimo laikas yra duotame
            double visomin = atvykimoPradzia.TotalSeconds;
            double visozin = žingsnis.TotalSeconds;
            for(int i=0;i<AsmenuList.Count();i++)
            {
                if (AsmenuList[i].laikas == atvykimoPradzia && visomin % visozin == 0)
                    Eile.Enqueue(AsmenuList[i]);
            }
            // intervale [atvykimoPradzia, atvykimoPradzia] ir yra kartotinis duotam
            // žingsniui žingsnis, įrašomi į eilės konteinerį.
          
        }
        // Formuoja žodyną
        static void Formuoti(List<Asmuo> AsmenuList, SortedDictionary<int, Asmuo> Zodynas,
        int metai, int[] Raktai)
        {
            for(int i=0;i<AsmenuList.Count;i++)
            {
                if(AsmenuList[i].amžius>metai)
                {
                    Zodynas.Add(Raktai[i], AsmenuList[i]);
                }

                
            }
            // ATLIKITE: Dinaminio masyvo asmenys, kurių amžius didesnis už duotą sveiką skaičių
            // metai, surašomi į rikiuotą žodyną. Žodyno raktai – sveiki skaičiai, paeiliui imami
            // iš duoto sveikų skaičių masyvo Raktai, o reikšmės – Asmuo klasės objektai.
        }
    }
}
