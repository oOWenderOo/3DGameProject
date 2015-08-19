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
        int arrayposition_y;

        public PlayerCollider(int LevelNummer, ref int[,] Säulen_Array)
        {
            switch (LevelNummer)
            {
                case 1:
                    Level_Array = new Level1().Level_Array;
                    break;
                case 2:
                    Level_Array = new Level2().Level_Array;
                    break;
                case 3:
                    Level_Array = new Level3().Level_Array;
                    break;
                case 4:
                    Level_Array = new Level4().Level_Array;
                    break;
                case 5:
                    Level_Array = new Level5().Level_Array;
                    break;
                case 6:
                    Level_Array = new Level6().Level_Array;
                    break;
                case 7:
                    Level_Array = new Level7().Level_Array;
                    break;
                case 8:
                    Level_Array = new Level8().Level_Array;
                    break;
                case 9:
                    Level_Array = new Level9().Level_Array;
                    break;
                default:
                    Level_Array = new Level0().Level_Array;
                    break;
            }

            for (int i = 0; i < 41; i++)
            {
                for (int j = 0; j < 41; j++)
                {
                    if (Level_Array[i, j] == 3)
                    {
                        Säulen_Array[i, j] = 1;
                    }
                    else
                    {
                        Säulen_Array[i, j] = 0;
                    }
                }
            }
        }

        //Kollisionsabfrage mit Spieler und Umgebung
        public bool IsColliding(Vector3 currentposition, Vector3 newposition)
        {
            arrayposition_x = (int)Math.Floor(currentposition.X);
            arrayposition_y = (int)Math.Floor(currentposition.Z);

            if (arrayposition_x != (int)Math.Floor(newposition.X) || arrayposition_y != (int)Math.Floor(newposition.Z))
            {
                int objectAtnew = Level_Array[(int)Math.Floor(newposition.X), (int)Math.Floor(newposition.Z)];

                switch (objectAtnew)
                {
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
