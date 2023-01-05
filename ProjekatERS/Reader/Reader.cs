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
        public Potrosnja ReadPotrosnja(int idp)
        {
            // TO-DO read potrosnja from DB
            string query = "select * from Potrosnja where IDB = @id";
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("id", idp);
                    using (SqlDataReader reader = comm.ExecuteReader())
                    {
                        Potrosnja p = new Potrosnja();
                        while (reader.Read())
                        {
                            p.IDB = reader.GetInt32(0);
                            p.PotrosnjaB = reader.GetDouble(1);
                            p.Mesec = reader.GetInt32(2);
                        }
                        return p;
                    }
                }
            }


        }
        public void SavePotrosnja(Potrosnja potrosnja)
        {
            // TO-DO save potrosnja to DB
            string query = "insert into Potrosnja(IDB,Potrosnja,Mesec) values (@id, @potrosnja, @mesec)";
            using (SqlConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (SqlCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    comm.Parameters.AddWithValue("id", potrosnja.IDB);
                    comm.Parameters.AddWithValue("potrosnja", potrosnja.PotrosnjaB);
                    comm.Parameters.AddWithValue("mesec", potrosnja.Mesec);
                    comm.ExecuteNonQuery();
                }
            }
        }
    }
}
