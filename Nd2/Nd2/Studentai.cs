using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd2
{
    //saugo studento duom.
    class Studentai
    {
        const int Cn = 500;
        private Studentas[] Stud;
        public int Kiek { get; set; }
        public Studentai()
        {
            Kiek = 0;
            Stud = new Studentas[Cn];
        }        public Studentas ImtiStudenta(int i) { return Stud[i]; }        public void DetiStudenta(Studentas stud) { Stud[Kiek++] = stud; }
    }

}
