using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

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

        public int[,] Level_Array;

        public Level_LoaderV2(int Level_Nummer)
        {
            this.Level_Nummer = Level_Nummer;

            switch (Level_Nummer)
            {
                case 1:
                    Level_Array = new Level1().Level_Array;
                    Licht_Start = new Level1().Licht_Start;
                    Licht_Richtung = new Level1().Licht_Richtung;
                    minuten = new Level1().minuten;
                    sekunden = new Level1().sekunden;
                    break;
                case 2:
                    Level_Array = new Level2().Level_Array;
                    Licht_Start = new Level2().Licht_Start;
                    Licht_Richtung = new Level2().Licht_Richtung;
                    minuten = new Level2().minuten;
                    sekunden = new Level2().sekunden;
                    break;
                case 3:
                    Level_Array = new Level3().Level_Array;
                    Licht_Start = new Level3().Licht_Start;
                    Licht_Richtung = new Level3().Licht_Richtung;
                    minuten = new Level3().minuten;
                    sekunden = new Level3().sekunden;
                    break;
                case 4:
                    Level_Array = new Level4().Level_Array;
                    Licht_Start = new Level4().Licht_Start;
                    Licht_Richtung = new Level4().Licht_Richtung;
                    minuten = new Level4().minuten;
                    sekunden = new Level4().sekunden;
                    break;
                case 5:
                    Level_Array = new Level5().Level_Array;
                    Licht_Start = new Level5().Licht_Start;
                    Licht_Richtung = new Level5().Licht_Richtung;
                    minuten = new Level5().minuten;
                    sekunden = new Level5().sekunden;
                    break;
                case 6:
                    Level_Array = new Level6().Level_Array;
                    Licht_Start = new Level6().Licht_Start;
                    Licht_Richtung = new Level6().Licht_Richtung;
                    minuten = new Level6().minuten;
                    sekunden = new Level6().sekunden;
                    break;
                case 7:
                    Level_Array = new Level7().Level_Array;
                    Licht_Start = new Level7().Licht_Start;
                    Licht_Richtung = new Level7().Licht_Richtung;
                    minuten = new Level7().minuten;
                    sekunden = new Level7().sekunden;
                    break;
                case 8:
                    Level_Array = new Level8().Level_Array;
                    Licht_Start = new Level8().Licht_Start;
                    Licht_Richtung = new Level8().Licht_Richtung;
                    minuten = new Level8().minuten;
                    sekunden = new Level8().sekunden;
                    break;
                case 9:
                    Level_Array = new Level9().Level_Array;
                    Licht_Start = new Level9().Licht_Start;
                    Licht_Richtung = new Level9().Licht_Richtung;
                    minuten = new Level9().minuten;
                    sekunden = new Level9().sekunden;
                    break;
                case 10:
                    Level_Array = new Level10().Level_Array;
                    Licht_Start = new Level10().Licht_Start;
                    Licht_Richtung = new Level10().Licht_Richtung;
                    minuten = new Level10().minuten;
                    sekunden = new Level10().sekunden;
                    break;
                case 11:
                    Level_Array = new Level11().Level_Array;
                    Licht_Start = new Level11().Licht_Start;
                    Licht_Richtung = new Level11().Licht_Richtung;
                    minuten = new Level11().minuten;
                    sekunden = new Level11().sekunden;
                    break;
                case 12:
                    Level_Array = new Level12().Level_Array;
                    Licht_Start = new Level12().Licht_Start;
                    Licht_Richtung = new Level12().Licht_Richtung;
                    minuten = new Level12().minuten;
                    sekunden = new Level12().sekunden;
                    break;
                case 13:
                    Level_Array = new Level13().Level_Array;
                    Licht_Start = new Level13().Licht_Start;
                    Licht_Richtung = new Level13().Licht_Richtung;
                    minuten = new Level13().minuten;
                    sekunden = new Level13().sekunden;
                    break;
                case 14:
                    Level_Array = new Level14().Level_Array;
                    Licht_Start = new Level14().Licht_Start;
                    Licht_Richtung = new Level14().Licht_Richtung;
                    minuten = new Level14().minuten;
                    sekunden = new Level14().sekunden;
                    break;
                case 15:
                    Level_Array = new Level15().Level_Array;
                    Licht_Start = new Level15().Licht_Start;
                    Licht_Richtung = new Level15().Licht_Richtung;
                    minuten = new Level15().minuten;
                    sekunden = new Level15().sekunden;
                    break;
                default:
                    Level_Array = new Level0().Level_Array;
                    Licht_Start = new Level0().Licht_Start;
                    Licht_Richtung = new Level0().Licht_Richtung;
                    minuten = new Level0().minuten;
                    sekunden = new Level0().sekunden;
                    break;
            }
        }

        public void Array_Loader(ContentManager content)
        {
            wand_model = content.Load<Model>("3DModelle/wand");                           //WAND
            säule_model = content.Load<Model>("3DModelle/saule_platz");                   //SÄULE
            loch_model = content.Load<Model>("3DModelle/saule_mit_loch_platz");           //WAND MIT LOCH
            boden_model = content.Load<Model>("3DModelle/ground");                        //BODEN
            barriere_model = content.Load<Model>("3DModelle/Farbbarrieren");              //BARRIERE
            tür_geschlossen_model = content.Load<Model>("3DModelle/boden");               //OFFENE TÜR
            tür_offen_model = content.Load<Model>("3DModelle/ground");                    //GESCHLOSSENE TÜR
            schalter_aus_model = content.Load<Model>("3DModelle/Door_Schalter");          //SCHALTER AUS
            schalter_an_model = content.Load<Model>("3DModelle/ground");                  //SCHALTER AN
            ziel_model = content.Load<Model>("3DModelle/Endpunkt");                       //Ziel
            barriereEffect = content.Load<Effect>("Shader/BarriereEffect");
        }

        public void Draw(GraphicsDevice graphicdevice, Matrix view, Matrix projection)
        {
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
                                    effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(i + 0.5f, 0.5f, j + 0.5f));
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
