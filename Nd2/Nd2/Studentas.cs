﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd2
{
    // vieno studento duom.
    class Studentas
    {
        public string PavVrd { get; set; }
        public int Pazym { get; set; }
        {
            PavVrd = pavv;
            Pazym = pazym;
        }
        {
            string eilute;
            eilute = string.Format("{0, -20} {1, 2}", PavVrd, Pazym);
            return eilute;
        }
    }
}