using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Writer;
using Replicator;
using DataModel;

namespace UIInterface
{
    public class Program
    {
        private static List<Writer.Writer> writers = new List<Writer.Writer>();
        private static ReplicatorReceiver receiver = new ReplicatorReceiver(10,5);
        private static ReplicatorSender sender = new ReplicatorSender(receiver);
        public static void Main(string[] args)
        {
            string unos;
            do
            {
                Console.WriteLine();
                Console.WriteLine("1 - Unos trenutne potrosnje vode korisnika");
                Console.WriteLine("2 - Izvestaj o potrosnji po mesecima za odredjenu ulicu");
                Console.WriteLine("3 - Izvestaj o potrosnji po mesecima za konkretno brojilo");
                Console.WriteLine("4 - Dodaj writer");
                Console.WriteLine("5 - Ugasi writer");
                Console.WriteLine("X - Izlazak iz programa");


                unos = Console.ReadLine();

                switch (unos)
                {
                    case "1":
                        UnosPotrosnje();
                        break;
                    case "2":
                        IzvestajUlica();
                        break;
                    case "3":
                        IzvestajBrojilo();
                        break;
                    case"4":
                        UpaliWriter();
                        break;
                    case "5":
                        UgasiWriter();
                        break;

                }
            } while (!(unos.ToUpper().Equals("X")));
            receiver.StopThread();
        }
        public static void UnosPotrosnje()
        {
            int id;
            double potrosnja;
            Console.WriteLine("Unesite id potrosnje:");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Unesite potrosnju:");
            double.TryParse(Console.ReadLine(), out potrosnja);
            int index = pronadjiUkljucenWriter();
            writers[index].AcceptPotrosnja(id, potrosnja);
            Console.WriteLine("Podaci prosledjeni slobodnom writeru");
        }
        public static void IzvestajUlica()
        {
            Console.WriteLine("Unesite ulicu za pretragu:");
            string ulica = Console.ReadLine();
            // TO-DO ispis po mesecima
        }
        public static void IzvestajBrojilo()
        {
            Console.WriteLine("Uneiste id brojila za pretragu:");
            int id;
            int.TryParse(Console.ReadLine(), out id);

            // TO-DO ispis po mesecima
        }
        public static void UpaliWriter() 
        {
            Writer.Writer writer = new Writer.Writer(sender);
            writer.Ukljuci();
            writers.Add(writer);
        
        }
        public static void UgasiWriter()
        {
            int i=0;
            foreach (var w in writers)
            {
                Console.WriteLine("Writer[{0}]:{1}",i,w.getStanje() ? "Uklucen" : "Iskljucen");
                i++;
            }
            Console.WriteLine("Unesite indeks:");
            int unos;
            int.TryParse(Console.ReadLine(),out unos); 
            if(unos>=0 && unos<writers.Count)
            {
                writers[unos].Iskljuci();
                Console.WriteLine("Writer sa indeksom {0} je uspesno ugasen!",unos);
            }
            else
            {
                Console.WriteLine("Unet je indeks van opsega!");
            }
        }
        private static int pronadjiUkljucenWriter()
        {
       
            int i=0;
            foreach(var w in writers)
            {
                if(w.getStanje())
                {
                    return i;
                }
                i++;
            }

            UpaliWriter();
            return writers.Count - 1;

        }

    }
}
