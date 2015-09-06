using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Crack_Tomb.Menuestruktur;

namespace MainMenuCo
{
    class Credits: GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        SpriteFont creditsFont;
        Button[] buttons = new Button[1];
        TriggerButton[] trigger = new TriggerButton[2];
        Texture2D mouse;
        Texture2D background;
        Texture2D creditsFläche;
        int anzahllevel;
        int creditsPositionX = 350;
        int creditsPositionY = 50;
        int anfang = 0;
        int ende = 16;
        string[] creditsText = { "",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "Dieses Projekt ist",
                                   "im Rahmen der Veranstaltung",
                                   "3D-Gameproject an",
                                   "der Otto-von-Guericke",
                                   "Universität entstanden.",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "Gruppenleitung",
                                   "",
                                   "Gabriel Moczalla",
                                   "",
                                   "",
                                   "Programmierung",
                                   "",
                                   "Anne Döbler",
                                   "Gabriel Moczalla",
                                   "Jannick Knechtel",
                                   "",
                                   "",
                                   "Modelle & Texturen",
                                   "",
                                   "Anne Döbler",
                                   "",
                                   "",
                                   "",
                                   "",
                                   "Audio",
                                   "",
                                   "Woosh - Mark DiAngelo",
                                   "The Curtain Rises",
                                   "Swords Collide",
                                   "         - Sound Explorer",
                                   "Phantom from Space",
                                   "Ossuary 5 - Rest",
                                   "Lost Time",
                                   "Large Door Slam",
                                   "          - SoundBible.com",
                                   "Hole Punch - Simon Craggs",
                                   "Annodomino - Winnenden Mix",
                                   "",
                                   ""};

        public Credits(int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");

            trigger[0] = new TriggerButton(new Vector2(creditsPositionX, creditsPositionY), "Zurück");
            trigger[1] = new TriggerButton(new Vector2(creditsPositionX + 300, creditsPositionY), "Weiter");
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

            trigger[0].SetTexture(content.Load<Texture2D>("2DTexturen/Pfeil_links"));
            trigger[0].SetFont(fontButton);

            trigger[1].SetTexture(content.Load<Texture2D>("2DTexturen/Pfeil_rechts"));
            trigger[1].SetFont(fontButton);

            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Hintergrund");
            creditsFläche = content.Load<Texture2D>("2DTexturen/CreditsFläche");
        }

        public override GameState Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState(0, anzahllevel);
            }

            if (trigger[0].isPressed())
            {
                if (anfang != 0)
                {
                    anfang -= 17;
                    ende -= 17;
                }
            }

            if (trigger[1].isPressed())
            {
                if (ende != creditsText.Length - 1)
                {
                    anfang += 17;
                    ende += 17;
                }
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

            SpriteBatch.Draw(creditsFläche, new Vector2(creditsPositionX, creditsPositionY), Color.White);

            for (int i = 0; i < trigger.Length; i++)
            {
                trigger[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            for (int i = anfang; i <= ende; i++)
            {
                SpriteBatch.DrawString(creditsFont, creditsText[i], new Vector2(creditsPositionX + 100, creditsPositionY + 70 + 15 * (i - anfang)), Color.Black);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
