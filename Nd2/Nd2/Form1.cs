using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Nd2
{
    public partial class Form1 : Form
    {
        const string CFd = "..\\..\\Studentai.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        Studentai TestasMas; // studentų testo rezultatai (Konteineris)
        Pazymys[] Pazymiai = new Pazymys[10] // pažymių objektų masyvas
        {
                new Pazymys(10, "Puikiai"),
                new Pazymys(9, "Labai gerai"),
                new Pazymys(8, "Gerai"),
                new Pazymys(7, "Vidutiniškai"),
                new Pazymys(6, "Patenkinamai"),
                new Pazymys(5, "Silpnai"),
                new Pazymys(4, "Nepatenkinamai"),
                new Pazymys(3, "Nepatenkinamai"),
                new Pazymys(2, "Nepatenkinamai"),
                new Pazymys(1, "Nepatenkinamai")
        };
           
        public Form1()
        {
            InitializeComponent();
            Spausdinti.Enabled = false;
            Skaičiuoti.Enabled = false;
            Rasti.Enabled = false;            if (File.Exists(CFr))
                File.Delete(CFr);            foreach (Pazymys paz in Pazymiai)
                Vertinimai.Items.Add(paz.Pazym + " " + paz.PazZodR);
        }

        private void Skaičiuoti_Click(object sender, EventArgs e)
        {
            string ivertis = Vertinimai.SelectedItem.ToString();
            string[] eilDalis = ivertis.Split(' ');
            int pazymys = Int32.Parse(eilDalis[0]);
            int kiekis = Kiekis(TestasMas, pazymys);
            if (kiekis > 0)
                Rezultatas.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                Rezultatas.Text = "Tokių studentų nėra.";
        }
        /// <summary>
        /// Perskaitomi duomenys ir irasomi i programos langa.
        /// </summary>
        /// <param name="siuntimas"></param>
        /// <param name="e"></param>
        private void Įvesti_Click(object siuntimas, EventArgs e)
        {
            rezultatai.LoadFile(CFd, RichTextBoxStreamType.PlainText);
            TestasMas = SkaitytiStudKont(CFd);
            Įvesti.Enabled = false;
            Spausdinti.Enabled = true;
            Skaičiuoti.Enabled = true;
            Rasti.Enabled = true;
        }
        /// <summary>
        /// Programos lange bei rezultatu faile spausdinami duomenys
        /// </summary>
        /// <param name="siuntimas"></param>
        /// <param name="e"></param>
        private void Spausdinti_Click(object siuntimas, EventArgs e)
        {
            SpausdintiStudKont(CFr, TestasMas,
            "Studentų sąrašas (testo rezultatai)");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            Vertinimai.SelectedIndex = 0; // parenkama 1-oji reikšmė
        }
        /// <summary>
        /// Ieskoma studento pagal jo duomenis
        /// </summary>
        /// <param name="siuntimas"></param>
        /// <param name="e"></param>
        private void Rasti_Click(object siuntimas, EventArgs e)
        {
            pavardeVardas.Text = "Pavardė ir vardas";
            string pavVrd = pavardeVrd.Text;
            int index = StudentoIndeksas(TestasMas, pavVrd);
            if (index > -1)
            {
                Studentas stud = TestasMas.ImtiStudenta(index);
                int pazymys = stud.Pazym;
                pavardeVardas.Text = pavardeVardas.Text + " (pažymys: "
                + pazymys.ToString() + ")";
            }
            else
                pavardeVardas.Text = pavardeVardas.Text +
                " (Tokio studento (-ės) nėra.)";
        }
        /// <summary>
        /// Uzdaroma programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Baigti_Click(object sender, EventArgs e)
        {
            Close();
        }
        //-----------------------------------------------------------------
        //                          Skaitymas
        //-----------------------------------------------------------------
        /// <summary>
        /// Vyksta skaitymas
        /// </summary>
        /// <param name="fv"></param>
        /// <returns></returns>

        static Studentai SkaitytiStudKont(string fv)
        {
            Studentai StudentaiKont = new Studentai();
            using (StreamReader duom = new StreamReader(fv,
            Encoding.GetEncoding(1257)))
            {
                string eilute; // visa duomenų failo eilutė
                while ((eilute = duom.ReadLine()) != null)
                {
                    string[] eilDalis = eilute.Split(';');
                    string pavVrd = eilDalis[0];
                    int pazym = int.Parse(eilDalis[1]);
                    Studentas studentas = new Studentas(pavVrd, pazym);
                    StudentaiKont.DetiStudenta(studentas);
                }
            }
            return StudentaiKont;
        }
        //-----------------------------------------------------------------
        //                          Spausdinimas
        //-----------------------------------------------------------------
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fv"></param>
        /// <param name="StudentaiKont"></param>
        /// <param name="antraste"></param>
        static void SpausdintiStudKont(string fv, Studentai StudentaiKont,string antraste)
        {
            const string Titulinis =
            "-----------------------------------\r\n"+ " Nr. Pavardė ir vardas Pazymys   \r\n"
            + "-----------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append),
            Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("\n " + antraste);
                fr.WriteLine(Titulinis);
                for (int i = 0; i < StudentaiKont.Kiek; i++)
                {
                    Studentas stud = StudentaiKont.ImtiStudenta(i);
                    fr.WriteLine("{0, 3} {1}", i + 1, stud);
                }
                fr.WriteLine("-----------------------------------\n");
            }
        }
        //-----------------------------------------------------------------
        //                          Skaiciuoja
        //-----------------------------------------------------------------
        /// <summary>
        /// Randamas nurodyta pertinima turinciu studentu skaiciu
        /// </summary>
        /// <param name="StudentaiKont"></param>
        /// <param name="pazymys"></param>
        /// <returns></returns>
        static int Kiekis(Studentai StudentaiKont, int pazymys)
        {
            int kiek = 0;
            for (int i = 0; i < StudentaiKont.Kiek; i++)
            {
                Studentas stud = StudentaiKont.ImtiStudenta(i);
                if (stud.Pazym == pazymys)
                    kiek++;
            }
            return kiek;
        }
        //-----------------------------------------------------------------
        //                          Pazimys
        //-----------------------------------------------------------------
        /// <summary>
        /// ieskomas norimo studento pazimys pagal jo duomenis.
        /// </summary>
        /// <param name="StudentaiKont"> Studentu objektu konteineris</param>
        /// <param name="pavVrd">Vardas ir pavarde</param>
        /// <returns> grazina studento indeksa</returns>        static int StudentoIndeksas(Studentai StudentaiKont, string pavVrd)
        {
            for (int i = 0; i < StudentaiKont.Kiek; i++)
            {
                Studentas stud = StudentaiKont.ImtiStudenta(i);
                if (stud.PavVrd == pavVrd)
                    return i;
            }
            return -1;
        }
        //-----------------------------------------------------------------
        /// <summary>
        /// Grazina programa i pradine padeti.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Atgal_Click(object sender, EventArgs e)
        {
            Įvesti.Enabled = true;
            rezultatai.Text=String.Empty;
            Rezultatas.Text = "Čia bus parodyti rezultatai";
            pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";            pavardeVardas.Text = "Pavardė ir vardas";            Vertinimai.Text = "Pasirinkite pažymį";
            
            Spausdinti.Enabled = false;
            Skaičiuoti.Enabled = false;
            Rasti.Enabled = false;
        }
    }

}
