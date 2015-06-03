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

    public class Level_Loader{

        /*

        Allgemein: Jedes Level wird eine Grundfläche von 10x10 "Blöcken" haben. JEDER Block hat 5x5 Felder (0.2 in float Wert pro Feld), davon sind 3x3 die "innere Fläche". 
        Die Äußeren Felder sind die "Wandfläche". Auf diesen werden Wände, Turen, Barrieren plaziert. Die Wandfläche eines Blocks ist GLEICHZEIT die wandfläche des benachbarten Blockes.
        Säulen sind immer im Zentrum des 5x5 Blockes. Truhen Immer im "Mittleren Ring", dasseble gilt für Schalter und (Leitern), welche immer an einer Wand sein Müssen.
        Daraus folgt eine 41x41 Fläche von Feldern, pro Ebene jedes Levels.
        
        Wenn wir später mehrere Ebenen pro Level machen wollen, wird das ganze einfach um eine Y-Achse erweitert, was aber nicht wirklich was ändert.
        
        Anschauliche erklärung folgt dann später Anhand von der Minecraft Weld wo die Level "gebaut" werden.
        Ein "gebautes" Level wird dann MANUELL in die untenfolgden Daten übertragen. Die einfach Listen[] werden einfach mit Objekten befüllt.
        Die Wände und Säulen werden in eine 41x41 Matrix übertragen und automatisch erzeugt. Die Anderen Objekte kommen da zur Übersicht mit hinnein, werden aber nicht ausgewertet.
        Die Vector3-Teile sind einfach die Positionen der EINMALIGEN Objekte.
        Beispiel ist in der Klasse Level.cs die erstmal als Test-Level dient.
        
        In die Objekt-Liste kommen dann die Gegenstände für das Level die der Spieler benötigt.


        */


        int Level_Nummer;
       
        int[,] Level_Array;                                               //wird zu Int[,][] wenn mehrere Ebenen implementier werden
        //public Schalter[] Schalter_List = new Schalter [41*41];
        //public Tür[] Tür_List = new Tür[41 *41];
        //public Barriere[] Barriere_List = new Barriere[41 * 41];
        public Truhe[] Truhe_List = new Truhe[41*41];
        //public Leiter[]

        public Wand[] Wand_List = new Wand[41*41];
        public Wand_Loch[] Wand_Loch_List = new Wand_Loch[41 * 41];
        public Säule[] Säule_List = new Säule[41 * 41];            //Leiter optional
        public Boden[] boden = new Boden[42 * 42];

        public Vector3 Spieler_Startpostion;
        public Vector3 Licht_Start;
        public Vector3 Licht_Ziel;

        public Level level;

        //public Level_Objekt[] level_objekte = new Level_Objekt[41*41];
        public int nW = 0;
        public int nWL = 0;
        public int nS = 0;
        public int nB = 0;

        public Level_Loader(Level h_level) {
            level = h_level;
            //get_Level_Nummer();
        }

        public void Array_Loader(Level level){                                  // Geht das ganze Level_Array durch und erzeugt automatisch Wände und Säulen die in den Level_Objekt_Container gelegt werden.

            for (int i = 0; i <= 40; i++){
                for (int j = 0; j <= 40; j++){

                    boden[nB] = new Boden((float)i / 5, 0, (float)j / 5);
                    nB++;

                    switch (level.Level_Array[i, j]) {                

                        case 1:
                            Wand_List[nW] = new Wand((float) i / 5, 0, (float) j / 5);
                            nW++;
                            break;
                            
                        case 2:
                            Wand_Loch_List[nWL] = new Wand_Loch((float)i / 5, 0, (float)j / 5);
                            nWL++;
                            break;

                        case 3:
                            Säule_List[nS] = new Säule((float)i / 5, 0, (float)j / 5);
                            nS++;
                            break;

                        default:

                            continue;
                    
                    
                    }
                }
            }
        }
        



    }
}
