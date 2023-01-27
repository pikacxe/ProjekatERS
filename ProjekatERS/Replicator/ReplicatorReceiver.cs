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
    public class ReplicatorReceiver:IReplicatorReceiver
    {
        
        private List<IPotrosnja> potrosnje;
        private List<Reader.Reader> readers;
        private int period;
        private Thread thread;

        public List<IPotrosnja> Potrosnje { get;}
        public List<Reader.Reader> Readers { get;}
        public Thread Thread { get; }

        public ReplicatorReceiver(int numOfReaders, int second)
        {
            potrosnje = new List<IPotrosnja>();
            readers = new List<Reader.Reader>();
            if (second < 0)
            {
                throw new ArgumentException("Perioda ne sme biti manja od nule!");
            }
            period = second;
            if (numOfReaders <= 0)
            {
                throw new ArgumentException("Broj reader-a ne sme biti manji od jedan!");
            }
            for (int i = 0; i < numOfReaders; i++)
            {
                readers.Add(new Reader.Reader());
            }
            thread = new Thread(new ThreadStart(MeriVreme));
            thread.Start();
        }

        public ReplicatorReceiver()
        {
        }

        public void AddPotrosnja(IPotrosnja potrosnja)
        {

            if (potrosnja == null)
            {
                throw new ArgumentNullException("Potrosnja ne sme biti null");
            }
            else
            {
                potrosnje.Add(potrosnja);
            }
        }


        public void SavePotrosnja()
        {
            if (potrosnje.Count > 0)
            {
                Random random = new Random();
                int i = random.Next(0, readers.Count);
                readers[i].SavePotrosnja(potrosnje[0]);
                potrosnje.RemoveAt(0);
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

        public int ReadersCount()
        {
            return readers.Count;
        }

        public int GetPerioda() 
        {
            return period;
        }

        public void SetPerioda(int perioda)
        {
            if (perioda < 0)
            {
                throw new ArgumentException("Perioda ne sme biti manja od nule!");
            }
            period = perioda;
        }

        public int ReaderCount()
        {
            throw new NotImplementedException();
        }
    }
}
