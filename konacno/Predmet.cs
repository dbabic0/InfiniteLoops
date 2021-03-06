﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;

namespace Forme
{
    public partial class Predmet : Form
    {
        private string id;
        private string predmet_id;
        public bool profesor_razrednik;
        private int tip;

        
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

        /// <summary>
        /// ovu formu je pozvao razrednik
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prezime"></param>
        /// <param name="ime"></param>
        /// <param name="oib"></param>
        /// <param name="datum"></param>
        /// <param name="tip"></param>
        public Predmet(string id, string prezime, string ime, string oib, string datum,int tip)
        {
            InitializeComponent();
            this.CenterToParent();
            this.tip = tip;
            txtImePrezimeUcenika.Text = ime + " " + prezime;
            txtDatumRodenja.Text = datum;
            txtOIB.Text = oib;
            Id = id;
            btnPotvrdiZakljucnu.Visible = false;
            txtZakljucna.Enabled = false;
            string sql = "SELECT \"ID_predmet\" FROM \"Pohada\" WHERE \"ID_korisnik\"='" + id + "';";
            profesor_razrednik = true;
            btnIzostanci.Visible = true;
            NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);

            List<string> idjevi_predmeta = new List<string>();
            while (citac.Read())
            {
                idjevi_predmeta.Add(citac["ID_predmet"].ToString());
            }
            citac.Close();

            foreach (string id_pr in idjevi_predmeta)
            { 
                sql = "SELECT naziv_predmeta FROM \"Predmeti\" WHERE \"ID_predmet\"='"+id_pr+"';";
                citac= BazaPodataka.Instance.DohvatiDataReader(sql);
                while(citac.Read())
                {
                    cmbPopis_predmeta.Items.Add(citac["naziv_predmeta"].ToString());

                }
                citac.Close();
            }
            if (tip == 2)
            {
                btnPotvrdiZakljucnu.Enabled = false;
            }
            try
            {
                cmbPopis_predmeta.SelectedIndex = 0;
            }
            catch
            {

            }
            }

        /// <summary>
        /// Ovu formu je pozvao profesor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="prezime"></param>
        /// <param name="ime"></param>
        /// <param name="oib"></param>
        /// <param name="datum"></param>
        /// <param name="predmet"></param>
        public Predmet(string id, string prezime, string ime, string oib, string datum, string predmet)
        {
            InitializeComponent();
            this.CenterToParent();
            btnIzvjestaj.Visible = false;
            profesor_razrednik = false;
            txtImePrezimeUcenika.Text = ime + " " + prezime;
            txtDatumRodenja.Text = datum;
            txtOIB.Text = oib;
            Id = id;
            Predmet_id = predmet;
            cmbPopis_predmeta.Visible = false;
            label10.Visible = false;
            Pokazi_ocjene();
        }

        /// <summary>
        /// 
        /// </summary>
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
            string sql = "SELECT date_part('month',datum), date_part('year',datum),tip,ocjena FROM \"Ocjena\" WHERE \"ID_korisnik\"='" + Id + "' AND \"ID_predmet\"='"+Predmet_id+"';";
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

