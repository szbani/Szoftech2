using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szoftech.Tarolok;

namespace Szoftech
{
    internal class Admin : Karbantarto
    {
        public Admin(string felhasznaloNev, string jelszo, string nev, FelhasznaloTipus tipus,
            Kolcsonzes kolcsonzes = null) : base(felhasznaloNev, jelszo, nev, tipus, kolcsonzes)
        {
            Tipus = tipus;
        }

        public void felhasznaloHozzaadasa(KolcsonzoSzemely felhasznalo)
        {
            FelhasznaloTarolo.felhasznaloHozzaad(felhasznalo);
            FelhasznaloTarolo.kiment();
        }

        public void felhasznaloTorlese(KolcsonzoSzemely felhasznalo)
        {
            FelhasznaloTarolo.felhasznaloTorol(felhasznalo);
            FelhasznaloTarolo.kiment();
        }

        public void felhasznaloModositasa(Felhasznalo felhasznalo, Felhasznalo ujFelhasznalo)
        {
            felhasznalo = ujFelhasznalo;
            FelhasznaloTarolo.kiment();
        }

        public void felhasznaloKereses(string nev)
        {
            for (int i = 0; i < FelhasznaloTarolo.Felhasznalok.Count; i++)
            {
                if (FelhasznaloTarolo.Felhasznalok[i].nev.ToLower().Contains(nev.ToLower()))
                    Console.WriteLine(FelhasznaloTarolo.Felhasznalok[i].nev);
            }
        }

        public void felhasznaloListazas()
        {
            for (int i = 0; i < FelhasznaloTarolo.Felhasznalok.Count; i++)
                Console.WriteLine(
                    $"{FelhasznaloTarolo.Felhasznalok[i].felhasznaloNev} {FelhasznaloTarolo.Felhasznalok[i].jelszo} {FelhasznaloTarolo.Felhasznalok[i].nev}");
        }

        public void karbantartoJogokKezelese(KolcsonzoSzemely karbantarto, bool tipus)
        {
            if (tipus)
                karbantarto.Tipus = FelhasznaloTipus.Karbantarto;
            else
                karbantarto.Tipus = FelhasznaloTipus.KolcsonzoSzemely;
            FelhasznaloTarolo.kiment();
        }

        public void bicikliPontLetrehozas(BicikliPont bicikliPont)
        {
            BicikliPontTarolo.BicikliPontHozzaadasa(bicikliPont);
            BicikliPontTarolo.kiment();
        }

        public void bicikliPontTorlese(BicikliPont bicikliPont)
        {
            BicikliPontTarolo.BicikliPontTorlese(bicikliPont);
            BicikliPontTarolo.kiment();
        }

        public void bicikliPontModositasa(BicikliPont bicikliPont, string nev)
        {
            bicikliPont.setNev(nev);
            BicikliPontTarolo.kiment();
        }

        public void bicikliPontKereses(string cim)
        {
            for (int i = 0; i < BicikliPontTarolo.BicikliPontok.Count; i++)
            {
                if (BicikliPontTarolo.BicikliPontok[i].getNev().ToLower().Contains(cim.ToLower()))
                    Console.WriteLine($"{BicikliPontTarolo.BicikliPontok[i].getNev()}");
            }
        }

        public void bicikliPontListazas()
        {
            BicikliPontTarolo.BicikliPontokListazasa();
        }

        public override void menu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Kölcsönző menü");
            Console.WriteLine("2. Karbantartó menü");
            Console.WriteLine("3. Bicikli pont akciok");
            Console.WriteLine("4. Felhasználó akciók");
            Console.WriteLine("5. Kijelentkezés");
            Console.WriteLine("6. Kilépés");

            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Program.menuVissza = false;

            switch (valasz)
            {
                case "1":
                    while (!(Program.menuVissza))
                        kolcsonzoMenu();
                    break;
                case "2":
                    while (!(Program.menuVissza))
                        karbantartoMenu();
                    break;
                case "3":
                    while (!(Program.menuVissza))
                        bicikliPontAkciok();
                    break;
                case "4":
                    while (!(Program.menuVissza))
                        felhasznaloAkciok();
                    break;
                case "5":
                    kijelentkezes();
                    break;
                case "6":
                    Program.kilepes = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }

        public void bicikliPontAkciok()
        {
            Console.WriteLine("\nBicikli pont akciók");
            Console.WriteLine("1. Bicikli pont létrehozása");
            Console.WriteLine("2. Bicikli pont törlése");
            Console.WriteLine("3. Bicikli pont keresése");
            Console.WriteLine("4. Bicikli pontok listázása");
            Console.WriteLine("5. Bicikli pont módosítása");
            Console.WriteLine("6. Kijelentkezés");
            Console.WriteLine("7. Kilépés");
            Console.WriteLine("8. Vissza");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Console.WriteLine();
            switch (valasz)
            {
                case "1":
                    Console.Write("Bicikli pont neve: ");
                    string biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont neve nem lehet üres!");
                        break;
                    }

                    BicikliPont bicikliPont = new BicikliPont(biciklipontneve);
                    bicikliPontLetrehozas(bicikliPont);
                    break;
                case "2":
                    Console.Write("Bicikli pont neve: ");
                    biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont neve nem lehet üres!");
                        break;
                    }

                    bicikliPont = BicikliPontTarolo.BicikliPontKeresese(biciklipontneve);
                    bicikliPontTorlese(bicikliPont);
                    break;
                case "3":
                    Console.Write("Bicikli pont neve: ");
                    biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont neve nem lehet üres!");
                        break;
                    }

