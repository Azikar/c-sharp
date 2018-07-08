using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
   public class Studentas
    {
        
        public Studentas(string mod, string vard,string pav,string grupe)
        {
            this.mod = mod;
            this.vard = vard;
            this.pav = pav;
            this.grupe = grupe;

        }
        public string mod { get; set; }
        public string vard { get; set; }
        public string pav { get; set; }
        public string grupe { get; set; }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        
        public override string ToString()
        {
            string eil;
            eil = string.Format("|{0,-20} | {1,-7} | {2,-20} | {3,6}|",mod,vard,pav,grupe);
            return eil;
        }
        
    }
}
