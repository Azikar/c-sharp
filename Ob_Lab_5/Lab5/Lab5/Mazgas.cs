﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
   public sealed class Mazgas<Tipas>
     //   where Tipas :IComparable<Tipas>
    {
        public Tipas Duomenys { get; set; }
        public Mazgas<Tipas> Kitas { get; set; }
        public Mazgas(Tipas duomenys,Mazgas<Tipas> adresas)
        {
            this.Duomenys = duomenys;
            this.Kitas = adresas;
        }
    }
}
