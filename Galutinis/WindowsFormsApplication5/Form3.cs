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
using System.Net.Mail;
namespace WindowsFormsApplication5
{
    public partial class Form3 : Form
    {
        List<string> klientai = new List<string>();
        List<Reklamos> reklamos = new List<Reklamos>();
        Tipai tipai = new Tipai();
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);

        public Form3()
        {
            InitializeComponent();
            string query = "SELECT * FROM tipas";
            tiipas(query);
        }

        private void klientaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form forma = new Form1();
            forma.Show();
        }

        private void reklamosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form forma = new Form2();
            forma.Show();
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            string el = dataGridView1.SelectedCells[0].Value.ToString();
            klientai.Add(el);
        }
        public void tiipas(string query)
        {
            // Tipas tipas;

            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                // All succesfully executed, now do something

                // IMPORTANT : 
                // If your query returns result, use the following processor :

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // Do something with every received database ROW
                        // reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        Tipas tipas = new Tipas(Int32.Parse(reader.GetString(1)), reader.GetString(0));
                        tipai.Detitipa(tipas);
                        comboBox1.Items.Add(tipas.imtName());

                    }
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
        public void Skaityt()
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            if (comboBox1.SelectedItem.ToString() != null)
            {
                int tipas = tipai.rasID(comboBox1.SelectedItem.ToString());

                try
                {
                    string query = string.Format("SELECT klientas.vardas, klientas.pavarde, klientas.e_pastas FROM klientas,tipas Where fk_tipasid_tipas =id_tipas and id_tipas={0}", tipas);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    try
                    {
                        // Open the database
                        databaseConnection.Open();

                        // Execute the query
                        reader = commandDatabase.ExecuteReader();

                        // All succesfully executed, now do something

                        // IMPORTANT : 
                        // If your query returns result, use the following processor :

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                                // Do something with every received database ROW
                                // reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                                // DateTime.Parse(reader.GetString(4)).ToString("yyyy-MM-dd");
                                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                        else
                        {

                        }
                        databaseConnection.Close();

                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    databaseConnection.Close();
                }
            }
        }
        public void Skaitytt()
        {
            this.dataGridView2.DataSource = null;
            this.dataGridView2.Rows.Clear();
            if (comboBox1.SelectedItem.ToString() != null)
            {
                int tipas = tipai.rasID(comboBox1.SelectedItem.ToString());

                try
                {
                    string query = string.Format("SELECT reklamos.Pavadinimas, reklamos.aprasas, reklamos.busena FROM reklamos,tipas Where fk_tipasid_tipas =id_tipas and id_tipas={0}", tipas);
                    MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

                    commandDatabase.CommandTimeout = 60;
                    MySqlDataReader reader;

                    try
                    {
                        // Open the database
                        databaseConnection.Open();

                        // Execute the query
                        reader = commandDatabase.ExecuteReader();

                        // All succesfully executed, now do something

                        // IMPORTANT : 
                        // If your query returns result, use the following processor :

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                // As our database, the array will contain : ID 0, FIRST_NAME 1,LAST_NAME 2, ADDRESS 3
                                // Do something with every received database ROW
                                // reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                                // DateTime.Parse(reader.GetString(4)).ToString("yyyy-MM-dd");
                                dataGridView2.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2));
                            }
                        }
                        else
                        {

                        }
                        databaseConnection.Close();

                    }
                    catch (Exception ex)
                    {
                        // Show any error message.
                        MessageBox.Show(ex.Message);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    databaseConnection.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Skaityt();
            Skaitytt();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            pictureBox1.ImageLocation = string.Format("../../{0}", dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            Reklamos klase = new Reklamos(dataGridView2.SelectedRows[0].Cells[0].Value.ToString(), 0,dataGridView2.SelectedRows[0].Cells[1].Value.ToString(), 0,dataGridView2.SelectedRows[0].Cells[2].Value.ToString());
            reklamos.Add(klase);
        }
    }
}
