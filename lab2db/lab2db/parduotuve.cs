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
    public partial class parduotuve : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dab1.2;";
        public parduotuve()
        {
            InitializeComponent();
            miestai();
        }
        public void miestai()
        {
            string query = "SELECT pavadinimas FROM miestas";
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
                        comboBox1.Items.Add(reader.GetString(0));
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

            skaityt();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
        }
        public void skaityt()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
           string query = "SELECT parduotuve.pavadinimas, parduotuve.adresas,parduotuve.tel_nr,parduotuve.e_pastas,parduotuve.id_parduotuve,miestas.pavadinimas FROM parduotuve, miestas where miestas.id_Miestas=parduotuve.fk_Miestasid_Miestas";
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;

            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                        // Do something with every received database ROW
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
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



        private string find(string pav)
        {
            string id;
            string query = string.Format("select id_Miestas from miestas where pavadinimas='{0}'", pav);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            try
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = reader.GetString(0);
                        return id;
                    }
                }
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
            return "0";


        }
        private void save_Click(object sender, EventArgs e)
        {
            string query = string.Format("INSERT INTO parduotuve Values('{0}','{1}','{2}','{3}','{4}','{5}')", textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,find(comboBox1.Text));
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
            skaityt();
        }

        private void update_Click(object sender, EventArgs e)
        {
            
string query = string.Format("UPDATE parduotuve SET pavadinimas='{0}', adresas='{1}',tel_nr='{2}', e_pastas='{3}',fk_Miestasid_Miestas='{5}' Where id_parduotuve='{4}'", textBox1.Text, textBox2.Text,textBox3.Text,textBox4.Text,textBox5.Text,find(comboBox1.Text));
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
            skaityt();

        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            string query = string.Format( "DELETE from parduotuve Where id_parduotuve='{0}'", textBox5.Text);
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
                MessageBox.Show("ID issorinis kaip raktas naudojamas darbuotoju lenteleje");
                databaseConnection.Close();
            }
            skaityt();
        }
    }
}
