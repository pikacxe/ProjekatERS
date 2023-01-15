using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replicator
{
    public class ReplicatorSender
    {
        private ReplicatorReceiver recv;

        public ReplicatorSender()
        {
            recv = new ReplicatorReceiver();
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