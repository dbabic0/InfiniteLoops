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
                string sql = "SELECT korisnicko_ime,lozinka,ime,prezime from \"Korisnik\" WHERE korisnicko_ime='" + txtKorIme.Text + "' AND lozinka='" + txtLozinka.Text + "';";
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
                    }
                    this.Hide();
                    citac.Close();

                    OdabirUloge odabiruloge = new OdabirUloge();
                    odabiruloge.ShowDialog();
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
