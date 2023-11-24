using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Szoftech.Tarolok;

namespace Szoftech
{
    class Bicikli
    {
        private string marka;
        private string rendszam;
        private bool hibas;
        private bool kolcsonozve;
        private string hibaLeiras;


        public Bicikli(string marka, string rendszam, bool hibas, bool kolcsonozve)
        {
            this.marka = marka;
            this.rendszam = rendszam;
            this.hibas = hibas;
            this.kolcsonozve = kolcsonozve;
        }

        public string getBicikliPosition()
        {
            foreach (BicikliPont element in BicikliPontTarolo.BicikliPontok)
            {
                if (element.getBicikli(rendszam) != null) return element.getNev();
            }

            return "";
        }

        public string Marka { get => marka; set => marka = value; }
        public string Rendszam { get => rendszam; set => rendszam = value; }
        public bool Hibas { get => hibas; set => hibas = value; }
        public bool Kolcsonozve { get => kolcsonozve; set => kolcsonozve = value; }
        public string HibaLeiras { get => hibaLeiras; set => hibaLeiras = value; }
    }
}
