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

        public Ocjena(string id_korisnika,string id_predmeta,string ocjena,string mjesec,int odabrani_redak)
        {
            InitializeComponent();
            this.CenterToParent();
            Id_predmeta=id_predmeta;
            if (string.Compare(ocjena, "0") == 0)
            {
                Postojeca = false;
            }
            else
            {
                Postojeca = true;

            }
            Id_korisnik=id_korisnika;
            if (odabrani_redak == 0) Kategorija = "pismeno";
            else if (odabrani_redak == 1) Kategorija = "usmeno";
            else if (odabrani_redak == 2) Kategorija = "aktivnost";
            else Kategorija = "domaca_zadaca";

            string sql = "SELECT napomena FROM \"Ocjena\" WHERE \"ID_korisnik\"='" + id_korisnika + "' AND \"ID_predmet\"='" + id_predmeta + "'";
            sql += " AND date_part('month',datum)='" + mjesec + "' AND " + Kategorija + " IS NOT NULL;";

            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                textBox2.Text = citac["napomena"].ToString();
            }
            //MessageBox.Show(ocjena);

            if (ocjena[0] == '-')
            {
                comboBox2.SelectedIndex = 2;
                if (ocjena[1] == '5')
                {
                    comboBox1.SelectedIndex = 0; 

                }
                else if (ocjena[1] == '4')
                {
                    comboBox1.SelectedIndex = 1;

                }
                else if (ocjena[1] == '3')
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (ocjena[1] == '2')
                {
                    comboBox1.SelectedIndex = 3;
                }
                else if (ocjena[1] == '1')
                {
                    comboBox1.SelectedIndex = 4;
                }
            }
            else if (ocjena[0] == '+')
            {
                comboBox2.SelectedIndex = 1;
                //+5 -5 5
                if (ocjena[1] == '5')
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (ocjena[1] == '4')
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if (ocjena[1] == '3')
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (ocjena[1] == '2')
                {
                    comboBox1.SelectedIndex = 3;
                }
                else if (ocjena[1] == '1')
                {
                    comboBox1.SelectedIndex = 4;
                }
            }

            else
            {

                if (ocjena[0] == '5')
                {
                    comboBox1.SelectedIndex = 0;
                }
                else if (ocjena[0] == '4')
                {
                    comboBox1.SelectedIndex = 1;
                }
                else if (ocjena[0] == '3')
                {
                    comboBox1.SelectedIndex = 2;
                }
                else if (ocjena[0] == '2')
                {
                    comboBox1.SelectedIndex = 3;
                }
                else if (ocjena[0] == '1')
                {
                    comboBox1.SelectedIndex = 4;
                }
            }
            citac.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Nije odabrana niti jedna ocjena!");
            }
            else if (comboBox1.Text == "1" && comboBox2.Text == "-")
            {
                MessageBox.Show("Ne mogu upisati ocjenu -1");
            }
            else
            {
                if (Postojeca == false)
                {
                    string sql = "INSERT INTO \"Ocjena\" ( \"ID_predmet\", \"ID_korisnik\", datum, " + kategorija + ", napomena) VALUES";
                    sql += "( '" + Id_predmeta + "','" + Id_korisnik + "','" + DateTime.Now.ToShortDateString() + "','" + comboBox2.Text + comboBox1.Text + "','" + textBox2.Text + "');";
                    BazaPodataka.Instance.IzvrsiUpit(sql);
                    
                }
                else
                {
                    string sql = "UPDATE \"Ocjena\" SET " + kategorija + "='" + comboBox2.Text + comboBox1.Text + "', napomena='" + textBox2.Text + "'  WHERE ";
                    sql += "\"ID_korisnik\"='" + Id_korisnik + "' AND \"ID_predmet\"='" + Id_predmeta + "'";
                    sql += " AND date_part('month',datum)='" + DateTime.Now.Month.ToString() + "';";
                    BazaPodataka.Instance.IzvrsiUpit(sql);
                    
                }
                MessageBox.Show("Uspješno upisana ocjena!");
                this.Close();
            }

        }
    }
}