              //  MessageBox.Show(citac["tip"].ToString());
                    if (string.Compare(citac["tip"].ToString(), "1") == 0) { 
                        dataGridView1.Rows[0].Cells[mj].Value = citac["ocjena"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["ocjena"].ToString();
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
                    if (string.Compare(citac["tip"].ToString(), "2") == 0) { 
                        dataGridView1.Rows[1].Cells[mj].Value = citac["ocjena"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["ocjena"].ToString();
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
                    if (string.Compare(citac["tip"].ToString(), "3") == 0) { 
                        dataGridView1.Rows[2].Cells[mj].Value = citac["ocjena"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["ocjena"].ToString();
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
                    if (string.Compare(citac["tip"].ToString(), "4") == 0) { 
                        dataGridView1.Rows[3].Cells[mj].Value = citac["ocjena"].ToString();
                        ukupno_ocjena++;
                        ocjena = citac["ocjena"].ToString();
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


                if (((float)(zbroj_ocjena / ukupno_ocjena)) > 5) txtProsjek.Text = "5";
                else
                {
                    txtProsjek.Text = ((Math.Round(zbroj_ocjena / ukupno_ocjena, 2))).ToString();

                }
            }
            sql = "SELECT zakljucna_ocjena FROM \"Pohada\" WHERE \"ID_predmet\"='"+Predmet_id+"' AND \"ID_korisnik\"='"+id+"';";
            citac = BazaPodataka.Instance.DohvatiDataReader(sql);
            if (citac.HasRows)
            {
                while (citac.Read())
                {
                    txtZakljucna.Text = citac["zakljucna_ocjena"].ToString();
                }
            }
            citac.Close();
            if (txtZakljucna.Text == "")
            {

            }
            else
            {
                txtZakljucna.Enabled = false;
                btnPotvrdiZakljucnu.Enabled = false;
            }
        }

        /// <summary>
        /// Dodaj jedan stupac ručno u datagrid
        /// </summary>
        /// <param name="ime_stupca"></param>
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

        /// <summary>
        /// unesi zaključnu ocjenu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult di = MessageBox.Show("Jeste li sigurni da želite unijeti zaključnu ocjenu?", "Zaključna ocjena",MessageBoxButtons.YesNo);
            if (di == DialogResult.Yes)
            {
                string sql = "UPDATE \"Pohada\" SET zakljucna_ocjena='" + txtZakljucna.Text + "'";
                sql += " WHERE \"ID_predmet\"='" + Predmet_id + "' AND \"ID_korisnik\"='" + id + "';";
                MessageBox.Show("Uspješno unesena zaključna ocjena!");


                BazaPodataka.Instance.IzvrsiUpit(sql);
                btnPotvrdiZakljucnu.Enabled = false;
                txtZakljucna.Enabled = false;
            }
            else
            {

            }
        }

        /// <summary>
        /// ako se klikne na neku ocjenu, prvo provjeri da li smiješ kliknuti na tu ocjenu,
        /// ako si profesor, onda smiješ kliknuti samo na one s tekućim
        /// mjesecom, a ako si razrednik
        /// onda smiješ kliknuti na sve mjesece
        /// a možeš miijenjati samo onu koja nije upisana
        /// za trenutni mjesec
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (tip == 2)
            {
            }
            else
            {
                string mjesec = DateTime.Now.Month.ToString();
                mjesec += ".";
                int odabrani_stupac = dataGridView1.CurrentCell.ColumnIndex;
                int odabrani_redak = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[odabrani_redak].Cells[odabrani_stupac].Value != null)
                {
                    MessageBox.Show("Ne mogu mijenjati već unesenu ocjenu!");
                }
                else if (dataGridView1.Columns[odabrani_stupac].HeaderText == mjesec || profesor_razrednik == true)
                {
                    Ocjena ocjena;
                    try
                    {
                        if (profesor_razrednik == false)
                        {
                            ocjena = new Ocjena(Id, predmet_id, dataGridView1.Rows[odabrani_redak].Cells[odabrani_stupac].Value.ToString(), DateTime.Now.Month.ToString(), odabrani_redak, false);
                        }
                        else
                        {

                            string poslani_mjesec = "";
                            if (odabrani_stupac >= 5) poslani_mjesec = (odabrani_stupac - 4).ToString();
                            else poslani_mjesec = (odabrani_stupac + 8).ToString();
                            ocjena = new Ocjena(Id, predmet_id, dataGridView1.Rows[odabrani_redak].Cells[odabrani_stupac].Value.ToString(), poslani_mjesec, odabrani_redak, true);
                        }
                    }

                    catch
                    {
                        if (profesor_razrednik == false)
                        {
                            ocjena = new Ocjena(Id, predmet_id, "0", DateTime.Now.Month.ToString(), odabrani_redak, false);
                        }
                        else
                        {
                            string poslani_mjesec = "";
                            if (odabrani_stupac >= 5) poslani_mjesec = (odabrani_stupac - 4).ToString();
                            else poslani_mjesec = (odabrani_stupac + 8).ToString();

                            ocjena = new Ocjena(Id, predmet_id, "0", poslani_mjesec, odabrani_redak, true);
                        }
                    }
                    this.Hide();
                    ocjena.ShowDialog();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    Pokazi_ocjene();
                    this.Show();
                }

                else
                {
                    MessageBox.Show("Ne mozete uredivati ocjene mjeseca razlicite od trenutnog!");
                }
            }
        }


        /// <summary>
        /// Ako se promijeni naziv predmeta onda ponovo selektiraj ocjene za novi selektirani predmet
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPopis_predmeta.Text == "") { }

            else
            { 
                string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE naziv_predmeta= '"+cmbPopis_predmeta.Text+"';";
                NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    Predmet_id = citac["ID_predmet"].ToString();
                }
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Pokazi_ocjene();

           
            }

        }

        /// <summary>
        /// ako se klikne na izostanke otvori formu s izostancima
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            //tectbox3
            //combobox1
            if (cmbPopis_predmeta.Text == "")
            {
                MessageBox.Show("Niste odabrali predmet!");
                
            }
            else
            {

                Izostanci izostanci = new Izostanci(txtOIB.Text, cmbPopis_predmeta.Text);
                izostanci.ShowDialog();

            }
        }

        /// <summary>
        /// selektiraj sve iz comboboxa predmete i za svaki predmet ponovo prikazi ocjene i na kraju spremi sve u word
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIzvjestaj_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Word Documents (*.doc)|*.doc";
            sfd.FileName = "Izvještaj" + id.ToString() + ".doc";
            string stOutput = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
            foreach (string predmet in cmbPopis_predmeta.Items)
            {
                string sql = "SELECT \"ID_predmet\" FROM \"Predmeti\" WHERE naziv_predmeta= '" + cmbPopis_predmeta.Text + "';";
                NpgsqlDataReader citac = BazaPodataka.Instance.DohvatiDataReader(sql);
                while (citac.Read())
                {
                    Predmet_id = citac["ID_predmet"].ToString();
                }
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                Pokazi_ocjene();

                stOutput += "\n-------------------------------\n";
                stOutput += "Predmet: " + predmet + "\n";
                stOutput += "=============================== \n\n";

 
                    // Export titles:
                    string sHeaders = "";

                    for (int j = 1; j < dataGridView1.Columns.Count; j++)
                    {
                        stOutput+= "Mjesec: "+sHeaders.ToString() + Convert.ToString(dataGridView1.Columns[j].HeaderText) + "\n";
                        try
                        {
                            stOutput += "Pismeno: " + dataGridView1.Rows[0].Cells[j].Value.ToString() + "\t";
                        }
                        catch
                        {
                            stOutput += "Pismeno: -\t";
                        }
                        try
                        {
                            stOutput += "Usmeno: " + dataGridView1.Rows[1].Cells[j].Value.ToString() + "\t";
                        }
                        catch
                        {
                            stOutput += "Usmeno: -\t";
                        }
                        try
                        {
                            stOutput += "Aktivnost: " + dataGridView1.Rows[2].Cells[j].Value.ToString() + "\t";
                        }
                        catch
                        {
                            stOutput += "Aktivnost: -\t";
                        }
                        try
                        {
                            stOutput += "Domaća zadaća: " + dataGridView1.Rows[3].Cells[j].Value.ToString() + "\t";
                        }
                        catch
                        {
                            stOutput += "Domaća zadaća: -\t";
                        }
                        stOutput += "\n\n";
                    } 
                    // Export data.

                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                UTF8Encoding utf8 = new UTF8Encoding();
                byte[] output = utf8.GetBytes(stOutput);
                FileStream fs = new FileStream(sfd.FileName, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();
                MessageBox.Show("Uspješno napravljen izvještaj");
            }
            //Izvjestaj izvjestaj = new Izvjestaj(id);
            //izvjestaj.ShowDialog();
        }
    }
}
