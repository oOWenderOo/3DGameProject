using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Spieler
{
    class PlayerSteuerung
    {
        Vector3 newposition;
        PlayerCollider playercollider;
        public float speed = 1;

        public PlayerSteuerung(int LevelNummer)
        {
            playercollider = new PlayerCollider(LevelNummer);
        }

        public Vector3 Update(Vector3 playerposition) 
        {
            //Bestimmung der neuen Position bei bestimmter Eingabe des Spielers
            if (Keyboard.GetState().IsKeyDown(Keys.W) || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                newposition = playerposition + new Vector3(0, speed, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.S) || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                newposition = playerposition + new Vector3(0, speed * -1, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A) || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                newposition = playerposition + new Vector3(speed * -1, 0, 0);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                newposition = playerposition + new Vector3(speed, 0, 0);
            }

            //Kollisionsprüfung
            if (!playercollider.IsColliding(playerposition, newposition))
            {
                return newposition;
            }
            else
            {
                return playerposition;
            }
        }
    }
}
