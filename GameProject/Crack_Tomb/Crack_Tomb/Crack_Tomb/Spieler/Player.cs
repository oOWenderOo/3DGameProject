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

        public Player(Vector3 startposition, Model model, int LevelNummer)
        {
            position = startposition;
            this.model = model;
            inventar = new Inventar();
            playersteuerung = new PlayerSteuerung(LevelNummer);
        }

        public void Update()
        {
            //Steuerung des Spielers
            position = playersteuerung.Update(position);
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
    }
}
