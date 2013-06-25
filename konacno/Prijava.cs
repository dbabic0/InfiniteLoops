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
    public partial class FrmPrijava : Form
    {

        private static string korisnicko_ime;
        private static string lozinka;
        private static string ime;
        private static string prezime;
        private static string id_korisnika;
        private static string tip_korisnika;
        private static string OIB;
        private static string Datum;
        public static string Tip_korisnika
        {
            get { return tip_korisnika; }
            private set { tip_korisnika = value; }
        }
        public static string Id_korisnika
        {
            get { return id_korisnika;}
            set{id_korisnika=value;}
        }

        public static string Korisnicko_ime
        {
            get{return korisnicko_ime;}
            set{korisnicko_ime=value;}
        }
        public static string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; }
        }
        public static string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public static string Prezime
        {
            get { return prezime;}
            set { prezime = value; }
        }

        public FrmPrijava()
        {
            InitializeComponent();

            this.CenterToParent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIzlaz_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            if (txtKorIme.Text == "")
            {
                MessageBox.Show("Niste unijeli korisnicko ime!");
            }
            else if (txtLozinka.Text == "")
            {
                MessageBox.Show("Niste unijeli lozinku!");
            }
            else
            {
                string sql = "SELECT \"ID_korisnik\",korisnicko_ime,lozinka,ime,prezime,tip_korisnika,\"OIB\",datum_rodenja::VARCHAR(10) FROM \"Korisnik\" WHERE korisnicko_ime='" + txtKorIme.Text + "' AND lozinka='" + txtLozinka.Text + "';";
                NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                if (citac.HasRows)
                {
                    MessageBox.Show("Uspješna prijava!");
                    
                    
                    Korisnicko_ime = txtKorIme.Text;
                    Lozinka = txtLozinka.Text;
                    while (citac.Read())
                    {
                        
                        Ime = citac["ime"].ToString();
                        Prezime = citac["prezime"].ToString();
                        Id_korisnika = citac["ID_korisnik"].ToString();
                        Tip_korisnika = citac["tip_korisnika"].ToString();
                        OIB=citac["OIB"].ToString();
                        Datum=citac["datum_rodenja"].ToString();
                    }
                    this.Hide();
                    citac.Close();
                    if (string.Compare(Tip_korisnika, "1") == 0)
                    {
                        OdabirUloge odabiruloge = new OdabirUloge();
                        odabiruloge.ShowDialog();
                    }
                    else
                    {
                        Predmet predmet = new Predmet(id_korisnika, prezime, ime, OIB, Datum, 2);
                        predmet.ShowDialog();
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neuspješna prijava!");
                    citac.Close();
                }

            }

        }
    }
}
