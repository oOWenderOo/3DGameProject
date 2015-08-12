using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Crack_Tomb;
using Crack_Tomb.Spieler;
using Lichtquelle;
using Crack_Tomb.Menuestruktur;

namespace MainMenuCo
{
    class InGame : GameState
    {
        BasicEffect effect;
        Level_Loader levelloader;
        VertexPositionColor[] vert = new VertexPositionColor[36];
        Kamera camera;
        public GraphicsDevice graphicdevice;
        Lichtstrahl licht;
        Vector3 lichtPos, lichtDir;
        Player player;
        PauseMenü pausemenü;
        bool gewonnen = false;
        Texture2D score;

        //Annes-Teil
        IngameTimer timer;
        int wartcount = 0;
        int levelnummer;

        public InGame(int levelnummer)
        {
            //Gabriels-Teil
            this.levelnummer = levelnummer;

            //Jannicks-Teil
            levelloader = new Level_Loader(levelnummer); //////////// TODO:  1 durch "LevelNummer" ersetzen die irgendwo noch herkommen muss von der Levelauswahl
            lichtPos = levelloader.Licht_Start;
            lichtDir = levelloader.Licht_Richtung;

            //Annes-Teil
            timer = new IngameTimer(2, 0);
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            graphicdevice = Graphics.GraphicsDevice;
            //Jannicks-Teil
            effect = new BasicEffect(graphicdevice);
            levelloader.Array_Loader(content);

            //Gabriels-Teil
            player = new Player(lichtPos, content.Load<Model>("Spieler_mit_Hut"), levelnummer, content);
            camera = new Kamera(player.position);
            licht = new Lichtstrahl(content.Load<Model>("partikel"), lichtPos, lichtDir, levelnummer, player);
            pausemenü = new PauseMenü(content);

            //Annes-Teil
            timer.setFont(content);
            timer.setTexture(content);
            timer.Position = new Vector2(50, 15);
            score = content.Load<Texture2D>("Score");
        }

        public override GameState Update(GameTime gameTime)
        {
            pausemenü.checkPause(gameTime);

            if (!pausemenü.ispause)
            {
                //Gabriels-Teil
                licht.Update(gameTime, ref player, ref gewonnen);
                player.Update(gameTime);
                camera.Update(player.position);

                if (gewonnen)
                    return new Gewonnen(levelnummer);

                //Annes-Teil
                timer.Update(gameTime);

                if (timer.Time == "00:00")
                {
                    if (wartcount >= 30)
                    {
                        return new GameOver(levelnummer);
                    }
                    else
                    {
                        wartcount = wartcount + 1;
                        return this;
                    }
                }
                else { return this; }
            }
            else
            {
                return pausemenü.Update(this);
            }
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {

            //Jannicks-Teil

            effect.VertexColorEnabled = true;
            effect.CurrentTechnique.Passes[0].Apply();



            levelloader.Draw(this.graphicdevice, camera.view, camera.projection);

            effect.View = camera.view;
            effect.Projection = camera.projection;
            
            
            

            //Gabriels-Teil
            licht.Draw(gameTime, camera.view, camera.projection);
            player.Draw(camera.view, camera.projection, SpriteBatch);

            //Annes-Teil
            timer.Draw(gameTime, Graphics, SpriteBatch);
            SpriteBatch.Begin();

            SpriteBatch.Draw(score, new Vector2(625, 20), Color.White);

            SpriteBatch.End();

            if (pausemenü.ispause)
            {
                pausemenü.Draw(gameTime, Graphics, SpriteBatch);
            }
        }
    }
}
