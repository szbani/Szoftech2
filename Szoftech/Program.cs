using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech
{
    internal class Program
    {
        public static Felhasznalo _felhasznalo = new Vendeg();
        public static bool kilepes = false;

        static void Main(string[] args)
        {
            FelhasznaloTarolo.beolvas();
            // _felhasznalo = new Admin("admin", "admin", "admin", FelhasznaloTipus.Admin);
            while (kilepes == false)
            {
                switch (_felhasznalo.Tipus)
                {
                    case FelhasznaloTipus.Vendeg:
                        Console.WriteLine("Vendég");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.KolcsonzoSzemely:
                        Console.WriteLine("Kölcsönző személy");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.Karbantarto:
                        Console.WriteLine("Karbantartó");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.Admin:
                        Console.WriteLine("Admin");
                        _felhasznalo.menu();
                        // FelhasznaloTarolo.felhasznaloHozzaad(felhasznalo);
                        // FelhasznaloTarolo.kiment();
                        // List<Felhasznalo> felhasznalok = FelhasznaloTarolo.getFelhasznalok();
                        //
                        // if (_felhasznalo is Admin admin)
                        // {
                        //     admin.felhasznaloListazas();
                        // }
                        //
                        // Console.WriteLine(_felhasznalo.GetType());
                        // foreach (var item in felhasznalok)
                        // {
                        //     Console.WriteLine(item.felhasznaloNev + " " + item.jelszo + " " + item.Tipus);
                        // }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}