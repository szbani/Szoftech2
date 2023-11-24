using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
            Console.Write("\nTalálatok:\n");
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

            Console.Write("\nTalálatok vége\n");
        }

        public void bicikliHozaadasa(Bicikli bicikli, BicikliPont bicikliPont)
        {
            try
            {
                BicikliTarolo.Biciklik.Add(bicikli);
                bicikliPont.addBicikli(bicikli);
                BicikliTarolo.kiment();
                BicikliPontTarolo.kiment();

                Console.WriteLine("\nSikeres hozzáadás\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nSikertelen hozzáadás\n");
            }
        }

        public void bicikliTorlese(Bicikli bicikli)
        {
            if (!(bicikli.getBicikliPosition() == ""))
            {
                BicikliTarolo.Biciklik.Remove(bicikli);
                Console.WriteLine("\nSikeres törlés\n");
            }
            else
            {
                Console.WriteLine("\nKölcsönzött biciklit nem lehet törölni!\n");
            }

            BicikliTarolo.kiment();
            BicikliPontTarolo.kiment();
        }

        public void hibasBicikliListazas()
        {
            Console.WriteLine("\nHibás biciklik:");
            Console.WriteLine("Rendszám\tKölcsönözve\tHibás\tHiba leírása\tBicikli pont");
            for (int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
            {
                if (BicikliTarolo.Biciklik[i].Hibas)
                {
                    Console.WriteLine(BicikliTarolo.Biciklik[i].Rendszam + "\t" +
                                      BicikliTarolo.Biciklik[i].Kolcsonozve + "\t" + BicikliTarolo.Biciklik[i].Hibas +
                                      "\t" + BicikliTarolo.Biciklik[i].HibaLeiras + "\t" +
                                      BicikliTarolo.Biciklik[i].getBicikliPosition());
                }
            }
        }

        public void hibasBicikliJavitas(Bicikli bicikli)
        {
            bicikli.Hibas = false;
            bicikli.HibaLeiras = "";
            BicikliTarolo.kiment();
        }

        public override void menu()
        {
            Console.WriteLine("1. Kölcsönző menü");
            Console.WriteLine("2. Karbantartó menü");
            Console.WriteLine("3. Kijelentkezés");
            Console.WriteLine("4. Kilépés");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();
            Program.menuVissza = false;

            switch (valasz)
            {
                case "1":
                    while (!Program.menuVissza)
                        kolcsonzoMenu();
                    break;
                case "2":
                    while (!Program.menuVissza)
                        karbantartoMenu();
                    break;
                case "3":
                    kijelentkezes();
                    break;
                case "4":
                    Program.kilepes = true;
                    break;
            }
        }

        public void karbantartoMenu()
        {
            Console.WriteLine("\nKarbantartó menü");
            Console.WriteLine("1. Bicikli keresése");
            Console.WriteLine("2. Bicikli hozzáadása");
            Console.WriteLine("3. Bicikli törlése");
            Console.WriteLine("4. Hibás biciklik listázása");
            Console.WriteLine("5. Hibás bicikli javítása");
            Console.WriteLine("6. Kijelentkezés");
            Console.WriteLine("7. Kilépés");
            Console.WriteLine("8. Vissza");
            Console.Write("Választás: ");
            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "1":
                    Console.Write("Rendszám: ");
                    string rendszam = Console.ReadLine();
                    Bicikli bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliKereses(bicikli.Rendszam);
                    break;
                case "2":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(rendszam))
                    {
                        Console.WriteLine("Rendszám nem lehet üres!");
                        break;
                    }
                    for (int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
                    {
                        if (BicikliTarolo.Biciklik[i].Rendszam == rendszam)
                        {
                            Console.WriteLine("\nSikertelen hozzáadás\nMár létezik ezzel a rendszámmal bicikli");
                            break;
                        }
                    }

                    Console.Write("Bicikli típusa: ");
                    string tipus = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(tipus))
                    {
                        Console.WriteLine("Bicikli típusa nem lehet üres!");
                        break;
                    }

                    BicikliPontTarolo.BicikliPontokListazasa();

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

                    bicikli = new Bicikli(tipus, rendszam, false, false);
                    bicikliHozaadasa(bicikli, bicikliPont);
                    break;
                case "3":
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
                case "4":
                    hibasBicikliListazas();
                    break;
                case "5":
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(rendszam))
                    {
                        Console.WriteLine("Rendszám nem lehet üres!");
                        break;
                    }

                    bicikli = BicikliTarolo.getBicikli(rendszam);
                    hibasBicikliJavitas(bicikli);
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
    }
}