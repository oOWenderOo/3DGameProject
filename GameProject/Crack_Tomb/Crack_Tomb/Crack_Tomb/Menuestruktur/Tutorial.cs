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
        bool isgedrücktT = false;
        bool isgedrücktZ = false;

        public Tutorial(int levelnummer)
        {
            switch (levelnummer)
            {
                case 1:
                    tutorialtext = new string[25];

                    tutorialtext[0] = "Willkommen bei CrackTomb!";
                    tutorialtext[1] = "";
                    tutorialtext[2] = "In diesem Spiel übernimmst ";
                    tutorialtext[3] = "du die Kontrolle über Hans.";
                    tutorialtext[4] = "Hans ist Rentner und kann ";
                    tutorialtext[5] = "seine Miete nicht mehr zahlen,";
                    tutorialtext[6] = "da im die Rente stark gekürzt wurde.";
                    tutorialtext[7] = "Aus diesem Grund entscheidet ";
                    tutorialtext[8] = "er sich, selbst Geld zu verdienen,";
                    tutorialtext[9] = "indem er verlassene Ruinen ";
                    tutorialtext[10] = "löst und die Schätze dort abgreift.";
                    tutorialtext[11] = "In diesem Level lernst du nun ";
                    tutorialtext[12] = "das Grunditem kennen. Den Spiegel.";
                    tutorialtext[13] = "Doch vorher klären wir ";
                    tutorialtext[14] = "was denn getan werden muss.";
                    tutorialtext[15] = "Der Lichtstrahl den du siehst, ";
                    tutorialtext[16] = "musst du ins Ziel führen.";
                    tutorialtext[17] = "Der Spiegel ist dir dabei behilflich, ";
                    tutorialtext[18] = "da du damit das Licht um";
                    tutorialtext[19] = "Ecken lenken kannst. ";
                    tutorialtext[20] = "Probier es aus indem du '1',";
                    tutorialtext[21] = "in der Nähe einer Säule, drückst!";
                    tutorialtext[22] = "";
                    tutorialtext[23] = "";
                    tutorialtext[24] = "";

                    seitenzahl = tutorialtext.Length / 5;
                    break;
                default:
                    tutorialzeichnen = false;
                    break;
            }
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Fonts/TutorialFont");
        }

        public void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.T) && !isgedrücktZ)
            {
                isgedrücktT = true;
            }
            else
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Z) && !isgedrücktT)
                {
                    isgedrücktZ = true;
                }
            }

            if (isgedrücktT && Keyboard.GetState().IsKeyUp(Keys.T))
            {
                isgedrücktT = false;
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
                if (isgedrücktZ && Keyboard.GetState().IsKeyUp(Keys.Z))
                {
                    isgedrücktZ = false;

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

                spritebatch.DrawString(font, "Seite: " + seite + " von " + seitenzahl, new Vector2(0, 70), Color.Black);

                for (int i = anfang; i <= ende; i++)
                {
                    spritebatch.DrawString(font, tutorialtext[i], new Vector2(0, 90 + 13 * (i - anfang)), Color.Black);
                }

                spritebatch.DrawString(font, "<-- Z            T -->", new Vector2(0, 162), Color.Black); // Weiter machen

                spritebatch.End();
            }
        }
    }
}
