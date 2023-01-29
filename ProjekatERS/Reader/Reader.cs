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

        public int ExistsById(int id,int mesec,IDbConnection conn)
        {
            if(id <= 0)
            {
                throw new ArgumentException("ID mora biti veci od 0");
            }
            if(mesec <= 0 || mesec > 12)
            {
                throw new ArgumentOutOfRangeException("Mesec je van opsega");
            }
            if(conn == null)
            {
                throw new ArgumentNullException("Konekcija ne sme biti null!");
            }
            string query = "select count(IDB) from Potrosnja where IDB = @id and Mesec = @mesec";
            using (IDbCommand comm = conn.CreateCommand())
            {
                comm.CommandText = query;
                ParameterUtil.AddParameter(comm, "id", DbType.Int32);
                ParameterUtil.AddParameter(comm,"mesec",DbType.Int32);
                comm.Prepare();
                ParameterUtil.SetParameterValue(comm, "id", id);
                ParameterUtil.SetParameterValue(comm, "mesec", mesec);
                return (int)comm.ExecuteScalar();
            }
        }
        public int SavePotrosnja(IPotrosnja potrosnja)
        {
            if(potrosnja == null)
            {
                throw new ArgumentNullException("Potrosnja ne sme biti null!");
            }
            string insert_query = "insert into Potrosnja(Potrosnja,Mesec,IDB) values ( @potrosnja, @mesec, @id)";
            string update_query = "update Potrosnja set Potrosnja=@potrosnja where Mesec=@mesec and IDB = @id ";
            using (IDbConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (IDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = ExistsById(potrosnja.IDB,potrosnja.Mesec,conn) == 1 ? update_query : insert_query;
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
