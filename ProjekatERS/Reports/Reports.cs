using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data.SqlClient;

namespace Reports
{
    public class Reports
    {
        public IEnumerable<Potrosnja> potrosnjaPoUlici(string ulica)
        {
            if(ulica == "")
            {
                throw new ArgumentException("Ulica ne sme biti prazna!");
            }
            if(ulica == null)
            {
                throw new ArgumentNullException("Ulica ne sme biti null!");
            }
            string query = "select * from Potrosnja where Ulica = @ulica";
            List<Potrosnja> potrosnje = new List<Potrosnja>();
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("ulica", ulica);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Potrosnja p = new Potrosnja();
                            p.IDB = reader.GetInt32(0);
                            p.PotrosnjaB = reader.GetDouble(1);
                            p.Mesec = reader.GetInt32(2);
                            potrosnje.Add(p);
                        }
                        return potrosnje;
                    }
                }
            }
        }

        public IEnumerable<Potrosnja> potrosnjaPoBrojilu(int idb)
        {
            if(idb <= 0)
            {
                throw new ArgumentNullException("ID mora biti veci od 0");
            }
            string query = "select * from Potrosnja where IDB = @id";
            List<Potrosnja> potrosnje = new List<Potrosnja>();
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("id", idb);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Potrosnja p = new Potrosnja();
                            p.IDB = reader.GetInt32(0);
                            p.PotrosnjaB = reader.GetDouble(1);
                            p.Mesec = reader.GetInt32(2);
                            potrosnje.Add(p);
                        }
                        return potrosnje;
                    }
                }
            }
        }
    }
}
