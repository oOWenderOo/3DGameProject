using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MainMenuCo;
using Microsoft.Xna.Framework.Content;

namespace Crack_Tomb.Menuestruktur
{
  public class IngameTimer
    {
        SpriteFont font;
        string Timetext = "";
        string MinutesText = "";
        string SecondsText = "";
        private Vector2 position;
        int minutes;
        float seconds;
        Texture2D timertextur;

        public IngameTimer(int startMinute, float startSeconds)
        {
            if (startSeconds > 59)
            {
                startSeconds = 59;
            }
       
            seconds = startSeconds;
            minutes= startMinute; 
        }

        public Vector2 Position 
        {
            get { return position;}
            set { position = value; }
        }

        public void setFont(ContentManager content)
        {
            font = content.Load<SpriteFont>("Normal");
        }

        public void setTexture(ContentManager content)
        {
            timertextur = content.Load<Texture2D>("Timer");
        }

        public int getSeconds()
        {
            return (int)seconds;
        }

        public int getMinutes()
        {
            return minutes;
        }

        public  void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
           
                if (seconds <= 0)
                {
                    if (minutes <= 0)
                    {
                        Timetext = "00:00";
                    }
                    else
                    {
                        minutes = minutes - 1;
                        seconds = 60;
                    
                    }
                }
                else
                    seconds = seconds - (deltaTime);


                if (minutes < 10)
                {
                    MinutesText = "0" + minutes.ToString();
                }

                else 
                {
                    MinutesText =  minutes.ToString();
                }

                if (seconds < 10)
                {
                    SecondsText = "0" + ((int)seconds).ToString();
                }
                else 
                {
                    SecondsText = ((int)seconds).ToString();
                }

                Timetext = MinutesText+":"+SecondsText;
            
           
        }

        public string Time
        {
            get { return Timetext; }
        }


        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(timertextur, new Vector2(Position.X - 30, Position.Y), Color.White);
            spriteBatch.DrawString(font, Timetext, Position, Color.Blue);
            spriteBatch.End();
        }

    }
}
