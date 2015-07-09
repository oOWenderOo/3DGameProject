using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Spieler
{
    class Player
    {
        public Vector3 position;
        Model model;
        public Inventar inventar;
        PlayerSteuerung playersteuerung;
        int[,] Säulen_Array = new int[41, 41];

        public Player(Vector3 startposition, Model model, int LevelNummer)
        {
            position = startposition;
            this.model = model;
            inventar = new Inventar();
            playersteuerung = new PlayerSteuerung(LevelNummer, ref Säulen_Array);
        }

        public void Update(GameTime gametime)
        {
            //Steuerung des Spielers
            position = playersteuerung.Update(gametime, position, ref Säulen_Array);
        }

        public void Draw(Matrix view, Matrix projection)
        {
            //Spieler wird sichtbar gemacht
            foreach (ModelMesh mesh in model.Meshes)
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

        public int[,] getSäulenArray()
        {
            return Säulen_Array;
        }
    }
}
