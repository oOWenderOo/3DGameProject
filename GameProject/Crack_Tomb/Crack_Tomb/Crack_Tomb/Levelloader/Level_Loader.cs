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
        Model b_rot, b_gelb_rot, b_gelb, b_gelb_grün, b_grün, b_cyan_grün, b_cyan, b_cyan_blau, b_blau, b_magenta_blau, b_magenta, b_magenta_rot;
        Model tür_offen, tür_geschlossen, schalter;
        int Level_Nummer;
       
        int[,] Level_Array;                                               



        //public Wand[] Wand_List = new Wand[42*42];
        //public Wand_Loch[] Wand_Loch_List = new Wand_Loch[42 * 42];
        //public Säule[] Säule_List = new Säule[42 * 42];            
        //public Boden[] Boden = new Boden[42 * 42];
        //public Barriere[] Barriere_List = new Barriere[42 * 42];
        public int[] Wand_List = new int[42 * 42*2];
        public int[] Loch_List = new int[42 * 42 * 2];
        public int[] Tür_List = new int[42 * 42 * 2];
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
        public int nBb = 0;
        public int nT = 0;
        public int nSch = 0;


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
                    break;

                case 4:
                    Level_Array = new Level4().Level_Array;
                    Licht_Start = new Level4().Licht_Start;
                    Licht_Richtung = new Level4().Licht_Richtung;
                    break;

                case 5:
                    Level_Array = new Level5().Level_Array;
                    Licht_Start = new Level5().Licht_Start;
                    Licht_Richtung = new Level5().Licht_Richtung;
                    break;

                case 6:
                    Level_Array = new Level6().Level_Array;
                    Licht_Start = new Level6().Licht_Start;
                    Licht_Richtung = new Level6().Licht_Richtung;
                    break;
                case 7:
                    Level_Array = new Level7().Level_Array;
                    Licht_Start = new Level7().Licht_Start;
                    Licht_Richtung = new Level7().Licht_Richtung;
                    break;

                case 8:
                    Level_Array = new Level8().Level_Array;
                    Licht_Start = new Level8().Licht_Start;
                    Licht_Richtung = new Level8().Licht_Richtung;
                    break;

                case 9:
                    Level_Array = new Level9().Level_Array;
                    Licht_Start = new Level9().Licht_Start;
                    Licht_Richtung = new Level9().Licht_Richtung;
                    break;

                case 10:
                    Level_Array = new Level10().Level_Array;
                    Licht_Start = new Level10().Licht_Start;
                    Licht_Richtung = new Level10().Licht_Richtung;
                    break;

                case 11:
                    Level_Array = new Level11().Level_Array;
                    Licht_Start = new Level11().Licht_Start;
                    Licht_Richtung = new Level11().Licht_Richtung;
                    break;

                case 12:
                    Level_Array = new Level12().Level_Array;
                    Licht_Start = new Level12().Licht_Start;
                    Licht_Richtung = new Level12().Licht_Richtung;
                    break;
                case 13:
                    Level_Array = new Level13().Level_Array;
                    Licht_Start = new Level13().Licht_Start;
                    Licht_Richtung = new Level13().Licht_Richtung;
                    break;

                case 14:
                    Level_Array = new Level14().Level_Array;
                    Licht_Start = new Level14().Licht_Start;
                    Licht_Richtung = new Level14().Licht_Richtung;
                    break;

                case 15:
                    Level_Array = new Level15().Level_Array;
                    Licht_Start = new Level15().Licht_Start;
                    Licht_Richtung = new Level15().Licht_Richtung;
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
            b_rot = content.Load<Model>("boden");                               //ROT-BARRIERE
            b_gelb_rot = content.Load<Model>("boden");                          //GELB-ROT-BARRIERE
            b_gelb = content.Load<Model>("boden");                              //GELB-BARRIERE
            b_gelb_grün= content.Load<Model>("boden");                          //GELB-GRÜN-BARRIERE
            b_grün = content.Load<Model>("boden");                              //GRÜN-BARRIERE
            b_cyan_grün = content.Load<Model>("boden");                         //CYAN-GRÜN-BARRIERE
            b_cyan = content.Load<Model>("boden");                              //CYAN-BARRIERE
            b_cyan_blau = content.Load<Model>("boden");                         //CYAN-BLAU-BARRIERE
            b_blau = content.Load<Model>("boden");                              //BLAU-BARRIERE
            b_magenta_blau = content.Load<Model>("boden");                      //MAGENTA-BLAU-BARRIERE
            b_magenta = content.Load<Model>("boden");                           //MAGENTA-BARRIERE
            b_magenta_rot = content.Load<Model>("boden");                       //MAGENTA-ROT-BARRIERE
            tür_geschlossen = content.Load<Model>("boden");                     //OFFENE TÜR
            tür_offen = content.Load<Model>("boden");                           //GESCHLOSSENE TÜR
            schalter = content.Load<Model>("boden");                            //SCHALTER


            for (int i = 0; i <= 40; i++){              //TODO : Implementierung der Zeichung von Türen/Schaltern, da dort noch ein logisches Problem ist...
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

                        case 5000001:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 000001;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5000010:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 000010;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5000100:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 000100;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5001000:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 001000;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5010000:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 010000;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5100000:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 100000;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5100001:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 100001;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5000011:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 000011;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5000110:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 000110;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5001100:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 001100;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5011000:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 011000;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 5110000:
                            Barriere_List[nBb] = i;
                            Barriere_List[nBb + 1] = j;
                            Barriere_List[nBb + 2] = 110000;
                            nBb++;
                            nBb++;
                            nBb++;
                            break;
                        case 71:
                            Tür_List[nT] = i;
                            Tür_List[nT+1] = j;
                            nT++;
                            nT++;
                            break;
                        case 72:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 73:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 74:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 75:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 76:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 77:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 78:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 79:
                            Tür_List[nT] = i;
                            Tür_List[nT + 1] = j;
                            nT++;
                            nT++;
                            break;
                        case 61:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 62:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 63:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 64:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 65:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 66:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 67:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 68:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;
                        case 69:
                            Schalter_List[nSch] = i;
                            Schalter_List[nSch + 1] = j;
                            nSch++;
                            nSch++;
                            break;                           

                        default:

                            continue;
                    
                    
                    }
                }
            }


            Boden_List[nB] = -1;
            Wand_List[nW] = -1;
            Loch_List[nWL] = -1;
            Säule_List[nS] = -1;
            Barriere_List[nBb] = -1;
            Tür_List[nT] = -1;
            Schalter_List[nSch] = -1;


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




            /*   BARRIERE   */

            while (this.Barriere_List[n] != -1 && n < 41 * 41)
            {

                switch (Barriere_List[n+2]){

                    case 000001:

                        foreach (ModelMesh mesh in b_rot.Meshes){
                            foreach (BasicEffect effect in mesh.Effects){
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 000010:

                        foreach (ModelMesh mesh in b_gelb.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 000100:

                        foreach (ModelMesh mesh in b_grün.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 001000:

                        foreach (ModelMesh mesh in b_cyan.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 010000:

                        foreach (ModelMesh mesh in b_blau.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 100000:

                        foreach (ModelMesh mesh in b_magenta.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 100001:

                        foreach (ModelMesh mesh in b_magenta_rot.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 000011:

                        foreach (ModelMesh mesh in b_gelb_rot.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 000110:

                        foreach (ModelMesh mesh in b_gelb_grün.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 001100:

                        foreach (ModelMesh mesh in b_cyan_grün.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 011000:

                        foreach (ModelMesh mesh in b_cyan_blau.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;

                    case 110000:

                        foreach (ModelMesh mesh in b_magenta_blau.Meshes)
                        {
                            foreach (BasicEffect effect in mesh.Effects)
                            {
                                effect.EnableDefaultLighting();
                                effect.View = view;
                                effect.Projection = projection;
                                effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Barriere_List[n] + 0.5f, 0.5f, this.Barriere_List[n + 1] + 0.5f));
                            }
                            mesh.Draw();
                        }
                        n++;
                        n++;
                        n++;
                        break;
                }
            }

            n = 0;


            /*   TÜR   */

            while (this.Tür_List[n] != -1 && n < 41 * 41)
            {
                foreach (ModelMesh mesh in tür_zu_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Tür_List[n] + 0.5f, 0.5f, this.Tür_List[n + 1] + 0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;

            /*   SCHALTER   */

            while (this.Schalter_List[n] != -1 && n < 41 * 41)
            {
                foreach (ModelMesh mesh in schalter_model.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        effect.EnableDefaultLighting();

                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = Matrix.CreateScale(0.5f) * Matrix.CreateTranslation(new Vector3(this.Schalter_List[n] + 0.5f, 0.5f, this.Schalter_List[n + 1] + 0.5f));
                    }
                    mesh.Draw();
                }
                n++;
                n++;
            }

            n = 0;


        }


    }
}
