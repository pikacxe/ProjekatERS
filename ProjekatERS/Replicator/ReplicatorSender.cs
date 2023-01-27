using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Replicator
{
    public class ReplicatorSender : IReplicatorSender
    {
        private IReplicatorReceiver recv;
        public IReplicatorReceiver Recv { get => recv; }
        public ReplicatorSender(IReplicatorReceiver receiver)
        {
            recv =receiver;
        }

        public void GetData(int id, double potrosnja)
        {
            try
            {
                IPotrosnja potr = new Potrosnja(id, potrosnja, DateTime.Now.Month);
                recv.AddPotrosnja(potr);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine("[ERROR] " + ae.Message);
            }
        }

    }
}



/*Replicator Sender:
        -   Komunikacija sa Writer-om
        -   prima podatke od writer-a
        -   prosledjuje podatke Replikator reciever   
        -   Testiranje*/