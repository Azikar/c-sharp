using Microsoft.VisualStudio.TestTools.UnitTesting;
using WindowsFormsApplication5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace WindowsFormsApplication5.Tests
{
    [TestClass()]
    public class Form1Tests
    {
        [TestMethod()]
        public void SkaitytTest()
        {
            Form1 t = new Form1();
            List<string> exp = new List<string>();
            List<string> idd;
            
            t.Skaityt(1, out idd);
            Console.WriteLine(idd[0]);
            exp.Add("ad");
            exp.Add("fsdgdgsdg");
            exp.Add("yeyteet");
            exp.Add("yeyteetdghthtdaf");
            CollectionAssert.AreEqual(exp,idd );           
        }
        [TestMethod()]
        public void rastTest()
        {
            Form1 t = new Form1();
            List<string> exp = new List<string>();
            List<string> idd;

            t.paiesk("ad", out idd);
            Console.WriteLine(idd[0]);
            exp.Add("ad");
            CollectionAssert.AreEqual(exp, idd);
        }
        [TestMethod()]
        public void pridetTest()
        {
            Form1 t = new Form1();
            List<string> exp = new List<string>();
            List<string> idd;
            DateTime dt = DateTime.ParseExact("1999-02-05", "yyyy-mm-dd", CultureInfo.InvariantCulture);
            Klientas klientas = new Klientas("a", "a", "a", "a", dt,1);
            t.pridet(klientas,out idd);
            t.Skaityt(1, out idd);
            exp.Add("a");
            exp.Add("ad");
            exp.Add("fsdgdgsdg");
            exp.Add("yeyteet");
            exp.Add("yeyteetdghthtdaf");
            CollectionAssert.AreEqual(exp, idd);
        }

        [TestMethod()]
        public void trintTest()
        {
            Form1 t = new Form1();
            List<string> exp = new List<string>();
            List<string> idd;
            DateTime dt = DateTime.ParseExact("1999-02-05", "yyyy-mm-dd", CultureInfo.InvariantCulture);
            Klientas klientas = new Klientas("a", "a", "a", "a", dt, 1);
          
            t.trint(klientas);
            t.Skaityt(1, out idd);
            exp.Add("ad");
            exp.Add("fsdgdgsdg");
            exp.Add("yeyteet");
            exp.Add("yeyteetdghthtdaf");
            CollectionAssert.AreEqual(exp, idd);
        }
    }
}