using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Crack_Tomb.Spieler
{
    class PlayerCollider
    {
        int[,] Level_Array;
        int arrayposition_x;
        int arrayposition_z;

        public PlayerCollider(int LevelNummer)
        {
            switch (LevelNummer)
            {
                case 0:
                    Level_Array = new Level0().Level_Array;
                    break;
                case 1:
                    Level_Array = new Level1().Level_Array;
                    break;
                default:
                    Level_Array = new Level0().Level_Array;
                    break;
            }
        }

        //Kollisionsabfrage mit Spieler und Umgebung
        public bool IsColliding(Vector3 currentposition, Vector3 newposition)
        {
            arrayposition_x = (int)currentposition.X;
            arrayposition_z = (int)currentposition.Z;

            if (arrayposition_x != (int)newposition.X || arrayposition_z != (int)newposition.Z)
            {
                int objectAtnew = Level_Array[(int)newposition.X, (int)newposition.Z];

                switch (objectAtnew)
                {
                    case 0:
                        return false;
                        break;
                    case 1:
                        return true;
                        break;
                    case 2:
                        return true;
                        break;
                    case 3:
                        return true;
                        break;
                    default:
                        return false;
                        break;
                }
            }

            return false;
        }
    }
}
