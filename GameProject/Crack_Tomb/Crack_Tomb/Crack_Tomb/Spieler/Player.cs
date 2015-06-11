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
        Vector3 position;
        Model model;
        float speed = 1;

        public Player(Vector3 startposition, Model model)
        {
            position = startposition;
            this.model = model;
        }

        public void Update()
        {
            //Steuerung des Spielers
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                position = position + new Vector3(0, speed, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                position = position + new Vector3(0, speed * -1, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                position = position + new Vector3(speed * -1, 0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                position = position + new Vector3(speed, 0, 0);
            }
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
