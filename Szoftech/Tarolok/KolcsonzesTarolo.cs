﻿using System;
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
            try
            {
                Kolcsonzesek.Add(kolcsonzes);
            } catch (Exception e)
            {
                Console.WriteLine("Kölcsönzés hozzáadása sikertelen!");
            }
        }

        public static void removeKolcsonzes(Kolcsonzes kolcsonzes)
        {
            try
            {
                Kolcsonzesek.Remove(kolcsonzes);
            } catch (Exception e)
            {
                Console.WriteLine("Kölcsönzés eltávolítása sikertelen!");
            }
        }

        public static void beolvas()
        {
            try
            {
                StreamReader sr = new StreamReader("kolcsonzestarolo.txt");
                while (!sr.EndOfStream)
                {

                    string sor = sr.ReadLine();
                    string[] adatok = sor.Split(';');

                    string bicikli = adatok[0];
                    DateTime kezdet = Convert.ToDateTime(adatok[1]);
                    string felhasznalo = adatok[2];
                    Kolcsonzes kolcsonzes = new Kolcsonzes(BicikliTarolo.getBicikli(bicikli), kezdet, felhasznalo);

                    Kolcsonzesek.Add(kolcsonzes);
                    FelhasznaloTarolo.getFelhasznalo(felhasznalo).kkolcsonzes = kolcsonzes;
                    Console.WriteLine("Kölcsönzés hozzáadva!");
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Kölcsönzések beolvasása sikertelen!");
            }
        }

        public static void kiment()
        {
            try
            {
                StreamWriter sw = new StreamWriter("kolcsonzestarolo.txt");

                foreach (var kolcsonzes in kolcsonzesek)
                {
                    sw.WriteLine(kolcsonzes.getBicikli().Rendszam + ";" + kolcsonzes.getKolcsonzesIdopont() + ";" + kolcsonzes.getFelhasznalo());
                }
                sw.Close();
            } catch (Exception e)
            {
                Console.WriteLine("Kölcsönzések kimentése sikertelen!"); 
            }
        }
    }
}
