using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szoftech.Tarolok
{
    internal static class BicikliTarolo
    {
        private static List<Bicikli> biciklik = new List<Bicikli>();

        internal static List<Bicikli> Biciklik { get => biciklik; set => biciklik = value; }

        public static Bicikli getBicikli(string rendszam)
        {
            return Biciklik.Find(x => x.Rendszam == rendszam);
        }

        public static void addBicikli(Bicikli bicikli)
        {
            Biciklik.Add(bicikli);
        }

        public static void removeBicikli(Bicikli bicikli)
        {
            Biciklik.Remove(bicikli);
        }

        public static void beolvas()
        {
            StreamReader sr = new StreamReader("biciklitarolo.txt");
            while (!sr.EndOfStream)
            {

                string sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                string marka = adatok[0];
                string rendszam = adatok[1];
                bool hibas = Convert.ToBoolean(adatok[2]);
                bool kolcsonozve = Convert.ToBoolean(adatok[3]);
                Biciklik.Add(new Bicikli(marka, rendszam, hibas, kolcsonozve));

            }
            sr.Close();
        }

        public static void kiment()
        {
            StreamWriter sw = new StreamWriter("biciklitarolo.txt");

            foreach (var bicikli in biciklik)
            {
                sw.WriteLine(bicikli.Marka + ";" + bicikli.Rendszam + ";" + bicikli.Hibas + ";" + bicikli.Kolcsonozve);
            }
            sw.Close();
        }
    }
}
