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
        Button[] buttons = new Button[3];
        Texture2D mouse;
        Texture2D background;
        bool pausegedrückt = false;

        public PauseMenü(ContentManager content)
        {
            mouse = content.Load<Texture2D>("MouseZeiger");
            fontButton = content.Load<SpriteFont>("ButtonTexture");
            fontText = content.Load<SpriteFont>("Normal");
            background = content.Load<Texture2D>("Pausenmenü mit Hintergund(grau)");

            buttons[0] = new Button(new Vector2(300, 225), "Fortsetzen", "Fortsetzen");
            buttons[1] = new Button(new Vector2(300, 300), "Levelauswahl", "Levelauswahl");
            buttons[2] = new Button(new Vector2(300, 150), "MainMenu", "Hauptmenü");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("Pausemenubutton"));
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
                    return buttons[i].GetState(0);
            }

            return aktuell;
        }

        public void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
