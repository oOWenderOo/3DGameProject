﻿using System;
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

        int wartezeit;
        int levelnummer;
        int punkte;
        string[] rangliste = new string[10];

        public Gewonnen(int levelnummer, int punkte)
        {
            this.levelnummer = levelnummer;
            this.punkte = punkte;

            buttons[0] = new Button(new Vector2(540, 370), "MainMenu", "Zurück ins Menü");
            buttons[1] = new Button(new Vector2(60, 370), "InGame", "Level erneut starten");

            wartezeit = 10;

            
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

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Du hast gewonnen!", new Vector2(300, 100), Color.Green);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }
            
            for (int i = 0; i < rangliste.Length; i++)
            {
                SpriteBatch.DrawString(fontText, rangliste[i], new Vector2(0, 30 * i), Color.Black);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

    }
}
