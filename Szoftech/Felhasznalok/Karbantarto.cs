using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szoftech.Tarolok;

namespace Szoftech
{
    internal class Karbantarto : KolcsonzoSzemely
    {
        public Karbantarto(string felhasznaloNev, string jelszo, string nev,FelhasznaloTipus tipus, Kolcsonzes kolcsonzes = null) : base(felhasznaloNev, jelszo, nev, tipus, kolcsonzes)
        {
            Tipus = tipus;
        }

        public void bicikliKereses(string rendszam)
        {
            foreach (Bicikli element in BicikliTarolo.Biciklik)
            {

                if (element.Rendszam.Contains(rendszam))
                {
                    Console.Write(element.Rendszam);

                    if (element.getBicikliPosition() == "")
                        Console.Write("Nem elérhető");
                    else
                        //Console.Write("Kölcsönözhető");
                        Console.Write("Kölcsönözhető, hely: " + element.getBicikliPosition() + "\n");
                }

                
                //if (element.Rendszam == rendszam)
                //{
                //    Console.WriteLine(rendszam);  
                //}
            }
            
        }

        public void bicikliHozaadasa(Bicikli bicikli,BicikliPont bicikliPont)
        {
            BicikliTarolo.Biciklik.Add(bicikli);
            bicikliPont.addBicikli(bicikli);
            Console.WriteLine("Sikeres hozzáadás");
        }

        public void bicikliTorlese(Bicikli bicikli)
        {
            if ( !(bicikli.getBicikliPosition() == "") ) {
                BicikliTarolo.Biciklik.Remove(bicikli);
                Console.WriteLine("Sikeres törlés");
            } else
            {
                Console.WriteLine("Kölcsönzött biciklit nem lehet törölni!");
            }
        }

        public override void menu()
        {
            Console.WriteLine("1. Kilépés");
            Console.WriteLine("2. Kijelentkezés");
            Console.WriteLine("3. Bicikli hiba jelentése");
            Console.WriteLine("4. Bicikli kölcsönzése");
            Console.WriteLine("5. Bicikli leadása");
            Console.WriteLine("6. Bicikli keresése");
            Console.WriteLine("7. Bicikli hozzáadása");
            Console.WriteLine("8. Bicikli törlése");
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
