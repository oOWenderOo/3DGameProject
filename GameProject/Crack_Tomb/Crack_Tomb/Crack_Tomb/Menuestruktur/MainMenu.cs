﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MainMenuCo
{
    class MainMenu : GameState
    {
        SpriteFont font;
        Button[] buttons = new Button[3];
        Texture2D mouse;

        public MainMenu()
        {
            buttons[0] = new Button(new Vector2(300, 200), "Rangliste", "Rangliste");
            buttons[1] = new Button(new Vector2(300, 100), "Credits", "Credits");
            buttons[2] = new Button(new Vector2(300, 300), "Levelauswahl", "Levelauswahl");
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            font = content.Load<SpriteFont>("Normal");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("button"));
                buttons[i].SetFont(font);
            }
            mouse = content.Load<Texture2D>("MouseZeiger");
        }

        public override GameState Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState();
            }

            return this;
        }

      

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.DrawString(font, "Sie befinden sich nun im Haupt-Menu!", new Vector2(Graphics.PreferredBackBufferHeight / 2, 50), Color.AntiqueWhite);
            

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
