using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Crack_Tomb.Lichtquelle;
using Crack_Tomb.Spieler;

namespace Lichtquelle
{
    class Lichtstrahl
    {
        Lichtquelle_Partikel p, newp;
        Vector3 position;
        Vector3 richtung;
        Model partikelmodel;
        PartikelCollider collider;

        public Lichtstrahl(Model partikelmodel, Vector3 position, Vector3 richtung , int levelnummer, Player player)
        {
            this.partikelmodel = partikelmodel;
            this.position = position;
            this.richtung = richtung;

            p = new Lichtquelle_Partikel(partikelmodel, position, richtung, null, null);
            collider = new PartikelCollider(levelnummer);
        }

        public void Update(GameTime gameTime, ref Player player)
        {
            if (p == null)
            {
                p = new Lichtquelle_Partikel(partikelmodel, position, richtung, null, null);
            }
            else
            {
                if (dist(position, p.getPosition()) > 1)
                {
                    newp = new Lichtquelle_Partikel(partikelmodel, position, richtung, p, null);
                    p.setNachfolger(newp);
                    p = p.getNachfolger();
                }

                p.Update(gameTime, collider, ref player);
            }
        }

        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            if (p != null)
            {
                p.Draw(gameTime, view, projection);
            }
        }

        private double dist(Vector3 a, Vector3 b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y) + (a.Z - b.Z) * (a.Z - b.Z));
        }
    }
}
