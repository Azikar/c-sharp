using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Herojei : Herojus
    {
        public int strenth { get; set; }
        public int agi { get; set; }
        public int intel { get; set; }
        public string power { get; set; }
        public Herojei()
        {

        }
        public Herojei(string vardas = "", string rase = "", string klase = "", int HP = 0, int MP = 0,
            int def = 0, int strenth = 0, int agi = 0, int intel = 0, string power = "") : base(vardas, rase, klase, HP, MP, def)
        {
            this.strenth = strenth;
            this.agi = agi;
            this.intel = intel;
            this.power = power;
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0} {1,4}|{2,4}|{3,4}|{4,10}|", base.ToString(), strenth,agi, intel,power);
            return eil;
        }
        public override double Suma()
        {
            return strenth + agi + intel;
        }
    }
 
}
