using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace WindowsFormsApplication5
{

    class Klientas
    {
        private string Vardas { get; set; }
        private string Pavarde { get; set; }
        private string Asmens_kodas { get; set; }
        private string El_pastas { get; set; }
        private DateTime data { get; set; }
        private int tipas { get; set; }
        public Klientas(string Vardas, string Pavarde,string Asmens_kodas,string El_pastas,DateTime data,int tipas)
        {
            this.Vardas = Vardas;
            this.Pavarde = Pavarde;
            this.Asmens_kodas = Asmens_kodas;
            this.El_pastas = El_pastas;
            this.tipas = tipas;
            this.data = data;
        }


        public string imtkodas() { return Asmens_kodas; }
        public string imtVardas() { return Vardas; }
        public string imtPavarde() { return Pavarde; }
        public string imtEl() { return El_pastas; }
        public DateTime imtMet() { return data; }
        public int imttipas() { return tipas; }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1} {2} {3} {4} {5} ", Vardas, Pavarde, Asmens_kodas, El_pastas,data, tipas);
            return eilute;
        }
        public bool Contains(string kodas)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = string.Format("SELECT asmens_kodas FROM klientas where asmens_kodas='{0}'", kodas);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {

                databaseConnection.Open();

                reader = commandDatabase.ExecuteReader();

               

                if (reader.HasRows)
                {
                    return true;
                }
                databaseConnection.Close();
            }
            catch 
            {
               
            }
            return false;
        }
    }
}
