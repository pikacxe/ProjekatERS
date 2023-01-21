using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replicator;



namespace Writer
{
    public class Writer
    {
        private bool stanje;
        private ReplicatorSender sender;

        public void Ukljuci()
        {
            stanje = true;
        }

        public void Iskljuci()
        {
            stanje = false;
        }
        public bool getStanje()
        {
            return stanje;
        }

        public Writer()
        {
            stanje = false;
            sender = new ReplicatorSender();
        }

        public void AcceptPotrosnja(int id, double potrosnja)
        {
            try
            {
                if (!stanje)
                {
                    throw new Exception("Writer trenutno nije ukljucen. Ukljucite pre koriscenja.");
                }
                if (id < 0)
                {
                    throw new ArgumentException("Id nije validan.");
                }
                if (potrosnja < 0)
                {
                    throw new ArgumentException("Potrosnja nije validna.");
                }
                sender.GetData(id, potrosnja);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
