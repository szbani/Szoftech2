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
                bool adminExists = false;
                foreach (var element in FelhasznaloTarolo.Felhasznalok)
                {
                    if (element.Tipus == FelhasznaloTipus.Admin) adminExists = true;
                }
                if (!adminExists)
                {
                    Console.WriteLine("Nincs admin felhasználó. Létrehoz egyet? (I/n)");
                    string valasz = Console.ReadLine();
                    if (valasz.ToLower() == "i" || valasz == "")
                    {
                        FelhasznaloTarolo.felhasznaloHozzaad(new KolcsonzoSzemely(felhasznaloNev, jelszo, nev,
                            FelhasznaloTipus.Admin));
                        FelhasznaloTarolo.kiment();

                        Console.WriteLine("Admin felhasználó létrehozva");
                        return;
                    }
                }
                    FelhasznaloTarolo.felhasznaloHozzaad(new KolcsonzoSzemely(felhasznaloNev, jelszo, nev,
                        FelhasznaloTipus.KolcsonzoSzemely));
                    FelhasznaloTarolo.kiment();

                    Console.WriteLine("Felhasználó létrehozva");
            } else
            {
                Console.WriteLine("Nem történt regisztrálás!");
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
                        if (tempFelhasznalo.Tipus == FelhasznaloTipus.Admin)
                        {
                            tempFelhasznalo = new Admin(tempFelhasznalo.felhasznaloNev, tempFelhasznalo.jelszo,
                                tempFelhasznalo.nev, tempFelhasznalo.Tipus,tempFelhasznalo.kkolcsonzes);
                        }
                        else if (tempFelhasznalo.Tipus == FelhasznaloTipus.Karbantarto)
                        {
                            tempFelhasznalo = new Karbantarto(tempFelhasznalo.felhasznaloNev, tempFelhasznalo.jelszo,
                                tempFelhasznalo.nev, tempFelhasznalo.Tipus,tempFelhasznalo.kkolcsonzes);
                        }

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
            Console.WriteLine("3. Biciklik listázása");
            Console.WriteLine("4. Kilépés");
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
                    osszesBicikliListaz();
                    break;
                case "4":
                    Program.kilepes = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}