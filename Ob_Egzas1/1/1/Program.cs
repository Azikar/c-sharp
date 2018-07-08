using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace _1
{
    public class Asmuo:IComparable<Asmuo>
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
        //public bool Equals(Asmuo a1,Asmuo a2)
        //{
        //    return a1.amžius == a2.amžius;
        //}
        //public int Compare(Asmuo kitas, Asmuo kitas1)
        //{
        //    if (kitas.amžius > kitas1.amžius)
        //        return 1;
        //    if (kitas.amžius < kitas1.amžius)
        //        return -1;
        //    else return 0;

        // }
        //public override bool Equals(object obj)
        //{
        //    Asmuo asm = obj as Asmuo;
        //    return asm.pavVard == pavVard && asm.amžius == amžius;
        //}
        //public int CompareTo(Asmuo kitas)
        //{
        //    int poz = string.Compare(this.pavVard, kitas.pavVard, StringComparison.CurrentCulture);
        //    if (poz > 0) return 1;
        //    if (poz < 0) return -1;
        //    else
        //        if (this.amžius > kitas.amžius) return 1;
        //    else if (this.amžius < kitas.amžius) return -1;
        //    else return 0;
        //}
        //public override bool Equals(object obj)
        //{
        //    Asmuo asm = obj as Asmuo;
        //    return asm.pavVard == pavVard && asm.amžius == amžius;
        //}
        public int CompareTo(Asmuo kitas)
        {
            int poz = string.Compare(this.pavVard, kitas.pavVard, StringComparison.CurrentCulture);
            if (poz < 0) return 1;
            if (poz > 0) return -1;
            else
                if (this.amžius > kitas.amžius) return 1;
            else if (this.amžius < kitas.amžius) return -1;
            else return 0;
        }
    }
    class Program
    {
        const string CFd1 = "..\\..\\Asmenys.txt"; // asmenų duomenų failo vardas
        static void Main(string[] args)
        {
            // Asmenų sąrašo sudarymas ir spausdinimas
            List<Asmuo> AsmenuList = SkaitytiAsmuoList(CFd1);
            AsmenuList.Sort();
            SpausdintiAsmenuList(AsmenuList, "Pradiniai duomenys");
            Queue<Asmuo> Eile = new Queue<Asmuo>();
            SortedDictionary<int , Asmuo> zodynas = new SortedDictionary<int, Asmuo>( );
            TimeSpan atvykimoPradzia = new TimeSpan(7, 0, 0); // tikrinamo laiko intervalo pradžia
            TimeSpan atvykimoPabaiga = new TimeSpan(10, 0, 0); // tikrinamo laiko intervalo pabaiga
            TimeSpan žingsnis = new TimeSpan(0, 10, 0); // laiko intervalo peržiūros žingsnis
            int[] Raktai = { 7, 9, 4, 1, 6, 2, 3 }; // žodyno raktai
            Atrinkti(AsmenuList, Eile, atvykimoPradzia, atvykimoPabaiga, žingsnis);
            Console.WriteLine(Eile.Count);
            if(Eile.Count!=0)
            Console.WriteLine(Eile.Peek());
            int metai = Eile.Peek().amžius;
            Formuoti(AsmenuList, zodynas, metai,Raktai);
            Spausdinti(zodynas);

            var did = zodynas.Max(elem => elem.Key);
           
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
            for (int i = 0; i < AsmenuList.Count; i++)
            {
                for (TimeSpan laikas=atvykimoPradzia;laikas<=atvykimoPabaiga;laikas=laikas+ žingsnis)
            {
               
                    if(AsmenuList[i].laikas==laikas&& AsmenuList[i].laikas.TotalMinutes% žingsnis.TotalMinutes==0)
                    {
                        Eile.Enqueue(AsmenuList[i]);
                       
                        
                    }
                }
            }
            // ATLIKITE: Dinaminio masyvo asmenys, kurių atvykimo laikas yra duotame
            // intervale [atvykimoPradzia, atvykimoPradzia] ir yra kartotinis duotam
            // žingsniui žingsnis, įrašomi į eilės konteinerį.
        }
        // Formuoja žodyną
        static void Formuoti(List<Asmuo> AsmenuList, SortedDictionary<int, Asmuo> Zodynas,
        int metai, int[] Raktai)
        {
            int j = 0;
            for(int i=0;i<AsmenuList.Count;i++)
            {
                if (AsmenuList[i].amžius > metai)
                    Zodynas.Add(Raktai[j], AsmenuList[i]);
                j++;
            }
            // ATLIKITE: Dinaminio masyvo asmenys, kurių amžius didesnis už duotą sveiką skaičių
            // metai, surašomi į rikiuotą žodyną. Žodyno raktai – sveiki skaičiai, paeiliui imami
            // iš duoto sveikų skaičių masyvo Raktai, o reikšmės – Asmuo klasės objektai.
        }
    }
}
