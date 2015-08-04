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
        
        Anschauliche erklärung folgt dann später Anhand von der Minecraft Welt wo die Level "gebaut" werden.
        Ein "gebautes" Level wird dann MANUELL in die untenfolgden Daten übertragen. Die einfach Listen[] werden einfach mit Objekten befüllt.
        Die Wände und Säulen werden in eine 41x41 Matrix übertragen und automatisch erzeugt. Die Anderen Objekte kommen da zur Übersicht mit hinnein, werden aber nicht ausgewertet.
        Die Vector3-Teile sind einfach die Positionen der EINMALIGEN Objekte.
        Beispiel ist in der Klasse Level.cs die erstmal als Test-Level dient.
        
        In die Objekt-Liste kommen dann die Gegenstände für das Level die der Spieler benötigt.


        */

        Model wand_model, loch_model, barriere_model, tür_offen_model, tür_zu_model, säule_model, schalter_model, boden_model;
        int Level_Nummer;
       
        int[,] Level_Array;                                               



        //public Wand[] Wand_List = new Wand[42*42];
        //public Wand_Loch[] Wand_Loch_List = new Wand_Loch[42 * 42];
        //public Säule[] Säule_List = new Säule[42 * 42];            
        //public Boden[] Boden = new Boden[42 * 42];
        //public Barriere[] Barriere_List = new Barriere[42 * 42];
        public int[] Wand_List = new int[42 * 42*2];
        public int[] Loch_List = new int[42 * 42 * 2];
        public int[] Tür_Zu_List = new int[42 * 42 * 2];
        public int[] Tür_Offen_List = new int[42 * 42 * 2];
        public int[] Säule_List = new int[42 * 42 * 2];
        public int[] Schalter_List = new int[42 * 42 * 2];
        public int[] Barriere_List = new int[42 * 42 * 2];
        public int[] Boden_List = new int[42 * 42 * 2];

        //public Schalter[] Schalter_List = new Schalter [41*41];       //TODO
        //public Tür[] Tür_List = new Tür[41 *41];                      //TODO
        //public Truhe[] Truhe_List = new Truhe[41*41];                 //TODO

        public Vector3 Spieler_Startpostion;
        public Vector3 Licht_Start;
        public Vector3 Licht_Richtung;
        public Vector3 Licht_Ziel;

        public int nW = 0;
        public int nWL = 0;
        public int nS = 0;
        public int nB = 0;


        public Level_Loader(int LevelNR) {

            Level_Nummer = LevelNR;

            switch (Level_Nummer) { 
            
                case 0:
                    Level_Array = new Level0().Level_Array;
                    Licht_Start = new Level0().Licht_Start;
                    Licht_Richtung = new Level0().Licht_Richtung;
                    break;

                case 1:
                    Level_Array = new Level1().Level_Array;
                    Licht_Start = new Level1().Licht_Start;
                    Licht_Richtung = new Level1().Licht_Richtung;
                    break;

                case 2:
                    Level_Array = new Level2().Level_Array;
                    Licht_Start = new Level2().Licht_Start;
                    Licht_Richtung = new Level2().Licht_Richtung;
                    break;

                case 3:
                    Level_Array = new Level3().Level_Array;
                    Licht_Start = new Level3().Licht_Start;
                    Licht_Richtung = new Level3().Licht_Richtung;
                    //Barriere_List = new Level3().Barriere_List;
                    break;

                case 4:
                    Level_Array = new Level4().Level_Array;
                    Licht_Start = new Level4().Licht_Start;
                    Licht_Richtung = new Level4().Licht_Richtung;
                    //Barriere_List = new Level4().Barriere_List;
                    break;

                case 5:
                    Level_Array = new Level5().Level_Array;
                    Licht_Start = new Level5().Licht_Start;
                    Licht_Richtung = new Level5().Licht_Richtung;
                    //Barriere_List = new Level5().Barriere_List;
                    break;

                case 6:
                    Level_Array = new Level6().Level_Array;
                    Licht_Start = new Level6().Licht_Start;
                    Licht_Richtung = new Level6().Licht_Richtung;
                    //Barriere_List = new Level6().Barriere_List;
                    break;

                default:
                    Level_Array = new Level0().Level_Array;
                    Licht_Start = new Level0().Licht_Start;
                    Licht_Richtung = new Level0().Licht_Richtung;
                    break;
            }
        }

        public void Array_Loader(ContentManager content)
        {                                  // Geht das ganze Level_Array durch und erzeugt automatisch Wände und Säulen die in die zugehörigen Listen gelegt werden.


            /*    HIER WERDEN DIE MODELLE GEALDEN      */

            wand_model = content.Load<Model>("wand");                           //WAND
            säule_model = content.Load<Model>("saule_platz");                   //SÄULE
            loch_model = content.Load<Model>("saule_mit_loch_platz");           //WAND MIT LOCH
            boden_model = content.Load<Model>("boden");                         //BODEN


            for (int i = 0; i <= 40; i++){
                for (int j = 0; j <= 40; j++){

                    Boden_List[nB] = i;
                    Boden_List[nB+1] = j;
                    nB++;
                    nB++;

                    switch (Level_Array[i, j]) {                

                        case 1:         //Wand                            
                            Wand_List[nW] = i;
                            Wand_List[nW+1] = j;
                            nW++;
                            nW++;
                            break;
                            
                        case 2:         //Wand mit Loch
                            Loch_List[nWL] = i;
                            Loch_List[nWL+1] = j;
                            nWL++;
                            nWL++;
                            break;

                        case 3:         //Säule
                            Säule_List[nS] = i;
                            Säule_List[nS+1] = j;
                            nS++;
                            nS++;
                            break;

                 /*       case 8:         //Lichtstartpunkt
                            Säule_List[nS] = new Säule((float)i , 0, (float)j );
                            nS++;
                            break;

                        case 9:         //Lichtendpunkt
                            Säule_List[nS] = new Säule((float)i , 0, (float)j );
                            nS++;
                            break;   */                     


                        default:

                            continue;
                    
                    
                    }
                }
            }


            Boden_List[nB] = -1;
            Wand_List[nW] = -1;
            Loch_List[nWL] = -1;
            Säule_List[nS] = -1;


        }

        public void Draw(GraphicsDevice graphicdevice, Matrix view, Matrix projection)
        {

            //graphicdevice.Clear(Color.CornflowerBlue);


            int n = 0;
            VertexPositionColor[] vert = new VertexPositionColor[36];

            /*   BODEN   */

            while (this.Boden_List[n] != -1)
            {
                foreach (ModelMesh mesh in boden_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Boden_List[n] + 0.5f, 0.5f, this.Boden_List[n + 1] + 0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;

            /*   WAND   */

            while (this.Wand_List[n] != -1 && n < 41 * 41 * 2)
            {

                foreach (ModelMesh mesh in wand_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f)*Matrix.CreateTranslation(new Vector3(this.Wand_List[n]+0.5f,0.5f,this.Wand_List[n+1]+0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;

            /*   WAND MIT LOCH   */

            while (this.Loch_List[n] != -1 && n < 41 * 41)
            {
                foreach (ModelMesh mesh in loch_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Loch_List[n] + 0.5f, 0.5f, this.Loch_List[n + 1] + 0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;

            /*   SÄULE   */                      

            while (this.Säule_List[n] != -1 && n < 41 * 41)
            {
                foreach (ModelMesh mesh in säule_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Säule_List[n] + 0.5f, 0.5f, this.Säule_List[n + 1] + 0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;

            /*while (this.Barriere_List[n] != null && n < 41 * 41)
            {
                vert = this.Barriere_List[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            }*/


        }


    }
}
