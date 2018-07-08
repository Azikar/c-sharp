using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
   public class Modulis
    {
        public Modulis(string pavad,string vardpav,int krd)
        {
            this.pavad = pavad;
            this.vardpav = vardpav;
            this.krd = krd;
          
        }
        public string pavad { get; set; }
        public string vardpav { get; set; }
        public int krd { get; set; }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("|{0,-20} | {1,-7} | {2,-8} |",pavad, vardpav, krd);
            return eil;
        }
    }
}
