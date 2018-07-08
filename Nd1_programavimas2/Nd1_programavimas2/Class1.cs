using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd1_programavimas2
{
    class Class1
    {
        public string PavVrd { get; set; }
        public int Pazym { get; set; }
        public  Class1(string pavv, int pazym)
        {
            PavVrd = pavv;
            Pazym = pazym;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-20}    {i,2}", PavVrd, Pazym);
            return eilute;
        }
    }
}
