using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
public class Knyga
{
    public string Pavadinimas { get; set; }
    public int Metai { get; set; }
    public int PuslapiuSk { get; set; }
    public Knyga(string pavad = "", int metai = 0, int puslSk = 0)
    {
        this.Pavadinimas = pavad;
        this.Metai = metai;
        this.PuslapiuSk = puslSk;
    }
    public override string ToString()
    {
        string eilute;
        eilute = string.Format("{0, -20} {1, 4:d} {2, 4:d}",
        Pavadinimas, Metai, PuslapiuSk);
        return eilute;
    }
}
// Klasė sąrašo vienam elementui saugoti
public sealed class Mazgas
{
    public Knyga Duom { get; set; } // duomenys
    public Mazgas Kitas { get; set; } // nuoroda į kitą elementą
    public Mazgas(Knyga duom, Mazgas adresas)
    {
        this.Duom = duom;
        this.Kitas = adresas;
    }
}
// Klasė knygų duomenims saugoti
public sealed class Sąrašas
{
    private Mazgas pr; // sąrašo pradžia
    private Mazgas pb; // sąrašo pabaiga
    private Mazgas ss; // sąrašo sąsaja
                       // Pradinės sąrašo nuorodų reikšmės
    public Sąrašas()
    {
        this.pr = null;
        this.pb = null;
        this.ss = null;
    }
    // Grąžina sąrašo sąsajos elemento reikšmę (duomenis)
    public Knyga ImtiDuomenis() { return ss.Duom; }
    // Sukuriamas sąrašo elementas ir prijungiamas prie sąrašo pabaigos
    // nauja – naujo elemento reikšmė (duomenys)
    public void DėtiDuomenisT(Knyga nauja)
    {
        // ATLIKITE: padėkite naują elementą sąrašo pabaigoje
        var d = new Mazgas(nauja, null);
        if(pr!=null)
        {
            d.Kitas = pr;
            pr = d;
        }
        else
        {
            pr = d;
            pb = d;
        }
    }
    // Sąsajai priskiriama sąrašo pradžia
    public void Pradžia() { ss = pr; }
    // Sąsajai priskiriamas sąrašo sekantis elementas
    public void Kitas() { ss = ss.Kitas; }
    // Grąžina true, jeigu sąsaja netuščia
    public bool Yra() { return ss != null; }
    // Šalina sąsajos rodomą elementą
    public void Salinti(Knyga kel)
    {
        // ATLIKITE: pašalinkite sąsajos rodomą elementą
        Mazgas dd = pr;
        if (pr!=null)
        {
            pr = pr.Kitas;
        }
        else
            while(dd.Kitas!=null)
            {
                if(dd.Kitas.Duom!=kel)
                {
                    dd.Kitas = dd.Kitas.Kitas;
                    return;
                }
            }
    }
}
class Program
{
    static void Main(string[] args)
    {
        const string CFd = @"..\..\Knygos.txt";
        const string CFr = @"..\..\Rezultatai.txt";
        if (File.Exists(CFr))
            File.Delete(CFr);
        string antraste=" ";
        Sąrašas Knygos = ĮvestiTiesiog(CFd);
        Spausdinti(CFr, Knygos, antraste);
        Console.WriteLine("Iveskite norima skaiciu");
        int sk = int.Parse(Console.ReadLine());
        Išmesti(Knygos, sk);
        Spausdinti(CFr, Knygos, antraste);
        var Knyg = new Knyga("pav", 10, 100);
        int vieta = 0;
        // Knygos.Pradžia();
        //Console.WriteLine( Knygos.ImtiDuomenis().Pavadinimas.Count());

        // ATLIKITE: skaitykite duomenis iš failo į tiesioginį sąrašą Knygos,
        // spausdinkite duomenis, pašalinkite knygas,
        // kurių pavadinime yra daugiau nei nurodytas knygų skaičius,
        // spausdinkite sąrašą.
        Console.WriteLine("Programa darbą baigė.");
    }
    // Skaitomos objektų reikšmės iš failo ir sudedamos į sąrašą tiesiogine tvarka
    // fv – duomenų failo vardas
    // Grąžina - sąrašo objekto nuorodą
    static Sąrašas ĮvestiTiesiog(string fv)
    {
        Sąrašas A = new Sąrašas();
        using (var failas = new StreamReader(fv, Encoding.GetEncoding(1257)))
        {
            string pavad;
            int metai;
            int pslSk;
            string eilute;
            while ((eilute = failas.ReadLine()) != null)
            {
                var eilDalis = eilute.Split(';');
                pavad = eilDalis[0];
                metai = Convert.ToInt32(eilDalis[1]);
                pslSk = Convert.ToInt32(eilDalis[2]);
                var Knyga = new Knyga(pavad, metai, pslSk);
                A.DėtiDuomenisT(Knyga);
            }
        }
        return A;
    }
    // Sąrašo A duomenys spausdinami lentele faile fv
    // fv – duomenų failo vardas
    // A - sąrašo objekto adresas
    // antraste - lentelės pavadinimas
    static void Spausdinti(string fv, Sąrašas A, string antraste)
    {
        using (var failas = new StreamWriter(fv, true))
        {
            failas.WriteLine(antraste);
            failas.WriteLine("-------------------------------------");
            failas.WriteLine("Pavadinimas Metai Puslapiai ");
            failas.WriteLine("-------------------------------------");
            // Sąrašo peržiūra, panaudojant sąsajos metodus
            for (A.Pradžia(); A.Yra(); A.Kitas())
            {
                failas.WriteLine(A.ImtiDuomenis());
            }
            failas.WriteLine("-------------------------------------\n");
        }
    }
    // Iš sąrašo išmeta knygas, kurių pavadinime yra didesnis nei nurodytas žodžių skaičius
    // A - sąrašo objekto adresas
    // zodSkaicius - žodžių skaičius knygos pavadinime
    static void Išmesti(Sąrašas A, int zodSkaicius)
    {
        // ATLIKITE: pašalinkite iš sąrašo knygas, kurių pavadinime yra didesnis nei
        // nurodytas žodžių skaičius
        string skir = ".,;:!?- ";
        
        int skaicius;

        for (A.Pradžia(); A.Yra(); A.Kitas())
             
        {
            
            
            int sk = A.ImtiDuomenis().Pavadinimas.Count();
            
                
            if (sk!=0)
            {
                skaicius = 1;
                for (int i = 0; i < sk; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (A.ImtiDuomenis().Pavadinimas[i] == skir[j])
                            skaicius++;
                    }
                }
                Console.WriteLine(skaicius);
                if (skaicius>zodSkaicius)
                {
                    Knyga kn = A.ImtiDuomenis();
                    A.Salinti(kn);
                }
            }
        }
    }
}
