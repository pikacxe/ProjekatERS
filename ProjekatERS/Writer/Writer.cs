using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Replicator;



namespace Writer
{
    public class Writer : IWriter
    {
        private bool stanje;
        private IReplicatorSender sender;

        public IReplicatorSender Sender { get => sender; }
        public bool Stanje { get => stanje; }

        public void Ukljuci()
        {
            stanje = true;
        }

        public void Iskljuci()
        {
            stanje = false;
        }

        public Writer(IReplicatorSender sender)
        {
            if (sender == null)
            {
                throw new ArgumentNullException("Sender ne sme biti null.");
            }
            else
            {
                stanje = false;
                this.sender = sender;
            }
        }

        public void AcceptPotrosnja(int id, double potrosnja)
        {
            if (!stanje)
            {
                throw new InvalidOperationException("Writer trenutno nije ukljucen. Ukljucite pre koriscenja.");
            }
            if (id <= 0)
            {
                throw new ArgumentException("Id nije validan.");
            }
            if (potrosnja < 0)
            {
                throw new ArgumentException("Potrosnja nije validna.");
            }
            sender.GetData(id, potrosnja);

        }
    }
}
