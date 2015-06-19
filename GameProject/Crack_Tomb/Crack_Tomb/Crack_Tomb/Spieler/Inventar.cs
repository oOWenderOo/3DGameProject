using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crack_Tomb.Spieler
{
    class Inventar
    {
        //Inventar besitzt ein Attribut. Dieses ist ein Integer Feld, welches sich merkt, von welchem Gegenstand es wie viele gibt.
        //Die Größe des Feldes ist abhängig davon, wie viele Objekte das Spiel besitzen wird(die der Spieler benutzen kann).

        //Bedeutung der Positionen
        //0 - Spiegel
        //1 - Doppelseitiger Spiegel
        //2 - Farbkristall
        //3 - Splitt-Prisma

        private int[] inventar;

        //Erzeugen eines Inventars
        public Inventar()
        {
            inventar = new int[4];

            for (int i = 0; i < inventar.Length; i++)
            {
                inventar[i] = 0;
            }
        }

        //Objekte ins Inventar einfügen
        public void pushSpiegel()
        {
            inventar[0]++;
        }

        public void pushDoppelSpiegel()
        {
            inventar[1]++;
        }

        public void pushFarbkristall()
        {
            inventar[2]++;
        }

        public void pushSplittPrisma()
        {
            inventar[3]++;
        }

        //Objekte aus dem Inventar entfernen
        public void pullSpiegel()
        {
            if (inventar[0] != 0)
            {
                inventar[0]--;
            }
        }

        public void pushDoppelSpiegel()
        {
            if (inventar[1] != 0)
            {
                inventar[1]--;
            }
        }

        public void pushFarbkristall()
        {
            if (inventar[2] != 0)
            {
                inventar[2]--;
            }
        }

        public void pushSplittPrisma()
        {
            if (inventar[3] != 0)
            {
                inventar[3]--;
            }
        }
    }
}
