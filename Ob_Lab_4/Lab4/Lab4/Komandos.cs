using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public sealed class Komandos
    {
        Mazgas pr;
        Mazgas pb;
        Mazgas d;
        public Komandos()
        {
            this.pr = null;
            this.pb = null;
            this.d = null;
        }
        public void Pradzia()
        {
            d = pr;
        }
        public void Kitas()
        {
            d = d.Kitas;
        }
        public bool Yra()
        {
            return d != null;
        }
        public Zaidejas imti()
        {
            return d.Duomenys;
        }
        public void DetiA(Zaidejas inf)
        {
            var d = new Mazgas(inf, null);
            d.Kitas = pr;
            pr = d;
        }
        public void DetiB(Zaidejas inf)
        {
            var d = new Mazgas(inf, null);
            if (pr != null)
            {
                pb.Kitas = d;
                pb = d;
            }
            else
            {
                pr = d;
                pb = d;
            }
        }
        public void Rikiuoti()
        {
            bool keista = true;
            Mazgas d1, d2;
            while (keista)
            {
                keista = false;
                d1 = d2 = pr;
                while (d2 != null)
                {
                    if (d2.Duomenys > d1.Duomenys)
                    {
                        Zaidejas z = d1.Duomenys;
                        d1.Duomenys = d2.Duomenys;
                        d2.Duomenys = z;
                        keista = true;
                    }
                    d1 = d2; d2 = d2.Kitas;
                }
            }
        }
        //public void Salinti(Zaidejas tas)
        //{
        //    Mazgas dd = null;
        //    for(Mazgas d= pr; d== null; d=d.Kitas)
        //    {
        //        Zaidejas pag = d.Duomenys;
        //        if(pag==tas)
        //        {
        //            if(dd==null)
        //            {
        //                Mazgas a, b;
        //                a = d;
        //                b = d.Kitas;
        //                a.Duomenys = b.Duomenys;
        //                a.Kitas = b.Kitas;
        //                b.Kitas = null;
        //                b = null;
        //            }
        //            else
        //            {
        //                dd.Kitas = d.Kitas;
        //            }
        //        }
        //        dd = d;
        //    }

        //}
        public void Naikint(Zaidejas kel)
        {
            if(pr!=null)
            {
                Mazgas dd = pr;
                if (pr.Duomenys == kel)
                    pr = pr.Kitas;
                else
                {
                    while(dd.Kitas!=null)
                    {
                        if(dd.Kitas.Duomenys==kel)
                        {
                            dd.Kitas = dd.Kitas.Kitas;
                            return;
                        }
                        dd = dd.Kitas;
                    }
                }
            }
        }
    }
}
