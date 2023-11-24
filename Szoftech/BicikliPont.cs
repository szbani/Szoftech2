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
            try
            {
                biciklik.Add(bicikli);
            } catch (Exception e) {
                Console.WriteLine("Bicikli hozzáadása bicikliponthoz sikertelen!");
            }
        }

        public void removeBicikli(Bicikli bicikli)
        {
            try
            {
                biciklik.Remove(bicikli);
            } catch (Exception e)
            {
                Console.WriteLine("Bicikli eltávolítása biciklipontból sikertelen!");
            }
        }

        public List<Bicikli> getBiciklik()
        {
            return biciklik;
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
