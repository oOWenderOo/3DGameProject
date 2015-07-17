﻿using System;
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
        GraphicsDevice graphicdevice;
        Lichtstrahl licht;
        Vector3 lichtPos, lichtDir;
        Player player;
        bool gewonnen = false;

        //Annes-Teil
        IngameTimer timer;
        int wartcount = 0;
        int levelnummer = 3;

        public InGame()
        {
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
            levelloader.Array_Loader();
            camera = new Kamera();

            //Gabriels-Teil
            player = new Player(lichtPos, content.Load<Model>("Dreieck"), levelnummer);
            licht = new Lichtstrahl(content.Load<Model>("cube"), lichtPos, lichtDir, levelnummer, player);

            //Annes-Teil
            timer.setFont(content);
            timer.Position = new Vector2(50, 25);
        }

        public override GameState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                return new Levelauswahl();

            //Jannicks-Teil
            //camera.Update();

            //Gabriels-Teil
            licht.Update(gameTime, ref player, ref gewonnen);
            player.Update(gameTime);

            if (gewonnen)
                return new Gewonnen();

            //Annes-Teil
            timer.Update(gameTime);

            if (timer.Time == "00:00")
            {
                if (wartcount >= 30)
                {
                    return new GameOver();
                }
                else
                {
                    wartcount = wartcount + 1;
                    return this;
                }
            }
            else { return this; }
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            //Graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            //Jannicks-Teil
            effect.VertexColorEnabled = true;

            effect.CurrentTechnique.Passes[0].Apply();

            int n = 0;

            while (levelloader.Boden[n] != null)
            {
                vert = levelloader.Boden[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 2);
                n++;
            }

            n = 0;

            while (levelloader.Wand_List[n] != null && n < 41 * 41)
            {
                vert = levelloader.Wand_List[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            }

            n = 0;

            while (levelloader.Wand_Loch_List[n] != null && n < 41 * 41)
            {
                vert = levelloader.Wand_Loch_List[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            }

            n = 0;

            while (levelloader.Säule_List[n] != null && n < 41 * 41)
            {
                vert = levelloader.Säule_List[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            }

            n = 0;

            while (levelloader.Barriere_List[n] != null && n < 41 * 41)
            {
                vert = levelloader.Barriere_List[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            }

            effect.View = camera.view;
            effect.Projection = camera.projection;

            //Gabriels-Teil
            licht.Draw(gameTime, camera.view, camera.projection);
            player.Draw(camera.view, camera.projection);

            //Annes-Teil
            timer.Draw(gameTime, Graphics, SpriteBatch);
        }
    }
}
