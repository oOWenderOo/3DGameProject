using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Crack_Tomb.Levelloader.Level;

namespace Crack_Tomb.Levelloader
{
    class Level_LoaderV2
    {
        int Level_Nummer;
        Model wand_model, loch_model, säule_model, boden_model;
        Model barriere_model;
        Model tür_offen_model, tür_geschlossen_model, schalter_an_model, schalter_aus_model;
        Model ziel_model, start_model;
        Effect barriereEffect;

        public Vector3 Licht_Start;
        public Vector3 Licht_Richtung;
        public int minuten;
        public int sekunden;
        public int anzahlSpiegel;
        public int anzahlSplittPrisma;
        public int anzahlRed;
        public int anzahlYellow;
        public int anzahlGreen;
        public int anzahlCyan;
        public int anzahlBlue;
        public int anzahlMagenta;

        public int[,] Level_Array;

        public Level_LoaderV2(int Level_Nummer)
        {
            this.Level_Nummer = Level_Nummer;

            ALevel level;

            switch (Level_Nummer)
            {
                case 1:
                    level = new Level01();
                    break;
                case 2:
                    level = new Level02();
                    break;
                case 3:
                    level = new Level03();
                    break;
                case 4:
                    level = new Level04();
                    break;
                case 5:
                    level = new Level05();
                    break;
                case 6:
                    level = new Level06();
                    break;
                case 7:
                    level = new Level07();
                    break;
                case 8:
                    level = new Level08();
                    break;
                case 9:
                    level = new Level09();
                    break;
                case 10:
                    level = new Level10();
                    break;
                case 11:
                    level = new Level11();
                    break;
                case 12:
                    level = new Level12();
                    break;
                case 13:
                    level = new Level13();
                    break;
                case 14:
                    level = new Level14();
                    break;
                case 15:
                    level = new Level15();
                    break;
                case 16:
                    level = new Level16();
                    break;
                case 17:
                    level = new Level17();
                    break;
                case 18:
                    level = new Level18();
                    break;
                default:
                    level = new Level00();
                    break;
            }

            Licht_Start = level.Licht_Start;
            Licht_Richtung = level.Licht_Richtung;
            minuten = level.minuten;
            sekunden = level.sekunden;
            anzahlSpiegel = level.anzahlSpiegel;
            anzahlSplittPrisma = level.anzahlSplittPrisma;
            anzahlRed = level.anzahlRed;
            anzahlYellow = level.anzahlYellow;
            anzahlGreen = level.anzahlGreen;
            anzahlCyan = level.anzahlCyan;
            anzahlBlue = level.anzahlBlue;
            anzahlMagenta = level.anzahlMagenta;

            Level_Array = level.Level_Array;

            bool gefunden = false;

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if (Level_Array[i, j] == 8)
                    {
                        Licht_Start = new Vector3(i + 0.5f, 0, j + 0.5f);
                        break;
                    }
                }

