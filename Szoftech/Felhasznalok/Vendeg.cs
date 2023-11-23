using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech
{
    internal class Vendeg : Felhasznalo
    {
        public Vendeg()
        {
        }

        public void regisztralas(string felhasznaloNev, string nev, string jelszo)
        {
            if (!(string.IsNullOrWhiteSpace(felhasznaloNev) && string.IsNullOrWhiteSpace(nev) &&
                  string.IsNullOrWhiteSpace(jelszo)))
            {
                FelhasznaloTarolo.felhasznaloHozzaad(new KolcsonzoSzemely(felhasznaloNev, jelszo, nev,
                                       FelhasznaloTipus.KolcsonzoSzemely));
                FelhasznaloTarolo.kiment();
            }
        }

        public void bejelentkezes(string felhasznaloNev, string jelszo)
        {
            if (!(string.IsNullOrWhiteSpace(felhasznaloNev) && string.IsNullOrWhiteSpace(jelszo)))
            {
                KolcsonzoSzemely tempFelhasznalo = FelhasznaloTarolo.getFelhasznalo(felhasznaloNev);
                if (tempFelhasznalo != null)
                {
                    if (tempFelhasznalo.jelszo == jelszo)
                    {
                        Program._felhasznalo = tempFelhasznalo;
                        Console.WriteLine("Sikeres bejelentkezés!");
                    }
                    else
                    {
                        Console.WriteLine("Hibás jelszó!");
                    }
                }
                else
                {
                    Console.WriteLine("Nincs ilyen felhasználó!");
                }
            }
        }

        public override void menu()
        {
            Console.WriteLine("1. Regisztráció");
            Console.WriteLine("2. Bejelentkezés");
            Console.WriteLine("3. Kilépés");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "1":
                    Console.Write("Felhasználónév: ");
                    string felhasznaloNev = Console.ReadLine();
                    Console.Write("Név: ");
                    string nev = Console.ReadLine();
                    Console.Write("Jelszó: ");
                    string jelszo = Console.ReadLine();
                    regisztralas(felhasznaloNev, nev, jelszo);
                    break;
                case "2":
                    Console.Write("Felhasználónév: ");
                    felhasznaloNev = Console.ReadLine();
                    Console.Write("Jelszó: ");
                    jelszo = Console.ReadLine();
                    bejelentkezes(felhasznaloNev, jelszo);
                    break;
                case "3":
                    Program.kilepes = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}