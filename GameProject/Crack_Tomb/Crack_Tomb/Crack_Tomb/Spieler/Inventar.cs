using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Spieler
{
    class Inventar
    {
        //Inventar besitzt ein Attribut. Dieses ist ein Integer Feld, welches sich merkt, von welchem Gegenstand es wie viele gibt.
        //Die Größe des Feldes ist abhängig davon, wie viele Objekte das Spiel besitzen wird(die der Spieler benutzen kann).

        //Bedeutung der Positionen
        //0 - Spiegel
        //1 - Splitt-Prisma
        //2 - Farbkristall

        private int[] inventar;
        SpriteFont font;

        //Erzeugen eines Inventars
        public Inventar(ContentManager content)
        {
            inventar = new int[3];
            font = content.Load<SpriteFont>("Normal");

            for (int i = 0; i < inventar.Length; i++)
            {
                inventar[i] = 5;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();

            for (int i = 0; i < inventar.Length; i++)
            {
                string str = "" + inventar[i];
                spritebatch.DrawString(font, str, new Vector2(500, 100 * i), Color.Black);
            }

            spritebatch.End();
        }

        //Objekte ins Inventar einfügen
        public void pushSpiegel()
        {
            inventar[0]++;
        }

        public void pushFarbkristall()
        {
            inventar[2]++;
        }

        public void pushSplittPrisma()
        {
            inventar[1]++;
        }

        //Objekte aus dem Inventar entfernen
        public void pullSpiegel()
        {
            if (inventar[0] != 0)
            {
                inventar[0]--;
            }
        }

        public void pullFarbkristall()
        {
            if (inventar[2] != 0)
            {
                inventar[2]--;
            }
        }

        public void pullSplittPrisma()
        {
            if (inventar[1] != 0)
            {
                inventar[1]--;
            }
        }

        public int getNumSpiegel()
        {
            return inventar[0];
        }

        public int getNumSplittPrisma()
        {
            return inventar[1];
        }

        public int getNumFarbkristall()
        {
            return inventar[2];
        }
    }
}
