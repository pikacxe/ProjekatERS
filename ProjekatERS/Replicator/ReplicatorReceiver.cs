using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Reader;

namespace Replicator
{
    public class ReplicatorReceiver
    {

        private List<Potrosnja> potrosnje;
        private Reader.Reader[] readers;
        private int period;
        private DateTime staroVreme;
        public ReplicatorReceiver()
        {
            potrosnje = new List<Potrosnja>();
            readers = new Reader.Reader[10];
        }

        public void GetPotrosnja(Potrosnja potrosnja)
        {
            try
            {
                if (potrosnja == null)
                {
                    throw new ArgumentNullException("Potrosnja ne sme biti null");
                }
                potrosnje.Add(potrosnja);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SavePotrosnja()
        {
            try
            {
                if (potrosnje[1] == null)
                {
                    throw new ArgumentNullException("Potrosnja ne sme biti null");
                }
                Random random = new Random();
                int i = random.Next(0, 10);
                readers[i].SavePotrosnja(potrosnje[1]); //TODO srediti data setove 


            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void MeriVreme()
        {
            if (DateTime.Now.Second >= staroVreme.Second)
            {
                SavePotrosnja();
                staroVreme = DateTime.Now;
                staroVreme.AddSeconds(period);
            }
        }

    }
}
