using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    abstract public class Herojus:IComparable<Herojus>
    {
        public string vardas { get; set; }
        public string rase { get; set; }
        public string klase { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }
        public int def { get; set; }
       
       

        public Herojus()
        {

        }
        public  Herojus(string vardas="", string rase="", string klase="", int HP=0, int MP=0,
            int def=0)
        {
            this.vardas = vardas;
            this.rase = rase;
            this.klase = klase;
            this.HP = HP;
            this.MP = MP;
            this.def = def;
            
          
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("|{0,-16}| {1,-16}|{2,-16}|{3,4}|{4,4}|{5,4}|",vardas,rase,klase,HP,MP,def);
            return eil;

        }
        public int CompareTo(Herojus kita)
        {
            int ras = string.Compare(this.rase, kita.rase, StringComparison.CurrentCulture);
            int var = string.Compare(this.vardas, kita.vardas, StringComparison.CurrentCulture);
            if ((ras > 0)|| (var > 0))
                return 1;
            else 
                return -1;

        }
        abstract public double Suma();
        
    }
}