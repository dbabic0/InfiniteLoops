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
    public partial class IzbornikRazrednika : Form
    {

        /// <summary>
        /// Selektiraj prvo razred kojemo je korisnik razrednik
        /// 
        /// </summary>
        public IzbornikRazrednika()
        {
            InitializeComponent();
            this.CenterToParent();
            string sql = "SELECT naziv_razreda FROM \"Razred\" WHERE \"ID_korisnik\"='" + FrmPrijava.Id_korisnika + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            try
            {
                while (citac.Read())
                {
                    cmbPredmeti.Items.Add(citac["naziv_razreda"].ToString());
                }
                cmbPredmeti.SelectedIndex = 0;
            }

            catch
            {
                MessageBox.Show("Niste nikome razrednik!");
            }
            citac.Close();
            txtImePrezime.Text = FrmPrijava.Ime + " " + FrmPrijava.Prezime;
        }

        /// <summary>
        /// Vrati se nazad na odabir uloge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            OdabirUloge odabiruloge = new OdabirUloge();
            this.Hide();
            odabiruloge.ShowDialog();
            this.Close();
        }

        /// <summary>
        /// Otvori formu evidencija sata i njoj pošalji za koji razred se radi evidencija sata i true
        /// zato jer ako je true onda se radi o razredniku
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEvidencijaSata_Click(object sender, EventArgs e)
        {
            EvidencijaSata evidencijasata = new EvidencijaSata(cmbPredmeti.Text, true);
            this.Hide();
            evidencijasata.ShowDialog();
            this.Show();
        }


        /// <summary>
        /// Ako se klikne na popis predmetnih učenika,
        /// Prvo selektiraj sve korisnike koji pripadaju tom razredu
        /// Dohvati ih u listu
        /// I onda pozovi formu popis predmetnih učenika i njoj proslijedi listu učenika
        /// na tom predmetu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPopisUcenika_Click(object sender, EventArgs e)
        {
            string sql = "SELECT \"ID_razred\" FROM \"Razred\" WHERE naziv_razreda='" + cmbPredmeti.Text + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string id_razred="";
            while(citac.Read())
            {
                id_razred = citac["ID_razred"].ToString();
            }
            citac.Close();
            sql = "SELECT \"ID_korisnik\" FROM \"ucenik_pohada_razred\" WHERE \"ID_razred\"='" + id_razred + "';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            List<string> lista_idjeva = new List<string>();
            while(citac.Read())
            {
                lista_idjeva.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();
            PopisPredmetnihUcenika popis=new PopisPredmetnihUcenika(lista_idjeva,txtImePrezime.Text, cmbPredmeti.Text);
            this.Hide();
            popis.ShowDialog();
            this.Show();
        }
    }
}
