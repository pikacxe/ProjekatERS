using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;
using System.Data;
using ConnectionUtils;

namespace Reports
{
    public class Report : IReports
    {
        public IEnumerable<Potrosnja> PotrosnjaPoUlici(string ulica)
        {
            if (ulica == null)
            {
                throw new ArgumentNullException("Ulica ne sme biti null!");
            }
            ulica = ulica.Trim();
            if(ulica == "")
            {
                throw new ArgumentException("Ulica ne sme biti prazna!");
            }
            string query = "select * from Potrosnja as p join Brojilo as b on p.IDB = b.ID where Ulica = @ulica";
            List<Potrosnja> potrosnje = new List<Potrosnja>();
            using (IDbConnection conn = ConnectionParameters.GetConnection())
            {
                conn.Open();
                using (IDbCommand comm = conn.CreateCommand())
                {
                    comm.CommandText = query;
                    ParameterUtil.AddParameter(comm, "ulica", DbType.String,30);
                    comm.Prepare();
                    ParameterUtil.SetParameterValue(comm,"ulica", ulica);
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
                            catch (Exception e)
                            {
                                Console.WriteLine("[ERROR] " + e.Message);
                            }
                        }
                        return potrosnje;
                    }
                }
            }
        }

        public IEnumerable<Potrosnja> PotrosnjaPoBrojilu(int idb)
        {
            if(idb <= 0)
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
                    ParameterUtil.AddParameter(comm, "id", DbType.Int32);
                    comm.Prepare();
                    ParameterUtil.SetParameterValue(comm,"id", idb);
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
                            catch (Exception e)
                            {
                                Console.WriteLine("[ERROR] " + e.Message);
                            }
                        }
                        return potrosnje;
                    }
                }
            }
        }
    }
}
