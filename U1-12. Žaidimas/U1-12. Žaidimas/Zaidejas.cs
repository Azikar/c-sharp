using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_12.Žaidimas
{
    class Zaidejas
    {
        public string PavVard { get; set; }
        public string lyt { get; set; }
        public int age { get; set; }
        public string lav { get; set; }
        public int zaid_sk { get; set; }
        public int kl { get; set; }
        public Zaidejas(string vard,string lyt,int age,string lav,int zaid_sk,int kl)
        {
            PavVard = vard;
            this.lyt = lyt;
            this.age = age;
            this.lav = lav;
            this.zaid_sk = zaid_sk;
            this.kl = kl;
        }
        public string imtlav() { return lav; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0,-20}{1,5} {2,8}{3,12} {4,15} {5,15}", PavVard, lyt, age, lav, zaid_sk, kl);
            return eilute;
        }
        public static bool operator>(Zaidejas zaid1,Zaidejas zaid2)
        {
            int p = String.Compare(zaid1.PavVard, zaid2.PavVard, StringComparison.CurrentCulture);

            return (p < 0 || p == 0);
            
        }
        public static bool operator <(Zaidejas zaid1, Zaidejas zaid2)
        {
            int p = String.Compare(zaid1.PavVard, zaid2.PavVard, StringComparison.CurrentCulture);

            return (p > 0 || p == 0);
        }
        
        

    }
}
