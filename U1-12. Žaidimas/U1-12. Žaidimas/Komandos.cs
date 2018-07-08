using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_12.Žaidimas
{
    class Komandos
    {
        const int Cn = 500;
        private Zaidejas[] Kom;
        public int Kiek { get; set; }
        public Komandos()
        {
            Kiek = 0;
            Kom = new Zaidejas[Cn];
        }
        public Zaidejas ImtiZaideja(int i) { return Kom[i]; }
        public void DetiZaideja(Zaidejas zaid) { Kom[Kiek++] = zaid; }
        /// <summary>
        /// rikiuja pagal abc
        /// </summary>
        public void Rikiuoti()
        {
            for (int i = 0; i < Kiek; i++)
                for (int j = i + 1; j < Kiek; j++)
                {
                    if (Kom[i] < Kom[j])
                    {
                        Zaidejas zaid = Kom[i];
                        Kom[i] = Kom[j];
                        Kom[j] = zaid;
                    }
                } 
        }
        /// <summary>
        /// is sarasu pasalina nuos kurie neatitinka kriterijaus
        /// </summary>
        public void Salinti()
        {
            int z = 0;
            for (int i = 0; i < Kiek; i++)
                if (Kom[i].lav != "aukst")
                    Kom[z++] = Kom[i];
            Kiek = z;


        }

    }
}
