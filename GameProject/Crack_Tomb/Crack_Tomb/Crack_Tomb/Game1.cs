using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Crack_Tomb
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        BasicEffect effect;
        
        VertexPositionColor[] vert = new VertexPositionColor[36];

        Test_Kamera camera;

        Level level;
        Level_Loader Levelloader;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            camera = new Test_Kamera(new Vector3(0, 3, 5), 0.05f, 0.01f, GraphicsDevice);

            Wand Wand_1 = new Wand(0, 0, 0);
            vert = Wand_1.ver;


            effect = new BasicEffect(GraphicsDevice);

            level = new Level();
            Levelloader= new Level_Loader(new Level());
            Levelloader.Array_Loader(level);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            camera.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            effect.VertexColorEnabled = true;

            effect.CurrentTechnique.Passes[0].Apply();

            int n = 0;

            while (Levelloader.Wand_List[n] != null && n < 41*41) {

                vert = Levelloader.Wand_List[n].ver;
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;
            
            }

            n = 0;

            while (Levelloader.Wand_Loch_List[n] != null && n < 41 * 41){

                vert = Levelloader.Wand_Loch_List[n].ver;
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;

            }

            n = 0;

            while (Levelloader.S�ule_List[n] != null && n < 41 * 41){

                vert = Levelloader.S�ule_List[n].ver;
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 12);
                n++;

            }

            while (Levelloader.boden[n] != null ){

                vert = Levelloader.boden[n].ver;
                GraphicsDevice.DrawUserPrimitives<VertexPositionColor>(PrimitiveType.TriangleList, vert, 0, 2);
                n++;

            }
            
            


            effect.View = camera.view;
            effect.Projection = camera.projection;


            base.Draw(gameTime);
        }
    }
}
