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
    public partial class IzbornikProfesora : Form
    {
        public IzbornikProfesora()
        {
            InitializeComponent();
            this.CenterToParent();
            string sql = "SELECT \"ID_predmet\" FROM \"Predaje\" WHERE \"Predaje\".\"ID_korisnik\"='" + FrmPrijava.Id_korisnika + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            List<string> lista_id_jeva = new List<string>();
            while (citac.Read())
            {
                lista_id_jeva.Add(citac["ID_predmet"].ToString());
      
            }

            citac.Close();
            foreach (string tekst in lista_id_jeva)
            {
                sql = "SELECT naziv_predmeta FROM \"Predmeti\" WHERE \"ID_predmet\" ='" + tekst + "';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    cmbPopis.Items.Add(citac["naziv_predmeta"].ToString());

                }
                citac.Close();
            }

            cmbPopis.SelectedIndex = 0;




            txtImePrezime.Text = FrmPrijava.Ime + " " + FrmPrijava.Prezime;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cmbPopis.Text == "")
            {

            }

            else 
            {
                EvidencijaSata evidencijasata = new EvidencijaSata(cmbPopis.Text);
                this.Hide();
                evidencijasata.ShowDialog();
                this.Show();


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OdabirUloge odabiruloge = new OdabirUloge();
            this.Hide();
            odabiruloge.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PopisPredmetnihUcenika popispredmetnihucenika = new PopisPredmetnihUcenika(cmbPopis.SelectedItem.ToString(),txtImePrezime.Text);
            this.Hide();
            popispredmetnihucenika.ShowDialog();
            this.Show();

        }

        private void txtImePrezime_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
