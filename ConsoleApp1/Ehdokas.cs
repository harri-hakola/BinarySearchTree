using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binaarihakupuu
{
    public class Ehdokas
    {
        public string etunimi;
        public string sukunimi;
        public int aanimaara;


        public Ehdokas(string etunimi, string sukunimi, int aanimaara) //konstruktori
        {
            this.etunimi = etunimi;
            this.sukunimi = sukunimi;
            this.aanimaara = aanimaara;
        }

        public Ehdokas leftNode;
        public Ehdokas rightNode;


        
        public void Insert(string etunimi, string sukunimi, int aanimaara) //datan lisäys nodeihin
        {
            
            if (sukunimi.CompareTo(this.sukunimi) >= 0) //Jos lisättävä suurempi kuin vertailtava, lisätään oikealle
            {
                if (rightNode == null)
                {
                    rightNode = new Ehdokas(etunimi, sukunimi, aanimaara); //Jos ei ole olemassa niin luodaan
                }
                else
                {
                    rightNode.Insert(etunimi, sukunimi, aanimaara); //Jos on niin lisätään
                }
            }
            else //Jos lisättävä pienempi kuin vertailtava lisätään vasempaan
            {
                if (leftNode == null)
                {
                    leftNode = new Ehdokas(etunimi, sukunimi, aanimaara); //Jos ei ole olemassa niin luodaan
                }
                else
                {
                    leftNode.Insert(etunimi, sukunimi, aanimaara); //Jos on niin lisätään
                }
            }
        }

        
        public Ehdokas Find(string value) //Hakufunktio
        {
            
            Ehdokas currentNode = this; 

            while (currentNode != null) 
            {
                if (value == currentNode.sukunimi) //Jos tiedot täsmää palauta arvo
                {
                    return currentNode;
                }
                else if (value.CompareTo(currentNode.sukunimi) >0) //Jos isompi arvo palauta oikealla oleva node
                {
                    currentNode = currentNode.rightNode;
                }
                else //Jos pienempi arvo, palauta vasen node
                {
                    currentNode = currentNode.leftNode;
                }
            }
            //Ei löytynyt
            return null;
        }

        public void InOrdertraversal() //Sisäjärjestys
        {
            if (leftNode != null)
                leftNode.InOrdertraversal();
            Console.WriteLine(etunimi + " " + sukunimi + " " + aanimaara);

            if (rightNode != null)
                rightNode.InOrdertraversal();
        }
    }
}
