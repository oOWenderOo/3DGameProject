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
        Button[] buttons = new Button[2];
        Texture2D mouse;
        Texture2D background;
        int levelnummer;
        int punkte;
        string[] rangliste = new string[10];
        int[] ranglistePunkte = new int[10];
        int position = 0; //in der Rangliste
        bool musseintragen = false;
        string EingabeName = "Hallo";

        public Gewonnen(int levelnummer, int punkte)
        {
            this.levelnummer = levelnummer;
            this.punkte = punkte;

            buttons[0] = new Button(new Vector2(540, 370), "MainMenu", "Zurück ins Menü");
            buttons[1] = new Button(new Vector2(60, 370), "InGame", "Level erneut starten");
            
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

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            fontButton = content.Load<SpriteFont>("ButtonTexture");
            fontText = content.Load<SpriteFont>("Normal");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("button"));
                buttons[i].SetFont(fontButton);
            }
            mouse = content.Load<Texture2D>("MouseZeiger");
            background = content.Load<Texture2D>("Testbildhintergrund");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (musseintragen)
            {
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
                        return buttons[i].GetState(levelnummer);
                }
            }

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Du hast gewonnen!", new Vector2(300, 100), Color.Green);

            if (!musseintragen)
            {
                for (int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].Draw(gameTime, Graphics, SpriteBatch);
                }
            }
            
            for (int i = 0; i < rangliste.Length; i++)
            {
                if (rangliste[i] != "")
                {
                    SpriteBatch.DrawString(fontText, rangliste[i], new Vector2(0, 30 * i), Color.Black);
                }
                else
                {
                    SpriteBatch.DrawString(fontText, "<-----------", new Vector2(0, 30 * i), Color.Black);
                }
            }

            if (musseintragen)
            {
                SpriteBatch.DrawString(fontText, EingabeName, new Vector2(300, 300), Color.Black);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

    }
}
