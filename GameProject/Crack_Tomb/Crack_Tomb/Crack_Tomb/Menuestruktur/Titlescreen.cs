using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Threading;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace MainMenuCo
{
    class Titlescreen:GameState
    {
        SpriteFont fontText;
        Texture2D background;

        public Titlescreen()
        {
            /*
            if (!File.Exists(@"c:\Users\Gabriel\Test.txt"))
            {
                string[] lines = { "Ralf 100", "Hans 90", "Mueller 80", "Hansen 70", "Wender 60", "Netuwi 50", "Jan 40", "Lisa 30", "Paul 20", "Patrick 10" };

                System.IO.File.WriteAllLines(@"c:\Users\Gabriel\Test.txt", lines);
            }*/
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics) 
        {
            fontText = content.Load<SpriteFont>("Normal");
            background = content.Load<Texture2D>("Testbildhintergrund");
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
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.DrawString(fontText, "~ Press Enter ~",new Vector2(280, 350), Color.Black);
            spriteBatch.End();
        }
        
    }
}
