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

        private void cmbPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdabirUloge odabiruloge = new OdabirUloge();
            this.Hide();
            odabiruloge.ShowDialog();
            this.Close();

        }

        private void btnEvidencijaSata_Click(object sender, EventArgs e)
        {
            EvidencijaSata evidencijasata = new EvidencijaSata(cmbPredmeti.Text, true);
            this.Hide();
            evidencijasata.ShowDialog();
            this.Show();
        }

        private void btnPopisUcenika_Click(object sender, EventArgs e)
        {
            PopisUcenika popisucenika = new PopisUcenika();
            this.Hide();

            popisucenika.ShowDialog();
            this.Show();

        }
    }
}
