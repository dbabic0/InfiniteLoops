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
        public Ocjena(string id_korisnika,string id_predmeta,string ocjena,string mjesec,int odabrani_redak)
        {
            InitializeComponent();
            this.CenterToParent();
            string kategorija;
            if (odabrani_redak == 0) kategorija = "pismeno";
            else if (odabrani_redak == 1) kategorija = "usmeno";
            else if (odabrani_redak == 2) kategorija = "aktivnost";
            else kategorija = "domaca_zadaca";

            string sql = "SELECT napomena FROM \"Ocjena\" WHERE \"ID_korisnik\"='" + id_korisnika + "' AND \"ID_predmet\"='" + id_predmeta + "'";
            sql += " AND date_part('month',datum)='" + mjesec + "' AND " + kategorija + " IS NOT NULL;";

            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                textBox2.Text = citac["napomena"].ToString();
            }
            //MessageBox.Show(ocjena);

            if (ocjena[0] == '-')
            {
                comboBox2.SelectedIndex = 1;
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
                comboBox2.SelectedIndex = 0;
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
    }
}
