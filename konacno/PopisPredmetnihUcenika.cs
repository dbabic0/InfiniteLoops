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
        private bool profesor_razrednik;
        private string razred;

       /// <summary>
       /// Pozovi funkciju koja dohvaca ucenike
       /// </summary>
       /// <param name="predmet"></param>
       /// <param name="razred"></param>
       /// <param name="imeprofesora"></param>
        public PopisPredmetnihUcenika(string predmet,string razred,string imeprofesora)
        {
            InitializeComponent();

            this.imeprofesora = imeprofesora;
            this.predmet = predmet;

            //MessageBox.Show(imeprofesora);
            this.CenterToParent();
            textBox3.Text = imeprofesora;

            profesor_razrednik = false;
            this.razred = razred;
            DohvatiUcenike();

        }

        /// <summary>
        /// Dohvati ucenike koji pripadaju tom predmetu i razredu ( lista_Idjeva)
        /// Zatim provjeri njihove ocjene za tekući mjesec i ako imaju ocjenu onda
        /// ih zacrveni 
        /// </summary>
        /// <param name="lista_idjeva"></param>
        /// <param name="imeprofesora"></param>
        /// <param name="razred"></param>
        public PopisPredmetnihUcenika(List<string> lista_idjeva, string imeprofesora, string razred)
        {
            InitializeComponent();
            textBox3.Text = imeprofesora;
            this.CenterToParent();
            this.imeprofesora = imeprofesora;
            this.razred = razred;
            btnRandomIspitivanje.Visible = false;
            profesor_razrednik = true;

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
            foreach (string id in lista_idjeva)
            {
                dataGridView1.Rows.Add();
                string sql = "SELECT \"OIB\", ime,prezime,datum_rodenja::varchar(10) FROM \"Korisnik\" WHERE \"ID_korisnik\"='" + id + "';";
               NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
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

    
            this.dataGridView1.Sort(this.dataGridView1.Columns[3], ListSortDirection.Ascending);

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        /// <summary>
        /// Dohvati sve učenike na tom predmetu u tom razredu
        /// </summary>
        private void DohvatiUcenike()
        {
       
            string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE \"naziv_predmeta\"='" + predmet + "';";
    
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            while (citac.Read())
            {
                id_predmeta = citac["ID_predmet"].ToString();

            }
            citac.Close();
            string id_razred = "";
            sql = "SELECT \"ID_razred\" FROM \"Razred\" WHERE \"naziv_razreda\"='"+razred+"';";
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
                sql = "SELECT \"ID_korisnik\" FROM \"ucenik_pohada_razred\" WHERE \"ID_korisnik\"='"+id+"' AND \"ID_razred\"='"+id_razred+"';";
                citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    idjevi.Add(citac["ID_korisnik"].ToString());
                }
                citac.Close();
            }

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
                sql += "AND \"Ocjena\".\"ID_korisnik\"='" + id + "' AND date_part('month',datum)='" + mjesec + "' AND date_part('year',datum)='" + godina + "' AND tip='2' AND \"ID_predmet\"='"+id_predmeta+"'; ";


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
            this.dataGridView1.Sort(this.dataGridView1.Columns[3], ListSortDirection.Ascending);

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Generiraj random broj koji dohvaća jednog učenika iz datagrida i ispituje ga
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            bool ponovno_generiraj = false;
            int ispitani;
            int i = 0;
            do
            {
                ponovno_generiraj = false;
                Random rnd = new Random();
                ispitani = rnd.Next(0, dataGridView1.Rows.Count - 1);
                if (dataGridView1.Rows[ispitani].DefaultCellStyle.BackColor == Color.LightPink)
                {
                   
                    ponovno_generiraj = true;

                }
                i++;
                if (i == 100)
                {
                    MessageBox.Show("Svi učenici su već ispitani!");
                    break;
                }
            } while (ponovno_generiraj == true);
            if (i == 100) { }
            else
            UpaliFormuPredmet(ispitani);
        }

        /// <summary>
        /// Otvori novu formu s ocjenama
        /// i pošalji joj podatke o učeniku i id predmeta 
        /// </summary>
        /// <param name="ispitani"></param>
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

        /// <summary>
        /// ako se klikne na nekog učenika u datagridu, selektiraj tog odabranog učenika
        /// i otvori formu s ocjenama
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (profesor_razrednik == false)
            {
                if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1) { }
                else
                {
                    UpaliFormuPredmet(dataGridView1.CurrentRow.Index);
                }
            }
            else
            {
                if (dataGridView1.CurrentRow.Index == dataGridView1.Rows.Count - 1) { }
                else
                {
                    int selektirani = dataGridView1.CurrentRow.Index;
                    string ime, prezime, datum, oib, id;
                    oib = dataGridView1.Rows[selektirani].Cells[0].Value.ToString();
                    datum = dataGridView1.Rows[selektirani].Cells[1].Value.ToString();
                    ime = dataGridView1.Rows[selektirani].Cells[2].Value.ToString();
                    prezime = dataGridView1.Rows[selektirani].Cells[3].Value.ToString();
                    id = dataGridView1.Rows[selektirani].Cells[4].Value.ToString();

                    this.Hide();
                    Predmet profil = new Predmet(id, prezime, ime, oib, datum,1);
                    profil.ShowDialog();
                    this.Show();
                    

                }

            }
        }
    }
}
