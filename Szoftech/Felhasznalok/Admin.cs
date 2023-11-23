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
            for(int i = 0; i < FelhasznaloTarolo.Felhasznalok.Count; i++)
            {

            }
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
            Console.WriteLine("");
            Console.WriteLine("1. Kilépés");
            Console.WriteLine("2. Kijelentkezés");
            Console.WriteLine("3. Bicikli hiba jelentése");
            Console.WriteLine("4. Bicikli kölcsönzése");
            Console.WriteLine("5. Bicikli leadása");
            Console.WriteLine("6. Bicikli keresése");
            Console.WriteLine("7. Bicikli hozzáadása");
            Console.WriteLine("8. Bicikli törlése");
            Console.WriteLine("9. Bicikli pont létrehozása");
            Console.WriteLine("10. Bicikli pont törlése");
            Console.WriteLine("11. Bicikli pont keresése");
            Console.WriteLine("12. Bicikli pontok listázása");
            Console.WriteLine("13. Bicikli pont módosítása");
            Console.WriteLine("14. Felhasználó hozzáadása");
            Console.WriteLine("15. Felhasználó törlése");
            Console.WriteLine("16. Felhasználó keresése");
            Console.WriteLine("17. Felhasználók listázása");
            Console.WriteLine("18. Felhasználó módosítása");
            Console.WriteLine("19. Karbantartó jogok kezelése");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "1":
                    Program.kilepes = true;
                    break;
                case "2":
                    kijelentkezes();
                    break;
                case "3":
                    Console.Write("Hiba leírása: ");
                    string hibaLeiras = Console.ReadLine();
                    Console.Write("Rendszám: ");
                    string rendszam = Console.ReadLine();
                    bicikliHibaJelentes(hibaLeiras, rendszam);
                    break;
                case "4":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    Bicikli bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliKolcsonzes(bicikli);
                    break;
                case "5":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliLeadasa(bicikli);
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}