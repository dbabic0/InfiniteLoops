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
                string sql = "SELECT korisnicko_ime,lozinka from \"Korisnik\" WHERE korisnicko_ime='" + txtKorIme.Text + "' AND lozinka='" + txtLozinka.Text + "';";
                NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                if (citac.HasRows == true)
                {
                    //MessageBox.Show("Uspješna prijava!");
                    this.Hide();
                    OdabirUloge odabiruloge = new OdabirUloge();
                    odabiruloge.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neuspješna prijava!");
                }

            }

        }
    }
}
