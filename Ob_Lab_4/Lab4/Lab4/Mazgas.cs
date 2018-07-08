using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
   public sealed class Mazgas
    {
        public Zaidejas Duomenys { get; set; }
        public Mazgas Kitas { get; set; }
        public Mazgas()
        { }
        public Mazgas(Zaidejas Duomenys,Mazgas Kitas)
        {
            this.Duomenys = Duomenys;
            this.Kitas = Kitas;
        }
       

    }
}
