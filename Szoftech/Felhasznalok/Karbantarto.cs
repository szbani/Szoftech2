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
        public Karbantarto(string felhasznaloNev, string jelszo, string nev, FelhasznaloTipus tipus,
            Kolcsonzes kolcsonzes = null) : base(felhasznaloNev, jelszo, nev, tipus, kolcsonzes)
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
            }
        }

        public void bicikliHozaadasa(Bicikli bicikli, BicikliPont bicikliPont)
        {
            try
            {
                BicikliTarolo.Biciklik.Add(bicikli);
                bicikliPont.addBicikli(bicikli);
                BicikliTarolo.kiment();
                BicikliPontTarolo.kiment();

                Console.WriteLine("Sikeres hozzáadás");
            } catch (Exception e)
            {
                Console.WriteLine("Sikertelen hozzáadás");
            }
        }

        public void bicikliTorlese(Bicikli bicikli)
        {
            if (!(bicikli.getBicikliPosition() == ""))
            {
                BicikliTarolo.Biciklik.Remove(bicikli);
                Console.WriteLine("Sikeres törlés");
            }
            else
            {
                Console.WriteLine("Kölcsönzött biciklit nem lehet törölni!");
            }
            BicikliTarolo.kiment();
            BicikliPontTarolo.kiment();
        }

        public override void menu()
        {
            Console.WriteLine("1. Bicikli hiba jelentése");
            Console.WriteLine("2. Bicikli kölcsönzése");
            Console.WriteLine("3. Bicikli leadása");
            Console.WriteLine("4. Bicikli keresése");
            Console.WriteLine("5. Bicikli hozzáadása");
            Console.WriteLine("6. Bicikli törlése");
            Console.WriteLine("7. Biciklik listázása");
            Console.WriteLine("8. Kijelentkezés");
            Console.WriteLine("9. Kilépés");
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
                    Console.WriteLine("\nBicikli pontok: ");

                    for (int i = 0; i < BicikliPontTarolo.BicikliPontok.Count; i++)
                        Console.WriteLine($"{BicikliPontTarolo.BicikliPontok[i].getNev()}");
                    Console.WriteLine("\n");

                    Console.Write("Bicikli pont: ");
                    string biciklipontneve = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(biciklipontneve))
                    {
                        Console.WriteLine("Bicikli pont nem lehet üres!");
                        break;
                    }

                    BicikliPont bicikliPont = BicikliPontTarolo.BicikliPontKeresese(biciklipontneve);
                    if (bicikliPont == null)
                    {
                        Console.WriteLine("Nincs ilyen bicikli pont");
                        break;
                    }
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
                case "8":
                    kijelentkezes();
                    break;
                case "9":
                    Program.kilepes = true;
                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}