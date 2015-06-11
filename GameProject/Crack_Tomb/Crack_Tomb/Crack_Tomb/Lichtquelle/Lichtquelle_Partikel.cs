using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Lichtquelle
{
    class Lichtquelle_Partikel
    {
        Vector3 quelleposition;
        Vector3 position;
        Vector3 bewegung;
        Model partikel;
        int lebenszeit;

        public Lichtquelle_Partikel(Model partikel, Vector3 position, Vector3 bewegung)
        {
            this.position = position;
            this.partikel = partikel;
            this.bewegung = bewegung;
            this.quelleposition = position;
            lebenszeit = 100;
        }

        public void Update(GameTime gameTime)
        {
            //Kollisionsabfrage mit anderen Modellen
            //Hierbei muss die Bewegung gändert werden
            if (lebenszeit > 0)
            {
                lebenszeit--;
            }
            else
            {
                position = quelleposition;
                lebenszeit = 100;
            }

            position += bewegung;
        }

        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            if (lebenszeit > 0)
            {
                foreach (ModelMesh mesh in partikel.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateTranslation(position);
                    }
                    mesh.Draw();
                }
            }
        }
    }
}
