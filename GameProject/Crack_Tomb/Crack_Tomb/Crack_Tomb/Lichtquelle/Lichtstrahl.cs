using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Lichtquelle
{
    class Lichtstrahl
    {
        Vector3 position;
        Vector3 richtung;

        int anzahlpartikel;
        int maxpartikel;
        Model partikel;

        Lichtquelle_Partikel[] p;

        public Lichtstrahl(int maxpartikel, Model partikel, Vector3 position, Vector3 richtung)
        {
            this.position = position;
            this.richtung = richtung;
            this.maxpartikel = maxpartikel;
            this.partikel = partikel;
            this.anzahlpartikel = 0;

            p = new Lichtquelle_Partikel[this.maxpartikel];
        }

        public void SetAnzhalPartikel(int anzhalpartikel)
        {
            this.anzahlpartikel = anzhalpartikel;
        }

        public void Update(GameTime gameTime)
        {
            if (anzahlpartikel < maxpartikel)
            {
                p[anzahlpartikel] = new Lichtquelle_Partikel(partikel, position, richtung);
                anzahlpartikel++;
            }

            for (int i = 0; i < anzahlpartikel; i++)
            {
                p[i].Update(gameTime);
            }
        }

        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            for (int i = 0; i < anzahlpartikel; i++)
            {
                p[i].Draw(gameTime, view, projection);
            }
        }
    }
}
