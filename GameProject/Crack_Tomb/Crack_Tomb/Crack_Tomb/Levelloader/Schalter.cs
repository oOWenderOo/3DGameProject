using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crack_Tomb{

    class Schalter {



        //Implementierung so wie bei den anderen Objekten, Konsturktor/Zeichenfunktion je nach späterem Aussehen

        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 1.0f;
        float SizeY = 1.0f;
        float SizeZ = 1.0f;

        public int ID;

        public int Richtung;           // 0 = --    1 = |   2,3  = andere Seite
        public int status;               // 0 = deaktiviert,  1 = aktiviert

        public int[] doors;

        //Implementierung so wie bei den anderen Objekten, Konsturktor/Zeichenfunktion je nach späterem Aussehen
        //Verbindungswert mit den Schaltern

        public Schalter(float hPosX, float hPosY, float hPosZ, int dir, int IDn, int[] hdoors){
        
            PosX = hPosX;
            PosY = hPosY;
            PosZ = hPosZ;
            Richtung = dir;
            ID = IDn;
            status = 0;
            doors = hdoors;
        }

    }
}
