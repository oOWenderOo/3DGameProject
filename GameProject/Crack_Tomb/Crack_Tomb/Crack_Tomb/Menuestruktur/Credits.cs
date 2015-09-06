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
        SpriteFont creditsFont;
        Button[] buttons = new Button[1];
        Texture2D mouse;
        Texture2D background;
        int anzahllevel;
        int creditsPositionX = 380;
        int creditsPositionY = 50;
        string[] creditsText = { "Dieses Projekt ist im Rahmen der Veranstaltung",
                                   "  3D-Gameproject an der Otto-von-Guericke",
                                   "         Universität entstanden.",
                                   "",
                                   "",
                                   "         Gruppenleitung",
                                   "",
                                   "        Gabriel Moczalla",
                                   "",
                                   "",
                                   "         Programmierung",
                                   "",
                                   "           Anne Döbler",
                                   "        Gabriel Moczalla",
                                   "        Jannick Knechtel",
                                   "",
                                   "",
                                   "       Modelle & Texturen",
                                   "",
                                   "           Anne Döbler",
                                   "",
                                   "",
                                   "             Audio",
                                   "",
                                   "         Woosh - Mark DiAngelo",
                                   " The Curtain Rises",
                                   "    Swords Collide - Sound Explorer",
                                   "Phantom from Space",
                                   "         Ossuary 5 - Rest",
                                   "         Lost Time",
                                   "   Large Door Slam - SoundBible.com",
                                   "        Hole Punch - Simon Craggs",
                                   "        Annodomino - Winnenden Mix"};

        public Credits(int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics) 
        {
            fontButton = content.Load<SpriteFont>("Fonts/Button");
            fontText = content.Load<SpriteFont>("Fonts/Normal");
            creditsFont = content.Load<SpriteFont>("Fonts/CreditsFont");

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetTexture(content.Load<Texture2D>("2DTexturen/button"));
                buttons[i].SetFont(fontButton);
            }

            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Hintergrund");
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

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            for (int i = 0; i < creditsText.Length; i++)
            {
                SpriteBatch.DrawString(creditsFont, creditsText[i], new Vector2(creditsPositionX, creditsPositionY + 15 * i), Color.Black);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
