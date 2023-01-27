using Replicator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Writer
{
    public interface IWriter
    {
        IReplicatorSender Sender { get; }
        bool Stanje { get; }
        void Ukljuci();
        void Iskljuci();
        void AcceptPotrosnja(int id, double potrosnja);
    }
}
