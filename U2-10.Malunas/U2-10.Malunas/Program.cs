using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_10.Malunas
{
    class Grudai
    {
        private string rusis;
        private double rupumas,
                       malim_nuostoliai,
                       tankis;
        public Grudai(string rusis, double rupumass,double malim_nuost,double tank)
        {
            this.rusis = rusis;
            rupumas = rupumass;
            malim_nuostoliai = malim_nuost;
           tankis = tank;
        }
        public string imtrusi() { return rusis; }
        public double imtrupumas() { return rupumas; }
        public double imtnuostolis() { return malim_nuostoliai; }
          public double imttankis() { return tankis; }

    }
    class Malunas
    {
        private string pavadinimas;
        private double pirm,
                        antr,
                        tret,
                        turis;
   public Malunas(string pavadinimass ,double pirm ,double antr ,double tret,double turis)
        {
            this.pavadinimas = pavadinimass;
            this.pirm=pirm;
            this.antr=antr;
            this.tret=tret;
            this.turis = turis;
        }
        public string imtpav() { return pavadinimas; }
        public double imtpirm() { return pirm; }
        public double imtantr() { return antr; }
        public double imttret() { return tret; }
        public double imtturi() { return turis; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string rus,pavad;
            double rupum,
                   nuost,
                   rupiaus = 0,
                   tankis,
                   turis,
                   maz=100,

                   bendras_miltu_kiekis;
                   
// reikiamas miltu kiekis:
              double   pirm,
                        antr,
                        tret;                   
            Console.Write("Įveskite grudų rūšį: ");
            rus = Console.ReadLine();
            Console.Write("Rupumas: ");
            rupum = double.Parse(Console.ReadLine());
            Console.Write("Nuostoliai %: ");
            nuost = double.Parse(Console.ReadLine());
            Console.Write("miltu tantis kg/m3: ");
            tankis = double.Parse(Console.ReadLine());
                                 
            Grudai rusis1;
            rusis1 = new Grudai(rus,rupum,nuost,tankis);
           if(maz>rusis1.imtnuostolis())
            {
                maz = rusis1.imtnuostolis();
                
            }
            if(rupiaus<rusis1.imtrupumas())
            {
                rupiaus = rusis1.imtrupumas();
                
            }
              //--------------------------------------------------
            Console.Write("Įveskite grudų rūšį: ");
            rus = Console.ReadLine();
            Console.Write("Rupumas: ");
            rupum = double.Parse(Console.ReadLine());
            Console.Write("Nuostoliai %: ");
            nuost = double.Parse(Console.ReadLine());
            Console.Write("miltu tantis kg/m3: ");
            tankis = double.Parse(Console.ReadLine());

            Grudai rusis2;
            rusis2 = new Grudai(rus, rupum, nuost,tankis);
            if (maz > rusis2.imtnuostolis())
            {
                maz = rusis2.imtnuostolis();
                
            }
            if (rupiaus < rusis2.imtrupumas())
            {
                rupiaus = rusis2.imtrupumas();
                
            }
            //---------------------------------------------------

            Console.Write("Įveskite grudų rūšį: ");
            rus = Console.ReadLine();
            Console.Write("Rupumas: ");
            rupum = double.Parse(Console.ReadLine());
            Console.Write("Nuostoliai %: ");
            nuost = double.Parse(Console.ReadLine());
            Console.Write("miltu tantis kg/m3: ");
            tankis = double.Parse(Console.ReadLine());

            Grudai rusis3;
            rusis3 = new Grudai(rus, rupum, nuost,tankis);
            if (maz > rusis3.imtnuostolis())
            {
                maz = rusis3.imtnuostolis();
                
            }
            if (rupiaus < rusis3.imtrupumas())
            {
                rupiaus = rusis3.imtrupumas();
               
            }

            Console.Write("Iveskite maluno pavadinima: ");
            pavad = Console.ReadLine();
            Console.Write("{0} reikiamas miltu kiekis t: ", rusis1.imtrusi());
            pirm = double.Parse(Console.ReadLine());
            Console.Write("{0} reikiamas miltu kiekis t: ", rusis2.imtrusi());
            antr = double.Parse(Console.ReadLine());
            Console.Write("{0} reikiamas miltu kiekis t: ", rusis3.imtrusi());
            tret = double.Parse(Console.ReadLine());
            Console.Write("bendras talpyklu turis L: ");
            turis = double.Parse(Console.ReadLine());
            turis = turis / 1000;
            Console.Clear();
            Malunas pav;
            pav = new Malunas(pavad, pirm, antr, tret,turis);            
            //rupiausi miltai

            Console.WriteLine("{0} malunas", pav.imtpav());
            if (rusis1.imtrupumas() == rusis2.imtrupumas() && rusis1.imtrupumas() == rusis3.imtrupumas())
                Console.WriteLine("visu miltu rupumas vienodas");
            else
            {
                if (rupiaus == rusis1.imtrupumas())
                    Console.WriteLine(" rupiausi miltai: {0}", rusis1.imtrusi());
                if (rupiaus == rusis2.imtrupumas())
                    Console.WriteLine("rupiausi miltai: {0}", rusis2.imtrusi());
                if (rupiaus == rusis3.imtrupumas())
                    Console.WriteLine("rupiausi miltai: {0}", rusis3.imtrusi());
            }
            if (rusis1.imtnuostolis() == rusis2.imtnuostolis() && rusis1.imtnuostolis() == rusis1.imtnuostolis())
                Console.WriteLine("visu grudu nuostolis vienodas");
            else
            {
                if (maz == rusis1.imtnuostolis())
                    Console.WriteLine("maziausias malimo nuostolis {0} grudu", rusis1.imtrusi());
                if (maz == rusis2.imtnuostolis())
                    Console.WriteLine("maziausias malimo nuostolis {0} grudu", rusis2.imtrusi());
                if (maz == rusis3.imtnuostolis())
                    Console.WriteLine("maziausias malimo nuostolis {0} grudu", rusis3.imtrusi());
            }
            //reikiamo grudu kiekio skaiciavimas:

            Console.WriteLine("{0} grudu reikia {1} t", rusis1.imtrusi(),Math.Round (pav.imtpirm() / (1 - rusis1.imtnuostolis() / 100.00),2));
            Console.WriteLine("{0} grudu reikia {1} t", rusis2.imtrusi(),Math.Round( pav.imtantr() / (1 - rusis2.imtnuostolis() / 100.00),2));
            Console.WriteLine("{0} grudu reikia {1} t", rusis3.imtrusi(),Math.Round( pav.imttret() / (1 - rusis3.imtnuostolis() / 100.00),2));
            //bendras miltu kiekis kubiniais metrais;

            bendras_miltu_kiekis = (pav.imtpirm()*1000/rusis1.imttankis()) + (pav.imtantr()*1000/rusis2.imttankis()) + (pav.imttret()*1000/rusis3.imttankis());           
            if (pav.imtturi() >= bendras_miltu_kiekis)
                Console.WriteLine("Miltai telpa ");
            else
                Console.WriteLine("Talpyklose nepakankamai vietos ");
        }
    }
}
