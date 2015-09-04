using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainMenuCo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Crack_Tomb.Menuestruktur
{
    class Gewonnen : GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons;
        Texture2D mouse;
        Texture2D background;
        Texture2D ranglisteHalterung;
        int levelnummer;
        int punkte;
        int anzahlLevel;
        string[] rangliste = new string[10];
        int[] ranglistePunkte = new int[10];
        int position = 0; //in der Rangliste
        bool musseintragen = false;
        string EingabeName = "Hallo";
        int ranglistePositionX = 460;
        int ranglistePosiitonY = 60;

        bool isGedrücktA = false,
             isGedrücktÄ = false,
             isGedrücktB = false,
             isGedrücktC = false,
             isGedrücktD = false,
             isGedrücktE = false,
             isGedrücktF = false,
             isGedrücktG = false,
             isGedrücktH = false,
             isGedrücktI = false,
             isGedrücktJ = false,
             isGedrücktK = false,
             isGedrücktL = false,
             isGedrücktM = false,
             isGedrücktN = false,
             isGedrücktO = false,
             isGedrücktÖ = false,
             isGedrücktP = false,
             isGedrücktQ = false,
             isGedrücktR = false,
             isGedrücktS = false,
             isGedrücktT = false,
             isGedrücktU = false,
             isGedrücktÜ = false,
             isGedrücktV = false,
             isGedrücktW = false,
             isGedrücktX = false,
             isGedrücktY = false,
             isGedrücktZ = false,
             isGedrücktUmschalt = false,
             isGedrücktBack = false,
             isGedrücktSpace = false;

        public Gewonnen() { }

        public Gewonnen(int levelnummer, int punkte, int anzahllevel)
        {
            this.anzahlLevel = anzahllevel;
            this.levelnummer = levelnummer;
            this.punkte = punkte;

            if (levelnummer < anzahlLevel)
            {
                buttons = new Button[3];

                buttons[0] = new Button(new Vector2(540, 370), "MainMenu", "Zurück ins Menü");
                buttons[1] = new Button(new Vector2(300, 370), "InGame", "Level erneut starten");
                buttons[2] = new Button(new Vector2(60, 370), "InGame", "Nächstes Level");
            }
            else
            {
                buttons = new Button[2];

                buttons[0] = new Button(new Vector2(540, 370), "MainMenu", "Zurück ins Menü");
                buttons[1] = new Button(new Vector2(300, 370), "InGame", "Level erneut starten");
            }
            int counter = 0;
            string line;
            string dateiname = "Level" + levelnummer + ".txt";

            System.IO.StreamReader file = new System.IO.StreamReader(@dateiname);

            while ((line = file.ReadLine()) != null)
            {
                if (counter != 0)
                {
                    rangliste[counter - 1] = line;
                }

                counter++;
            }

            file.Close();

            for (int i = 0; i < rangliste.Length; i++)
            {
                for (int j = rangliste[i].Length - 1; j >= 0; j--)
                {
                    if (rangliste[i].ElementAt<char>(j) == ' ')
                    {
                        ranglistePunkte[i] = Convert.ToInt32(rangliste[i].Substring(j + 1));
                        break;
                    }
                }
            }

            for (int i = 0; i < ranglistePunkte.Length; i++)
            {
                if (ranglistePunkte[i] >= punkte)
                {
                    position++;
                }
                else
                {
                    break;
                }
            }

            for (int i = rangliste.Length - 1; i > position; i--)
            {
                rangliste[i] = rangliste[i - 1];
            }

            if (position < rangliste.Length)
            {
                rangliste[position] = "";
                musseintragen = true;
            }

            if (levelnummer < anzahllevel)
            {
                string[] levelfrei = new string[11];
                levelfrei[0] = "true";
                string dateiname2 = "Level" + (levelnummer + 1) + ".txt";
                counter = 0;

                System.IO.StreamReader file2 = new System.IO.StreamReader(@dateiname2);

                while ((line = file2.ReadLine()) != null)
                {
                    if (counter != 0)
                    {
                        levelfrei[counter] = line;
                    }

                    counter++;
                }

                file2.Close();

                System.IO.File.WriteAllLines(@dateiname2, levelfrei);
            }
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            fontButton = content.Load<SpriteFont>("Fonts/Button");
            fontText = content.Load<SpriteFont>("Fonts/Normal");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("2DTexturen/button"));
                buttons[i].SetFont(fontButton);
            }
            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
            ranglisteHalterung = content.Load<Texture2D>("2DTexturen/Rangliste");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (musseintragen)
            {
                if (isGedrücktBack == false && Keyboard.GetState().IsKeyDown(Keys.Back) && EingabeName.Length > 0)
                {
                    isGedrücktBack = true;
                }

                if (EingabeName.Length <= 25)
                {
                    eingabeKontrolle();
                }

                if (isGedrücktBack == true && Keyboard.GetState().IsKeyUp(Keys.Back))
                {
                    isGedrücktBack = false;
                    EingabeName = EingabeName.Substring(0, EingabeName.Length - 1);
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Enter) && EingabeName.Length > 0)
                {
                    string dateiname = "Level" + levelnummer + ".txt";

                    rangliste[position] = EingabeName + " " + punkte;

                    string[] neurangliste = new string[11];

                    for (int i = 0; i < neurangliste.Length; i++)
                    {
                        if (i == 0)
                        {
                            neurangliste[i] = "true";
                        }
                        else
                        {
                            neurangliste[i] = rangliste[i - 1];
                        }
                    }

                    System.IO.File.WriteAllLines(@dateiname, neurangliste);

                    musseintragen = false;
                }
            }
            else
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    if (buttons[i].isPressed())
                    {
                        if (i == 2)
                        {
                            return buttons[i].GetState(levelnummer + 1, anzahlLevel);
                        }
                        else
                        {
                            return buttons[i].GetState(levelnummer, anzahlLevel);
                        }
                    }
                }
            }

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Du hast gewonnen!", new Vector2(300, 100), Color.Green);

            SpriteBatch.Draw(ranglisteHalterung, new Vector2(300, 0), Color.White);

            if (!musseintragen)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Draw(gameTime, Graphics, SpriteBatch);
                }
            }
            
            for (int i = 0; i < rangliste.Length; i++)
            {
                SpriteBatch.DrawString(fontText, (i + 1) + ".", new Vector2(ranglistePositionX - 80, ranglistePosiitonY + 60 + 30 * i), Color.Black);

                if (rangliste[i] != "")
                {
                    SpriteBatch.DrawString(fontText, rangliste[i], new Vector2(ranglistePositionX - 30, ranglistePosiitonY + 60 + 30 * i), Color.Black);
                }
            }

            if (musseintragen)
            {
                if (((int)gameTime.TotalGameTime.Milliseconds) % 800 >= 0 && ((int)gameTime.TotalGameTime.Milliseconds) % 800 <= 400)
                {
                    SpriteBatch.DrawString(fontText, EingabeName, new Vector2(ranglistePositionX - 30, ranglistePosiitonY + 60 + 30 * position), Color.Red);
                }
                else
                {
                    SpriteBatch.DrawString(fontText, EingabeName + "_", new Vector2(ranglistePositionX - 30, ranglistePosiitonY + 60 + 30 * position), Color.Red);
                }
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

        private void eingabeKontrolle()
        {
            //Was passiert, wenn eine Taste gedrückt wird?
            if (isGedrücktA == false && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isGedrücktA = true;
            }

            if (isGedrücktÄ == false && Keyboard.GetState().IsKeyDown(Keys.OemQuotes))
            {
                isGedrücktÄ = true;
            }

            if (isGedrücktB == false && Keyboard.GetState().IsKeyDown(Keys.B))
            {
                isGedrücktB = true;
            }

            if (isGedrücktC == false && Keyboard.GetState().IsKeyDown(Keys.C))
            {
                isGedrücktC = true;
            }

            if (isGedrücktD == false && Keyboard.GetState().IsKeyDown(Keys.D))
            {
                isGedrücktD = true;
            }

            if (isGedrücktE == false && Keyboard.GetState().IsKeyDown(Keys.E))
            {
                isGedrücktE = true;
            }

            if (isGedrücktF == false && Keyboard.GetState().IsKeyDown(Keys.F))
            {
                isGedrücktF = true;
            }

            if (isGedrücktG == false && Keyboard.GetState().IsKeyDown(Keys.G))
            {
                isGedrücktG = true;
            }

            if (isGedrücktH == false && Keyboard.GetState().IsKeyDown(Keys.H))
            {
                isGedrücktH = true;
            }

            if (isGedrücktI == false && Keyboard.GetState().IsKeyDown(Keys.I))
            {
                isGedrücktI = true;
            }

            if (isGedrücktJ == false && Keyboard.GetState().IsKeyDown(Keys.J))
            {
                isGedrücktJ = true;
            }

            if (isGedrücktK == false && Keyboard.GetState().IsKeyDown(Keys.K))
            {
                isGedrücktK = true;
            }

            if (isGedrücktL == false && Keyboard.GetState().IsKeyDown(Keys.L))
            {
                isGedrücktL = true;
            }

            if (isGedrücktM == false && Keyboard.GetState().IsKeyDown(Keys.M))
            {
                isGedrücktM = true;
            }

            if (isGedrücktN == false && Keyboard.GetState().IsKeyDown(Keys.N))
            {
                isGedrücktN = true;
            }

            if (isGedrücktO == false && Keyboard.GetState().IsKeyDown(Keys.O))
            {
                isGedrücktO = true;
            }

            if (isGedrücktÖ == false && Keyboard.GetState().IsKeyDown(Keys.OemTilde))
            {
                isGedrücktÖ = true;
            }

            if (isGedrücktP == false && Keyboard.GetState().IsKeyDown(Keys.P))
            {
                isGedrücktP = true;
            }

            if (isGedrücktQ == false && Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                isGedrücktQ = true;
            }

            if (isGedrücktR == false && Keyboard.GetState().IsKeyDown(Keys.R))
            {
                isGedrücktR = true;
            }

            if (isGedrücktS == false && Keyboard.GetState().IsKeyDown(Keys.S))
            {
                isGedrücktS = true;
            }

            if (isGedrücktT == false && Keyboard.GetState().IsKeyDown(Keys.T))
            {
                isGedrücktT = true;
            }

            if (isGedrücktU == false && Keyboard.GetState().IsKeyDown(Keys.U))
            {
                isGedrücktU = true;
            }

            if (isGedrücktÜ == false && Keyboard.GetState().IsKeyDown(Keys.OemSemicolon))
            {
                isGedrücktÜ = true;
            }

            if (isGedrücktV == false && Keyboard.GetState().IsKeyDown(Keys.V))
            {
                isGedrücktV = true;
            }

            if (isGedrücktW == false && Keyboard.GetState().IsKeyDown(Keys.W))
            {
                isGedrücktW = true;
            }

            if (isGedrücktX == false && Keyboard.GetState().IsKeyDown(Keys.X))
            {
                isGedrücktX = true;
            }

            if (isGedrücktY == false && Keyboard.GetState().IsKeyDown(Keys.Y))
            {
                isGedrücktY = true;
            }

            if (isGedrücktZ == false && Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                isGedrücktZ = true;
            }

            if (isGedrücktUmschalt == false && (Keyboard.GetState().IsKeyDown(Keys.LeftShift) || Keyboard.GetState().IsKeyDown(Keys.RightShift)))
            {
                isGedrücktUmschalt = true;
            }

            if (isGedrücktSpace == false && Keyboard.GetState().IsKeyDown(Keys.Space) && EingabeName.Length > 0)
            {
                isGedrücktSpace = true;
            }

            //Was passiert, wenn eine Taste losgelassen wird?
            if (isGedrücktSpace == true && Keyboard.GetState().IsKeyUp(Keys.Space))
            {
                isGedrücktSpace = false;
                EingabeName += " ";
            }

            if (isGedrücktUmschalt == false)
            {
                //Kleinbuchstaben
                if (isGedrücktA == true && Keyboard.GetState().IsKeyUp(Keys.A))
                {
                    isGedrücktA = false;
                    EingabeName += "a";
                }

                if (isGedrücktÄ == true && Keyboard.GetState().IsKeyUp(Keys.OemQuotes))
                {
                    isGedrücktÄ = false;
                    EingabeName += "ä";
                }

                if (isGedrücktB == true && Keyboard.GetState().IsKeyUp(Keys.B))
                {
                    isGedrücktB = false;
                    EingabeName += "b";
                }

                if (isGedrücktC == true && Keyboard.GetState().IsKeyUp(Keys.C))
                {
                    isGedrücktC = false;
                    EingabeName += "c";
                }

                if (isGedrücktD == true && Keyboard.GetState().IsKeyUp(Keys.D))
                {
                    isGedrücktD = false;
                    EingabeName += "d";
                }

                if (isGedrücktE == true && Keyboard.GetState().IsKeyUp(Keys.E))
                {
                    isGedrücktE = false;
                    EingabeName += "e";
                }

                if (isGedrücktF == true && Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isGedrücktF = false;
                    EingabeName += "f";
                }

                if (isGedrücktG == true && Keyboard.GetState().IsKeyUp(Keys.G))
                {
                    isGedrücktG = false;
                    EingabeName += "g";
                }

                if (isGedrücktH == true && Keyboard.GetState().IsKeyUp(Keys.H))
                {
                    isGedrücktH = false;
                    EingabeName += "h";
                }

                if (isGedrücktI == true && Keyboard.GetState().IsKeyUp(Keys.I))
                {
                    isGedrücktI = false;
                    EingabeName += "i";
                }

                if (isGedrücktJ == true && Keyboard.GetState().IsKeyUp(Keys.J))
                {
                    isGedrücktJ = false;
                    EingabeName += "j";
                }

                if (isGedrücktK == true && Keyboard.GetState().IsKeyUp(Keys.K))
                {
                    isGedrücktK = false;
                    EingabeName += "k";
                }

                if (isGedrücktL == true && Keyboard.GetState().IsKeyUp(Keys.L))
                {
                    isGedrücktL = false;
                    EingabeName += "l";
                }

                if (isGedrücktM == true && Keyboard.GetState().IsKeyUp(Keys.M))
                {
                    isGedrücktM = false;
                    EingabeName += "m";
                }

                if (isGedrücktN == true && Keyboard.GetState().IsKeyUp(Keys.N))
                {
                    isGedrücktN = false;
                    EingabeName += "n";
                }

                if (isGedrücktO == true && Keyboard.GetState().IsKeyUp(Keys.O))
                {
                    isGedrücktO = false;
                    EingabeName += "o";
                }

                if (isGedrücktÖ == true && Keyboard.GetState().IsKeyUp(Keys.OemTilde))
                {
                    isGedrücktÖ = false;
                    EingabeName += "ö";
                }

                if (isGedrücktP == true && Keyboard.GetState().IsKeyUp(Keys.P))
                {
                    isGedrücktP = false;
                    EingabeName += "p";
                }

                if (isGedrücktQ == true && Keyboard.GetState().IsKeyUp(Keys.Q))
                {
                    isGedrücktQ = false;
                    EingabeName += "q";
                }

                if (isGedrücktR == true && Keyboard.GetState().IsKeyUp(Keys.R))
                {
                    isGedrücktR = false;
                    EingabeName += "r";
                }

                if (isGedrücktS == true && Keyboard.GetState().IsKeyUp(Keys.S))
                {
                    isGedrücktS = false;
                    EingabeName += "s";
                }

                if (isGedrücktT == true && Keyboard.GetState().IsKeyUp(Keys.T))
                {
                    isGedrücktT = false;
                    EingabeName += "t";
                }

                if (isGedrücktU == true && Keyboard.GetState().IsKeyUp(Keys.U))
                {
                    isGedrücktU = false;
                    EingabeName += "u";
                }

                if (isGedrücktÜ == true && Keyboard.GetState().IsKeyUp(Keys.OemSemicolon))
                {
                    isGedrücktÜ = false;
                    EingabeName += "ü";
                }

                if (isGedrücktV == true && Keyboard.GetState().IsKeyUp(Keys.V))
                {
                    isGedrücktV = false;
                    EingabeName += "v";
                }

                if (isGedrücktW == true && Keyboard.GetState().IsKeyUp(Keys.W))
                {
                    isGedrücktW = false;
                    EingabeName += "w";
                }

                if (isGedrücktX == true && Keyboard.GetState().IsKeyUp(Keys.X))
                {
                    isGedrücktX = false;
                    EingabeName += "x";
                }

                if (isGedrücktY == true && Keyboard.GetState().IsKeyUp(Keys.Y))
                {
                    isGedrücktY = false;
                    EingabeName += "y";
                }

                if (isGedrücktZ == true && Keyboard.GetState().IsKeyUp(Keys.Z))
                {
                    isGedrücktZ = false;
                    EingabeName += "z";
                }
            }
            else
            {
                if (Keyboard.GetState().IsKeyUp(Keys.LeftShift) || Keyboard.GetState().IsKeyUp(Keys.RightShift))
                {
                    isGedrücktUmschalt = false;
                }

                //Großbuchstaben
                if (isGedrücktA == true && Keyboard.GetState().IsKeyUp(Keys.A))
                {
                    isGedrücktA = false;
                    EingabeName += "A";
                }

                if (isGedrücktÄ == true && Keyboard.GetState().IsKeyUp(Keys.OemQuotes))
                {
                    isGedrücktÄ = false;
                    EingabeName += "Ä";
                }

                if (isGedrücktB == true && Keyboard.GetState().IsKeyUp(Keys.B))
                {
                    isGedrücktB = false;
                    EingabeName += "B";
                }

                if (isGedrücktC == true && Keyboard.GetState().IsKeyUp(Keys.C))
                {
                    isGedrücktC = false;
                    EingabeName += "C";
                }

                if (isGedrücktD == true && Keyboard.GetState().IsKeyUp(Keys.D))
                {
                    isGedrücktD = false;
                    EingabeName += "D";
                }

                if (isGedrücktE == true && Keyboard.GetState().IsKeyUp(Keys.E))
                {
                    isGedrücktE = false;
                    EingabeName += "E";
                }

                if (isGedrücktF == true && Keyboard.GetState().IsKeyUp(Keys.F))
                {
                    isGedrücktF = false;
                    EingabeName += "F";
                }

                if (isGedrücktG == true && Keyboard.GetState().IsKeyUp(Keys.G))
                {
                    isGedrücktG = false;
                    EingabeName += "G";
                }

                if (isGedrücktH == true && Keyboard.GetState().IsKeyUp(Keys.H))
                {
                    isGedrücktH = false;
                    EingabeName += "H";
                }

                if (isGedrücktI == true && Keyboard.GetState().IsKeyUp(Keys.I))
                {
                    isGedrücktI = false;
                    EingabeName += "I";
                }

                if (isGedrücktJ == true && Keyboard.GetState().IsKeyUp(Keys.J))
                {
                    isGedrücktJ = false;
                    EingabeName += "J";
                }

                if (isGedrücktK == true && Keyboard.GetState().IsKeyUp(Keys.K))
                {
                    isGedrücktK = false;
                    EingabeName += "K";
                }

                if (isGedrücktL == true && Keyboard.GetState().IsKeyUp(Keys.L))
                {
                    isGedrücktL = false;
                    EingabeName += "L";
                }

                if (isGedrücktM == true && Keyboard.GetState().IsKeyUp(Keys.M))
                {
                    isGedrücktM = false;
                    EingabeName += "M";
                }

                if (isGedrücktN == true && Keyboard.GetState().IsKeyUp(Keys.N))
                {
                    isGedrücktN = false;
                    EingabeName += "N";
                }

                if (isGedrücktO == true && Keyboard.GetState().IsKeyUp(Keys.O))
                {
                    isGedrücktO = false;
                    EingabeName += "O";
                }

                if (isGedrücktÖ == true && Keyboard.GetState().IsKeyUp(Keys.OemTilde))
                {
                    isGedrücktÖ = false;
                    EingabeName += "Ö";
                }

                if (isGedrücktP == true && Keyboard.GetState().IsKeyUp(Keys.P))
                {
                    isGedrücktP = false;
                    EingabeName += "P";
                }

                if (isGedrücktQ == true && Keyboard.GetState().IsKeyUp(Keys.Q))
                {
                    isGedrücktQ = false;
                    EingabeName += "Q";
                }

                if (isGedrücktR == true && Keyboard.GetState().IsKeyUp(Keys.R))
                {
                    isGedrücktR = false;
                    EingabeName += "R";
                }

                if (isGedrücktS == true && Keyboard.GetState().IsKeyUp(Keys.S))
                {
                    isGedrücktS = false;
                    EingabeName += "S";
                }

                if (isGedrücktT == true && Keyboard.GetState().IsKeyUp(Keys.T))
                {
                    isGedrücktT = false;
                    EingabeName += "T";
                }

                if (isGedrücktU == true && Keyboard.GetState().IsKeyUp(Keys.U))
                {
                    isGedrücktU = false;
                    EingabeName += "U";
                }

                if (isGedrücktÜ == true && Keyboard.GetState().IsKeyUp(Keys.OemSemicolon))
                {
                    isGedrücktÜ = false;
                    EingabeName += "Ü";
                }

                if (isGedrücktV == true && Keyboard.GetState().IsKeyUp(Keys.V))
                {
                    isGedrücktV = false;
                    EingabeName += "V";
                }

                if (isGedrücktW == true && Keyboard.GetState().IsKeyUp(Keys.W))
                {
                    isGedrücktW = false;
                    EingabeName += "W";
                }

                if (isGedrücktX == true && Keyboard.GetState().IsKeyUp(Keys.X))
                {
                    isGedrücktX = false;
                    EingabeName += "X";
                }

                if (isGedrücktY == true && Keyboard.GetState().IsKeyUp(Keys.Y))
                {
                    isGedrücktY = false;
                    EingabeName += "Y";
                }

                if (isGedrücktZ == true && Keyboard.GetState().IsKeyUp(Keys.Z))
                {
                    isGedrücktZ = false;
                    EingabeName += "Z";
                }
            }
        }
    }
}
