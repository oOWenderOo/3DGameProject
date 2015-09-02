using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Crack_Tomb.Lichtquelle;
using Crack_Tomb.Spieler;
using Crack_Tomb;
using Crack_Tomb.Levelloader;

namespace Lichtquelle
{
    class Lichtquelle_Partikel
    {
        MyColor farbe;
        Vector3 position;
        Vector3 richtung;
        Model partikelmodel;
        Lichtquelle_Partikel vorgänger;
        Lichtquelle_Partikel nachfolger;
        public Effect effect;
        int letzteBewegung = 0;

        public Lichtquelle_Partikel(Model partikelmodel, Vector3 position, Vector3 richtung, Lichtquelle_Partikel vorgänger, Lichtquelle_Partikel nachfolger, MyColor farbe, Effect effect)
        {
            this.effect = effect;
            this.farbe = farbe;
            this.partikelmodel = partikelmodel;
            this.position = position;
            this.richtung = richtung;
            this.vorgänger = vorgänger;
            this.nachfolger = nachfolger;
        }

        public void Update(GameTime gameTime, PartikelCollider collider, ref Player player, ref bool gewonnen, ref Level_LoaderV2 levelloader)
        {
            if (vorgänger != null)
            {
                vorgänger.Update(gameTime, collider, ref player, ref gewonnen, ref levelloader);
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

            if (gameTime.TotalGameTime.Milliseconds % 100 == 0)
            {
                int letzeBewegung = gameTime.TotalGameTime.Milliseconds;

                Vector3 newposition = position + richtung;

                collider.colliding(this, newposition, ref player, ref gewonnen, ref levelloader);
            }
            else
            {
                Vector3 newposition = position;

                collider.colliding(this, newposition, ref player, ref gewonnen, ref levelloader);
            }
        }

        public void Draw(GameTime gameTime, Matrix view, Matrix projection)
        {
            if (vorgänger != null)
            {
                vorgänger.Draw(gameTime, view, projection);
            }

            foreach (ModelMesh mesh in partikelmodel.Meshes)
            {
                foreach (ModelMeshPart part in mesh.MeshParts)
                {
                    part.Effect = effect;

                    if(richtung == new Vector3(0, 0, 1) || richtung == new Vector3(0, 0, -1)) 
                        effect.Parameters["World"].SetValue(Matrix.CreateScale(0.1f, 0.1f, 1) * Matrix.CreateTranslation(position + new Vector3(0, 1f, 0)));
                    else
                        effect.Parameters["World"].SetValue(Matrix.CreateScale(0.1f, 0.1f, 1) * Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(position + new Vector3(0, 1f, 0)));
                    
                    
                    effect.Parameters["View"].SetValue(view);
                    effect.Parameters["Projection"].SetValue(projection);

                    switch (farbe.mycolor)
                    {
                        case 000000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 1, 1, 1));
                            break;
                        case 000001:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 0, 1));
                            break;
                        case 000010:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 1, 0, 1));
                            break;
                        case 000100:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 0, 1));
                            break;
                        case 001000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 1, 1));
                            break;
                        case 010000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0, 1, 1));
                            break;
                        case 100000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 1, 1));
                            break;
                        case 000011:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0.5f, 0, 1));
                            break;
                        case 000110:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0.5f, 1, 0, 1));
                            break;
                        case 001100:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 0.5f, 1));
                            break;
                        case 011000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0.5f, 1, 1));
                            break;
                        case 110000:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0.5f, 0, 1, 1));
                            break;
                        case 100001:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 0.5f, 1));
                            break;
                        default:
                            effect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0, 0, 1));
                            break;
                    }

                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                    effect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                }
                mesh.Draw();
            }
        }

        public Vector3 getPosition()
        {
            return position;
        }

        public Vector3 getRichtung()
        {
            return richtung;
        }

        public MyColor getFarbe()
        {
            return farbe;
        }

        public Model getModel()
        {
            return partikelmodel;
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

        public void setFarbe(MyColor farbe)
        {
            this.farbe = farbe;
        }
    }
}
