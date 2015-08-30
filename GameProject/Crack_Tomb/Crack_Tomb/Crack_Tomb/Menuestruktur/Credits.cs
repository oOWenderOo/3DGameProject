using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace MainMenuCo
{
    class Credits: GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[1];
        Texture2D mouse;
        Texture2D background;
        int anzahllevel;

        public Credits(int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");
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
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
        }

        public override GameState Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState(0, anzahllevel);
            }
            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            SpriteBatch.DrawString(fontText, "Credits", new Vector2(60, 50), Color.Black);


            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
