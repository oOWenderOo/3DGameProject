using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Crack_Tomb{

    public class Truhe{

        //TODO: Drag-Drop Mechanik für Items
        //Textur bzw. Modell
        //Truhen-Ineventar

        //Konsturktor und Zeichner wird auf Modell angepasst werden müssen


        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 0.1f;
        float SizeY = 0.1f;
        float SizeZ = 0.1f;

        Spieler_Obejkte[] Items;


        public Truhe(float h_PosX, float h_PosY, float h_PosZ)
        {

            PosX = h_PosX;
            PosY = h_PosY;
            PosZ = h_PosZ;

        }



        
    }
}
