using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Text.RegularExpressions;

namespace Forme
{
    public partial class EvidencijaSata : Form
    {
        public EvidencijaSata()
        {
            InitializeComponent();
        }
        private string ime_predmeta;
        private string id_predmeta2;

        private bool id = false;
        public EvidencijaSata(string razred, bool id)
        {
            InitializeComponent();
            id = true;
            lblDatum.Text = DateTime.Today.ToShortDateString();
            string sql = "SELECT \"ID_predmet\" FROM \"Razred\" WHERE naziv_razreda='" + razred + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);

            string id_predmeta = "";
            while (citac.Read())
            {
                id_predmeta = citac["ID_predmet"].ToString();
            }

            id_predmeta2 = id_predmeta;
            citac.Close();
            DohvatiStudentePredmeta(ref sql,ref citac,id_predmeta);
        }

        public EvidencijaSata(string imePredmeta)
        {
            InitializeComponent();
            this.CenterToParent();
            ime_predmeta = imePredmeta;
            //MessageBox.Show(ime_predmeta);
            lblDatum.Text= DateTime.Today.ToShortDateString();
            string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE naziv_predmeta='" + ime_predmeta + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string id_predmeta= "";
            while(citac.Read())
            {
                id_predmeta= citac["ID_predmet"].ToString();
                id_predmeta2 = id_predmeta;
            }
            citac.Close();
            DohvatiStudentePredmeta(ref sql, ref citac, id_predmeta);
                
         }

        private void DohvatiStudentePredmeta(ref string sql, ref NpgsqlDataReader citac, string id_predmeta)
        {
            sql = "SELECT \"ID_korisnik\" FROM \"Pohada\" WHERE \"ID_predmet\"='" + id_predmeta + "';";
            List<string> lista_idjeva = new List<string>();
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                lista_idjeva.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();
            foreach (string tekst in lista_idjeva)
            {
                sql = "SELECT ime, prezime FROM \"Korisnik\" WHERE \"ID_korisnik\"='" + tekst + "';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    string tekst2 = "";
                    tekst2 += tekst;
                    tekst2 += " " + citac["ime"].ToString() + " ";
                    tekst2 += citac["prezime"].ToString();
                    txtPrisutni.Text += tekst + " " + citac["ime"].ToString() + " " + citac["prezime"].ToString() + Environment.NewLine;
                    cmbPrisutni.Items.Add(tekst2);

                }
                citac.Close();


            }
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(textBox1.Text))
            {

            }
            else 
            {
                textBox1.Text = "";
                MessageBox.Show("U redni broj sata mozete unijeti samo brojeve!");
            }
            if (textBox1.Text == "") { }
            else
            {
                string sql = "INSERT INTO \"Evidencija\"(\"ID_korisnik\",redni_broj_sata,tema) VALUES ( '" + FrmPrijava.Id_korisnika + "','" + textBox1.Text + "','" + textBox2.Text+"');";
                BazaPodataka.Instance.IzvrsiUpit(sql);
                foreach(string stavka in cmbIzostali.Items)
                {
                    //MessageBox.Show("Ovo je korisnik: " + stavka);
                    string id_korisnika="";
                    for (int i = 0; i < stavka.Length; i++)
                    {
                        if (stavka[i] == ' ') i = stavka.Length;
                        else
                        {
                            id_korisnika += stavka[i].ToString();
                        }
                    }
                    //MessageBox.Show(id_korisnika);
                    sql = "";
                    sql = "INSERT INTO \"Izostanci\"(\"ID_korisnik\",\"ID_predmet\",datum) VALUES ('"+ id_korisnika +"','"+ id_predmeta2 +"','"+ DateTime.Now.ToShortDateString() +"');";
                    //MessageBox.Show(sql);
                    BazaPodataka.Instance.IzvrsiUpit(sql);
                }


                MessageBox.Show("Evidencija sata uspjesno unesena!");
                this.Close();
            }

           


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EvidencijaSata_Load(object sender, EventArgs e)
        {

        }

        private void lblSvi_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnIzostao_Click(object sender, EventArgs e)
        {
            if (cmbPrisutni.Text == "")
            {
                MessageBox.Show("Niti jedan ucenik nije odabran!");
            }
            else
            {
                cmbIzostali.Items.Add(cmbPrisutni.Text);
                cmbPrisutni.Items.Remove(cmbPrisutni.SelectedItem);
                cmbPrisutni.Text = "";

                txtPrisutni.Text = "";
                txtIzostali.Text = "";
                foreach(string tekst in cmbIzostali.Items)
                {
                    txtIzostali.Text+=tekst + Environment.NewLine;
                }

                foreach (string tekst in cmbPrisutni.Items)
                {
                    txtPrisutni.Text += tekst + Environment.NewLine;
                }


            }


        }

        private void btnNijeIzostao_Click(object sender, EventArgs e)
        {
            if (cmbIzostali.Text == "")
            {
                MessageBox.Show("Niti jedan ucenik nije odabran!");
            }
            else
            {
                cmbPrisutni.Items.Add(cmbIzostali.Text);
                cmbIzostali.Items.Remove(cmbIzostali.SelectedItem);
                cmbIzostali.Text = "";

                txtPrisutni.Text = "";
                txtIzostali.Text = "";
                foreach (string tekst in cmbIzostali.Items)
                {
                    txtIzostali.Text += tekst + Environment.NewLine;
                }

                foreach (string tekst in cmbPrisutni.Items)
                {
                    txtPrisutni.Text += tekst + Environment.NewLine;
                }
            }
        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }
    }
}
