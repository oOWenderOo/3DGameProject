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

        public Player(Vector3 startposition, Model spielermodel, int LevelNummer, ContentManager content)
        {
            position = startposition;
            this.spielermodel = spielermodel;
            inventar = new Inventar(content);
            playersteuerung = new PlayerSteuerung(LevelNummer, ref Säulen_Array, content.Load<SoundEffect>("Audio/farbkristallkramen"), content.Load<SoundEffect>("Audio/herausnehmen"));
            spiegel = content.Load<Model>("3DModelle/Mirror");
            splittprisma = content.Load<Model>("3DModelle/Splittprisma");
            farbkristall = content.Load<Model>("3DModelle/kristall");
            kristalleffect = content.Load<Effect>("Shader/KristallEffect");
            setInventar(LevelNummer);
        }

        public void Update(GameTime gametime, ref Level_LoaderV2 levelloader)
        {
            //Steuerung des Spielers
            position = playersteuerung.Update(gametime, position, ref Säulen_Array, ref inventar, ref levelloader);
        }

        public void setInventar(int levelnummer)
        {
            switch (levelnummer)
            {
                case 1:
                    inventar.setSpiegel(new Level1().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level1().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level1().anzahlRed);
                    inventar.setFatbkristallYellow(new Level1().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level1().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level1().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level1().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level1().anzahlMagenta);
                    break;
                case 2:
                    inventar.setSpiegel(new Level2().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level2().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level2().anzahlRed);
                    inventar.setFatbkristallYellow(new Level2().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level2().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level2().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level2().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level2().anzahlMagenta);
                    break;
                case 3:
                    inventar.setSpiegel(new Level3().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level3().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level3().anzahlRed);
                    inventar.setFatbkristallYellow(new Level3().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level3().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level3().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level3().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level3().anzahlMagenta);
                    break;
                case 4:
                    inventar.setSpiegel(new Level4().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level4().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level4().anzahlRed);
                    inventar.setFatbkristallYellow(new Level4().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level4().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level4().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level4().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level4().anzahlMagenta);
                    break;
                case 5:
                    inventar.setSpiegel(new Level5().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level5().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level5().anzahlRed);
                    inventar.setFatbkristallYellow(new Level5().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level5().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level5().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level5().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level5().anzahlMagenta);
                    break;
                case 6:
                    inventar.setSpiegel(new Level6().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level6().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level6().anzahlRed);
                    inventar.setFatbkristallYellow(new Level6().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level6().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level6().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level6().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level6().anzahlMagenta);
                    break;
                case 7:
                    inventar.setSpiegel(new Level7().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level7().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level7().anzahlRed);
                    inventar.setFatbkristallYellow(new Level7().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level7().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level7().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level7().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level7().anzahlMagenta);
                    break;
                case 8:
                    inventar.setSpiegel(new Level8().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level8().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level8().anzahlRed);
                    inventar.setFatbkristallYellow(new Level8().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level8().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level8().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level8().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level8().anzahlMagenta);
                    break;
                case 9:
                    inventar.setSpiegel(new Level9().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level9().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level9().anzahlRed);
                    inventar.setFatbkristallYellow(new Level9().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level9().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level9().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level9().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level9().anzahlMagenta);
                    break;
                case 10:
                    inventar.setSpiegel(new Level10().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level10().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level10().anzahlRed);
                    inventar.setFatbkristallYellow(new Level10().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level10().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level10().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level10().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level10().anzahlMagenta);
                    break;
                case 11:
                    inventar.setSpiegel(new Level11().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level11().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level11().anzahlRed);
                    inventar.setFatbkristallYellow(new Level11().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level11().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level11().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level11().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level11().anzahlMagenta);
                    break;
                case 12:
                    inventar.setSpiegel(new Level12().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level12().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level12().anzahlRed);
                    inventar.setFatbkristallYellow(new Level12().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level12().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level12().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level12().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level12().anzahlMagenta);
                    break;
                case 13:
                    inventar.setSpiegel(new Level13().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level13().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level13().anzahlRed);
                    inventar.setFatbkristallYellow(new Level13().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level13().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level13().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level13().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level13().anzahlMagenta);
                    break;
                case 14:
                    inventar.setSpiegel(new Level14().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level14().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level14().anzahlRed);
                    inventar.setFatbkristallYellow(new Level14().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level14().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level14().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level14().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level14().anzahlMagenta);
                    break;
                case 15:
                    inventar.setSpiegel(new Level15().anzahlSpiegel);
                    inventar.setSplittPrisma(new Level15().anzahlSplittPrisma);
                    inventar.setFatbkristallRed(new Level15().anzahlRed);
                    inventar.setFatbkristallYellow(new Level15().anzahlYellow);
                    inventar.setFatbkristallGreen(new Level15().anzahlGreen);
                    inventar.setFatbkristallCyan(new Level15().anzahlCyan);
                    inventar.setFatbkristallBlue(new Level15().anzahlBlue);
                    inventar.setFatbkristallMagenta(new Level15().anzahlMagenta);
                    break;
                default:
                    inventar.setSpiegel(0);
                    inventar.setSplittPrisma(0);
                    inventar.setFatbkristallRed(0);
                    inventar.setFatbkristallYellow(0);
                    inventar.setFatbkristallGreen(0);
                    inventar.setFatbkristallCyan(0);
                    inventar.setFatbkristallBlue(0);
                    inventar.setFatbkristallMagenta(0);
                    break;
            }
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
                            spiegel.Draw(Matrix.CreateScale(0.25f) * Matrix.CreateRotationZ(3.141f / 4f) * Matrix.CreateRotationX(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)), view, projection);
                            break;
                        case 3:
                            spiegel.Draw(Matrix.CreateScale(0.25f) * Matrix.CreateRotationZ(3.141f / -4f) * Matrix.CreateRotationX(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)), view, projection);
                            break;
                        case 4:
                            splittprisma.Draw(Matrix.CreateTranslation(new Vector3(i, 0, j)), view, projection);
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
