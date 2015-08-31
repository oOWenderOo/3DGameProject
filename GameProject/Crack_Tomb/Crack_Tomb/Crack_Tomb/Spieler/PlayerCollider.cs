using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Crack_Tomb.Levelloader;

namespace Crack_Tomb.Spieler
{
    class PlayerCollider
    {
        int arrayposition_x;
        int arrayposition_y;

        public PlayerCollider()
        {}

        //Kollisionsabfrage mit Spieler und Umgebung
        public bool IsColliding(Vector3 currentposition, Vector3 newposition, ref Level_LoaderV2 levelloader)
        {
            arrayposition_x = (int)Math.Floor(currentposition.X);
            arrayposition_y = (int)Math.Floor(currentposition.Z);

            if (arrayposition_x != (int)Math.Floor(newposition.X) || arrayposition_y != (int)Math.Floor(newposition.Z))
            {
                int objectAtnew = levelloader.Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)];

                switch (objectAtnew)
                {
                    case 1:
                        return true;
                    case 10:
                        return true;
                    case 11:
                        return true;
                    case 12:
                        return true;
                    case 13:
                        return true;
                    case 14:
                        return true;
                    case 15:
                        return true;
                    case 16:
                        return true;
                    case 17:
                        return true;
                    case 18:
                        return true;
                    case 19:
                        return true;
                    case 2:
                        return true;
                    case 3:
                        return true;
                    case 70:
                        return true;
                    case 9:
                        return true;
                    default:
                        return false;
                }
            }

            return false;
        }
    }
}
