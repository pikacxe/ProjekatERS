using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data.SqlClient;


namespace Reader
{
    public class Reader
    {
        public Reader()
        {

        }
        public IEnumerable<Potrosnja> ReadPotrosnjaBrojila(int idp)
        {
            
            string query = "select * from Potrosnja where IDB = @id";
            List<Potrosnja> potrosnje = new List<Potrosnja>();
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("id", idp);
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

        private int ExistsById(int id, SqlConnection conn)
        {
            string query = "select count(IDB) from Potrosnja where IDB = @id";
            using (SqlCommand comm = conn.CreateCommand())
            {
                comm.CommandText = query;
                comm.Parameters.AddWithValue("id", id);
                return (int)comm.ExecuteScalar();
            }
        }
        public void SavePotrosnja(Potrosnja potrosnja)
        {
            // TO-DO save potrosnja to DB
            string inser_query = "insert into Potrosnja(Potrosnja,Mesec,IDB) values ( @potrosnja, @mesec, @id)";
            string update_query = "update Potrosnja set Potrosnja=@potrosnja, Mesec=@mesec where IDB = @id";
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = ExistsById(potrosnja.IDB, conn) == 1 ? update_query : inser_query;
                    comm.Parameters.AddWithValue("potrosnja", potrosnja.PotrosnjaB);
                    comm.Parameters.AddWithValue("mesec", potrosnja.Mesec);
                    comm.Parameters.AddWithValue("id", potrosnja.IDB);
                    comm.ExecuteNonQuery();
                }
            }
        }

        // TO-DO Reports


        public IEnumerable<Potrosnja> potrosnjaPoUlici(string ulica)
        {
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
    }
}
