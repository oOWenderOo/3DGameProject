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

    class Tür{

        //Implementierung so wie bei den anderen Objekten, Konsturktor/Zeichenfunktion je nach späterem Aussehen

        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 1.0f;
        float SizeY = 1.0f;
        float SizeZ = 1.0f;

        public int ID;

        public int Richtung;           // 0 = --    1 = | 
        public int Open;               // 0 = geschlosse,  1 = offen

        //Implementierung so wie bei den anderen Objekten, Konsturktor/Zeichenfunktion je nach späterem Aussehen
        //Verbindungswert mit den Schaltern

        public Tür(float hPosX, float hPosY, float hPosZ, int dir, int IDn, int open){
        
            PosX = hPosX;
            PosY = hPosY;
            PosZ = hPosZ;
            Richtung = dir;
            ID = IDn;
            Open = open;
        }

    }
}
