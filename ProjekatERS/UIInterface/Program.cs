using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Writer;
using Replicator;
using DataModel;
using Reports;

namespace UIInterface
{
    public class Program
    {
        private static List<IWriter> writers = new List<IWriter>();
        private static IReplicatorReceiver receiver = new ReplicatorReceiver(10,5);
        private static IReplicatorSender sender = new ReplicatorSender(receiver);
        private static IReports reports = new Report();
        private static string[] meseci = new string[] { "Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul", "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar" };

        public static void Main(string[] args)
        {
            string unos;
            do
            {
                Console.WriteLine();
                Console.WriteLine("============= Opcije =============");
                Console.WriteLine("1 - Unos trenutne potrosnje vode korisnika");
                Console.WriteLine("2 - Izvestaj o potrosnji po mesecima za odredjenu ulicu");
                Console.WriteLine("3 - Izvestaj o potrosnji po mesecima za konkretno brojilo");
                Console.WriteLine("4 - Dodaj writer");
                Console.WriteLine("5 - Ugasi writer");
                Console.WriteLine("6 - Upali writer");
                Console.WriteLine("7 - Promeni periodu upisivanja u bazu");
                Console.WriteLine("X - Izlazak iz programa");

                Console.WriteLine();
                Console.Write("Odaberite opciju: ");
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
                        DodajWriter();
                        break;
                    case "5":
                        UgasiWriter();
                        break;
                    case "6":
                        UpaliWriter();
                        break;
                    case "7":
                        PromeniPeriodu();
                        break;

                }
            } while (!(unos.ToUpper().Equals("X")));
            receiver.StopThread();
        }

        private static void PromeniPeriodu()
        {
            Console.Write("Unesite novu periodu (sekunde):");
            int perioda;
            int.TryParse(Console.ReadLine(), out perioda);
            try
            {
                receiver.SetPerioda(perioda);
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine("[ERROR] " + ae.Message);
            }
            
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
            try
            {
                writers[index].AcceptPotrosnja(id, potrosnja);
                Console.WriteLine("Podaci prosledjeni slobodnom writeru");
            }
            catch(Exception e)
            {
                Console.WriteLine("[ERROR] " + e.Message);
            }
        }
        public static void IzvestajUlica()
        {
            Console.WriteLine("Unesite ulicu za pretragu:");
            string ulica = Console.ReadLine();
            try
            {

                List<Potrosnja> potrosnja = reports.PotrosnjaPoUlici(ulica).ToList();
                if (potrosnja.Count == 0)
                {
                    Console.WriteLine("Nema podataka za datu ulicu!");
                }
                for (int x = 0; x < meseci.Length; x++)
                {
                    Console.WriteLine("\n=========== " + meseci[x] + " ===========\n");
                    Console.WriteLine(Potrosnja.GetFormattedHeader());
                    foreach (var p in potrosnja)
                    {
                        if (p.Mesec - 1 == x)
                            Console.WriteLine(p.ToString());
                    }
                    Console.WriteLine("==============================\n");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("[ERROR] " + e.Message);
            }
        }
        public static void IzvestajBrojilo()
        {
            Console.WriteLine("Uneiste id brojila za pretragu:");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            try
            {
                List<Potrosnja> potrosnja = reports.PotrosnjaPoBrojilu(id).ToList();
                if (potrosnja.Count == 0)
                {
                    Console.WriteLine("Nema podataka za dato brolijo!");
                }
                for (int x = 0; x < meseci.Length; x++)
                {
                    Console.WriteLine("\n=========== " + meseci[x] + " ===========\n");
                    Console.WriteLine(Potrosnja.GetFormattedHeader());
                    foreach (var p in potrosnja)
                    {
                        if (p.Mesec - 1 == x)
                            Console.WriteLine(p.ToString());
                    }
                    Console.WriteLine("==============================\n");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] " + e.Message);
            }
        }
        public static void DodajWriter() 
        {
            try
            {
                Writer.Writer writer = new Writer.Writer(sender);
                writer.Ukljuci();
                writers.Add(writer);
                Console.WriteLine("Writer uspesno dodat!");
            }
            catch (Exception e)
            {
                Console.WriteLine("[ERROR] " + e.Message);
            }
        }

        public static void UpaliWriter()
        {
            int i = 0;
            if(writers.Count==0)
            {
                Console.WriteLine("Ne postoji ni jedan writer. Dodajte novi.");
                return;
            }
            foreach (var w in writers)
            {
                Console.WriteLine("Writer[{0}]:{1}", i, w.Stanje ? "Ukljucen" : "Iskljucen");
                i++;
            }
            Console.Write("Unesite indeks:");
            int unos;
            int.TryParse(Console.ReadLine(), out unos);
            if (unos >= 0 && unos < writers.Count)
            {
                writers[unos].Ukljuci();
                Console.WriteLine("Writer sa indeksom {0} je uspesno ugasen!", unos);
            }
            else
            {
                Console.WriteLine("Unet je indeks van opsega!");
            }
        }
        public static void UgasiWriter()
        {
            int i=0;
            if (writers.Count == 0)
            {
                Console.WriteLine("Ne postoji ni jedan writer. Dodajte novi.");
                return;
            }
            foreach (var w in writers)
            {
                Console.WriteLine("Writer[{0}]:{1}",i,w.Stanje ? "Ukljucen" : "Iskljucen");
                i++;
            }
            Console.Write("Unesite indeks:");
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
                if(w.Stanje)
                {
                    return i;
                }
                i++;
            }

            DodajWriter();
            return writers.Count - 1;

        }

    }
}
