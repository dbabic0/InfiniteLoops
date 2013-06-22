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
    public partial class PopisPredmetnihUcenika : Form
    {
        private string id_predmeta;
        private string predmet;
        private string imeprofesora;
       
        public PopisPredmetnihUcenika(string predmet,string imeprofesora)
        {
            InitializeComponent();

            this.imeprofesora = imeprofesora;
            this.predmet = predmet;

            //MessageBox.Show(imeprofesora);
            this.CenterToParent();
            textBox3.Text = imeprofesora;


            DohvatiUcenike();

        }

        private void DohvatiUcenike()
        {
            string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE \"naziv_predmeta\"='" + predmet + "';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                id_predmeta = citac["ID_predmet"].ToString();

            }
            citac.Close();


            sql = "SELECT \"ID_korisnik\" FROM \"Pohada\" WHERE \"ID_predmet\"='" + id_predmeta + "';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);

            List<string> idjevi = new List<string>();

            while (citac.Read())
            {
                idjevi.Add(citac["ID_korisnik"].ToString());

            }
            citac.Close();

            DataGridViewColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "OIB";
            dataGridView1.Columns.Add(col1);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Datum rođenja";
            dataGridView1.Columns.Add(col4);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Ime";//order by
            dataGridView1.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Prezime";
            dataGridView1.Columns.Add(col3);

            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Id";
            dataGridView1.Columns.Add(col5);
            dataGridView1.Columns[4].Visible = false;


            int i = 0;
            foreach (string id in idjevi)
            {
                dataGridView1.Rows.Add();
            }

            int mjesec = DateTime.Now.Month;
            int godina = DateTime.Now.Year;

            foreach (string id in idjevi)
            {
                //,date_part('month',datum),date_part('year',datum)

                sql = "SELECT \"OIB\", ime,prezime,datum_rodenja::varchar(10) FROM \"Korisnik\", \"Ocjena\" WHERE \"Korisnik\".\"ID_korisnik\"='" + id + "' ";
                sql += "AND \"Ocjena\".\"ID_korisnik\"='" + id + "' AND date_part('month',datum)='" + mjesec + "' AND date_part('year',datum)='" + godina + "' AND Usmeno IS NOT NULL; ";


                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        dataGridView1.Rows[i].Cells[0].Value = citac["OIB"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = citac["datum_rodenja"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = citac["ime"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = citac["prezime"].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = id;

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightPink;
                    }
                    i++;
                    citac.Close();
                }
                else
                {
                    citac.Close();
                    //SELECT date_part('month',datum), date_part('year',datum) FROM "Ocjena";
                    sql = "SELECT \"OIB\", ime,prezime,datum_rodenja::varchar(10) FROM \"Korisnik\" WHERE \"ID_korisnik\"='" + id + "';";

                    citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                    while (citac.Read())
                    {
                        dataGridView1.Rows[i].Cells[0].Value = citac["OIB"].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = citac["datum_rodenja"].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = citac["ime"].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = citac["prezime"].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = id;
                    }

                    i++;

                    citac.Close();
                }
            }
            this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Ascending);

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool ponovno_generiraj = false;
            int ispitani;
            do
            {
                ponovno_generiraj = false;
                Random rnd = new Random();
                ispitani = rnd.Next(0, dataGridView1.Rows.Count - 1);
                if (dataGridView1.Rows[ispitani].DefaultCellStyle.BackColor == Color.LightPink)
                {
                   
                    ponovno_generiraj = true;

                }

            } while (ponovno_generiraj == true);
            UpaliFormuPredmet(ispitani);
        }

        private void UpaliFormuPredmet(int ispitani)
        {
            string ime, prezime, datum, oib, id;
            oib = dataGridView1.Rows[ispitani].Cells[0].Value.ToString();
            datum = dataGridView1.Rows[ispitani].Cells[1].Value.ToString();
            ime = dataGridView1.Rows[ispitani].Cells[2].Value.ToString();
            prezime = dataGridView1.Rows[ispitani].Cells[3].Value.ToString();
            id = dataGridView1.Rows[ispitani].Cells[4].Value.ToString();
            Predmet predmet = new Predmet(id, prezime, ime, oib, datum, id_predmeta);
            this.Hide();
            predmet.ShowDialog();
            this.Show();
            dataGridView1.Columns[0].Dispose();
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            DohvatiUcenike();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1) { }
            else
            {
                UpaliFormuPredmet(dataGridView1.CurrentRow.Index);
            }

        }
    }
}
