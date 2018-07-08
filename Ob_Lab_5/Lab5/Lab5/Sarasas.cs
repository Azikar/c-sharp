using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
    public sealed class Sarasas<Tipas>
    {
        Mazgas<Tipas> pr;
        Mazgas<Tipas> d;
        Mazgas<Tipas> pb;
        public Sarasas()
        {
            this.pr = null;
            this.d = null;
            this.pb = null;

        }
        public void Pradzia()
        {
            d = pr;

        }
        public void Kitas()
        {
            d = d.Kitas;
        }
        public bool Yra()
        {
            return d != null;
        }
        public Tipas imtiDuom() { return d.Duomenys; }
        public void DetiDuom(Tipas inf)
        {
            var d = new Mazgas<Tipas>(inf, null);
            if(pr!=null)
            {
                pb.Kitas = d;
                pb = d;
            }
            else
            {
                pr = d;
                pb = d;
            }

        }
    }
}
