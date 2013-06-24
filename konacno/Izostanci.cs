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
    public partial class Izostanci : Form
    {
        public Izostanci(string OIB, string predmet)
        {
            InitializeComponent();
            this.CenterToParent();
            string sql = "SELECT \"ID_korisnik\" FROM \"Korisnik\" WHERE \"OIB\"='"+OIB+"';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string id_korisnik="";
            while (citac.Read())
            {
                id_korisnik = citac["ID_korisnik"].ToString();
            }
            citac.Close();
            sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE \"naziv_predmeta\"='"+predmet+"';";
            string id_predmet = "";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                id_predmet = citac["ID_predmet"].ToString();
            }
            citac.Close();
            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Datum";//order by
            dataGridView1.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Predmet";//order by
            dataGridView1.Columns.Add(col3);
           
            sql="SELECT \"ID_predmet\", datum FROM \"Izostanci\" WHERE \"ID_korisnik\"='"+id_korisnik+"' AND \"ID_predmet\"='"+id_predmet+"' ORDER BY datum;";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            int i = 0;
            List<string> datum = new List<string>();
            List<string> id = new List<string>();
            while (citac.Read())
            {
               // dataGridView1.Rows.Add();
               // dataGridView1.Rows[i].Cells[0].Value = citac["datum"].ToString();
               // dataGridView1.Rows[i].Cells[1].Value = citac["Predmet"].ToString();
                datum.Add(citac["datum"].ToString());
                id.Add(citac["ID_predmet"].ToString());
            }
            citac.Close();
            foreach (string dat in datum)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = dat;
                sql = "SELECT \"naziv_predmeta\" FROM \"Predmeti\" WHERE \"ID_predmet\"='"+id[i]+"';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    dataGridView1.Rows[i].Cells[1].Value = citac["naziv_predmeta"].ToString();
                }
                citac.Close();
                i++;
                dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
