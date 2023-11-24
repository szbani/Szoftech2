using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szoftech.Tarolok;

namespace Szoftech
{
    internal class KolcsonzoSzemely : Felhasznalo
    {
        protected string FelhasznaloNev;
        protected string Jelszo;
        protected string Nev;
        protected Kolcsonzes kolcsonzes;


        public KolcsonzoSzemely(string felhasznaloNev, string jelszo, string nev, FelhasznaloTipus tipus,
            Kolcsonzes kolcsonzes = null)
        {
            this.FelhasznaloNev = felhasznaloNev;
            this.jelszo = jelszo;
            this.nev = nev;
            this.kolcsonzes = kolcsonzes;
            this.Tipus = tipus;
        }

        public string felhasznaloNev
        {
            get { return FelhasznaloNev; }
            set { FelhasznaloNev = value; }
        }

        public string jelszo
        {
            get { return Jelszo; }
            set { Jelszo = value; }
        }

        public string nev
        {
            get { return Nev; }
            set { Nev = value; }
        }

        public Kolcsonzes kkolcsonzes
        {
            get { return kolcsonzes; }
            set { kolcsonzes = value; }
        }

        public void kijelentkezes()
        {
            Program._felhasznalo = new Vendeg();
        }

        public void szabadBicikliListaz()
        {
            Console.WriteLine("\nSzabad biciklik");
            Console.WriteLine("Rendszám\tBicikli pont");
            for (int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
            {
                if (!BicikliTarolo.Biciklik[i].Kolcsonozve)
                {
                    Console.WriteLine(BicikliTarolo.Biciklik[i].Rendszam + "\t\t" +
                                      BicikliTarolo.Biciklik[i].getBicikliPosition());
                }
            }
        }

        public void bicikliHibaJelentes(string hibaLeiras, string rendszam)
        {
            for (int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
            {
                if (BicikliTarolo.Biciklik[i].Rendszam == rendszam)
                {
                    BicikliTarolo.Biciklik[i].Hibas = true;
                    BicikliTarolo.Biciklik[i].HibaLeiras = hibaLeiras;
                }
            }
        }

        public void bicikliKolcsonzes(Bicikli bicikli)
        {
            if (bicikli.Kolcsonozve == false)
            {
                BicikliPont bicikliPont = BicikliPontTarolo.BicikliPontKeresese(bicikli.getBicikliPosition());
                if (bicikliPont != null)
                {
                    kolcsonzes = new Kolcsonzes(bicikli, DateTime.Now, FelhasznaloNev);
                    KolcsonzesTarolo.addKolcsonzes(kolcsonzes);
                    bicikli.Kolcsonozve = true;
                    bicikliPont.removeBicikli(bicikli);
                    KolcsonzesTarolo.kiment();
                    BicikliPontTarolo.kiment();
                    BicikliTarolo.kiment();
                }
            }
            else
            {
                //TODO: hiba
            }
        }

        public void bicikliLeadasa(Bicikli bicikli, BicikliPont bp)
        {
            if (bicikli.Kolcsonozve)
            {
                bool fizetve = false;
                while (!fizetve)
                {
                    int osszeg = 0;
                    DateTime kezd = kolcsonzes.getKolcsonzesIdopont();
                    DateTime veg = DateTime.Now;
                    TimeSpan ts = veg - kezd;
                    int orak = ts.Hours;
                    osszeg = orak * 5000;

                    Console.WriteLine("Kölcsönzés összege:"+ osszeg.ToString());
                    Console.WriteLine("\nFizetés\n1. Készpénz\n2. Kártya");
                    string valasz = Console.ReadLine();
                    switch (valasz)
                    {
                        case "1":
                            fizetve = true;
                            break;
                        case "2":
                            fizetve = true;
                            break;
                        default:
                            Console.WriteLine("Nincs ilyen menüpont!");
                            break;
                    }
                }
                KolcsonzesTarolo.removeKolcsonzes(kolcsonzes);
                kolcsonzes = null;
                bicikli.Kolcsonozve = false;
                bp.addBicikli(bicikli);
                BicikliPontTarolo.kiment();
                BicikliTarolo.kiment();
                KolcsonzesTarolo.kiment();
                Console.WriteLine("Sikeres leadás!");
                Console.WriteLine("Köszönjük, hogy minket választott!");
            }
        }

        public override void menu()
        {
            kolcsonzoMenu();
        }

        public void kolcsonzoMenu()
        {
            Console.WriteLine("\nKölcsönző menü");
            Console.WriteLine("1. Bicikli hiba jelentése");
            Console.WriteLine("2. Bicikli kölcsönzése");
            Console.WriteLine("3. Bicikli leadása");
            Console.WriteLine("4. Biciklik listázása");
            Console.WriteLine("5. Kijelentkezés");
            Console.WriteLine("6. Kilépés");
            if (Program._felhasznalo.Tipus != FelhasznaloTipus.KolcsonzoSzemely)
            {
                Console.WriteLine("7. Vissza");
            }

            Console.Write("Választás: ");

            string valasz = Console.ReadLine();

            switch (valasz)
            {
                case "1":
                    szabadBicikliListaz();
                    Console.Write("Hiba leírása: ");
                    string hibaLeiras = Console.ReadLine();
                    Console.Write("Rendszám: ");
                    string rendszam = Console.ReadLine();
                    bicikliHibaJelentes(hibaLeiras, rendszam);
                    break;
                case "2":
                    if (kolcsonzes!= null)
                    {
                        Console.WriteLine("Már van kölcsönzött biciklid!");
                        break;
                    }
                    szabadBicikliListaz();
                    Console.Write("Rendszám: ");
                    rendszam = Console.ReadLine();
                    Bicikli bicikli = BicikliTarolo.getBicikli(rendszam);
                    bicikliKolcsonzes(bicikli);
                    break;
                case "3":
                    if (kolcsonzes == null)
                    {
                        Console.WriteLine("Nincs kölcsönzött biciklid!");
                        break;
                    }

                    Console.WriteLine("Leadod a biciklid?\n1. Igen\n2. Nem");
                    string lead = Console.ReadLine();
                    if (lead == "1")
                    {
                        BicikliPontTarolo.BicikliPontokListazasa();
                        Console.WriteLine("BicikliPont neve: ");
                        string bicikliPont = Console.ReadLine();
                        BicikliPont bp = BicikliPontTarolo.BicikliPontKeresese(bicikliPont);
                        if (bp == null)
                        {
                            Console.WriteLine("Nincs ilyen biciklipont!");
                            break;
                        }

                        bicikliLeadasa(kolcsonzes.getBicikli(), bp);
                    }

                    break;
                case "4":
                    osszesBicikliListaz();
                    break;
                case "5":
                    Program.menuVissza = true;
                    kijelentkezes();
                    break;
                case "6":
                    Program.menuVissza = true;
                    Program.kilepes = true;
                    break;
                case "7":
                    if (Program._felhasznalo.Tipus != FelhasznaloTipus.KolcsonzoSzemely)
                    {
                        Program.menuVissza = true;
                    }

                    break;
                default:
                    Console.WriteLine("Nincs ilyen menüpont!");
                    break;
            }
        }
    }
}