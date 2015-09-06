using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Menuestruktur
{
    class Tutorial
    {
        public bool spielerLiest = true;

        string[] tutorialtext;
        bool tutorialzeichnen = true;
        SpriteFont font;
        int anfang = 0;
        int ende = 4;
        int seitenzahl;
        int seite = 1;
        bool isgedrücktD = false;
        bool isgedrücktA = false;
        Texture2D tutorialRahmen;
        int tutorialPositionX = 0;
        int tutorialPositionY = 0;

        public Tutorial(int levelnummer)
        {
            switch (levelnummer)
            {
                case 1:
                    tutorialtext = new string[60];

                    //Seite 1        /                            /
                    tutorialtext[0] = "Willkommen bei CrackTomb!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "In diesem Spiel dreht sich";
                    tutorialtext[3] = "alles um Frank. Hans ist ein";
                    tutorialtext[4] = "Rentner, welcher im Krieg";
                    //Seite 2
                    tutorialtext[5] = "gedient hat. Jedoch wurde ihm";
                    tutorialtext[6] = "die Rente stark gekürzt. Er";
                    tutorialtext[7] = "kann sich also kaum noch über";
                    tutorialtext[8] = "Wasser halten. Daher hat er";
                    tutorialtext[9] = "sich dafür entschieden";
                    //Seite 3
                    tutorialtext[10] = "verschollene Grabstätten";
                    tutorialtext[11] = "aufzusuchen und aus diesen";
                    tutorialtext[12] = "Schätze zu bergen.";
                    tutorialtext[13] = "";
                    tutorialtext[14] = "";
                    //Seite 4
                    tutorialtext[15] = "Nun kommt dein Part. Frank";
                    tutorialtext[16] = "ist Rentner und kann einiges";
                    tutorialtext[17] = "nicht mehr allein tun. Daher";
                    tutorialtext[18] = "übernimmst du die Kontrolle";
                    tutorialtext[19] = "über ihn.";
                    //Seite 5
                    tutorialtext[20] = "Steuern kannst du ihn mit";
                    tutorialtext[21] = "den Tasten 'W', 'A', 'S'";
                    tutorialtext[22] = "und 'D'.";
                    tutorialtext[23] = "";
                    tutorialtext[24] = "";
                    //Seite 6
                    tutorialtext[25] = "Alle Grabstätten die Frank";
                    tutorialtext[26] = "aufsucht, haben einen";
                    tutorialtext[27] = "ähnlichen Mechanismus.";
                    tutorialtext[28] = "Um an die Schätze der Grab-";
                    tutorialtext[29] = "stätte zu kommen, muss man";
                    //Seite 7
                    tutorialtext[30] = "einen Lichtstrahl in ein";
                    tutorialtext[31] = "Ziel führen. Hört sich";
                    tutorialtext[32] = "simpler an als es ist,";
                    tutorialtext[33] = "da man Licht nicht einfach";
                    tutorialtext[34] = "um Ecken biegen kann.";
                    //Seite 8
                    tutorialtext[35] = "Hierzu hast du Spiegel in";
                    tutorialtext[36] = "deinem Inventar. Mit '1'";
                    tutorialtext[37] = "kannst du Spiegel in Säulen";
                    tutorialtext[38] = "setzen. Befindet sich in einer";
                    tutorialtext[39] = "Säule bereits ein Spiegel,";
                    //Seite 9
                    tutorialtext[40] = "so kannst du mit '1' den";
                    tutorialtext[41] = "Spiegel rotieren und somit die";
                    tutorialtext[42] = "Abfälschrichtung ändern.";
                    tutorialtext[43] = "Da die Level später größer";
                    tutorialtext[44] = "werden, gibt es eine Hilfe den";
                    //Seite 10
                    tutorialtext[45] = "Überblick nicht zu verlieren.";
                    tutorialtext[46] = "Mit 'M' kannst du dir die";
                    tutorialtext[47] = "Grabstätte von oben ansehen";
                    tutorialtext[48] = "und schauen wo du dich be-";
                    tutorialtext[49] = "findest.";
                    //Seite 11
                    tutorialtext[50] = "Mit 'E' kannst du Objekte";
                    tutorialtext[51] = "aus den Säulen wieder ent-";
                    tutorialtext[52] = "fernen.";
                    tutorialtext[53] = "";
                    tutorialtext[54] = "";
                    //Seite 12
                    tutorialtext[55] = "Eine kleine Information am";
                    tutorialtext[56] = "Rande: Desto schneller das";
                    tutorialtext[57] = "Level gelöst wird, desto mehr";
                    tutorialtext[58] = "Punkte erhälst du am Ende.";
                    tutorialtext[59] = "Lass dir aber nicht zu viel Zeit.";
                    break;
                case 4:
                    tutorialtext = new string[15];

                    //Seite 1        /                            /
                    tutorialtext[0] = "Willkommen zurück!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "Da Frank immer noch nicht";
                    tutorialtext[3] = "genug Gold ergattern konnte,";
                    tutorialtext[4] = "muss er weiter Schätze jagen.";
                    //Seite 2
                    tutorialtext[5] = "Hierzu reicht es nicht mehr";
                    tutorialtext[6] = "lediglich das Licht um Ecken";
                    tutorialtext[7] = "zu lenken. Es gibt auch";
                    tutorialtext[8] = "Löcher in Wänden welche es";
                    tutorialtext[9] = "dir erlauben das Licht durch";
                    //Seite 3
                    tutorialtext[10] = "die Wand zu führen. Versuche";
                    tutorialtext[11] = "es in diesem Level und hilf";
                    tutorialtext[12] = "Frank somit seinen Lebens-";
                    tutorialtext[13] = "unterhalt zu verdienen.";
                    tutorialtext[14] = "";
                    break;
                case 7:
                    tutorialtext = new string[35];

                    //Seite 1        /                            /
                    tutorialtext[0] = "Erneut willkommen!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "Ich denke du merkst, dass";
                    tutorialtext[3] = "Frank mehr Geld braucht als";
                    tutorialtext[4] = "andere Rentner und, dass es";
                    //Seite 2
                    tutorialtext[5] = "immer noch nicht ausreicht.";
                    tutorialtext[6] = "Daher benötigt er weiterhin";
                    tutorialtext[7] = "deine Unterstützung.";
                    tutorialtext[8] = "";
                    tutorialtext[9] = "";
                    //Seite 3
                    tutorialtext[10] = "Wie du dir sicher denkst,";
                    tutorialtext[11] = "gibt es neue Hindernisse.";
                    tutorialtext[12] = "In diesem Level lernen wir";
                    tutorialtext[13] = "die Farbbarrieren kennen.";
                    tutorialtext[14] = "Diese erlauben nur einer";
                    //Seite 4
                    tutorialtext[15] = "bestimmten Lichtfarbe den";
                    tutorialtext[16] = "Durchgang. Die Lichtfarbe";
                    tutorialtext[17] = "kannst du natürlich beein-";
                    tutorialtext[18] = "flussen. Dies ermöglichen";
                    tutorialtext[19] = "dir Farbkristalle.";
                    //Seite 5
                    tutorialtext[20] = "Um ein Farbkristall einzu-";
                    tutorialtext[21] = "setzen, musst du zunächst";
                    tutorialtext[22] = "die Farbkristallauswahl mit";
                    tutorialtext[23] = "'3' öffnen. Danach kannst du";
                    tutorialtext[24] = "mit '1-6' den jeweiligen Farb-";
                    //Seite 6
                    tutorialtext[25] = "kristall auswählen. Mit 'E'";
                    tutorialtext[26] = "schließt du die Farbkristall-";
                    tutorialtext[27] = "auswahl. Bedenke, dass es";
                    tutorialtext[28] = "spezielle Mischverhältnisse";
                    tutorialtext[29] = "gibt. Finde diese heraus";
                    //Seite 7
                    tutorialtext[30] = "und merke sie dir.";
                    tutorialtext[31] = "Versuche nun die Farb-";
                    tutorialtext[32] = "barriere zu überwinden und";
                    tutorialtext[33] = "das Level damit zu lösen.";
                    tutorialtext[34] = "";
                    break;
                case 13:
                    tutorialtext = new string[25];

                    //Seite 1        /                            /
                    tutorialtext[0] = "Hallo!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "Frank hat scheinbar immer noch";
                    tutorialtext[3] = "nicht genug Geld. Nicht wahr?";
                    tutorialtext[4] = "Lassen wir nun das Thema.";
                    //Seite 2
                    tutorialtext[5] = "In diesem Level lernst du";
                    tutorialtext[6] = "zwei neue Spielelemente";
                    tutorialtext[7] = "kennen. Den Schalter und die";
                    tutorialtext[8] = "Tür. Wie du dir sicher";
                    tutorialtext[9] = "denkst, öffnet ein Schalter";
                    //Seite 3
                    tutorialtext[10] = "eine Tür. Da hast du recht.";
                    tutorialtext[11] = "Jedoch reicht es hier den";
                    tutorialtext[12] = "Schalter einmal zu";
                    tutorialtext[13] = "aktivieren und die Tür";
                    tutorialtext[14] = "bleibt dauerhaft geschlossen.";
                    //Seite 4
                    tutorialtext[15] = "Versuche nun die Tür die";
                    tutorialtext[16] = "dir den Weg zum Ziel versperrt";
                    tutorialtext[17] = "mithilfe des Lichts zu öffnen.";
                    tutorialtext[18] = "Denn nur der Lichtstrahl kann";
                    tutorialtext[19] = "den Schalter aktivieren.";
                    //Seite 5
                    tutorialtext[20] = "Unabhängig von dessen Farbe.";
                    tutorialtext[21] = "";
                    tutorialtext[22] = "";
                    tutorialtext[23] = "";
                    tutorialtext[24] = "";
                    break;
                case 18:
                    tutorialtext = new string[25];

                    //Seite 1        /                            /
                    tutorialtext[0] = "Ein letztes mal hallo!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "Da Frank sein Geld scheinbar";
                    tutorialtext[3] = "verschleudert, hilf ihm bis";
                    tutorialtext[4] = "das Spiel beendet ist.";
                    //Seite 2
                    tutorialtext[5] = "In diesem letzten Tutorial";
                    tutorialtext[6] = "möchten wir dir das letzte";
                    tutorialtext[7] = "Item in deinem Inventar";
                    tutorialtext[8] = "näher bringen. Es ist das";
                    tutorialtext[9] = "Splittprisma. Dieses";
                    //Seite 3
                    tutorialtext[10] = "ermöglicht es dir den";
                    tutorialtext[11] = "Lichtstrahl in alle Richt-";
                    tutorialtext[12] = "ungen gleichzeitig abzu-";
                    tutorialtext[13] = "fälschen. Hierzu musst";
                    tutorialtext[14] = "du in der nähe einer";
                    //Seite 4
                    tutorialtext[15] = "Säule '2' drücken.";
                    tutorialtext[16] = "Das Splittprisma soll";
                    tutorialtext[17] = "dir vor allem Zeit sparen.";
                    tutorialtext[18] = "";
                    tutorialtext[19] = "";
                    //Seite 5
                    tutorialtext[20] = "Da dies das letzte Tutorial";
                    tutorialtext[21] = "war, möchten wir dir für";
                    tutorialtext[22] = "die folgenden Level viel";
                    tutorialtext[23] = "Spaß wünschen.";
                    tutorialtext[24] = "";
                    break;
                default:
                    tutorialzeichnen = false;
                    spielerLiest = false;
                    break;
            }

            if(tutorialzeichnen)
                seitenzahl = tutorialtext.Length / 5;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Fonts/TutorialFont");
            tutorialRahmen = content.Load<Texture2D>("2DTexturen/Tutorialrahmen");
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D) && !isgedrücktA)
            {
                isgedrücktD = true;
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.A) && !isgedrücktD)
                {
                    isgedrücktA = true;
                }
            }

            if (isgedrücktD && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                isgedrücktD = false;
                anfang += 5;
                ende += 5;
                seite++;

                if (ende >= tutorialtext.Length)
                {
                    anfang -= 5;
                    ende -= 5;

                    tutorialzeichnen = false;
                    spielerLiest = false;
                }
            }
            else
            {
                if (isgedrücktA && Keyboard.GetState().IsKeyUp(Keys.A))
                {
                    isgedrücktA = false;

                    if (anfang >= 5)
                    {
                        anfang -= 5;
                        ende -= 5;

                        seite--;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spritebatch)
        {
            if (tutorialzeichnen)
            {
                spritebatch.Begin();

                spritebatch.Draw(tutorialRahmen, new Vector2(tutorialPositionX, tutorialPositionY), Color.White);

                spritebatch.DrawString(font, "Seite: " + seite + " von " + seitenzahl, new Vector2(tutorialPositionX + 100, tutorialPositionY + 18), Color.Black);

                for (int i = anfang; i <= ende; i++)
                {
                    spritebatch.DrawString(font, tutorialtext[i], new Vector2(tutorialPositionX + 50, tutorialPositionY + 55 + 14 * (i - anfang)), Color.Black);
                }

                spritebatch.DrawString(font, "<-- A            D -->", new Vector2(tutorialPositionX + 85, tutorialPositionY + 130), Color.Black);

                spritebatch.End();
            }
        }
    }
}
