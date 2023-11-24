using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Szoftech.Tarolok;

namespace Szoftech
{
    abstract class Felhasznalo
    {

        protected FelhasznaloTipus tipus;

        public abstract void menu();

        public FelhasznaloTipus Tipus
        {
            get { return tipus; }
            set { tipus = value; }
        }

        public void osszesBicikliListaz()
        {
            Console.WriteLine("\nÖsszes bicikli listázása");
            Console.WriteLine("Rendszám\tKölcsönözve\tBicikli pont");
            for (int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
            {
                if (!BicikliTarolo.Biciklik[i].Hibas)
                {
                    Console.WriteLine(BicikliTarolo.Biciklik[i].Rendszam + "\t\t" + BicikliTarolo.Biciklik[i].Kolcsonozve + "\t\t" + BicikliTarolo.Biciklik[i].getBicikliPosition());
                }
            }
        }

    }
}
