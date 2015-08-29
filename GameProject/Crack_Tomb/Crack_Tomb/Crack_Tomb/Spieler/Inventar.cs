using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

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
        Texture2D inventarTextur;
        public bool drawFarbkristalle = false;
        SoundEffect einsetzen;
        int positionNumX = 85;
        int positionNumY = 420;

        //Erzeugen eines Inventars
        public Inventar(ContentManager content)
        {
            inventar = new int[8];
            font = content.Load<SpriteFont>("Fonts/InventarNummer");
            inventarTextur = content.Load<Texture2D>("2DTexturen/Inventar");
            einsetzen = content.Load<SoundEffect>("Audio/einsetzen");

            for (int i = 0; i < inventar.Length; i++)
            {
                inventar[i] = 5;
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();

            spritebatch.Draw(inventarTextur, new Vector2(-10, 370), Color.White);

            if (drawFarbkristalle)
            {

                for (int i = 2; i < inventar.Length; i++)
                {
                    string str = "" + inventar[i];
                    spritebatch.DrawString(font, str, new Vector2(positionNumX + 80 * i, positionNumY), Color.Black);
                }
            }
            else
            {
                for (int i = 0; i < 2; i++)
                {
                    string str = "" + inventar[i];
                    spritebatch.DrawString(font, str, new Vector2(positionNumX + 80 * i, positionNumY), Color.Black);
                }

                spritebatch.DrawString(font, "" + getNumFarbkristall(), new Vector2(positionNumX + 80 * 2, positionNumY), Color.Black);
            }

            spritebatch.End();
        }

        //Object im Inventar auf bestimmten Wert setzen
        public void setSpiegel(int anzahl)
        {
            inventar[0] = anzahl;
        }

        public void setSplittPrisma(int anzahl)
        {
            inventar[1] = anzahl;
        }

        public void setFatbkristallRed(int anzahl)
        {
            inventar[2] = anzahl;
        }

        public void setFatbkristallYellow(int anzahl)
        {
            inventar[3] = anzahl;
        }

        public void setFatbkristallGreen(int anzahl)
        {
            inventar[4] = anzahl;
        }

        public void setFatbkristallCyan(int anzahl)
        {
            inventar[5] = anzahl;
        }

        public void setFatbkristallBlue(int anzahl)
        {
            inventar[6] = anzahl;
        }

        public void setFatbkristallMagenta(int anzahl)
        {
            inventar[7] = anzahl;
        }

        //Objekte ins Inventar einfügen
        public void pushSpiegel()
        {
            inventar[0]++;
        }

        public void pushSplittPrisma()
        {
            inventar[1]++;
        }


        public void pushFarbkristallRed()
        {
            inventar[2]++;
        }


        public void pushFarbkristallYellow()
        {
            inventar[3]++;
        }


        public void pushFarbkristallGreen()
        {
            inventar[4]++;
        }


        public void pushFarbkristallCyan()
        {
            inventar[5]++;
        }


        public void pushFarbkristallBlue()
        {
            inventar[6]++;
        }


        public void pushFarbkristallMagenta()
        {
            inventar[7]++;
        }

        //Objekte aus dem Inventar entfernen
        public void pullSpiegel()
        {
            if (inventar[0] != 0)
            {
                inventar[0]--;
                einsetzen.Play();
            }
        }

        public void pullSplittPrisma()
        {
            if (inventar[1] != 0)
            {
                inventar[1]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallRed()
        {
            if (inventar[2] != 0)
            {
                inventar[2]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallYellow()
        {
            if (inventar[3] != 0)
            {
                inventar[3]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallGreen()
        {
            if (inventar[4] != 0)
            {
                inventar[4]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallCyan()
        {
            if (inventar[5] != 0)
            {
                inventar[5]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallBlue()
        {
            if (inventar[6] != 0)
            {
                inventar[6]--;
                einsetzen.Play();
            }
        }

        public void pullFarbkristallMagenta()
        {
            if (inventar[7] != 0)
            {
                inventar[7]--;
                einsetzen.Play();
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
            return inventar[2] + inventar[3] + inventar[4] + inventar[5] + inventar[6] + inventar[7];
        }

        public int getNumFarbkristallRed()
        {
            return inventar[2];
        }

        public int getNumFarbkristallYellow()
        {
            return inventar[3];
        }

        public int getNumFarbkristallGreen()
        {
            return inventar[4];
        }

        public int getNumFarbkristallCyan()
        {
            return inventar[5];
        }

        public int getNumFarbkristallBlue()
        {
            return inventar[6];
        }

        public int getNumFarbkristallMagenta()
        {
            return inventar[7];
        }
    }
}
