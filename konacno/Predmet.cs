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
    public partial class Predmet : Form
    {
        private string id;
        private string predmet_id;

        private string Predmet_id
        {
            get
            {
                return predmet_id;
            }

            set
            {
                predmet_id = value;
            }
        }


        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Predmet(string id, string prezime, string ime, string oib, string datum, string predmet)
        {
            InitializeComponent();
            this.CenterToParent();
            textBox1.Text = ime + " " + prezime;
            textBox2.Text = datum;
            textBox3.Text = oib;
            Id = id;
            Predmet_id = predmet;
            Pokazi_ocjene();



        }

        private void Pokazi_ocjene()
        {
            dodaj_stupac("");
            dodaj_stupac("9.");
            dodaj_stupac("10.");
            dodaj_stupac("11.");
            dodaj_stupac("12.");
            dodaj_stupac("1.");
            dodaj_stupac("2.");
            dodaj_stupac("3.");
            dodaj_stupac("4.");
            dodaj_stupac("5.");
            dodaj_stupac("6.");
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows.Add();
            dataGridView1.Rows[0].Cells[0].Value = "Pismeni";
            dataGridView1.Rows[1].Cells[0].Value = "Usmeni";
            dataGridView1.Rows[2].Cells[0].Value = "Aktivnost";
            dataGridView1.Rows[3].Cells[0].Value = "Domaća zadaća";
            string sql = "SELECT date_part('month',datum), date_part('year',datum), pismeno, usmeno, aktivnost, domaca_zadaca FROM \"Ocjena\" WHERE \"ID_korisnik\"='" + Id + "' AND \"ID_predmet\"='"+Predmet_id+"';";
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            string mjesec = DateTime.Now.Month.ToString();
            
            int ukupno_ocjena = 0;
            double zbroj_ocjena = 0;



            while (citac.Read())
            {
                int mj=0; 
                if (string.Compare(citac[0].ToString(),"9")==0) mj=1;
                else if (string.Compare(citac[0].ToString(),"10")==0) mj=2;
                else if (string.Compare(citac[0].ToString(),"11")==0) mj=3;
                else if (string.Compare(citac[0].ToString(),"12")==0) mj=4;
                else if (string.Compare(citac[0].ToString(),"1")==0) mj=5;
                else if (string.Compare(citac[0].ToString(),"2")==0) mj=6;
                else if (string.Compare(citac[0].ToString(),"3")==0) mj=7;
                else if (string.Compare(citac[0].ToString(),"4")==0) mj=8;
                else if (string.Compare(citac[0].ToString(),"5")==0) mj=9;
                else if (string.Compare(citac[0].ToString(),"6")==0) mj=10;

                string ocjena;


                    if (string.Compare(citac["pismeno"].ToString(), "") == 0) { }
                    else
                    {
                        dataGridView1.Rows[0].Cells[mj].Value = citac["pismeno"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["pismeno"].ToString();
                        if (ocjena[0] == '-')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) - 0.25;
                        }
                        else if (ocjena[0] == '+')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) + 0.25;
                        }
                        else
                        {
                            zbroj_ocjena += float.Parse(ocjena);
                        }
                    }
                    if (string.Compare(citac["usmeno"].ToString(), "") == 0) { }
                    else
                    {
                        dataGridView1.Rows[1].Cells[mj].Value = citac["usmeno"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["usmeno"].ToString();
                        if (ocjena[0] == '-')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) - 0.25;
                        }
                        else if (ocjena[0] == '+')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) + 0.25;
                        }
                        else
                        {
                            zbroj_ocjena += float.Parse(ocjena);
                        }
                    }
                    if (string.Compare(citac["aktivnost"].ToString(), "") == 0) { }
                    else
                    {
                        dataGridView1.Rows[2].Cells[mj].Value = citac["aktivnost"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["aktivnost"].ToString();
                        if (ocjena[0] == '-')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) - 0.25;
                        }
                        else if (ocjena[0] == '+')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) + 0.25;
                        }
                        else
                        {
                            zbroj_ocjena += float.Parse(ocjena);
                        }
                    }
                    if (string.Compare(citac["domaca_zadaca"].ToString(), "") == 0) { }
                    else
                    {
                        dataGridView1.Rows[3].Cells[mj].Value = citac["domaca_zadaca"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["domaca_zadaca"].ToString();
                        if (ocjena[0] == '-')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) - 0.25;
                        }
                        else if (ocjena[0] == '+')
                        {
                            zbroj_ocjena += float.Parse(ocjena[1].ToString()) + 0.25;
                        }
                        else
                        {
                            zbroj_ocjena += float.Parse(ocjena);
                        }
                    }

               
            }
            citac.Close();
            if (ukupno_ocjena == 0) { }
            else
            {


                if (((float)(zbroj_ocjena / ukupno_ocjena)) > 5) textBox8.Text = "5";
                else
                {
                    textBox8.Text = ((Math.Round(zbroj_ocjena / ukupno_ocjena, 2))).ToString();

                }
            }
            sql = "SELECT zakljucna_ocjena FROM \"Pohada\" WHERE \"ID_predmet\"='"+Predmet_id+"' AND \"ID_korisnik\"='"+id+"';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            if (citac.HasRows)
            {
                while (citac.Read())
                {
                    textBox9.Text = citac["zakljucna_ocjena"].ToString();
                }
            }
            citac.Close();
        }

        public void dodaj_stupac(string ime_stupca)
        {
            DataGridViewColumn stupac = new DataGridViewTextBoxColumn();
            stupac.HeaderText = ime_stupca;
            dataGridView1.Columns.Add(stupac);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE \"Pohada\" SET zakljucna_ocjena='"+textBox9.Text+"'";
            sql+=" WHERE \"ID_predmet\"='"+Predmet_id+"' AND \"ID_korisnik\"='"+id+"';";
            MessageBox.Show("Uspješno unesena zaključna ocjena!");


            BazaPodataka.Instance.IzvrsiUpit(sql);
        }

    }
}
