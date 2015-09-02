using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Crack_Tomb.Levelloader;

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
        Effect kristalleffect;

        public Player(Vector3 startposition, Model spielermodel, int LevelNummer, ContentManager content, ref Level_LoaderV2 levelloader)
        {
            position = startposition;
            this.spielermodel = spielermodel;
            inventar = new Inventar(content);
            playersteuerung = new PlayerSteuerung(LevelNummer, ref Säulen_Array, content.Load<SoundEffect>("Audio/farbkristallkramen"), content.Load<SoundEffect>("Audio/herausnehmen"));
            spiegel = content.Load<Model>("3DModelle/Mirror");
            splittprisma = content.Load<Model>("3DModelle/Splittprisma");
            farbkristall = content.Load<Model>("3DModelle/kristall");
            kristalleffect = content.Load<Effect>("Shader/KristallEffect");
            setInventar(ref levelloader);

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if (levelloader.Level_Array[i, j] == 3)
                    {
                        Säulen_Array[i, j] = 1;
                    }
                    else
                    {
                        Säulen_Array[i, j] = 0;
                    }
                }
            }
        }

        public void Update(GameTime gametime, ref Level_LoaderV2 levelloader, bool isMapActive)
        {
            //Steuerung des Spielers
            if(!isMapActive)
                position = playersteuerung.Update(gametime, position, ref Säulen_Array, ref inventar, ref levelloader);
        }

        public void setInventar(ref Level_LoaderV2 levelloader)
        {
            inventar.setSpiegel(levelloader.anzahlSpiegel);
            inventar.setSplittPrisma(levelloader.anzahlSplittPrisma);
            inventar.setFatbkristallRed(levelloader.anzahlRed);
            inventar.setFatbkristallYellow(levelloader.anzahlYellow);
            inventar.setFatbkristallGreen(levelloader.anzahlGreen);
            inventar.setFatbkristallCyan(levelloader.anzahlCyan);
            inventar.setFatbkristallBlue(levelloader.anzahlBlue);
            inventar.setFatbkristallMagenta(levelloader.anzahlMagenta);
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
                    effect.World = Matrix.CreateScale(0.70f) * Matrix.CreateTranslation(position);
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
                            spiegel.Draw(Matrix.CreateScale(0.1f) * Matrix.CreateRotationZ(3.141f / 4f) * Matrix.CreateRotationX(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 1f, j + 0.5f)), view, projection);
                            break;
                        case 3:
                            spiegel.Draw(Matrix.CreateScale(0.1f) * Matrix.CreateRotationZ(3.141f / -4f) * Matrix.CreateRotationX(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 1f, j + 0.5f)), view, projection);
                            break;
                        case 4:
                            splittprisma.Draw(Matrix.CreateScale(0.175f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.8f, j + 0.5f)), view, projection);
                            break;
                        case 5:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
                            break;
                        case 6:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 1, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
                            break;
                        case 7:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
                            break;
                        case 8:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
                            break;
                        case 9:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
                            break;
                        case 10:
                            foreach (ModelMesh mesh in farbkristall.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = kristalleffect;
                                    kristalleffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i, 0, j)));
                                    kristalleffect.Parameters["View"].SetValue(view);
                                    kristalleffect.Parameters["Projection"].SetValue(projection);
                                    kristalleffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(position + new Vector3(0, 0.5f, 0))));
                                    kristalleffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }
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
