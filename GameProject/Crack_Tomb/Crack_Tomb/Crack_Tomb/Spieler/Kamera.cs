using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Spieler
{
    class Kamera
    {
        public Matrix view;
        public Matrix projection;
        public Vector3 playerposition;

        public Kamera(Vector3 playerposition)
        {
            this.playerposition = playerposition;
            view = Matrix.CreateLookAt(new Vector3(10.5f, 20, 30f), playerposition, Vector3.UnitY);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
        }

        public void Update(Vector3 playerposition)
        {
            view = Matrix.CreateLookAt(playerposition + new Vector3(0, 10, 10), playerposition, Vector3.UnitY);
        }
    }
}
