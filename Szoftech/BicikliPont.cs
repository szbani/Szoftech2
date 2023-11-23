using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech
{
    internal class BicikliPont
    {

        private List<Bicikli> biciklik = new List<Bicikli>();
        private string nev;

        public BicikliPont(string nev)
        {
            this.nev = nev;
        }

        public void addBicikli(Bicikli bicikli)
        {
            biciklik.Add(bicikli);
        }

        public void removeBicikli(Bicikli bicikli)
        {
            biciklik.Remove(bicikli);
        }

        public Bicikli getBicikli(string rendszam)
        {
            //return biciklik[rendszam];

            return biciklik.Find(x => x.Rendszam == rendszam);

        }

        public string getNev()
        {
            return nev;
        }

        public void setNev(string nev)
        {
            this.nev = nev;
        }

    }
}
