using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech.Tarolok
{
    internal static class BicikliPontTarolo
    {
        private static List<BicikliPont> bicikliPontok = new List<BicikliPont>();

        public static List<BicikliPont> BicikliPontok
        {
            get { return bicikliPontok; }
            set { bicikliPontok = value; }
        }

        public static void BicikliPontHozzaadasa(BicikliPont bicikliPont)
        {
            try
            {
                if (BicikliPontKeresese(bicikliPont.getNev()) != null)
                    throw new Exception("Már létezik ilyen biciklipont!");
                bicikliPontok.Add(bicikliPont);
            }
            catch (Exception e)
            {
                Console.WriteLine("Biciklipont hozzáadása sikertelen!\n" + e);
            }
        }

        public static void BicikliPontTorlese(BicikliPont bicikliPont)
        {
            try
            {
                bicikliPontok.Remove(bicikliPont);
            }
            catch (Exception e)
            {
                Console.WriteLine("Biciklipont törlése sikertelen!");
            }
        }

        public static BicikliPont BicikliPontKeresese(string nev)
        {
            return bicikliPontok.Find(x => x.getNev().ToLower() == nev.ToLower());
        }

        public static void BicikliPontokListazasa()
        {
            Console.WriteLine("\nBicikli pontok: ");

            for (int i = 0; i < BicikliPontTarolo.BicikliPontok.Count; i++)
                Console.WriteLine($"{BicikliPontTarolo.BicikliPontok[i].getNev()}");
            Console.WriteLine("\n");
        }

        public static void beolvas()
        {
            try
            {
                StreamReader sr = new StreamReader("biciklipontok.txt");
                string sor;
                while (!sr.EndOfStream)
                {
                    sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    string nev = adatok[0];
                    string[] biciklik = adatok[1].Split(',');
                    BicikliPont bicikliPont = new BicikliPont(nev);
                    foreach (var rendszam in biciklik)
                    {
                        if (!(string.IsNullOrWhiteSpace(rendszam)))
                        {
                            Bicikli bicikli = BicikliTarolo.getBicikli(rendszam);
                            if (bicikli != null)
                            {
                                bicikliPont.addBicikli(bicikli);
                            }
                        }
                    }
                    BicikliPontHozzaadasa(bicikliPont);
                }

                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Biciklipontok beolvasása sikertelen!");
            }
        }

        public static void kiment()
        {
            try
            {
                StreamWriter sw = new StreamWriter("biciklipontok.txt");

                foreach (var bicikliPont in bicikliPontok)
                {
                    string biciklik = "";
                    if (bicikliPont.getBiciklik().Count > 0)
                    {
                        foreach (var bicikli in bicikliPont.getBiciklik())
                        {
                            biciklik += bicikli.Rendszam + ",";
                        }
                    }

                    sw.WriteLine(bicikliPont.getNev() + ";" + biciklik);
                }

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Biciklipontok kimentése sikertelen!");
            }
        }
    }
}