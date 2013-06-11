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
            //string sql = "SELECT ime, prezime FROM \"Korisnik\" WHERE korisnicko_ime='" + Login.korisnicko_ime + "' AND lozinka='" + Login.lozinka + "';";
            //NpgsqlDataReader citac= BazaPodataka.Instance.DohvatiDataReader(sql);
            //while (citac.Read())
            //{
            //    txtImePrezime.Text = citac["ime"] + " " + citac["prezime"];
            //}
            //citac.Close();
            txtImePrezime.Text = FrmPrijava.Ime + " " + FrmPrijava.Prezime;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
