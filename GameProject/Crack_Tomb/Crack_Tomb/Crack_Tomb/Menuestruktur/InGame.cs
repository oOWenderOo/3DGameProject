using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Crack_Tomb;

namespace MainMenuCo
{
    class InGame : GameState
    {
        BasicEffect effect;
        Level level;
        Level_Loader levelloader;
        VertexPositionColor[] vert = new VertexPositionColor[36];
        Test_Kamera camera;
        GraphicsDevice graphicdevice;

        public InGame()
        {
            level = new Level();
            levelloader = new Level_Loader(level);

            Wand Wand_1 = new Wand(0, 0, 0);
            vert = Wand_1.ver;

            levelloader.Array_Loader(level);
        }

        public override void LoadContent(ContentManager content, GraphicsDeviceManager Graphics)
        {
            graphicdevice = Graphics.GraphicsDevice;
            effect = new BasicEffect(graphicdevice);
            camera = new Test_Kamera(new Vector3(0, 3, 5), 0.05f, 0.01f, graphicdevice);
        }

        public override GameState Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                return new Levelauswahl();

            camera.Update();

            return new InGame();
        }

        public override void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch)
        {
            effect.VertexColorEnabled = true;

            effect.CurrentTechnique.Passes[0].Apply();

            int n = 0;

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

            while (levelloader.boden[n] != null)
            {
                vert = levelloader.boden[n].ver;
                graphicdevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 2);
                n++;
            }

            effect.View = camera.view;
            effect.Projection = camera.projection;
        }
    }
}
