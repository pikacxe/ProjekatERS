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
            if (receiver == null)
            {
                throw new ArgumentNullException("Reciver ne sme biti null!");
            }
            else
            {
                recv =receiver;
            }
        }

        public void GetData(int id, double potrosnja)
        {
            if (id <=0)
            {
                throw new ArgumentException("ID brojila ne sme biti manji od nule!");
            }
            if (potrosnja < 0)
            {
                throw new ArgumentException("Potrosnja ne sme biti manja od nule!");
            }
            else
            {
                IPotrosnja potr = new Potrosnja(id, potrosnja, DateTime.Now.Month);
                recv.AddPotrosnja(potr);
            }
           
        }

    }
}



/*Replicator Sender:
        -   Komunikacija sa Writer-om
        -   prima podatke od writer-a
        -   prosledjuje podatke Replikator reciever   
        -   Testiranje*/