using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel;

namespace Replicator
{
    public class ReplicatorSender
    {
        private ReplicatorReceiver recv;

        public ReplicatorSender(ReplicatorReceiver receiver)
        {
            recv =receiver;
        }

        public void GetData(int id, double potrosnja)
        {
            Potrosnja potr = new Potrosnja(id, potrosnja, DateTime.Now.Month);

            recv.GetPotrosnja(potr);
        }

    }
}



/*Replicator Sender:
        -   Komunikacija sa Writer-om
        -   prima podatke od writer-a
        -   prosledjuje podatke Replikator reciever   
        -   Testiranje*/