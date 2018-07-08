using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Rases
    {
        public string rase { get; set; }
        public int kiek{get;set;}
        public Rases(string rase, int kiek)
        {
            this.rase = rase;
            this.kiek = kiek;
        }
        public override string ToString()
        {
            string eil;
            eil = string.Format("{0,-16}{1,4}", rase, kiek);
            return eil;
        }
    }
}
