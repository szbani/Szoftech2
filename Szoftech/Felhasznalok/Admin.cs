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

        public void felhasznaloModositasa(Felhasznalo felhasznalo)
        {
        }

        public void felhasznaloKereses(string nev)
        {
            for (int i = 0; i < FelhasznaloTarolo.Felhasznalok.Count; i++)
            {
                if (FelhasznaloTarolo.Felhasznalok[i].nev.Contains(nev))
                    Console.WriteLine(FelhasznaloTarolo.Felhasznalok[i].nev);
            }
        }

        public void felhasznaloListazas()
        {
            for (int i = 0; i < FelhasznaloTarolo.Felhasznalok.Count; i++)
                Console.WriteLine(
                    $"{FelhasznaloTarolo.Felhasznalok[i].felhasznaloNev} {FelhasznaloTarolo.Felhasznalok[i].jelszo} {FelhasznaloTarolo.Felhasznalok[i].nev}");
        }

        public void karbantartoJogokKezelese(Karbantarto karbantarto)
        {
        }

        public void bicikliPontLetrehozas(BicikliPont bicikliPont)
        {
            BicikliPontTarolo.BicikliPontHozzaadasa(bicikliPont);
        }

        public void bicikliPontTorlese(BicikliPont bicikliPont)
        {
            BicikliPontTarolo.BicikliPontTorlese(bicikliPont);
        }

        public void bicikliPontModositasa(BicikliPont bicikliPont)
        {
        }

        public void bicikliPontKereses(string cim)
        {
            for (int i = 0; i < BicikliPontTarolo.BicikliPontok.Count; i++)
            {
                if (BicikliPontTarolo.BicikliPontok[i].getNev().Contains(cim))
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
                    bicikliPontAkciok();
                    break;
                case "3":
                    felhasznaloAkciok();
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
            Console.WriteLine("1. Bicikli hiba jelentése");
            Console.WriteLine("2. Bicikli kölcsönzése");
            Console.WriteLine("3. Bicikli leadása");
            Console.WriteLine("4. Bicikli keresése");
            Console.WriteLine("5. Bicikli hozzáadása");
            Console.WriteLine("6. Bicikli törlése");
            Console.WriteLine("Visszához hagyd üresen.");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
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
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }

        public void bicikliPontAkciok()
        {
            Console.WriteLine("1. Bicikli pont létrehozása");
            Console.WriteLine("2. Bicikli pont törlése");
            Console.WriteLine("3. Bicikli pont keresése");
            Console.WriteLine("4. Bicikli pontok listázása");
            Console.WriteLine("5. Bicikli pont módosítása");
            Console.WriteLine("Visszához hagyd üresen.");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            switch (valasz)
            {
                
            }
        }

        public void felhasznaloAkciok()
        {
            Console.WriteLine("1. Felhasználó hozzáadása");
            Console.WriteLine("2. Felhasználó törlése");
            Console.WriteLine("3. Felhasználó keresése");
            Console.WriteLine("4. Felhasználók listázása");
            Console.WriteLine("5. Felhasználó módosítása");
            Console.WriteLine("6. Karbantartó jogok kezelése");
            Console.WriteLine("Visszához hagyd üresen.");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
        }
    }
}