using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Binaarihakupuu
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaariPuu binaariPuu = new BinaariPuu(); 

            List<Ehdokas> ehdokkaat = new List<Ehdokas>();
            string rivi;

            //Luetaan tekstitiedosto ja lisätään tiedot ehdokkaat-listaan
            StreamReader tiedosto = new StreamReader(@"ehdokkaat.txt", Encoding.Default);
            while ((rivi = tiedosto.ReadLine()) != null)
            {
                string[] teksti = rivi.Split(new Char[] { ' ', '\t', ',' });
                int aanet = Int32.Parse(teksti[3]);
                
                ehdokkaat.Add(new Ehdokas(teksti[0], teksti[1], aanet));
            }
            tiedosto.Close();

            ////Tulostetaan ehdokkaat lista
            //foreach (var item in ehdokkaat)
            //{
            //    Console.WriteLine(item.etunimi + " " + item.sukunimi + " " + item.aanimaara);
            //}


            //Lisätään ehdokkaat listalta puuhun
            foreach (var item in ehdokkaat)
            {
                binaariPuu.Insert(item.etunimi, item.sukunimi, item.aanimaara);
            }


            //Sisäjärjestys
            Console.WriteLine("Sisäjärjestys\n");
            binaariPuu.InOrderTraversal();


            //Haku            
            Console.WriteLine("\nAnna etsittävä sukunimi: ");
            var node = binaariPuu.Find(Console.ReadLine());
            if (node != null)
            {
              Console.WriteLine(node.etunimi + " " + node.sukunimi + " " + node.aanimaara);
            }
            else Console.WriteLine("Ei löytynyt");



            Console.ReadLine();  
           
            

        }
    }
}
