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
            for(int i = 0; i < BicikliTarolo.Biciklik.Count; i++)
            {
                Console.WriteLine($"{BicikliTarolo.Biciklik[i].Marka} {BicikliTarolo.Biciklik[i].Rendszam} {BicikliTarolo.Biciklik[i].Hibas} {BicikliTarolo.Biciklik[i].Kolcsonozve}");
            }
        }



    }
}
