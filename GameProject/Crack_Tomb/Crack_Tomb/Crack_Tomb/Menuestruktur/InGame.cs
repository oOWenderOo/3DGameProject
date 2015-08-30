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
using Crack_Tomb.Levelloader;
using Microsoft.Xna.Framework.Media;

namespace MainMenuCo
{
    class InGame : GameState
    {
        BasicEffect effect;
        Level_LoaderV2 levelloader;
        VertexPositionColor[] vert = new VertexPositionColor[36];
        Kamera camera;
        public GraphicsDevice graphicdevice;
        Lichtstrahl licht;
        Vector3 lichtPos, lichtDir;
        Player player;
        PauseMenü pausemenü;
        bool gewonnen = false;
        Texture2D score;
        SpriteFont schriftartscore;
        int punkte;
        int minuten = 2;
        int sekunden = 0;

        //Annes-Teil
        IngameTimer timer;
        int wartcount = 0;
        int levelnummer;
        int anzahllevel;

        public InGame() { }

        public InGame(int levelnummer, int anzahllevel)
        {
            //Gabriels-Teil
            this.levelnummer = levelnummer;
            this.anzahllevel = anzahllevel;

            //Jannicks-Teil
            levelloader = new Level_LoaderV2(levelnummer); //////////// TODO:  1 durch "LevelNummer" ersetzen die irgendwo noch herkommen muss von der Levelauswahl
            lichtPos = levelloader.Licht_Start;
            lichtDir = levelloader.Licht_Richtung;

            //Annes-Teil
            timer = new IngameTimer(levelloader.minuten, levelloader.sekunden);
            punkte = minuten * 60 * 10 + sekunden * 10;
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            graphicdevice = Graphics.GraphicsDevice;
            //Jannicks-Teil
            effect = new BasicEffect(graphicdevice);
            levelloader.Array_Loader(content);

            //Gabriels-Teil
            player = new Player(lichtPos, content.Load<Model>("3DModelle/Spieler_mit_Hut"), levelnummer, content, ref levelloader);
            camera = new Kamera(player.position);
            licht = new Lichtstrahl(content.Load<Model>("3DModelle/partikel"), lichtPos, lichtDir, levelnummer, content.Load<Effect>("Shader/PartikelEffect"));
            pausemenü = new PauseMenü(content, anzahllevel);

            //Annes-Teil
            timer.setFont(content);
            timer.setTexture(content);
            timer.Position = new Vector2(50, 15);
            score = content.Load<Texture2D>("2DTexturen/Score");
            schriftartscore = content.Load<SpriteFont>("Fonts/Normal");
        }

        public override GameState Update(GameTime gameTime)
        {
            pausemenü.checkPause(gameTime);

            if (!pausemenü.ispause)
            {
                //Gabriels-Teil
                licht.Update(gameTime, ref player, ref gewonnen, ref levelloader);
                player.Update(gameTime, ref levelloader);
                camera.Update(player.position);
                MediaPlayer.Resume();

                if (gewonnen)
                    return new Gewonnen(levelnummer, punkte, anzahllevel);

                //Annes-Teil
                timer.Update(gameTime);
                punkte = timer.getMinutes() * 60 * 10 + timer.getSeconds() * 10;

                if (timer.Time == "00:00")
                {
                    if (wartcount >= 30)
                    {
                        return new GameOver(levelnummer, anzahllevel);
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
                MediaPlayer.Pause();
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
            SpriteBatch.DrawString(schriftartscore, "" + punkte, new Vector2(665, 22), Color.Black);

            SpriteBatch.End();

            if (pausemenü.ispause)
            {
                pausemenü.Draw(gameTime, Graphics, SpriteBatch);
            }
        }
    }
}
