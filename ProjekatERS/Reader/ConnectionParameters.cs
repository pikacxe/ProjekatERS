using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Reader
{
    public class ConnectionParameters
    {

        private static string connectionString = "";
        private SqlConnection instance;

        public SqlConnection GetConnection()
        {
            try
            {
                instance = new SqlConnection(connectionString);
                return instance;
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom povezivanja sa bazom!\n" + e.Message);
            }
            return instance;
        }
    }
}
