using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaffeemaschineLösung
{
    internal class Kaffeemaschine
    {
        //Deklaration der Felder für die unsere Kaffeemaschinen-Objekte gebraucht werden.
        //Da kein Zugriffsmodifikator davor steht gelten die felde als privat.
        //Was im Zuge der Datenkapselung auch so sein sollte.
        int wasserstand;
        int bohnenmenge;

        //Die folgenden Felder sind statische Felder. Das bedeutet sie sind für alle Objekte dieser Klasse gleich.
        //Kein Objekt hat dafür einen individuellen Wert.
        static int maxWasserstand = 100;
        static int maxBohnenmenge = 100;

        //Die Eigenschaften unserere Klasse
        //Diese haben wir aus unseren Feldern erstellt.
        public int Wasserstand { get => wasserstand; set => wasserstand = value; }
        public int Bohnenmenge { get => bohnenmenge; set => bohnenmenge = value; }
        public static int MaxWasserstand { get => maxWasserstand; }
        public static int MaxBohnenmenge { get => maxBohnenmenge; }

        public Kaffeemaschine(int wasserstand, int bohnenmenge)
        {
            this.wasserstand = wasserstand;
            this.bohnenmenge = bohnenmenge;
        }

        //Zwei Methoden die jeweils Wasser bzw Bohnen auf das Maxium auffüllen.

        public void WasserAuffuellen()
        {
            int auffuelmenge = MaxWasserstand - wasserstand;
            wasserstand = maxWasserstand;
            Console.WriteLine($"Ihr neuer Wasserstand ist {wasserstand} Einheiten. \n Es wurdne dafür {auffuelmenge} Einheiten Wasser gebraucht.");
            Console.ReadKey();
        }

        public void BohnenAuffuellen()
        {
            int auffuelmenge = MaxBohnenmenge - bohnenmenge;
            bohnenmenge = maxBohnenmenge;
            Console.WriteLine($"Ihr neuer Wasserstand ist {bohnenmenge} Einheiten. \n Es wurdne dafür {auffuelmenge} Einheiten Wasser gebraucht.");
            Console.ReadKey();
        }

        private bool Wasserstandsprüfung()
        {
            if (wasserstand >= 20) return true;
            else return false;
            
        }
        private bool Bohnenmengenprüfung()
        {
            if (bohnenmenge >= 2) return true;
            else return false;
            
        }

        //Es folgt die Methode um einen Kaffee zu machen.

        public void KaffeeZapfen()
        {
            if (Wasserstandsprüfung() && Bohnenmengenprüfung())
            {
                wasserstand -= 20; //wasserstand - 20
                bohnenmenge -= 2;
                Console.WriteLine("Hier bitte Ihr Kaffee");
            }
            else if (!Wasserstandsprüfung() && Bohnenmengenprüfung())
            {
                Console.WriteLine("Bitte Wasser auffüllen");
            }
            else if (!Bohnenmengenprüfung() && Wasserstandsprüfung())
            {
                Console.WriteLine("Bitte Bohnen auffüllen");
            }
            else
            {
                Console.WriteLine("Bitte Wasser und Bohnen auffüllen");
            }
        }

        public void KaffeeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Senseo Kaffeemaschine 1.0\n\nWasserstand: {wasserstand} Einheiten\tBohnenmenge: {bohnenmenge} Einheiten");
                Console.WriteLine("Bitte machen Sie eine Eingabe:\n\t1 - Kaffee machen\n\t2 - Wasser auffüllen\n\t3- Bohnen auffüllen");
                Console.Write("Eingabe: ");
                string eingabe = Console.ReadLine();

                if (eingabe == "1")
                {
                    KaffeeZapfen();
                }
                else if (eingabe == "2")
                {
                    WasserAuffuellen();
                }
                else if(eingabe == "3")
                {
                    BohnenAuffuellen();
                }
                else
                {
                    Console.WriteLine("Falsche eingabe");
                    Console.ReadKey();
                }
            }
        }
    }
}
