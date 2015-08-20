using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Crack_Tomb.Spieler
{
    class Player
    {
        public Vector3 position;
        Model spielermodel;
        Model spiegel, splittprisma, farbkristall;
        Inventar inventar;
        PlayerSteuerung playersteuerung;
        int[,] Säulen_Array = new int[41, 41];

        public Player(Vector3 startposition, Model spielermodel, int LevelNummer, ContentManager content)
        {
            position = startposition;
            this.spielermodel = spielermodel;
            inventar = new Inventar(content);
            playersteuerung = new PlayerSteuerung(LevelNummer, ref Säulen_Array);
            spiegel = content.Load<Model>("Spiegel");
            splittprisma = content.Load<Model>("Splittprisma");
            farbkristall = content.Load<Model>("kristall");
        }

        public void Update(GameTime gametime)
        {
            //Steuerung des Spielers
            position = playersteuerung.Update(gametime, position, ref Säulen_Array, ref inventar);
        }

        public void Draw(Matrix view, Matrix projection, SpriteBatch spritebatch)
        {
            //Spieler wird sichtbar gemacht
            foreach (ModelMesh mesh in spielermodel.Meshes)
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

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    switch (Säulen_Array[i, j])
                    {
                        case 2:
                            spiegel.Draw(Matrix.CreateTranslation(new Vector3(i,0,j)), view, projection);
                            break;
                        case 3:
                            spiegel.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 4:
                            splittprisma.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 5:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 6:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 7:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 8:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 9:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 10:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 11:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        case 12:
                            farbkristall.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
                            break;
                        default:
                            break;
                    }
                }
            }

            inventar.Draw(spritebatch);
        }

        public int[,] getSäulenArray()
        {
            return Säulen_Array;
        }
    }
}
