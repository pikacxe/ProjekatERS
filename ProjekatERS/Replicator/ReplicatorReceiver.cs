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
        private List<Reader.Reader> readers;
        private int period;
        private DateTime staroVreme;
        public ReplicatorReceiver()
        {
            potrosnje = new List<Potrosnja>();
            readers = new List<Reader.Reader>();
            period = 5;

            for(int i = 0; i < 10; i++)
            {
                readers.Add(new Reader.Reader());
            }
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
                if (potrosnje.Count <= 0)
                {
                    return;
                }
                if (potrosnje[0] != null)
                {
                    Random random = new Random();
                    int i = random.Next(0, 10);
                    readers[i].SavePotrosnja(potrosnje[0]);
                }

            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MeriVreme()
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
