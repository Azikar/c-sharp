using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sql.test
{
    [TestClass]
    public class test
    {
       
        public void ShouldReturn()
        {

            WindowsFormsApplication5.Form1 db = new WindowsFormsApplication5.Form1();
            List<string> exp=new List<string>();
            List<string> idd;
            db.Skaityt(1,out idd);
            Console.WriteLine(idd[0]);
            exp.Add("ad");
            exp.Add("fsdgdgsdg");
            exp.Add("yeyteet");
            exp.Add("yeyteetdghthtdaf");
            CollectionAssert.AreEqual(exp, idd);
            

        }
    }
}
