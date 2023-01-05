using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Reader
{
    public class ConnectionParameters : IDisposable
    {

        private static string connectionString = "Data Source=spasic.co.rs,25565;Initial Catalog=ERS_projekat;User ID=ers_projekat;Password=radimo123.";
        private static SqlConnection instance;

        public void Dispose()
        {
            if(instance != null)
            {
                instance.Close();
                instance.Dispose();
            }
        }

        public static SqlConnection GetConnection()
        {
            try
            {
                instance = new SqlConnection(connectionString);
                return instance;
            }
            catch(Exception e)
            {
                Console.WriteLine("Greska prilikom povezivanja sa bazom!\nError stack:" + e.Message);
            }
            return instance;
        }
    }
}
