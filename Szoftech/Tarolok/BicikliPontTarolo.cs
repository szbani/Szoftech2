using System;
using System.Collections.Generic;
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
                bicikliPontok.Add(bicikliPont);
            }
            catch (Exception e)
            {
                Console.WriteLine("Biciklipont hozzáadása sikertelen!");
            }
            
        }

        public static void BicikliPontTorlese(BicikliPont bicikliPont)
        {
            try
            {
                bicikliPontok.Remove(bicikliPont);
            } catch (Exception e)
            {
                Console.WriteLine("Biciklipont törlése sikertelen!");
            }
        }

        public static BicikliPont BicikliPontKeresese(string nev)
        {
            return bicikliPontok.Find(x => x.getNev() == nev);
        }

        public static List<BicikliPont> BicikliPontokListazasa()
        {
            return bicikliPontok;
        }

        public static void beolvasas()
        {
            StreamReader sr = new StreamReader("biciklipontok.txt");
            string sor;
            while (!sr.EndOfStream)
            {
                sor = sr.ReadLine();
                string[] adatok = sor.Split(';');
                string nev = adatok[0];
                BicikliPont bicikliPont = new BicikliPont(nev);
                BicikliPontHozzaadasa(bicikliPont);
            }
            sr.Close();
        }

        public static void kiment()
        {
            StreamWriter sw = new StreamWriter("biciklipontok.txt");
            foreach (var bicikliPont in bicikliPontok)
            {
                sw.WriteLine(bicikliPont.getNev());
            }
            sw.Close();
        }

    }
}
