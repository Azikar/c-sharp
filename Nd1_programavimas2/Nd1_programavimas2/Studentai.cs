using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nd1_programavimas2
{
    class Studentai
    {
        const int Cn = 500;
        private Class1[] stud;
        public int Kiek { get; set; }
        public Studentai()
        {
            Kiek = 0;
            stud = new Class1[Cn];
        }
        public Class1 imtiStud(int i) { return stud[i]; }

        public void DetiStud(Class1 Stud) { stud[Kiek++] = Stud; }

    }
}
