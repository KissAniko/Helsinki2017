using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    internal class Korcsolya
    {
        string nev;
        string orszagKodja;
        double technikaiPontszam;
        double komponensPontszam;
        int hibapont;
        

        
        public Korcsolya(string nev, string orszagKodja, double technikaiPontszam, double komponensPontszam, int hibapont)
        {
            this.Nev = nev;
            this.OrszagKodja = orszagKodja;
            this.TechnikaiPontszam = technikaiPontszam;
            this.KomponensPontszam = komponensPontszam;
            this.Hibapont = hibapont;

        }

        public string Nev { get => nev; set => nev = value; }
        public string OrszagKodja { get => orszagKodja; set => orszagKodja = value; }
        public double TechnikaiPontszam { get => technikaiPontszam; set => technikaiPontszam = value; }
        public double KomponensPontszam { get => komponensPontszam; set => komponensPontszam = value; }
        public int Hibapont { get => hibapont; set => hibapont = value; }
       
     //   public double Eredmeny { get => this.technikaiPontszam + this.komponensPontszam - this.hibapont; }
    }
}
