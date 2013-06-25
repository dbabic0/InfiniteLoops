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

        /// <summary>
        /// Ako je razrednik pozvao evidenciju sata
        /// Onda se prvo selektira id razreda s tim nazivom
        /// Zatim se selektiraju idjevi učenika koji pohađaju taj razred
        /// Zatim se selektiraju podaci učenika s tim idjevima
        /// </summary>
        /// <param name="razred">Ime predmeta koji profesor predaje</param>
        /// <param name="id">Naziv razreda kojem profesor predaje taj predmet</param>
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

            string id_razred = "";
            sql = "SELECT \"ID_razred\" FROM \"Razred\" WHERE \"naziv_razreda\"='" + razred + "';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                id_razred = citac["ID_razred"].ToString();
            }

            sql = "SELECT \"Pohada\".\"ID_korisnik\" FROM \"Pohada\" WHERE \"Pohada\".\"ID_predmet\"='" + id_predmeta + "';";
            //  AND \"ucenik_pohada_razred\".\"ID_razred\"='"+id_razred+"' AND \ucenik_pohada_razred\".\"ID_predmet\"='"+id_predmeta+"';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);

            List<string> idjevi = new List<string>();
            List<string> idjevi2 = new List<string>();

            while (citac.Read())
            {
                idjevi2.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();
            foreach (string id2 in idjevi2)
            {
                sql = "SELECT \"ID_korisnik\" FROM \"ucenik_pohada_razred\" WHERE \"ID_korisnik\"='" + id2 + "' AND \"ID_razred\"='" + id_razred + "';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    idjevi.Add(citac["ID_korisnik"].ToString());
                }
                citac.Close();
            }
            DohvatiStudentePredmeta(ref sql,ref citac,id_predmeta,idjevi);
        }


        /// <summary>
        /// Ako je evidenciju sata pozvao profesor, pozvaoi ju je sa predmetom i razredom 
        /// Onda selektiramo sve idjeve učenika koji pripadaju tom predmetu i razredu
        /// </summary>
        /// <param name="imePredmeta">Ime predmeta koji profesor predaje</param>
        /// <param name="razred"> Naziv razreda kojem profesor predaje taj predmet</param>
        public EvidencijaSata(string imePredmeta,string razred)
        {
            InitializeComponent();
            this.CenterToParent();
            ime_predmeta = imePredmeta;
            //MessageBox.Show(ime_predmeta);
            lblDatum.Text= DateTime.Today.ToShortDateString();
            string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE naziv_predmeta='" + ime_predmeta + "';";

            //////////////////////////////////////////////////////////////
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string id_predmeta = "";
            while (citac.Read())
            {
                id_predmeta = citac["ID_predmet"].ToString();
                id_predmeta2 = id_predmeta;
            }
            citac.Close();
       
            string id_razred = "";
            sql = "SELECT \"ID_razred\" FROM \"Razred\" WHERE \"naziv_razreda\"='" + razred + "';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                id_razred = citac["ID_razred"].ToString();
            }

            sql = "SELECT \"Pohada\".\"ID_korisnik\" FROM \"Pohada\" WHERE \"Pohada\".\"ID_predmet\"='" + id_predmeta + "';";
            //  AND \"ucenik_pohada_razred\".\"ID_razred\"='"+id_razred+"' AND \ucenik_pohada_razred\".\"ID_predmet\"='"+id_predmeta+"';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);

            List<string> idjevi = new List<string>();
            List<string> idjevi2 = new List<string>();

            while (citac.Read())
            {
                idjevi2.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();
            foreach (string id in idjevi2)
            {
                sql = "SELECT \"ID_korisnik\" FROM \"ucenik_pohada_razred\" WHERE \"ID_korisnik\"='" + id + "' AND \"ID_razred\"='" + id_razred + "';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    idjevi.Add(citac["ID_korisnik"].ToString());
                }
                citac.Close();
            }
            //////////////////////////////////////////////////////////////
           
            DohvatiStudentePredmeta(ref sql, ref citac, id_predmeta,idjevi);
                
         }

        /// <summary>
        /// Dohvacamo studente i spremamo ih prvo u comboboxove onih koji su prisutni na nastavi
        /// I spremamo ih u text box sa strane koji prikazuje preglednije listu učenika 
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="citac"></param>
        /// <param name="id_predmeta"></param>
        /// <param name="lista_idjeva"></param>
        private void DohvatiStudentePredmeta(ref string sql, ref NpgsqlDataReader citac, string id_predmeta,List<string> lista_idjeva)
        {
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

        /// <summary>
        /// Ako se klikne na korisnika da je izostao,
        /// Prvo ga se premjesti u drugi combo box ( izostali ),
        /// Zatim se isprazni iz trenutnog comboboxa ( prisutni )
        /// Zatim se isprazne i ponovno popune oni textboxovi sa strane  s prisutnim i izostalim učenicima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Isto kao i za gumb/funkciju iznad ( IZOSTAO )
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Ako se klikne evidentiraj
        /// Prvo se provjeri REGEXP ( kopiran sa internet stranice stack overflow
        /// Zatim se upiše u evidenciju sata i upišu se korisnici koji su izostali
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvidentiraj_Click(object sender, EventArgs e)
        {

            Regex regex = new Regex(@"^[0-9]+$");

            if (regex.IsMatch(txtRedni_broj_sata.Text))
            {

            }
            else
            {
                txtRedni_broj_sata.Text = "";
                MessageBox.Show("U redni broj sata mozete unijeti samo brojeve!");
            }
            if (txtRedni_broj_sata.Text == "") { }
            else
            {
                string sql = "INSERT INTO \"Evidencija\"(\"ID_korisnik\",redni_broj_sata,tema) VALUES ( '" + FrmPrijava.Id_korisnika + "','" + txtRedni_broj_sata.Text + "','" + txtTema.Text + "');";
                BazaPodataka.Instance.IzvrsiUpit(sql);
                foreach (string stavka in cmbIzostali.Items)
                {
                    //MessageBox.Show("Ovo je korisnik: " + stavka);
                    string id_korisnika = "";
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
                    sql = "INSERT INTO \"Izostanci\"(\"ID_korisnik\",\"ID_predmet\",datum) VALUES ('" + id_korisnika + "','" + id_predmeta2 + "','" + DateTime.Now.ToShortDateString() + "');";
                    //MessageBox.Show(sql);
                    BazaPodataka.Instance.IzvrsiUpit(sql);
                }


                MessageBox.Show("Evidencija sata uspjesno unesena!");
                this.Close();
            }
        }
    }
}
