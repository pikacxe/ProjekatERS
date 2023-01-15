using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Replicator
{
    public class ReplicatorReceiver
    {

       private List<Potrosnja> potrosnje=new List<Potrosnja>();

        public ReplicatorReceiver()
        {

        }

        public void GetPotrosnja(Potrosnja potrosnja) 
        {
            SavePotrosnja(potrosnja);
        
        }

        public void SavePotrosnja(Potrosnja potrosnja) 
        {
            potrosnje.Add(potrosnja);    
        }
    }
}
