using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MainMenuCo
{
    class Button
    {
        Vector2 position;
        Texture2D texture;
        string state;
        string text;
        SpriteFont font;

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
                return true;
            }
            else
            {
                return false;
            }
        }

        public GameState GetState()
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
                return new InGame();

            return new Titlescreen();
        }

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Draw(texture, position, Color.White);
            SpriteBatch.DrawString(font, text, new Vector2(position.X + 10, position.Y + 10), Color.Black);
        }
    }
}
