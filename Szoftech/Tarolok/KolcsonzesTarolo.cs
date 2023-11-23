using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech.Tarolok
{
    internal static class KolcsonzesTarolo
    {
        private static List<Kolcsonzes> kolcsonzesek = new List<Kolcsonzes>();

        internal static List<Kolcsonzes> Kolcsonzesek { get => kolcsonzesek; set => kolcsonzesek = value; }

        public static Kolcsonzes getKolcsonzes(string felhasznaloNev)
        {
            return Kolcsonzesek.Find(x => x.getFelhasznalo() == felhasznaloNev);
        }

        public static void addKolcsonzes(Kolcsonzes kolcsonzes)
        {
            Kolcsonzesek.Add(kolcsonzes);
        }

        public static void removeKolcsonzes(Kolcsonzes kolcsonzes)
        {
            Kolcsonzesek.Remove(kolcsonzes);
        }

        public static void beolvas()
        {
            StreamReader sr = new StreamReader("kolcsonzestarolo.txt");
            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');

                string bicikli = adatok[0];
                DateTime kezdet = Convert.ToDateTime(adatok[1]);
                string felhasznalo = adatok[2];
                
                Kolcsonzesek.Add(new Kolcsonzes(BicikliTarolo.getBicikli(bicikli), kezdet, felhasznalo));

            }
            sr.Close();
        }

        public static void kiment()
        {
            StreamWriter sw = new StreamWriter("kolcsonzestarolo.txt");

            foreach (var kolcsonzes in kolcsonzesek)
            {
                sw.WriteLine(kolcsonzes.getBicikli() + ";" + kolcsonzes.getKolcsonzesIdopont() + ";" + kolcsonzes.getFelhasznalo());
            }
            sw.Close();
        }
    }
}
