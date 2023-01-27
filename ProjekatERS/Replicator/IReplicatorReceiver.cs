using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataModel;


namespace Replicator
{

    public interface IReplicatorReceiver
    {
        List<IPotrosnja> Potrosnje { get;}
        List<Reader.Reader> Readers { get;}
        Thread Thread { get;}

        void AddPotrosnja(IPotrosnja potrosnja);
        void SavePotrosnja();
        void MeriVreme();
        void StopThread();
        int ReaderCount();
        int GetPerioda();
        void SetPerioda(int perioda);



    }
}
