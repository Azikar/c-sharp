using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace lab2db
{
    public partial class Kategorija : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dab1.2;";
        public Kategorija()
        {
            InitializeComponent();
        }
        public Boolean arYra(string pavad)
        {
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            string query = string.Format("SELECT pavadinimas FROM kategorija where pavadinimas='{0}'", pavad);
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

        private void Nuskaityt_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string query = "SELECT * FROM kategorija";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("No rows found.");
                }
                databaseConnection.Close();
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void pridet_Click(object sender, EventArgs e)
        {
            if (arYra(textBox1.Text))
                MessageBox.Show("Toks egzistuoja");
            else
            {
                string query = string.Format("INSERT INTO kategorija Values('{0}','{1}')", textBox2.Text, textBox1.Text);
                MySqlConnection databaseConnection = new MySqlConnection(connectionString);


                try
                {
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                    commandDatabase.CommandTimeout = 60;
                    databaseConnection.Open();
                    MySqlDataReader myReader = commandDatabase.ExecuteReader();

                    MessageBox.Show("Sekmingai prideta");

                    databaseConnection.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    databaseConnection.Close();
                }
            }
        }

        private void Pakeist_Click(object sender, EventArgs e)
        {
            string query = string.Format("UPDATE kategorija SET pavadinimas='{0}' Where id_kategorija='{1}'", textBox2.Text, textBox1.Text);

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                MessageBox.Show("SEKMINGAI PAKEISTA");
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }

        private void trinti_Click(object sender, EventArgs e)
        {
            //string query = string.Format("UPDATE produktas SET fk_kategorijaid_kategorija='NULL' Where fk_kategorija='{0}' ", textBox1.Text);


           string  query = string.Format("UPDATE produktas SET fk_kategorijaid_kategorija=NULL Where fk_kategorijaid_kategorija='{0}';"+ "DELETE from kategorija Where id_kategorija='{0}'", textBox1.Text);

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                databaseConnection.Close();
                MessageBox.Show(string.Format("{0} istrinta", textBox1.Text));
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }
    }
}
