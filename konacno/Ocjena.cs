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

namespace Forme
{
    public partial class Ocjena : Form
    {
        private string id_predmeta; 
        private string kategorija;
        private string id_korisnik;
        private bool postojeca;
        private bool profesor_razrednik;
        public string Id_predmeta
        {
            get{return id_predmeta;}
            set{id_predmeta=value;}
        }
        public string Kategorija
        {
            get{ return kategorija;}
            set{kategorija=value;}
        }
        public string Id_korisnik
        {
            get{return id_korisnik;}
            set{id_korisnik=value;}
        }
        public bool Postojeca
        {
            get { return postojeca; }
            set { postojeca = value; }
        }

        public Ocjena(string id_korisnika,string id_predmeta,string ocjena,string mjesec,int odabrani_redak, bool profesor_razrednik)
        {
            InitializeComponent();
            this.CenterToParent();
            Id_predmeta=id_predmeta;
            this.profesor_razrednik = profesor_razrednik;
            if (string.Compare(ocjena, "0") == 0)
            {
                Postojeca = false;
            }
            else
            {
                Postojeca = true;

            }
            Id_korisnik=id_korisnika;
            if (odabrani_redak == 0) Kategorija = "1";
            else if (odabrani_redak == 1) Kategorija = "2";
            else if (odabrani_redak == 2) Kategorija = "3";
            else Kategorija = "4";

            string sql = "SELECT napomena,datum FROM \"Ocjena\" WHERE \"ID_korisnik\"='" + id_korisnika + "' AND \"ID_predmet\"='" + id_predmeta + "'";
            sql += " AND date_part('month',datum)='" + mjesec + "' AND tip='" +kategorija+ "';";

            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                txtNapomena.Text = citac["napomena"].ToString();
               //ss MessageBox.Show(citac["datum"].ToString());
                dateTimePicker1.Value = Convert.ToDateTime(citac["datum"].ToString());

            }
            //MessageBox.Show(ocjena);

            if (ocjena[0] == '-')
            {
                cmbPredznak.SelectedIndex = 2;
                if (ocjena[1] == '5')
                {
                    cmbOcjena.SelectedIndex = 0; 

                }
                else if (ocjena[1] == '4')
                {
                    cmbOcjena.SelectedIndex = 1;

                }
                else if (ocjena[1] == '3')
                {
                    cmbOcjena.SelectedIndex = 2;
                }
                else if (ocjena[1] == '2')
                {
                    cmbOcjena.SelectedIndex = 3;
                }
                else if (ocjena[1] == '1')
                {
                    cmbOcjena.SelectedIndex = 4;
                }
            }
            else if (ocjena[0] == '+')
            {
                cmbPredznak.SelectedIndex = 1;
                //+5 -5 5
                if (ocjena[1] == '5')
                {
                    cmbOcjena.SelectedIndex = 0;
                }
                else if (ocjena[1] == '4')
                {
                    cmbOcjena.SelectedIndex = 1;
                }
                else if (ocjena[1] == '3')
                {
                    cmbOcjena.SelectedIndex = 2;
                }
                else if (ocjena[1] == '2')
                {
                    cmbOcjena.SelectedIndex = 3;
                }
                else if (ocjena[1] == '1')
                {
                    cmbOcjena.SelectedIndex = 4;
                }
            }

            else
            {

                if (ocjena[0] == '5')
                {
                    cmbOcjena.SelectedIndex = 0;
                }
                else if (ocjena[0] == '4')
                {
                    cmbOcjena.SelectedIndex = 1;
                }
                else if (ocjena[0] == '3')
                {
                    cmbOcjena.SelectedIndex = 2;
                }
                else if (ocjena[0] == '2')
                {
                    cmbOcjena.SelectedIndex = 3;
                }
                else if (ocjena[0] == '1')
                {
                    cmbOcjena.SelectedIndex = 4;
                }
            }
            citac.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (profesor_razrednik == false)
            {
                if (cmbOcjena.Text == "")
                {
                    MessageBox.Show("Nije odabrana niti jedna ocjena!");
                }
                else if (cmbOcjena.Text == "1" && cmbPredznak.Text == "-")
                {
                    MessageBox.Show("Ne mogu upisati ocjenu -1");
                }
                else
                {
                    DialogResult di=MessageBox.Show("Jeste li sigurni da želite unijeti ocjenu?","Potvrda unosa",MessageBoxButtons.YesNo);

                    if (di == DialogResult.Yes)
                    {
                        if (Postojeca == false)
                        {
                            string sql = "INSERT INTO \"Ocjena\" ( \"ID_predmet\", \"ID_korisnik\", datum, tip,ocjena,napomena) VALUES";
                            sql += "( '" + Id_predmeta + "','" + Id_korisnik + "','" + DateTime.Now.ToShortDateString() +"','"+kategorija+ "','" + cmbPredznak.Text + cmbOcjena.Text + "','" + txtNapomena.Text + "');";
                            BazaPodataka.Instance.IzvrsiUpit(sql);

                        }
                        else
                        {
                            string sql = "UPDATE \"Ocjena\" SET ocjena='" + cmbPredznak.Text + cmbOcjena.Text + "', napomena='" + txtNapomena.Text + "'  WHERE ";
                            sql += "\"ID_korisnik\"='" + Id_korisnik + "' AND \"ID_predmet\"='" + Id_predmeta + "'";
                            sql += " AND date_part('month',datum)='" + DateTime.Now.Month.ToString() + "' AND tip='"+kategorija+"';";
                            BazaPodataka.Instance.IzvrsiUpit(sql);

                        }
                        MessageBox.Show("Uspješno upisana ocjena!");
                        this.Close();
                    }
                    else
                    {

                    }
                }
            }

            else 
            {

                this.Close();
            }

        }
    }
}
