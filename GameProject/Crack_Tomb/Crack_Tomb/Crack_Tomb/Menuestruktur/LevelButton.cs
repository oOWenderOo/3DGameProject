using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Menuestruktur
{
    class LevelButton
    {
        Vector2 position;
        Texture2D texture;
        string text;
        SpriteFont font;
        int levelnummer;

        public LevelButton(int levelnummer, Vector2 position, string text)
        {
            this.levelnummer = levelnummer;
            this.position = position;
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

        public int getLevelnummer()
        {
            return levelnummer;
        }

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch, int levelnummer)
        {
            if (this.levelnummer != levelnummer)
            {
                SpriteBatch.Draw(texture, position, Color.White);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 15), Color.Black);
            }
            else
            {
                SpriteBatch.Draw(texture, position, Color.Red);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 15), Color.White);
            }
        }
    }
}
