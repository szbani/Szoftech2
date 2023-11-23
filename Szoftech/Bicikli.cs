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
        private KolcsonzoSzemely kolcsonozte;
        private string hibaLeiras;
        private BicikliPont bicikliPont;


        public Bicikli(string marka, string rendszam, bool hibas, KolcsonzoSzemely kolcsonozte,BicikliPont bicikliPont)
        {
            this.marka = marka;
            this.rendszam = rendszam;
            this.hibas = hibas;
            this.kolcsonozte = kolcsonozte;
            this.hibaLeiras = "";
            this.bicikliPont = bicikliPont;
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
        public KolcsonzoSzemely Kolcsonozte { get => kolcsonozte; set => kolcsonozte = value; }
        public string HibaLeiras { get => hibaLeiras; set => hibaLeiras = value; }
        public BicikliPont BicikliPont { get => bicikliPont; set => bicikliPont = value; }
    }
}
