﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Crack_Tomb.Menuestruktur;

namespace MainMenuCo
{
    class Button
    {
        Vector2 position;
        Texture2D texture;
        string state;
        string text;
        SpriteFont font;
        bool isgedrückt = false;

        public Button(Vector2 position, string state, string text)
        {
            this.position = position;
            this.state = state;
            this.text = text;
        }

        public void SetFont(SpriteFont font)
        {
            this.font = font;
        }

        public void SetTexture(Texture2D texture)
        {
            this.texture = texture;
        }

        public bool isPressed()
        {
            var mousestate = Mouse.GetState();
            Vector2 mouseposition = new Vector2(mousestate.X, mousestate.Y);

            int hoehe = texture.Height;
            int breite = texture.Width;

            if (mousestate.LeftButton == ButtonState.Pressed && mouseposition.X > position.X && mouseposition.Y > position.Y && mouseposition.Y < (position.Y + hoehe) && mouseposition.X < (position.X + breite))
            {
                isgedrückt = true;
                return false;
            }
            else
            {
                if (isgedrückt == true && mousestate.LeftButton == ButtonState.Released && mouseposition.X > position.X && mouseposition.Y > position.Y && mouseposition.Y < (position.Y + hoehe) && mouseposition.X < (position.X + breite))
                {
                    isgedrückt = false;
                    return true;
                }
                else
                {
                    if (mousestate.LeftButton == ButtonState.Released && isgedrückt == true)
                    {
                        isgedrückt = false;
                    }
                }

                return false;
            }
        }

        public GameState GetState(int levelnummer)
        {
            if (state == "MainMenu")
                return new MainMenu();
            if (state == "Rangliste")
                return new Rangliste();
            if (state == "Credits")
                return new Credits();
            if (state == "Levelauswahl")
                return new Levelauswahl();
            if (state == "InGame")
                return new InGame(levelnummer);
            if (state == "Beenden")
                return new Beenden();

            return new Titlescreen();
        }

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            var mousestate = Mouse.GetState();
            Vector2 mouseposition = new Vector2(mousestate.X, mousestate.Y);

            int hoehe = texture.Height;
            int breite = texture.Width;

            if (mouseposition.X > position.X && mouseposition.Y > position.Y && mouseposition.Y < (position.Y + hoehe) && mouseposition.X < (position.X + breite))
            {
                SpriteBatch.Draw(texture, position, Color.Gray);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 15), Color.Black);
            }
            else
            {
                SpriteBatch.Draw(texture, position, Color.White);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 15), Color.Black);
            }
        }
    }
}
