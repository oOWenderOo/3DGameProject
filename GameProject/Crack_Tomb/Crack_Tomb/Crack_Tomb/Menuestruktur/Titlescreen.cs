using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Threading;
using Microsoft.Xna.Framework.Input;

namespace MainMenuCo
{
    class Titlescreen:GameState
    {
        SpriteFont font;
        

        public Titlescreen()
        {
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics) 
        {
            font = content.Load<SpriteFont>("Normal");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new MainMenu();
            }
            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch spriteBatch )
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Welcome by Crack Tomb!", new Vector2(230, 50), Color.AntiqueWhite);
            spriteBatch.DrawString(font, "~ Press Enter ~",new Vector2(280, 350), Color.AntiqueWhite);
            spriteBatch.End();
        }
        
    }
}
