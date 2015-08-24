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
using Microsoft.Xna.Framework.Media;

namespace MainMenuCo
{
    class Titlescreen:GameState
    {
        SpriteFont fontText;
        Texture2D background;
        int anzahllevel = 10;
        Song song;

        public Titlescreen()
        {
            for (int i = 1; i <= anzahllevel; i++)
            {
                string dateiname = "Level" + i + ".txt";

                if (!File.Exists(@dateiname))
                {
                    if (i == 1)
                    {
                        string[] lines = { "true", "Ralf 100", "Hans 90", "Mueller 80", "Hansen 70", "Wender 60", "Netuwi 50", "Jan 40", "Lisa 30", "Paul 20", "Patrick 10" };

                        System.IO.File.WriteAllLines(@dateiname, lines);
                    }
                    else
                    {
                        string[] lines = { "false", "Ralf 100", "Hans 90", "Mueller 80", "Hansen 70", "Wender 60", "Netuwi 50", "Jan 40", "Lisa 30", "Paul 20", "Patrick 10" };

                        System.IO.File.WriteAllLines(@dateiname, lines);
                    }
                }
            }
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics) 
        {
            fontText = content.Load<SpriteFont>("Normal");
            background = content.Load<Texture2D>("Testbildhintergrund");
            song = content.Load<Song>("song");
            MediaPlayer.Play(song);
            MediaPlayer.IsRepeating = true;
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
