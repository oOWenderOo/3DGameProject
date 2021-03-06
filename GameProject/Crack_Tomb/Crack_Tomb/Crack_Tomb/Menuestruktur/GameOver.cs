﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MainMenuCo;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Menuestruktur
{
    class GameOver : GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[2];
        Texture2D mouse;
        Texture2D background;

        int wartezeit;
        int levelnummer;
        int anzahllevel;

        public GameOver() { }

        public GameOver(int levelnummer, int anzahllevel)
        {
            this.levelnummer = levelnummer;
            this.anzahllevel = anzahllevel;

            buttons[0] = new Button(new Vector2(60, 275), "MainMenu", "Zurück ins Menü");
            buttons[1] = new Button(new Vector2(60, 200), "InGame", "Level neu starten");

            wartezeit = 10;
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
            background = content.Load<Texture2D>("2DTexturen/Hintergrund");
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
                    return buttons[i].GetState(levelnummer, anzahllevel);
            }
            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Du hast verloren!", new Vector2(400, 77), Color.Red);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

    }
}
