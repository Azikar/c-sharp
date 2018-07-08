﻿using System;
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
namespace WindowsFormsApplication5
{

    public partial class Form1 : Form
    {
        Tipai tipai = new Tipai();
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);
        public Form1()
        {
            InitializeComponent();
            //string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
            string query = "SELECT * FROM tipas";
            //MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            tiipas(query);

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

        private void Nuskaityt_Click(object sender, EventArgs e)
        {
            List<string> idd;
            Skaityt(tipai.rasID(comboBox1.SelectedItem.ToString()),out idd);

        }
        public void Skaityt(int id,out List<string> idd)
        {
            idd = new List<string>();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
           
                int ID = id;

                try
                {
                    string query = string.Format("SELECT Vardas, Pavarde, asmens_kodas, e_pastas,Gimimo_data,Pavadinimas FROM klientas,tipas Where fk_tipasid_tipas =id_tipas and id_tipas={0}", ID);
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
                                dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), DateTime.Parse(reader.GetString(4)).ToString("yyyy-MM-dd"), reader.GetString(5));
                                idd.Add(reader.GetString(2));
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
                        databaseConnection.Close();
                        
                        
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    databaseConnection.Close();
                }

            
            
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<string> idd;
            DateTime dt = DateTime.ParseExact(textBox5.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
           
            Klientas klientas = new Klientas(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dt, tipai.rasID(comboBox1.SelectedItem.ToString()));
            pridet(klientas,out idd);
        }


        public void pridet(Klientas klientas,out List<string> idd)
        {
            idd = new List<string>();
            string query = "";
            try
            {
               
                if (klientas.Contains(klientas.imtkodas()))
                    MessageBox.Show("Toks egzistuoja");
                else
                {
                    var sqlFormattedDate = klientas.imtMet().ToString("yyyy-MM-dd");
                    query = string.Format("INSERT INTO klientas Values('{0}','{1}','{2}','{3}','{4}','{5}')", klientas.imtVardas(), klientas.imtPavarde(), klientas.imtkodas(), klientas.imtEl(), sqlFormattedDate, klientas.imttipas());



                    try
                    {
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;
                        databaseConnection.Open();
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Sekmingai prideta");

                        databaseConnection.Close();
                       
                        Skaityt(tipai.rasID(comboBox1.SelectedItem.ToString()), out idd);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        databaseConnection.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bloga ivestis");
                databaseConnection.Close();
            }
        }
    



        private void buttonPaieska_Click(object sender, EventArgs e)
        {
            List<string> idd;
            paiesk(textBox3.Text,out idd);
        }
        public void paiesk(string id, out List<string> idd)
        {
            idd = new List<string>();
            this.dataGridView1.DataSource = null;
            this.dataGridView1.Rows.Clear();
            string query = string.Format("Select * from klientas where klientas.asmens_kodas='{0}'",id);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            try
            {
                databaseConnection.Open();
                MySqlDataReader reader = commandDatabase.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), DateTime.Parse(reader.GetString(4)).ToString("yyyy-MM-dd"), reader.GetString(5));
                        idd.Add(reader.GetString(2));
                    }
                    databaseConnection.Close();
                }
                else MessageBox.Show("Tokio nera");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }
        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(dataGridView1.SelectedRows[0].Cells[5].Value.ToString());
            textBox3.Enabled = false;

        }

        private void buttonPakeist_Click(object sender, EventArgs e)
        {
            List<string> idd;
            DateTime dt = DateTime.ParseExact(textBox5.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            Klientas klientas = new Klientas(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dt, tipai.rasID(comboBox1.SelectedItem.ToString()));
            string query = string.Format("UPDATE klientas SET Vardas='{0}',Pavarde='{1}',e_pastas='{2}',Gimimo_data='{3}',fk_tipasid_tipas='{4}' Where asmens_kodas='{5}'", klientas.imtVardas(), klientas.imtPavarde(), klientas.imtEl(), sqlFormattedDate, klientas.imttipas(), klientas.imtkodas());
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
                Skaityt(tipai.rasID(comboBox1.SelectedItem.ToString()),out idd);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }

        private void buttonAtgal_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = true;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            
            DateTime dt = DateTime.ParseExact(textBox5.Text, "yyyy-mm-dd", CultureInfo.InvariantCulture);
            var sqlFormattedDate = dt.ToString("yyyy-MM-dd");
            Klientas klientas = new Klientas(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, dt, tipai.rasID(comboBox1.SelectedItem.ToString()));
            trint(klientas);
        }
        public void trint(Klientas klientas)
        {
            List<string> idd;
           string query = string.Format("DELETE FROM klientas where asmens_kodas='{0}'", klientas.imtkodas());
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                string message = string.Format("{0} {1} {2} {3} {4} {5} SEKMINGAI ISTRINTAS ", klientas.imtVardas(), klientas.imtPavarde(), klientas.imtEl(), klientas.imtMet(), klientas.imttipas(), klientas.imtkodas());
                MessageBox.Show(message);
                databaseConnection.Close();
                Skaityt(tipai.rasID(comboBox1.SelectedItem.ToString()), out idd);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DateTime dDate;
            if (DateTime.TryParse(textBox5.Text, out dDate))
            {
                String.Format("{0:d/MM/yyyy}", dDate);
                textBox5.BackColor = Color.LightGreen;
            }
            else
            {
                textBox5.BackColor = Color.Red;// <-- Control flow goes here
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(textBox4.Text);
                textBox4.BackColor = Color.LightGreen;
            }
            catch
            {
                textBox4.BackColor = Color.Red;
            }
        }
    }
}
