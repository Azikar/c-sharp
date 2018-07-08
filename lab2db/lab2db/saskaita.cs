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
using System.Globalization;
namespace lab2db
{
    public partial class saskaita : Form
    {
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=dab1.2;";
        public saskaita()
        {
            InitializeComponent();
            uzsakymai();
            klientai();
        }
        private void uzsakymai()
        {
            string query = "SELECT Nr FROM uzsakymo_forma";
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

            skaityt1();
        }
        private void klientai()
        {
            string query = "SELECT fk_klientaskodas FROM mokejimas";
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
                        
                        comboBox2.Items.Add(reader.GetString(0));
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

            skaityt1();
        }
        public void skaityt1()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string query = "SELECT data,suma,id_saskaita,fk_uzsakymo_formaNr from saskaita";
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
                        dataGridView1.Rows.Add(DateTime.Parse(reader.GetString(0)).ToString("yyyy-MM-dd"), reader.GetString(1), reader.GetString(2), reader.GetString(3));
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
        public void skaityt2()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            string query =string.Format( "SELECT mokejimas.data,mokejimas.suma,id_mokejimas,fk_klientaskodas from mokejimas, saskaita where mokejimas.fk_saskaitaid_saskaita=saskaita.id_saskaita and id_saskaita='{0}'", dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
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
                        dataGridView2.Rows.Add(DateTime.Parse(reader.GetString(0)).ToString("yyyy-MM-dd"), reader.GetString(1), reader.GetString(2), reader.GetString(3));
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
        private void pridet_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(textBox1.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            string query = string.Format("insert into saskaita values('{0}','{1}','{2}','{3}','{4}')", textBox3.Text, sqlFormattedDate, textBox2.Text, textBox3.Text, comboBox1.Text);
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
            skaityt1();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.FindStringExact(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            skaityt2();
        }

        private void pakeist_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(textBox1.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            string query = string.Format("UPDATE saskaita SET data='{0}', suma='{1}',fk_uzsakymo_formaNr='{2}' Where id_saskaita='{3}'", sqlFormattedDate, textBox2.Text, comboBox1.Text,textBox3.Text);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);


            try
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Sekmingai pakeista");

                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
            skaityt1();
        }

        private void pasalint_Click(object sender, EventArgs e)
        {
            string query = string.Format("DELETE from saskaita Where id_saskaita='{0}'", textBox3.Text);
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
                skaityt1();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show("ID issorinis kaip raktas naudojamas mokejimu lenteleje");
                databaseConnection.Close();
            }
            
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            textBox4.Text = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textBox6.Text = dataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            comboBox2.SelectedIndex = comboBox2.FindStringExact(dataGridView2.SelectedRows[0].Cells[3].Value.ToString());
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(textBox4.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            string query = string.Format("insert into mokejimas values('{0}','{1}','{2}','{3}','{4}')", sqlFormattedDate, textBox5.Text, textBox6.Text, comboBox2.Text, textBox3.Text);
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
            skaityt2();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string query = string.Format("DELETE from mokejimas Where id_mokejimas='{0}'", textBox6.Text);
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
              //  MessageBox.Show("ID issorinis kaip raktas naudojamas mokejimu lenteleje");
                databaseConnection.Close();
            }
            skaityt2();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.ParseExact(textBox4.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            string query = string.Format("UPDATE mokejimas SET data='{0}', suma='{1}',fk_klientaskodas='{3}',fk_saskaitaid_saskaita='{4}' Where id_mokejimas='{2}'", sqlFormattedDate, textBox5.Text, textBox6.Text ,comboBox2.Text,textBox3.Text);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);


            try
            {
                MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                commandDatabase.CommandTimeout = 60;
                databaseConnection.Open();
                MySqlDataReader myReader = commandDatabase.ExecuteReader();

                MessageBox.Show("Sekmingai pakeista");

                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
            skaityt2();
        }
    }
    }

