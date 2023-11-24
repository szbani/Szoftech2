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
                    bicikli.Kolcsonozve = true;
                    bicikliPont.removeBicikli(bicikli);
                    KolcsonzesTarolo.kiment();
                }
            }
        }

        public void bicikliLeadasa(Bicikli bicikli)
        {
            if (bicikli.Kolcsonozve == true)
            {
                BicikliPont bicikliPont = BicikliPontTarolo.BicikliPontKeresese(bicikli.getBicikliPosition());
                if (bicikliPont == null)
                {
                    bicikli.Kolcsonozve = false;
                    bicikliPont.addBicikli(bicikli);
                    //KolcsonzesTarolo.kiment();
                }
            }
        }

        public override void menu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Bicikli hiba jelentése");
            Console.WriteLine("2. Bicikli kölcsönzése");
            Console.WriteLine("3. Bicikli leadása");
            Console.WriteLine("4. Biciklik listázása");
            Console.WriteLine("5. Kijelentkezés");
            Console.WriteLine("6. Kilépés");

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
                    osszesBicikliListaz();
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
    }
}