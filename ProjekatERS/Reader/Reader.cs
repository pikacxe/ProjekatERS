using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataModel;
using System.Data;
using ConnectionUtils;

namespace Reader
{
    public class Reader : IReader
    {
        public IEnumerable<Potrosnja> ReadPotrosnjaBrojila(int idp)
        {
            if (idp <= 0)
            {
                throw new ArgumentException("ID mora biti veci od 0");
            }
            string query = "select * from Potrosnja where IDB = @id";
            List<Potrosnja> potrosnje = new List<Potrosnja>();
            using (IDbConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (IDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    ParameterUtil.AddParameter(comm,"id", DbType.Int32);
                    comm.Prepare();
                    ParameterUtil.SetParameterValue(comm, "id", idp);
                    using (IDataReader reader = comm.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            try
                            {
                                Potrosnja p = new Potrosnja();
                                p.IDB = reader.GetInt32(0);
                                p.PotrosnjaB = reader.GetDouble(1);
                                p.Mesec = reader.GetInt32(2);
                                potrosnje.Add(p);
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine("[ERROR] " + e.Message);
                            }
                        }
                        return potrosnje;
                    }
                }
            }


        }

        public int ExistsById(int id, IDbConnection conn)
        {
            if(id <= 0)
            {
                throw new ArgumentException("ID mora biti veci od 0");
            }
            if(conn == null)
            {
                throw new ArgumentNullException("Konekcija ne sme biti null!");
            }
            string query = "select count(IDB) from Potrosnja where IDB = @id";
            using (IDbCommand comm = conn.CreateCommand())
            {
                comm.CommandText = query;
                ParameterUtil.AddParameter(comm, "id", DbType.Int32);
                comm.Prepare();
                ParameterUtil.SetParameterValue(comm, "id", id);
                return (int)comm.ExecuteScalar();
            }
        }
        public int SavePotrosnja(IPotrosnja potrosnja)
        {
            if(potrosnja == null)
            {
                throw new ArgumentNullException("Potrosnja ne sme biti null!");
            }
            string inser_query = "insert into Potrosnja(Potrosnja,Mesec,IDB) values ( @potrosnja, @mesec, @id)";
            string update_query = "update Potrosnja set Potrosnja=@potrosnja, Mesec=@mesec where IDB = @id";
            using (IDbConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (IDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = ExistsById(potrosnja.IDB, conn) == 1 ? update_query : inser_query;
                    ParameterUtil.AddParameter(comm, "potrosnja", DbType.Double);
                    ParameterUtil.AddParameter(comm, "mesec", DbType.Int32);
                    ParameterUtil.AddParameter(comm, "id", DbType.Int32);
                    comm.Prepare();
                    ParameterUtil.SetParameterValue(comm,"potrosnja", potrosnja.PotrosnjaB);
                    ParameterUtil.SetParameterValue(comm,"mesec", potrosnja.Mesec);
                    ParameterUtil.SetParameterValue(comm, "id", potrosnja.IDB);
                    return comm.ExecuteNonQuery();
                }
            }
        }
    }
}
