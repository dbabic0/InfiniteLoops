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
    public partial class EvidencijaSata : Form
    {
        public EvidencijaSata()
        {
            InitializeComponent();
        }
        private string ime_predmeta;
        public EvidencijaSata(string imePredmeta)
        {
            InitializeComponent();
            ime_predmeta = imePredmeta;
            //MessageBox.Show(ime_predmeta);
            lblDatum.Text= DateTime.Today.ToShortDateString();
            string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE naziv_predmeta='" + ime_predmeta + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string id_predmeta= "";
            while(citac.Read())
            {
                id_predmeta= citac["ID_predmet"].ToString();
            }
            citac.Close();
            sql= "SELECT \"ID_korisnik\" FROM \"Pohada\" WHERE \"ID_predmet\"='" + id_predmeta + "';";
            List<string> lista_idjeva= new List<string>();
            citac=BazaPodataka.Instance.DohvatiDataReader(sql);
            while(citac.Read())
            {
                lista_idjeva.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();
            foreach(string tekst in lista_idjeva)
                {
                    sql= "SELECT ime, prezime FROM \"Korisnik\" WHERE \"ID_korisnik\"='" + tekst + "';";
                    citac=BazaPodataka.Instance.DohvatiDataReader(sql);
                    while(citac.Read())
                    {
                        string tekst2 = "";
                        tekst2 += tekst;
                        tekst2 += citac["ime"].ToString();
                        tekst2 += citac["prezime"].ToString();
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
            if (textBox1.Text == "") { }
           


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
    }
}
