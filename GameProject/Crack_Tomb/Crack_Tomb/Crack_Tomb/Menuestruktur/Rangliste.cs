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
    class Rangliste : GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[1];
        Texture2D mouse;
        Texture2D background;
        Texture2D ranglisteHalterung;
        TriggerButton[] trigger = new TriggerButton[2];

        string[] rangliste = new string[10];
        int levelnummer = 1;
        int anzahlLevel;

        public Rangliste(int anzahllevel)
        {
            this.anzahlLevel = anzahllevel;
            buttons[0] = new Button(new Vector2(60, 370), "MainMenu", "Zurück");

            int positionX = 320;
            int positionY = 20;

            trigger[0] = new TriggerButton(new Vector2(positionX, positionY), "Zurück");
            trigger[1] = new TriggerButton(new Vector2(positionX + 300, positionY), "Weiter");

            checkRangliste(1);
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

            trigger[0].SetTexture(content.Load<Texture2D>("2DTexturen/Pfeil_links"));
            trigger[0].SetFont(fontButton);

            trigger[1].SetTexture(content.Load<Texture2D>("2DTexturen/Pfeil_rechts"));
            trigger[1].SetFont(fontButton);

            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
            ranglisteHalterung = content.Load<Texture2D>("2DTexturen/Rangliste");
        }

        public override GameState Update(GameTime gameTime)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].isPressed())
                    return buttons[i].GetState(0, anzahlLevel);
            }

            if (trigger[0].isPressed())
            {
                if (levelnummer == 1)
                {
                    levelnummer = anzahlLevel;
                }
                else
                {
                    levelnummer--;
                }

                checkRangliste(levelnummer);
            }

            if (trigger[1].isPressed())
            {
                if (levelnummer == anzahlLevel)
                {
                    levelnummer = 1;
                }
                else
                {
                    levelnummer++;
                }

                checkRangliste(levelnummer);
            }

            return this;
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Vector2(0, 0), Color.White);

            SpriteBatch.Draw(ranglisteHalterung, new Vector2(300, 0), Color.White);

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            for (int i = 0; i < trigger.Length; i++)
            {
                trigger[i].Draw(gameTime, Graphics, SpriteBatch);
            }
            
            for (int i = 0; i < rangliste.Length; i++)
            {
                SpriteBatch.DrawString(fontText, "" + (i + 1) + ".", new Vector2(380, 120 + 30 * i), Color.Black);
                SpriteBatch.DrawString(fontText, rangliste[i], new Vector2(430, 120 + 30 * i), Color.Black);
            }

            SpriteBatch.DrawString(fontText, "" + levelnummer, new Vector2(510, 10), Color.Black);

            SpriteBatch.DrawString(fontText, "Rangliste", new Vector2(460, 60), Color.Black);

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }

        public void checkRangliste(int levelnummer)
        {
            int counter = 0;
            string line;
            string dateiname = "Level" + levelnummer + ".txt";

            System.IO.StreamReader file = new System.IO.StreamReader(@dateiname);

            while ((line = file.ReadLine()) != null)
            {
                if (counter != 0)
                {
                    rangliste[counter - 1] = line;
                }
                counter++;
            }

            file.Close();
        }
    }
}
