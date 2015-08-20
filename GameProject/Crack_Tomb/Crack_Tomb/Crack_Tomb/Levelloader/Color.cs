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

    public class MyColor{

        public int mycolor;              //6-bit Wert
        public Color color;                //XNA-Farbe

        public MyColor(int hcolor) {
            mycolor = hcolor;
            if (mycolor == 000000) color = Color.White;              //White
            else if (mycolor == 000001) color = new Color(1f, 0f, 0f);         //Red
            else if (mycolor == 000010) color = new Color(1f, 1f, 0f);         //Yellow
            else if (mycolor == 000100) color = new Color(0f, 1f, 0f);         //Green
            else if (mycolor == 001000) color = new Color(0f, 1f, 1f);         //Cyan
            else if (mycolor == 010000) color = new Color(0f, 0f, 1f);         //Blue
            else if (mycolor == 100000) color = new Color(1f, 0f, 1f);         //Magenta
            else if (mycolor == 000011) color = new Color(1f, 0.5f, 0f);      //Red-Yellow
            else if (mycolor == 000110) color = new Color(0.5f, 1f, 0f);      //Green-Yellow
            else if (mycolor == 001100) color = new Color(0f, 1f, 0.5f);      //Green-Cyan
            else if (mycolor == 011000) color = new Color(0f, 0.5f, 1f);      //Blue-Cyan
            else if (mycolor == 110000) color = new Color(0.5f, 0f, 1f);      //Blue-Magenta
            else if (mycolor == 100001) color = new Color(1f, 0f, 0.5f);      //Red-Magenta
            else color = new Color(1, 1, 1);                                //Black
        }

        public int mixColor(MyColor RayColor, MyColor ObjectColor){               //RayColor kann 12 Farbwerte + Schwarz/Weiss annehmen, Objectcolor nur 6 + S/W  (da es nur 6 farbige Kristalle gibt)
                                                                                    //Klasse für Mischung von Lichtstrahfarbe und KristallFarbe. 
                                                                                    //Vergleich für die Lichtbarrieren und Schalter erfolgt über direkten Vergleich der jeweiligen "X.Mycolor.mycolor" Werte
            int newColor = 000000;

            //Alle Mischmöglichkeiten... 5 verschiedene Abstandsfälle

            //Komplementärfarbenmischfälle  (6 Abstand)  ---> Farbe wird weiss
            if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 001000) newColor = 000000;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 010000) newColor = 000000;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 100000) newColor = 000000;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 000001) newColor = 000000;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 000010) newColor = 000000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 000100) newColor = 000000;

            //Mischung von 2 Farben mit 2 Abstand

            else if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 000010) newColor = 000011;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 000100) newColor = 000110;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 001000) newColor = 001100;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 010000) newColor = 011000;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 100000) newColor = 110000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 000001) newColor = 100001;
            else if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 100000) newColor = 100001;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 000001) newColor = 000011;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 000010) newColor = 000110;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 000100) newColor = 001100;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 001000) newColor = 011000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 010000) newColor = 110000;

            //Mischung bei Farben mit 0 Abstand --> Farbe bleibt gleich

            else if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 000001) newColor = 000001;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 000010) newColor = 000010;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 000100) newColor = 000100;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 001000) newColor = 001000;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 010000) newColor = 010000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 100000) newColor = 100000;

            //Mischung bei Farben mit 1 Abstand --> Grundfarbe gewinnt

            else if (ObjectColor.mycolor == 000001 && RayColor.mycolor == 100001) newColor = 000001;
            else if (ObjectColor.mycolor == 000001 && RayColor.mycolor == 000011) newColor = 000001;
            else if (ObjectColor.mycolor == 000010 && RayColor.mycolor == 000011) newColor = 000010;
            else if (ObjectColor.mycolor == 000010 && RayColor.mycolor == 000110) newColor = 000010;
            else if (ObjectColor.mycolor == 000100 && RayColor.mycolor == 000110) newColor = 000100;
            else if (ObjectColor.mycolor == 000100 && RayColor.mycolor == 001100) newColor = 000100;
            else if (ObjectColor.mycolor == 001000 && RayColor.mycolor == 001100) newColor = 001000;
            else if (ObjectColor.mycolor == 001000 && RayColor.mycolor == 011000) newColor = 001000;
            else if (ObjectColor.mycolor == 010000 && RayColor.mycolor == 011000) newColor = 010000;
            else if (ObjectColor.mycolor == 010000 && RayColor.mycolor == 110000) newColor = 010000;
            else if (ObjectColor.mycolor == 100000 && RayColor.mycolor == 110000) newColor = 100000;
            else if (ObjectColor.mycolor == 100000 && RayColor.mycolor == 100001) newColor = 100000;

            //Mischung bei Farben mit 4 Abstand

            else if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 000100) newColor = 000010;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 001000) newColor = 000100;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 010000) newColor = 001000;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 100000) newColor = 010000;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 000001) newColor = 100000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 000010) newColor = 000001;
            else if (RayColor.mycolor == 000001 && ObjectColor.mycolor == 010000) newColor = 100000;
            else if (RayColor.mycolor == 000010 && ObjectColor.mycolor == 100000) newColor = 000001;
            else if (RayColor.mycolor == 000100 && ObjectColor.mycolor == 000001) newColor = 000010;
            else if (RayColor.mycolor == 001000 && ObjectColor.mycolor == 000010) newColor = 000100;
            else if (RayColor.mycolor == 010000 && ObjectColor.mycolor == 000100) newColor = 001000;
            else if (RayColor.mycolor == 100000 && ObjectColor.mycolor == 001000) newColor = 010000;

            //Mischung bei Farben mit 3 Abstand

            else if (RayColor.mycolor == 000110 && ObjectColor.mycolor == 000001) newColor = 000011;
            else if (RayColor.mycolor == 110000 && ObjectColor.mycolor == 000001) newColor = 100001;
            else if (RayColor.mycolor == 001100 && ObjectColor.mycolor == 000010) newColor = 000110;
            else if (RayColor.mycolor == 100001 && ObjectColor.mycolor == 000010) newColor = 000011;
            else if (RayColor.mycolor == 011000 && ObjectColor.mycolor == 000100) newColor = 001100;
            else if (RayColor.mycolor == 000011 && ObjectColor.mycolor == 000100) newColor = 000110;
            else if (RayColor.mycolor == 110000 && ObjectColor.mycolor == 001000) newColor = 011000;
            else if (RayColor.mycolor == 000110 && ObjectColor.mycolor == 001000) newColor = 001100;
            else if (RayColor.mycolor == 100001 && ObjectColor.mycolor == 010000) newColor = 110000;
            else if (RayColor.mycolor == 001100 && ObjectColor.mycolor == 010000) newColor = 011000;
            else if (RayColor.mycolor == 000011 && ObjectColor.mycolor == 100000) newColor = 100001;
            else if (RayColor.mycolor == 011000 && ObjectColor.mycolor == 100000) newColor = 110000;

            //Mischung bei Farben mit 5 Abstand

            else if (RayColor.mycolor == 001100 && ObjectColor.mycolor == 000001) newColor = 000010;
            else if (RayColor.mycolor == 011000 && ObjectColor.mycolor == 000001) newColor = 100000;
            else if (RayColor.mycolor == 011000 && ObjectColor.mycolor == 000010) newColor = 000100;
            else if (RayColor.mycolor == 110000 && ObjectColor.mycolor == 000010) newColor = 000001;
            else if (RayColor.mycolor == 110000 && ObjectColor.mycolor == 000100) newColor = 001000;
            else if (RayColor.mycolor == 100001 && ObjectColor.mycolor == 000100) newColor = 000010;
            else if (RayColor.mycolor == 100001 && ObjectColor.mycolor == 001000) newColor = 010000;
            else if (RayColor.mycolor == 000011 && ObjectColor.mycolor == 001000) newColor = 000100;
            else if (RayColor.mycolor == 000011 && ObjectColor.mycolor == 010000) newColor = 100000;
            else if (RayColor.mycolor == 000110 && ObjectColor.mycolor == 010000) newColor = 001000;
            else if (RayColor.mycolor == 000110 && ObjectColor.mycolor == 100000) newColor = 000001;
            else if (RayColor.mycolor == 001100 && ObjectColor.mycolor == 100000) newColor = 010000;

            //Mischung mit Weiss-Kristall und Schwarz-Kristall                  [Optionales Feature] Weisser Kristall färbt JEDES Licht das durch ihn geht Weiss. Schwarzer Kristall färbt JEDER Licht das duch ihn geht schwarz. Schwarzes Licht geht durch ALLES AUßER den Weissen Kristall der es wieder weiss macht.

            else if (ObjectColor.mycolor == 111111) newColor = 111111;
            else newColor = 000000;

            return newColor;
        }
    }
}
