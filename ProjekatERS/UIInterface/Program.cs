using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Writer;

namespace UIInterface
{
    public class Program
    {
        private Writer.Writer[] writers=new Writer.Writer[10];
        public static void Main(string[] args)
        {
            string unos;
            do
            {
                Console.WriteLine("1 - Unos trenutne potrosnje vode korisnika");
                Console.WriteLine("2 - Izvestaj o potrosnji po mesecima za odredjenu ulicu");
                Console.WriteLine("3 - Izvestaj o potrosnji po mesecima za konkretno brojilo");
                Console.WriteLine("4 - Upali writer");
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
        }
        public static void UnosPotrosnje()
        { 
        
        }
        public static void IzvestajUlica()
        { }
        public static void IzvestajBrojilo()
        { }
        public static void UpaliWriter() 
        { }
        public static void UgasiWriter()
        { }

    }
}
