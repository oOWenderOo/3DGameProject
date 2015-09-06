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
        Texture2D titel;
        int anzahllevel;

        public Titlescreen(int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            for (int i = 1; i <= anzahllevel; i++)
            {
                string dateiname = "Level" + i + ".txt";

                if (!File.Exists(@dateiname))
                {
                    if (i == 1)
                    {
                        string[] lines = { "true", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0" };

                        System.IO.File.WriteAllLines(@dateiname, lines);
                    }
                    else
                    {
                        string[] lines = { "false", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0", "------ 0" };

                        System.IO.File.WriteAllLines(@dateiname, lines);
                    }
                }
            }
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics) 
        {
            fontText = content.Load<SpriteFont>("Fonts/Normal");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
            titel = content.Load<Texture2D>("2DTexturen/Titel");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return new MainMenu(anzahllevel);
            }
            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch spriteBatch )
        {
            spriteBatch.Begin();
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            spriteBatch.Draw(titel, new Vector2(40, 100), Color.White);
            
            if (((int)gameTime.TotalGameTime.Milliseconds) % 800 >= 0 && ((int)gameTime.TotalGameTime.Milliseconds) % 800 <= 400)
            {
                spriteBatch.DrawString(fontText, "~ Enter drücken ~", new Vector2(270, 350), Color.Black);
            }

            spriteBatch.End();
        }
    }
}
