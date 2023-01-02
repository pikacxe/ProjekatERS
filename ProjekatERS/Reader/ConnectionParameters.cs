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

        private static string connectionString = "Data Source=spasic.co.rs,25565;Initial Catalog=ERS_projekat;User ID=ers_projekat;Password=radimo123.";
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
