using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataModel;
using Reader;

namespace Replicator
{

    public interface IReplicatorReceiver
    {
        List<IPotrosnja> Potrosnje { get;}
        List<IReader> Readers { get;}
        Thread Thread { get;}

        void AddPotrosnja(IPotrosnja potrosnja);
        void SavePotrosnja();
        void MeriVreme();
        void StopThread();
        int GetPerioda();
        void SetPerioda(int perioda);



    }
}
