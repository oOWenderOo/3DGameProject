﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Crack_Tomb.Menuestruktur;

namespace MainMenuCo
{
    class Rangliste : GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[1];
        LevelButton[] levelbuttons;
        Texture2D mouse;
        Texture2D background;
        Texture2D ranglisteHalterung;

        string[] rangliste = new string[10];
        int levelnummer = 1;
        int anzahlLevel = 15;

        public Rangliste()
        {
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");

            levelbuttons = new LevelButton[anzahlLevel];

            int help = 0;
            int help2 = 0;

            for (int i = 0; i < anzahlLevel; i++)
            {
                string text = "";
                text = text + (i + 1);

                if (i % 5 == 0)
                {
                    help += 55;
                    help2 = 0;
                }

                levelbuttons[i] = new LevelButton(i + 1, new Vector2(300 + help2, 100 + help), text, true);

                help2 += 55;
            }

            checkRangliste(1);
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

            for (int i = 0; i < anzahlLevel; i++)
            {
                levelbuttons[i].SetTexture(content.Load<Texture2D>("2DTexturen/levelbutton"));
                levelbuttons[i].SetFont(fontButton);
            }

            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
            ranglisteHalterung = content.Load<Texture2D>("2DTexturen/Rangliste");
        }

        public override GameState Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState(0);
            }

            for (int i = 0; i < anzahlLevel; i++)
            {
                if (levelbuttons[i].isPressed() && levelbuttons[i].getFreigeschaltet() == true)
                {
                    levelnummer = levelbuttons[i].getLevelnummer();
                    checkRangliste(levelnummer);
                }
            }

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Rangliste", new Vector2(60, 50), Color.Black);

            SpriteBatch.Draw(ranglisteHalterung, new Vector2(0, 0), Color.White);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            for (int i = 0; i < anzahlLevel; i++)
            {
                levelbuttons[i].Draw(gameTime, Graphics, SpriteBatch, levelnummer);
            }
            
            for (int i = 0; i < rangliste.Length; i++)
            {
                SpriteBatch.DrawString(fontText, rangliste[i], new Vector2(0, 30 * i), Color.Black);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

        public void checkRangliste(int levelnummer)
        {
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
        }
    }
}
