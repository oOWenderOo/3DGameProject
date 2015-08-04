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

    public class Säule{ 

        float PosX;
        float PosY;
        float PosZ;

        float SizeX = 1.0f;     //Größen für Säulen müssen noch angepasst werden. Eventuell auch mit richtigem 3D-Objekt statt Textur
        float SizeY = 1.0f;
        float SizeZ = 1.0f;

        int ID;

        bool Locked;                                                                    //Feste Säule, also Säule die von anfang an 1 Objekt hat welches auch nicht verändert werden kann
                                                                                        //Feste Säulen werden NICHT über das Level_Array erstellt sondern manuell über die Level_Liste.

        Spieler_Obejkte Spieler_Objekt;                                                 //Objekt das aktuell in der Säule ist.

        int Objekt_Richtung;                                                            //Ausrichtung des Objektes. Genaue Funktionsweise unklar.




        public Säule(float h_PosX, float h_PosY, float h_PosZ)
        {

            PosX = h_PosX;
            PosY = h_PosY;
            PosZ = h_PosZ;

        }

    }
}
