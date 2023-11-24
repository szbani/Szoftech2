using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szoftech.Tarolok;

namespace Szoftech
{
    internal class Program
    {
        public static Felhasznalo _felhasznalo = new Vendeg();
        public static bool kilepes = false;
        public static bool menuVissza = false;


        static void Main(string[] args)
        {
            FelhasznaloTarolo.beolvas();
            BicikliTarolo.beolvas();
            BicikliPontTarolo.beolvas();
            KolcsonzesTarolo.beolvas();
            while (kilepes == false)
            {
                switch (_felhasznalo.Tipus)
                {
                    case FelhasznaloTipus.Vendeg:
                        Console.WriteLine("\n\n\nVendég");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.KolcsonzoSzemely:
                        Console.WriteLine("\n\n\nKölcsönző személy");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.Karbantarto:
                        Console.WriteLine("\n\n\nKarbantartó");
                        _felhasznalo.menu();
                        break;
                    case FelhasznaloTipus.Admin:
                        Console.WriteLine("\n\n\nAdmin");
                        _felhasznalo.menu();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}