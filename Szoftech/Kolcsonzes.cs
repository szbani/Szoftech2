using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szoftech
{
    internal class Kolcsonzes
    {
        private Bicikli bicikli;
        private DateTime kolcsonzesIdopont;
        private string felhasznalo;

        public Kolcsonzes(Bicikli bicikli, DateTime kolcsonzesIdopont, string felhasznalo)
        {
            this.bicikli = bicikli;
            this.kolcsonzesIdopont = kolcsonzesIdopont;
            this.felhasznalo = felhasznalo;
        }

        public Bicikli getBicikli()
        {
            return bicikli;
        }

        public DateTime getKolcsonzesIdopont()
        {
            return kolcsonzesIdopont;
        }

        public string getFelhasznalo()
        {
            return felhasznalo;
        }

        public void setBicikli(Bicikli b)
        {
            this.bicikli = b;
        }

        public void setKolcsonzesIdopont(DateTime date)
        {
            this.kolcsonzesIdopont = date;
        }

        public void setFelhasznalo(string fnev)
        {
            this.felhasznalo = fnev;
        }
    }
}
