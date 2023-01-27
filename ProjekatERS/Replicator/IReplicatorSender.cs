using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replicator
{
    public interface IReplicatorSender
    {
        IReplicatorReceiver Recv { get; }
        void GetData(int id, double potrosnja);
    }
}
