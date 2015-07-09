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

        public Kamera()
        {
            view = Matrix.CreateLookAt(new Vector3(10.5f, 20, 30f), new Vector3(10.5f, 0, 10), Vector3.UnitY);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
        }
    }
}
