using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Szoftech
{
    internal static class FelhasznaloTarolo
    {
        private static List<KolcsonzoSzemely> felhasznalok = new List<KolcsonzoSzemely>();

        public static List<KolcsonzoSzemely> Felhasznalok
        {
            get { return felhasznalok; }
            set { felhasznalok = value; }
        }
        public static void felhasznaloHozzaad(KolcsonzoSzemely felhasznalo)
        {
            try
            {
                felhasznalok.Add(felhasznalo);
            } catch (Exception e) {
                Console.WriteLine("Felhasználó hozzáadása sikertelen!");
            }
        }

        public static void felhasznaloTorol(KolcsonzoSzemely felhasznalo)
        {
            try
            {
                felhasznalok.Remove(felhasznalo);
            } catch (Exception e)
            {
                Console.WriteLine("Felhasználó törlése sikertelen!");
            }
        }

        public static KolcsonzoSzemely getFelhasznalo(string felhasznaloNev)
        {
            return felhasznalok.Find(x => x.felhasznaloNev == felhasznaloNev);
        }

        public static void kiment()
        {
            try
            {
                StreamWriter sw = new StreamWriter("felhasznalok.txt");
                foreach (var felhasznalo in felhasznalok)
                {
                    sw.WriteLine(felhasznalo.felhasznaloNev + ";" + felhasznalo.jelszo + ";" + felhasznalo.nev + ";" + felhasznalo.Tipus);
                }
                sw.Close();
            } catch (Exception e)
            {
                Console.WriteLine("Felhasználók beolvasása sikertelen!");
            }
        }

        public static void beolvas()
        {
            try
            {
                StreamReader sr = new StreamReader("felhasznalok.txt");
                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');
                    string felhasznaloNev = adatok[0];
                    string jelszo = adatok[1];
                    string nev = adatok[2];
                    FelhasznaloTipus tipus = (FelhasznaloTipus)Enum.Parse(typeof(FelhasznaloTipus), adatok[3]);
                    KolcsonzoSzemely felhasznalo;
                    if (tipus == FelhasznaloTipus.KolcsonzoSzemely)
                    {
                        felhasznalo = new KolcsonzoSzemely(felhasznaloNev, jelszo, nev, tipus);
                    }
                    else if (tipus == FelhasznaloTipus.Karbantarto)
                    {
                        felhasznalo = new Karbantarto(felhasznaloNev, jelszo, nev, tipus);
                    }
                    else
                    {
                        felhasznalo = new Admin(felhasznaloNev, jelszo, nev, tipus);
                    }

                    felhasznaloHozzaad(felhasznalo);
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Felhasználók beolvasása sikertelen!");
            }
            
        }
    }
}
