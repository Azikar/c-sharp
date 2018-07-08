using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication5
{
    class Reklamos
    {
        public string Pavadinimas { get; set; }
        public int ID { get; set; }
        public string Aprasas { get; set; }
        public int Tipas { get; set; }
        public string Busena { get; set; }
        public Reklamos(string Pavadinimas, int ID, string Aprasas, int Tipas, string Busena)
        {
            this.Pavadinimas = Pavadinimas;
            this.ID = ID;
            this.Aprasas = Aprasas;
            this.Tipas = Tipas;
            this.Busena = Busena;
        }
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0} {1} {2} {3} {4} ", Pavadinimas, ID, Aprasas, Tipas, Busena);
            return eilute;
        }
        public bool Contains(int ID)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = string.Format("SELECT ID FROM reklamos where ID='{0}'", ID);
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
