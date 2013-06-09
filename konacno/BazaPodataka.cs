using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Forme
{
    class BazaPodataka
    {
        private static BazaPodataka instance;
        private string connectionString;
        private NpgsqlConnection konekcija;
        //singleton
        public static BazaPodataka Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BazaPodataka();

                }
                return instance;
            }
       
        }

        public string ConnectionString
        {
            get { return connectionString; }
            private set { connectionString = value; }
        }
        public NpgsqlConnection Konekcija
        {
            get { return konekcija; }
            private set { konekcija = value; }
        }
        private BazaPodataka()
        {
            ConnectionString="Server=localhost;Port=5432;Database=Eimenik;User Id=postgres;Password=postgres";
            Konekcija=new NpgsqlConnection(ConnectionString);
            Konekcija.Open();
        }

        ~BazaPodataka()
        {
            Konekcija.Close();
            konekcija = null;

        }

        public NpgsqlDataReader DohvatiDataReader(string sql)
        {
            NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
            return naredba.ExecuteReader();

        }

        public int IzvrsiUpit(string sql)
        {
            NpgsqlCommand naredba = new NpgsqlCommand(sql, Konekcija);
            return naredba.ExecuteNonQuery();
        }
    }
}
