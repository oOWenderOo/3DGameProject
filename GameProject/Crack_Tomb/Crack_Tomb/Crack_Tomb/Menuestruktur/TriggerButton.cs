using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Crack_Tomb.Menuestruktur
{
    class TriggerButton
    {
        Vector2 position;
        Texture2D texture;
        string text;
        SpriteFont font;
        bool isgedrückt = false;

        public TriggerButton(Vector2 position, string text)
        {
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

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            var mousestate = Mouse.GetState();
            Vector2 mouseposition = new Vector2(mousestate.X, mousestate.Y);

            int hoehe = texture.Height;
            int breite = texture.Width;

            if (mouseposition.X > position.X && mouseposition.Y > position.Y && mouseposition.Y < (position.Y + hoehe) && mouseposition.X < (position.X + breite))
            {
                SpriteBatch.Draw(texture, position, Color.Gray);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 22), Color.Black);
            }
            else
            {
                SpriteBatch.Draw(texture, position, Color.White);
                SpriteBatch.DrawString(font, text, new Vector2(position.X + 20, position.Y + 22), Color.Black);
            }
        }
    }
}
