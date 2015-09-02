using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MainMenuCo;
using Microsoft.Xna.Framework.Content;

namespace Crack_Tomb.Menuestruktur
{
    class PauseMenü
    {
        public bool ispause = false;

        SpriteFont fontButton;
        SpriteFont fontText;
        SpriteFont pauseFont;
        Button[] buttons = new Button[4];
        Texture2D mouse;
        Texture2D background;
        bool pausegedrückt = false;
        int anzahllevel;
        int levelnummer;

        public PauseMenü(ContentManager content, int anzahllevel, int levelnummer)
        {
            this.levelnummer = levelnummer;
            this.anzahllevel = anzahllevel;
            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            fontButton = content.Load<SpriteFont>("Fonts/Button");
            fontText = content.Load<SpriteFont>("Fonts/Normal");
            pauseFont = content.Load<SpriteFont>("Fonts/PauseFont");
            background = content.Load<Texture2D>("2DTexturen/Pausenmenü mit Hintergund(grau)");

            int positionY = 80;
            int positionX = 310;
            int abstand = 60;

            buttons[0] = new Button(new Vector2(positionX, positionY + abstand * 1), "Fortsetzen", "Fortsetzen");
            buttons[1] = new Button(new Vector2(positionX, positionY + abstand * 3), "Levelauswahl", "Levelauswahl");
            buttons[2] = new Button(new Vector2(positionX, positionY + abstand * 4), "MainMenu", "Hauptmenü");
            buttons[3] = new Button(new Vector2(positionX, positionY + abstand * 2), "InGame", "Neustart");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("2DTexturen/Pausenmenubutton"));
                buttons[i].SetFont(fontButton);
            }
        }

        public void checkPause(GameTime gametime)
        {
            if (ispause)
            {
                if (buttons[0].isPressed())
                    ispause = false;
            }

            if ((Keyboard.GetState().IsKeyDown(Keys.Escape) || Keyboard.GetState().IsKeyDown(Keys.P)))
            {
                pausegedrückt = true;
            }
            else
            {
                if (pausegedrückt == true && (Keyboard.GetState().IsKeyUp(Keys.Escape) || Keyboard.GetState().IsKeyUp(Keys.P)))
                {
                    pausegedrückt = false;
                    ispause = (!ispause);
                }
            }
        }

        public GameState Update(GameState aktuell)
        {
            for (int i = 1; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                {
                    if (i == 3)
                    {
                        return buttons[i].GetState(levelnummer, anzahllevel);
                    }
                    else
                    {
                        return buttons[i].GetState(0, anzahllevel);
                    }
                }
            }

            return aktuell;
        }

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            SpriteBatch.DrawString(pauseFont, "Pause", new Vector2(330, 80), Color.Black);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
