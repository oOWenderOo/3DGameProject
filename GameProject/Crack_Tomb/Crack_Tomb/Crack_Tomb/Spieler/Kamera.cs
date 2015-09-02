using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Spieler
{
    class Kamera
    {
        public Matrix view;
        public Matrix projection;
        Vector3 playerposition;
        bool isgedrücktM = false;
        bool mapActive = false;
        Vector3 mapPosition = new Vector3(20.5f, 50, 20.5f);

        public Kamera(Vector3 playerposition)
        {
            this.playerposition = playerposition;
            view = Matrix.CreateLookAt(new Vector3(10.5f, 20, 30f), playerposition, Vector3.UnitY);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
        }

        public void Update(Vector3 playerposition)
        {
            if (!mapActive)
            {
                view = Matrix.CreateLookAt(playerposition + new Vector3(0, 5, 5), playerposition, Vector3.UnitY);

                if (Keyboard.GetState().IsKeyDown(Keys.M) && !isgedrücktM)
                {
                    isgedrücktM = true;
                }

                if (isgedrücktM && Keyboard.GetState().IsKeyUp(Keys.M))
                {
                    isgedrücktM = false;
                    mapActive = true;
                }
            }
            else
            {
                view = Matrix.CreateLookAt(mapPosition, new Vector3(20.5f, 0, 20.5f), Vector3.UnitZ * -1);

                if (Keyboard.GetState().IsKeyDown(Keys.M) && !isgedrücktM)
                {
                    isgedrücktM = true;
                }

                if (isgedrücktM && Keyboard.GetState().IsKeyUp(Keys.M))
                {
                    isgedrücktM = false;
                    mapActive = false;
                }
            }
        }

        public bool getMapActive()
        {
            return mapActive;
        }
    }
}
