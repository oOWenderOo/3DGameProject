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
    class MainMenu : GameState
    {
        SpriteFont fontButton;
        SpriteFont fontText;
        Button[] buttons = new Button[4];
        Texture2D mouse;
        Texture2D background;
        int anzahllevel;

        int wartezeit;

        public MainMenu(int anzahllevel)
        {
            this.anzahllevel = anzahllevel;
            buttons[0] = new Button(new Vector2(60, 225), "Rangliste", "Rangliste");
            buttons[1] = new Button(new Vector2(60, 300), "Credits", "Credits");
            buttons[2] = new Button(new Vector2(60, 150), "Levelauswahl", "Levelauswahl");
            buttons[3] = new Button(new Vector2(60, 375), "Beenden", "Spiel beenden");

            wartezeit = 6;
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
            mouse = content.Load<Texture2D>("2DTexturen/MouseZeiger");
            background = content.Load<Texture2D>("2DTexturen/Testbildhintergrund");
        }

        public override GameState Update(GameTime gameTime)
        {
            if (wartezeit > 0)
            {
                wartezeit--;
                return this;
            }

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
            SpriteBatch.DrawString(fontText, "Hauptmenü", new Vector2( 60, 50), Color.Black);
            

            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].Draw(gameTime, Graphics, SpriteBatch);
            }

            SpriteBatch.Draw(mouse, new Vector2(Mouse.GetState().X, Mouse.GetState().Y), Color.White);

            SpriteBatch.End();
        }
    }
}
