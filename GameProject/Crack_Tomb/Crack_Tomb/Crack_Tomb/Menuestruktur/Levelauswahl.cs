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
    class Levelauswahl : GameState //Status Levelauswahl
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[2];
        LevelButton[] levelbuttons;
        Texture2D mouse;
        Texture2D background;

        int wartezeit;
        int levelnummer = 1;
        int anzahl_level = 15;

        public Levelauswahl()
        {
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");
            buttons[1] = new Button(new Vector2(540, 370), "InGame", "Level starten");

            levelbuttons = new LevelButton[anzahl_level];
            int help = 0;
            int help2 = 0;

            for (int i = 0; i < anzahl_level; i++)
            {
                string text = "";
                text = text + (i + 1);
                string dateiname = "Level" + (i + 1) + ".txt";
                string line;

                System.IO.StreamReader file = new System.IO.StreamReader(@dateiname);

                line = file.ReadLine();

                file.Close();

                if (i % 8 == 0)
                {
                    help += 55;
                    help2 = 0;
                }

                if (line == "true")
                {
                    levelbuttons[i] = new LevelButton(i + 1, new Vector2(300 + help2, 100 + help), text, true);
                }
                else
                {
                    levelbuttons[i] = new LevelButton(i + 1, new Vector2(300 + help2, 100 + help), text, false);
                }

                help2 += 55;

                text = "";
            }

            wartezeit = 6;
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

            for (int i = 0; i < anzahl_level; i++)
            {
                levelbuttons[i].SetTexture(content.Load<Texture2D>("2DTexturen/levelbutton"));
                levelbuttons[i].SetFont(fontButton);
            }

            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (wartezeit > 0)
            {
                wartezeit--;
                return this;
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState(levelnummer);
            }

            for (int i = 0; i < anzahl_level; i++)
            {
                if (levelbuttons[i].isPressed() && levelbuttons[i].getFreigeschaltet() == true)
                    levelnummer = levelbuttons[i].getLevelnummer();
            }

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Levelauswahl", new Vector2(60, 50), Color.Black);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            for (int i = 0; i < anzahl_level; i++)
            {
                levelbuttons[i].Draw(gameTime, Graphics, SpriteBatch, levelnummer);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
