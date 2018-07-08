using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    class Tipai
    {

        private List<Tipas> tipas;
        public Tipai()
        {
            tipas = new List<Tipas>();
        }
       
        public Tipas Imtitipa(int i) { return tipas[i]; }
        public void Detitipa(Tipas tip) { tipas.Add(tip); }
        public int rasID(string name)
        {
            for (int i = 0; i < tipas.Count; i++)
                if (tipas[i].imtName() == name)
                    return tipas[i].imtID();
            return -1;
        }
       

    }
    class Tipas
    {
        private int ID { get; set; }
        private string Name { get; set; }

        public Tipas(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }

        public int imtID() { return ID; }
        public string imtName() { return Name; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1}", ID, Name);
            return eilute;
        }
    }
}
