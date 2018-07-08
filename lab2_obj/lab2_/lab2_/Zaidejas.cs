using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_
{
    class Zaidejai: IComparable<Zaidejai>
    {
        public string PavVard { get; set; }
        public string lyt { get; set; }
        public int age { get; set; }
        public string lav { get; set; }
        public int zaid_sk { get; set; }
        public int kl { get; set; }
        public Zaidejai(string vard, string lyt, int age, string lav, int zaid_sk, int kl)
        {
            PavVard = vard;
            this.lyt = lyt;
            this.age = age;
            this.lav = lav;
            this.zaid_sk = zaid_sk;
            this.kl = kl;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-20},{1,5},{2,8},{3,12},{4,15},{5,15},", PavVard, lyt, age, lav, zaid_sk, kl);
            return eilute;
        }
        public override bool Equals(object objektas)
        {
            Zaidejai stud = objektas as Zaidejai;
            return stud.PavVard == PavVard;
        }
        // Užklotas metodas GetHashCode()
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public int CompareTo(Zaidejai kitas)
        {
            int poz = String.Compare(this.PavVard, kitas.PavVard,
                                    StringComparison.CurrentCulture);
            if (poz > 0)
                return 1;
            if (poz < 0)
                return -1;
            else
                return 0;

        }
        public static bool operator >(Zaidejai zaid1,Zaidejai zaid2)
        {
            int p = String.Compare(zaid1.PavVard, zaid2.PavVard, StringComparison.CurrentCulture);
            return (p < 0 || p == 0);
        }
        public static bool operator <(Zaidejai zaid1, Zaidejai zaid2)
        {
            int p = String.Compare(zaid1.PavVard, zaid2.PavVard, StringComparison.CurrentCulture);
            return (p > 0 || p == 0);
        }
    }
}


