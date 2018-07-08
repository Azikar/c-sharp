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

namespace WindowsFormsApplication5
{
    public partial class Form2 : Form
    {
        Tipai tipai = new Tipai();
        static string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=inziner;";
        MySqlConnection databaseConnection = new MySqlConnection(connectionString);

        public Form2()
        {
            InitializeComponent();
            string query = "SELECT * FROM tipas";
            tiipas(query);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.Rows.Clear();
                string query = string.Format("Select * from reklamos where reklamos.ID='{0}'", textBox2.Text);
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
                            dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4));
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
                    string query = string.Format("SELECT reklamos.Pavadinimas, reklamos.ID, reklamos.Aprasas, tipas.Pavadinimas, reklamos.Busena FROM reklamos,tipas Where fk_tipasid_tipas =id_tipas and id_tipas={0}", tipas);
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
                                dataGridView1.Rows.Add(reader.GetString(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
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

        private void button5_Click(object sender, EventArgs e)
        {
            Skaityt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "";
            try
            {
                Reklamos reklama = new Reklamos(textBox1.Text, int.Parse(textBox2.Text), richTextBox1.Text, tipai.rasID(comboBox1.SelectedItem.ToString()), textBox4.Text);
                if (reklama.Contains(reklama.ID))
                    MessageBox.Show("Toks egzistuoja");
                else
                {
                    query = string.Format("INSERT INTO reklamos Values('{0}','{1}','{2}','{3}','{4}')", reklama.Pavadinimas, reklama.ID, reklama.Aprasas, reklama.Tipas, reklama.Busena);



                    try
                    {
                        MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
                        commandDatabase.CommandTimeout = 60;
                        databaseConnection.Open();
                        MySqlDataReader myReader = commandDatabase.ExecuteReader();

                        MessageBox.Show("Sekmingai prideta");

                        databaseConnection.Close();
                        Skaityt();
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

        private void button4_Click(object sender, EventArgs e)
        {
            Reklamos reklama = new Reklamos(textBox1.Text, int.Parse(textBox2.Text), richTextBox1.Text, tipai.rasID(comboBox1.SelectedItem.ToString()), textBox4.Text);
            string query = string.Format("UPDATE reklamos SET Pavadinimas='{0}',Aprasas='{1}',fk_tipasid_tipas='{2}', busena='{3}' Where reklamos.ID='{4}'", reklama.Pavadinimas, reklama.Aprasas, reklama.Tipas, reklama.Busena, reklama.ID);
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
                Skaityt();
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
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(dataGridView1.SelectedRows[0].Cells[3].Value.ToString());
            textBox2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Reklamos reklama = new Reklamos(textBox1.Text, int.Parse(textBox2.Text), richTextBox1.Text, tipai.rasID(comboBox1.SelectedItem.ToString()), textBox4.Text);
            string query = string.Format("DELETE FROM reklamos where ID='{0}'", reklama.ID);
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;
            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                string message = string.Format("{0} {1} {2} {3} {4} SEKMINGAI ISTRINTAS ", reklama.Pavadinimas, reklama.ID, reklama.Aprasas, reklama.Tipas, reklama.Busena);
                MessageBox.Show(message);
                databaseConnection.Close();
                Skaityt();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                databaseConnection.Close();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog failas = new OpenFileDialog();
            if (failas.ShowDialog() == DialogResult.OK)
            { 
                var onlyFileName = System.IO.Path.GetFileName(failas.FileName);
                textBox4.Text = onlyFileName;
            }
        }
    }
}
