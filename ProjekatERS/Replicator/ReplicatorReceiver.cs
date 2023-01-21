using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Reader;
using System.Threading;

namespace Replicator
{
    public class ReplicatorReceiver
    {

        private List<Potrosnja> potrosnje;
        private List<Reader.Reader> readers;
        private int period;
        private Thread thread;
        public ReplicatorReceiver(int numOfReaders,int second)
        {
            potrosnje = new List<Potrosnja>();
            readers = new List<Reader.Reader>();
            period = second;
            for(int i = 0; i < numOfReaders; i++)
            {
                readers.Add(new Reader.Reader());
            }
            thread = new Thread(new ThreadStart(MeriVreme));
            thread.Start();
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
                if (potrosnje.Count > 0)
                {
                    Random random = new Random();
                    int i = random.Next(0, readers.Count);
                    readers[i].SavePotrosnja(potrosnje[0]);
                    potrosnje.RemoveAt(0);
                }
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void MeriVreme()
        {
            while (true)
            {
                SavePotrosnja();
                Thread.Sleep(1000 * period);
                // Console.WriteLine("Radim!"); // For debugging purposes
            }
        }

        public void StopThread()
        {
            thread.Abort();
        }
    }
}