                    bicikliPontKereses(biciklipontneve);
                    break;
                case "4":
                    bicikliPontListazas();
                    break;
                case "5":
                    bicikliPontListazas();
                    Console.Write("Bicikli pont neve: ");
                    biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont neve nem lehet üres!");
                        break;
                    }

                    bicikliPont = BicikliPontTarolo.BicikliPontKeresese(biciklipontneve);
                    Console.Write("Új bicikli pont neve: ");
                    string ujbiciklipontneve = Console.ReadLine();
                    bicikliPontModositasa(bicikliPont, ujbiciklipontneve);
                    break;
                case "6":
                    Program.menuVissza = true;
                    kijelentkezes();
                    break;
                case "7":
                    Program.menuVissza = true;
                    Program.kilepes = true;
                    break;
                case "8":
                    Program.menuVissza = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }

        public void felhasznaloAkciok()
        {
            KolcsonzoSzemely felhasznalo;
            Console.WriteLine("\nFelhasználó akciók");
            Console.WriteLine("1. Felhasználó hozzáadása");
            Console.WriteLine("2. Felhasználó törlése");
            Console.WriteLine("3. Felhasználó keresése");
            Console.WriteLine("4. Felhasználók listázása");
            Console.WriteLine("5. Felhasználó módosítása");
            Console.WriteLine("6. Karbantartó jogok kezelése");
            Console.WriteLine("7. Kijelentkezés");
            Console.WriteLine("8. Kilépés");
            Console.WriteLine("9. Vissza");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Console.WriteLine();
            switch (valasz)
            {
                case "1":
                    Console.Write("Felhasználó neve: ");
                    string nev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    Console.Write("Felhasználó jelszava: ");
                    string jelszo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(jelszo))
                    {
                        Console.WriteLine("Felhasználó jelszava nem lehet üres!");
                        break;
                    }

                    Console.Write("Felhasználó felhasználóneve: ");
                    string felhasznalonev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(felhasznalonev))
                    {
                        Console.WriteLine("Felhasználó felhasználóneve nem lehet üres!");
                        break;
                    }

                    Console.Write("Felhasználó típusa: ");
                    string tipus = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(tipus))
                    {
                        Console.WriteLine("Felhasználó típusa nem lehet üres!");
                        break;
                    }

                    felhasznalo = new KolcsonzoSzemely(felhasznalonev, jelszo, nev,
                        (FelhasznaloTipus)Enum.Parse(typeof(FelhasznaloTipus), tipus));
                    felhasznaloHozzaadasa(felhasznalo);
                    break;
                case "2":
                    Console.Write("Felhasználó neve: ");
                    nev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    felhasznalo = FelhasznaloTarolo.getFelhasznalo(nev);
                    felhasznaloTorlese(felhasznalo);
                    break;
                case "3":
                    Console.Write("Felhasználó neve: ");
                    nev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    felhasznaloKereses(nev);
                    break;
                case "4":
                    felhasznaloListazas();
                    break;
                case "5":
                    Console.Write("Felhasználó neve: ");
                    nev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    felhasznalo = FelhasznaloTarolo.getFelhasznalo(nev);
                    Console.Write("Új felhasználó neve: ");
                    string ujnev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ujnev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    Console.Write("Új felhasználó jelszava: ");
                    string ujjelszo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ujjelszo))
                    {
                        Console.WriteLine("Felhasználó jelszava nem lehet üres!");
                        break;
                    }

                    Console.Write("Új felhasználó felhasználóneve: ");
                    string ujfelhasznalonev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ujfelhasznalonev))
                    {
                        Console.WriteLine("Felhasználó felhasználóneve nem lehet üres!");
                        break;
                    }

                    Console.Write("Új felhasználó típusa: ");
                    string ujtipus = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(ujtipus))
                    {
                        Console.WriteLine("Felhasználó típusa nem lehet üres!");
                        break;
                    }

                    Felhasznalo ujfelhasznalo = new KolcsonzoSzemely(ujfelhasznalonev, ujjelszo, ujnev,
                        (FelhasznaloTipus)Enum.Parse(typeof(FelhasznaloTipus), ujtipus));
                    felhasznaloModositasa(felhasznalo, ujfelhasznalo);
                    Console.WriteLine("Sikeres módosítás!");
                    break;
                case "6":
                    Console.Write("Felhasználó neve: ");
                    nev = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nev))
                    {
                        Console.WriteLine("Felhasználó neve nem lehet üres!");
                        break;
                    }

                    felhasznalo = FelhasznaloTarolo.getFelhasznalo(nev);
                    Console.Write("Karbantartó jogosultságok: ");
                    Console.WriteLine("1. Igen");
                    Console.WriteLine("2. Nem");
                    Console.Write("Választás: ");
                    string valasz2 = Console.ReadLine();
                    bool karbantarto = false;
                    switch (valasz2)
                    {
                        case "1":
                            karbantarto = true;
                            break;
                        case "2":
                            karbantarto = false;
                            break;
                        default:
                            Console.WriteLine("Nincs ilyen menüpont!");
                            break;
                    }

                    karbantartoJogokKezelese(felhasznalo, karbantarto);
                    Console.WriteLine("Sikeres módosítás!");
                    break;
                case "7":
                    Program.menuVissza = true;
                    kijelentkezes();
                    break;
                case "8":
                    Program.menuVissza = true;
                    Program.kilepes = true;
                    break;
                case "9":
                    Program.menuVissza = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}