                if (gefunden)
                    break;
            }
        }

        public void Array_Loader(ContentManager content)
        {
            wand_model = content.Load<Model>("3DModelle/wand");                           //WAND
            säule_model = content.Load<Model>("3DModelle/Säule mit Loch");                   //SÄULE
            loch_model = content.Load<Model>("3DModelle/saule_mit_loch_platz");           //WAND MIT LOCH
            boden_model = content.Load<Model>("3DModelle/ground");                        //BODEN
            barriere_model = content.Load<Model>("3DModelle/Farbbarrieren");              //BARRIERE
            tür_geschlossen_model = content.Load<Model>("3DModelle/boden");               //OFFENE TÜR
            tür_offen_model = content.Load<Model>("3DModelle/ground");                    //GESCHLOSSENE TÜR
            schalter_aus_model = content.Load<Model>("3DModelle/Door_Schalter");          //SCHALTER AUS
            schalter_an_model = content.Load<Model>("3DModelle/Door_Schalter_An");        //SCHALTER AN
            ziel_model = content.Load<Model>("3DModelle/Endpunkt");                       //Ziel
            start_model = content.Load<Model>("3DModelle/ground");              //ANFANG
            barriereEffect = content.Load<Effect>("Shader/BarriereEffect");
        }

        public void Draw(GraphicsDevice graphicdevice, Matrix view, Matrix projection)
        {
            foreach (ModelMesh mesh in start_model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();

                    effect.View = view;
                    effect.Projection = projection;
                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(Licht_Start);
                }
                mesh.Draw();
            }

            for (int i = 0; i < 40; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    switch (Level_Array[i, j])
                    {
                        case 0: //Boden
                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 1: //Wand
                            foreach (ModelMesh mesh in wand_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.5f));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 2: // Wand mit Loch
                            foreach (ModelMesh mesh in loch_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.5f));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 3: //Säule
                            foreach (ModelMesh mesh in säule_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.3f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.5f));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000000: //Farbbariere-Weiß
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 1, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000001: //Farbbarriere-Rot
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000010: //Farbbarriere-Gelb
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 1, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000100: //Farbbarriere-Grün
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5001000: //Farbbarriere-Cyan
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5010000: //Farbbarriere-Blau
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5100000: //Farbbarriere-Magenta
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000011: //Farbbarriere-Rot-Gelb
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0.5f, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5000110: //Farbbarriere-Grün-Gelb
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0.5f, 1, 0, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5001100: //Farbbarriere-Grün-Cyan
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 1, 0.5f, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5011000: //Farbbarriere-Blau-Cyan
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0, 0.5f, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5110000: //Farbbarriere-Blau-Magenta
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(0.5f, 0, 1, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 5100001: //Farbbarriere-Rot-Magenta
                            foreach (ModelMesh mesh in barriere_model.Meshes)
                            {
                                foreach (ModelMeshPart part in mesh.MeshParts)
                                {
                                    part.Effect = barriereEffect;
                                    if (Level_Array[i + 1, j] == 1 || Level_Array[i + 1, j] == 2)
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateRotationY(3.141f/2f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    else
                                    {
                                        barriereEffect.Parameters["World"].SetValue(Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f)));
                                    }
                                    barriereEffect.Parameters["View"].SetValue(view);
                                    barriereEffect.Parameters["Projection"].SetValue(projection);
                                    barriereEffect.Parameters["AmbientColor"].SetValue(new Vector4(1, 0, 0.5f, 1));

                                    Matrix worldInverseTransposeMatrix = Matrix.Transpose(Matrix.Invert(mesh.ParentBone.Transform * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f))));
                                    barriereEffect.Parameters["WorldInverseTranspose"].SetValue(worldInverseTransposeMatrix);
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 70: //Tür zu
                            foreach (ModelMesh mesh in tür_geschlossen_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 71: //Tür offen
                            foreach (ModelMesh mesh in tür_offen_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0, j + 0.5f));
                                }
                                mesh.Draw();
                            }
                            break;
                        case 9:
                            foreach (ModelMesh mesh in ziel_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0f, j + 0.5f));
                                }
                                mesh.Draw();
                            }

                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                        default:
                            foreach (ModelMesh mesh in boden_model.Meshes)
                            {
                                foreach (BasicEffect effect in mesh.Effects)
                                {
                                    effect.EnableDefaultLighting();

                                    effect.View = view;
                                    effect.Projection = projection;
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                                }
                                mesh.Draw();
                            }
                            break;
                    }

                    if (Level_Array[i, j] >= 600000 && Level_Array[i, j] <= 604141)
                    {
                        foreach (ModelMesh mesh in schalter_aus_model.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();

                                effect.View = view;
                                effect.Projection = projection;

                                if (Level_Array[i + 1, j] == 1)
                                {
                                    effect.World = Matrix.CreateRotationY(3.141f / -2f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.95f, 0.5f, j + 0.5f));
                                }
                                else
                                {
                                    if (Level_Array[i - 1, j] == 1)
                                    {
                                        effect.World = Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i - 0.95f, 0.5f, j + 0.5f));
                                    }
                                    else
                                    {
                                        if (Level_Array[i, j + 1] == 1)
                                        {
                                            effect.World = Matrix.CreateRotationY(3.141f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.95f));
                                        }
                                        else
                                        {
                                            effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j - 0.95f));
                                        }
                                    }
                                }
                            }
                            mesh.Draw();
                        }

                        foreach (ModelMesh mesh in boden_model.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();

                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                            }
                            mesh.Draw();
                        }
                    }

                    if (Level_Array[i, j] >= 610000 && Level_Array[i, j] <= 614141)
                    {
                        foreach (ModelMesh mesh in schalter_an_model.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();

                                effect.View = view;
                                effect.Projection = projection;

                                if (Level_Array[i + 1, j] == 1)
                                {
                                    effect.World = Matrix.CreateRotationY(3.141f / -2f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.95f, 0.5f, j + 0.5f));
                                }
                                else
                                {
                                    if (Level_Array[i - 1, j] == 1)
                                    {
                                        effect.World = Matrix.CreateRotationY(3.141f / 2f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i - 0.95f, 0.5f, j + 0.5f));
                                    }
                                    else
                                    {
                                        if (Level_Array[i, j + 1] == 1)
                                        {
                                            effect.World = Matrix.CreateRotationY(3.141f) * Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.95f));
                                        }
                                        else
                                        {
                                            effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j - 0.95f));
                                        }
                                    }
                                }
                            }
                            mesh.Draw();
                        }

                        foreach (ModelMesh mesh in boden_model.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();

                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(0.5f + i, 0f, 0.5f + j));
                            }
                            mesh.Draw();
                        }
                    }
                }
            }
        }
    }
}
