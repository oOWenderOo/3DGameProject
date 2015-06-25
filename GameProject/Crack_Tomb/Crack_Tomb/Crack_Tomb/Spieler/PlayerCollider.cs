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

            return true;
        }
    }
}
