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
        private ReplicatorSender sender;

        public Writer()
        {
            sender = new ReplicatorSender();
        }

        public void AcceptPotrosnja(int id, double potrosnja)
        {
            sender.GetData(id, potrosnja);
        }
    }
}
