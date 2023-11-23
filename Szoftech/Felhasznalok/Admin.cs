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
        }

        public void felhasznaloTorlese(KolcsonzoSzemely felhasznalo)
        {
            FelhasznaloTarolo.felhasznaloTorol(felhasznalo);
        }

        public void felhasznaloModositasa(Felhasznalo felhasznalo,Felhasznalo ujFelhasznalo)
        {
            felhasznalo = ujFelhasznalo;
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
                Console.WriteLine($"{FelhasznaloTarolo.Felhasznalok[i].felhasznaloNev} {FelhasznaloTarolo.Felhasznalok[i].jelszo} {FelhasznaloTarolo.Felhasznalok[i].nev}");
        }

        public void karbantartoJogokKezelese(KolcsonzoSzemely karbantarto,bool tipus)
        {
            if (tipus)
                karbantarto.Tipus = FelhasznaloTipus.Karbantarto;
            else
                karbantarto.Tipus = FelhasznaloTipus.KolcsonzoSzemely;
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

        public void bicikliPontModositasa(BicikliPont bicikliPont,string nev)
        {
            bicikliPont.setNev(nev);
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
            for (int i = 0; i < BicikliPontTarolo.BicikliPontok.Count; i++)
                Console.WriteLine($"{BicikliPontTarolo.BicikliPontok[i].getNev()}");
        }

        public override void menu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Bicikli akciok");
            Console.WriteLine("2. Felhasznalo akciok");
            Console.WriteLine("3. Bicikli pont akciok");
            Console.WriteLine("4. Kijelentkezés");
            Console.WriteLine("5. Kilépés");

            Console.Write("Választás: ");
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "1":
                    bicikliAkciok();
                    break;
                case "2":
                    felhasznaloAkciok();
                    break;
                case "3":
                    bicikliPontAkciok();
                    break;
                case "4":
                    kijelentkezes();
                    break;
                case "5":
                    Program.kilepes = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }

        public void bicikliAkciok()
        {
            Console.WriteLine();
            Console.WriteLine("1. Bicikli hiba jelentése");
            Console.WriteLine("2. Bicikli kölcsönzése");
            Console.WriteLine("3. Bicikli leadása");
            Console.WriteLine("4. Bicikli keresése");
            Console.WriteLine("5. Bicikli hozzáadása");
            Console.WriteLine("6. Bicikli törlése");
            Console.WriteLine("7. Biciklik listázása");
            Console.WriteLine("Visszához hagyd üresen.");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Console.WriteLine();
            switch (valasz)
            {
                case "1":
                    Console.Write("Hiba leírása: ");
                    string hibaLeiras = Console.ReadLine();
                    Console.Write("Rendszám: ");
                    string rendszam = Console.ReadLine();
                    bicikliHibaJelentes(hibaLeiras, rendszam);
                    break;
                case "2":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    Bicikli bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliKolcsonzes(bicikli);
                    break;
                case "3":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliLeadasa(bicikli);
                    break;
                case "4":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliKereses(bicikli.Rendszam);
                    break;
                case "5":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(rendszam))
                    {
                        Console.WriteLine("Rendszám nem lehet üres!");
                        break;
                    }

                    Console.Write("Bicikli típusa: ");
                    string tipus = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(tipus))
                    {
                        Console.WriteLine("Bicikli típusa nem lehet üres!");
                        break;
                    }
                    Console.Write("Bicikli pont: ");
                    string biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont nem lehet üres!");
                        break;
                    }
                    BicikliPont bicikliPont = BicikliPontTarolo.BicikliPontKeresese(biciklipontneve);
                    bicikli = new Bicikli(rendszam, tipus, false, false);
                    bicikliHozaadasa(bicikli, bicikliPont);
                    break;
                case "6":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(rendszam))
                    {
                        Console.WriteLine("Rendszám nem lehet üres!");
                        break;
                    }
                    bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliTorlese(bicikli);
                    break;
                case "7":
                    osszesBicikliListaz();
                    break;
            }
        }

        public void bicikliPontAkciok()
        {
            Console.WriteLine();
            Console.WriteLine("1. Bicikli pont létrehozása");
            Console.WriteLine("2. Bicikli pont törlése");
            Console.WriteLine("3. Bicikli pont keresése");
            Console.WriteLine("4. Bicikli pontok listázása");
            Console.WriteLine("5. Bicikli pont módosítása");
            Console.WriteLine("Visszához hagyd üresen.");
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
                    bicikliPontModositasa(bicikliPont,ujbiciklipontneve);
                    break;
            }
        }

        public void felhasznaloAkciok()
        {
            KolcsonzoSzemely felhasznalo;
            Console.WriteLine();
            Console.WriteLine("1. Felhasználó hozzáadása");
            Console.WriteLine("2. Felhasználó törlése");
            Console.WriteLine("3. Felhasználó keresése");
            Console.WriteLine("4. Felhasználók listázása");
            Console.WriteLine("5. Felhasználó módosítása");
            Console.WriteLine("6. Karbantartó jogok kezelése");
            Console.WriteLine("Visszához hagyd üresen.");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Console.WriteLine();
            switch(valasz)
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
                    felhasznalo = new KolcsonzoSzemely(felhasznalonev, jelszo, nev, (FelhasznaloTipus)Enum.Parse(typeof(FelhasznaloTipus), tipus));
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
                    Felhasznalo ujfelhasznalo = new KolcsonzoSzemely(ujfelhasznalonev, ujjelszo, ujnev, (FelhasznaloTipus)Enum.Parse(typeof(FelhasznaloTipus), ujtipus));
                    felhasznaloModositasa(felhasznalo,ujfelhasznalo);
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
                    Console.Write("Karbantartó jogok: ");
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
                    karbantartoJogokKezelese(felhasznalo,karbantarto);
                    Console.WriteLine("Sikeres módosítás!");
                    break;
            }
        }
    }
}