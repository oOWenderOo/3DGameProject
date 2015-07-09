using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crack_Tomb.Lichtquelle;
using Crack_Tomb.Spieler;

namespace Lichtquelle
{
    class Lichtquelle_Partikel
    {
        Vector3 position;
        Vector3 richtung;
        Model partikelmodel;
        Lichtquelle_Partikel vorgänger;
        Lichtquelle_Partikel nachfolger;

        public Lichtquelle_Partikel(Model partikelmodel, Vector3 position, Vector3 richtung, Lichtquelle_Partikel vorgänger, Lichtquelle_Partikel nachfolger)
        {
            this.partikelmodel = partikelmodel;
            this.position = position;
            this.richtung = richtung;
            this.vorgänger = vorgänger;
            this.nachfolger = nachfolger;
        }

        public void Update(GameTime gameTime, PartikelCollider collider, ref Player player, ref bool gewonnen)
        {
            if (vorgänger != null)
            {
                vorgänger.Update(gameTime, collider, ref player, ref gewonnen);
            }
            else
            {
                if (richtung == new Vector3(0, 0, 0))
                {
                    nachfolger.setVorgänger(null);
                }
            }

            if (nachfolger != null)
            {
                if (nachfolger.richtung == new Vector3(0, 0, 0))
                {
                    löscheNachfolger();
                }
            }

            if (((int)gameTime.TotalGameTime.Milliseconds) % 100 == 0)
            {
                Vector3 newposition = position + richtung;

                collider.colliding(this, newposition, ref player, ref gewonnen);
            }
            else
            {
                Vector3 newposition = position;

                collider.colliding(this, newposition, ref player, ref gewonnen);
            }
        }

        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            if (vorgänger != null)
            {
                vorgänger.Draw(gameTime, view, projection);
            }

            partikelmodel.Draw(Matrix.CreateTranslation(position), view, projection);
        }

        public Vector3 getPosition()
        {
            return position;
        }

        public Vector3 getRichtung()
        {
            return richtung;
        }

        public void setVorgänger(Lichtquelle_Partikel vorgänger)
        {
            this.vorgänger = vorgänger;
        }

        public void setNachfolger(Lichtquelle_Partikel nachfolger)
        {
            this.nachfolger = nachfolger;
        }

        public Lichtquelle_Partikel getVorgänger()
        {
            return vorgänger;
        }

        public Lichtquelle_Partikel getNachfolger()
        {
            return nachfolger;
        }

        public void löscheNachfolger()
        {
            nachfolger = nachfolger.getNachfolger();

            if (nachfolger != null)
            {
                nachfolger.setVorgänger(this);
            }
        }

        public void setPosition(Vector3 position)
        {
            this.position = position;
        }

        public void setRichtung(Vector3 richtung)
        {
            this.richtung = richtung;
        }
    }
}
