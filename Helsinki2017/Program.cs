using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helsinki2017
{
    internal class Program
    {

       // static List<Korcsolya> rovidprogramok;
       // static List<Korcsolya> dontok;
         static double OsszPontszam;
        static void Main(string[] args)
        {

            // Ellenőrzés:

            /*    var sorok = File.ReadAllLines("rovidprogram.csv");

                  foreach (var sor in sorok)
                  {
                      Console.WriteLine(sor);

                  }
             */

            /*     // Ellenőrzés:

                    var sorok = File.ReadAllLines("donto.csv");

                       foreach (var sor in sorok)
                       {
                           Console.WriteLine(sor);

                       }  */


            List<Korcsolya> rovidprogramok = new List<Korcsolya>();

            string[] sorok = File.ReadAllLines("rovidprogram.csv", Encoding.UTF8);
            for (int i = 1; i < sorok.Length; i++)
            {
                string[] adat = sorok[i].Split(';');


                string nev = adat[0];
                string orszagKodja = adat[1];
                double technikaiPontszam = Convert.ToDouble(adat[2].Replace('.', ','));
                double komponensPontszam = Convert.ToDouble(adat[3].Replace('.', ','));
                int hibapont = int.Parse(adat[4]);

                Korcsolya rovidprogram = new Korcsolya(nev, orszagKodja, technikaiPontszam, komponensPontszam, hibapont);
                rovidprogramok.Add(rovidprogram);

            }

            List<Korcsolya> dontok = new List<Korcsolya>();

            string[] sorok1 = File.ReadAllLines("rovidprogram.csv", Encoding.UTF8);
            for (int i = 1; i < sorok1.Length; i++)
            {
                string[] adat1 = sorok1[i].Split(';');


                string nev = adat1[0];
                string orszagKodja = adat1[1];
                double technikaiPontszam = Convert.ToDouble(adat1[2].Replace('.', ','));  // Replace --> a pontot kicseréljük vesszőre)
                double komponensPontszam = Convert.ToDouble(adat1[3].Replace('.', ','));
                int hibapont = int.Parse(adat1[4]);

                Korcsolya donto = new Korcsolya(nev, orszagKodja, technikaiPontszam, komponensPontszam, hibapont);
                dontok.Add(donto);

            }


            // 2. feladat : Határozza meg és írja ki a képernyőre a rövidprogramban elindult versenyzők számát!

            Console.WriteLine("2.feladat");
            Console.WriteLine($"\tA rövidprogramban {rovidprogramok.Count()} induló volt");

            //--------------------------------------------------------------------------------------------------------------

            // 3.feladat: Írja ki a képernyőre, hogy a magyar versenyző bejutott-e a kűrbe.

            Console.WriteLine("3.feladat");



            bool Bejutott = true;
            for (int i = 0; i < dontok.Count; i++)
            {
                if (dontok[i].OrszagKodja == "HUN")
                {
                    Bejutott = true;
                }
            }
            if (Bejutott == false)
            {
                Console.WriteLine("\tA magyar versenyző nem bejutott be a kűrbe");
            }
            else
            {
                Console.WriteLine("\tA magyar versenyző bejutott a kűrbe");
            }

            // LINQ-val:


            Console.WriteLine(dontok.Any(x => x.OrszagKodja == "HUN") ? "\tA magyar versenyzo bejutott a kűrbe" : "\tA magyar versenyzo nem bejutott be a kűrbe");

            //--------------------------------------------------------------------------------------------------------

            // 4. feladat: Készítsen metódust (függvényt) vagy jellemzőt Összpontszám azonosítóval, amely egy versenyző
            //             rövidprogramban és a kűrben kapott pontszámának összegét adja. Ha valaki nem jutott be a kűrbe,
            //             akkor csak a rövidprogram pontszámát kell számolni.
            //             (Metódus esetén a paraméter legyen a versenyző neve).


         double OsszPontszam(string nev)
           
             {
                double osszpontszam = 0;
                foreach (Korcsolya i in rovidprogramok)
                {
                    if (i.Nev == nev)
                    {
                        osszpontszam += i.TechnikaiPontszam + i.KomponensPontszam - i.Hibapont;
                    }
                }

                foreach (Korcsolya i in dontok)
                {
                    if (i.Nev == nev)
                    {
                        osszpontszam += i.TechnikaiPontszam + i.KomponensPontszam - i.Hibapont;
                    }
                }
                return osszpontszam;
            }  

            //------------------------------------------------------------------------------------------

            // 5. feladat: Kérje be a felhasználótól a versenyző nevét.
            //             Ha a versenyző nem található meg az indulók között, 
            //             akkor írja ki a képernyőre, hogy "Ilyen induló nem volt"!

            Console.WriteLine("5.feladat");
           
            string bekertNev = "Amy LIN";
           
                if (rovidprogramok.Any(x => x.Nev == bekertNev))                {                    
                    
                    Console.WriteLine($"\tKérem a versenyző nevét: {bekertNev}");                   
                }
                else
                {
                    Console.WriteLine("Ilyen induló nem volt!");
                }

        //----------------------------------------------------------------------------------------

                /* 6.feladat: Írja ki a képernyőre az előző feladatban bekért versenyző összpontszámát 
                 *            (ha indul a versenyen). Amennyiben nem tudta megoldani az előző feladatot, akkor
                 *            "Amy LIN pontszámát írja ki a képernyőre. 
                 *            A megoldás során használja a 4. feladatban elkészített metódust vagy jellemzőt!   */

                Console.WriteLine("6.feladat");

                
                 double pontszam = OsszPontszam(bekertNev);
                Console.WriteLine($"\tA versenyző összpontszáma: {pontszam}");     // Nem helyes a feladat megoldása!!!!!!


            //----------------------------------------------------------------------------------------

            // 7.feladat: Készítsen összesítést arról, hogy országonként
            //            hány versenyző jutott tovább a rövidprogram
            //            bemutatása után. Írja ki a képernyőre a minta
            //            szerint azon országok  kódját és a versenyzők számát,
            //            amelyek esetében egynél több versenyző jutott tovább.

            var orszagok = dontok.GroupBy(x => x.OrszagKodja).Where( y => y.Count()> 1);

            foreach (var orszag in orszagok)
            {
                Console.WriteLine($"\t{orszag.Key} : {orszag.Count()} versenyző");
            }

            //---------------------------------------------------------------------------------------------------

            /* 8.feladat: Készítsen UTF-8 kódolású állományt 'vegeredmeny.csv' néven,
                          amely tartalmazza a verseny végeredményét. A fájlban ';'-vel elválasztva
                          a következő adatok szerepeljenek.
                                         - Helyezés
                                         - Versenyző neve
                                         - Ország
                                         - Összpontszám   */


            StreamWriter sw = new StreamWriter("vegeredmeny.csv");

            int helyezes = 0;

            foreach (var versenyzo in dontok.OrderByDescending(x => OsszPontszam(x.Nev)))
            {
                helyezes++;
                sw.WriteLine($"{helyezes}; {versenyzo.Nev}; {versenyzo.OrszagKodja}; {OsszPontszam (versenyzo.Nev)}");
            }

                sw.Close();
            }
        }
    }
  

        
    

