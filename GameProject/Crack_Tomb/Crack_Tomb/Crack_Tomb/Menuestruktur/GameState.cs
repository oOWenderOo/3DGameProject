using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MainMenuCo
{
    abstract class GameState //Ist eine Abstrakte Klasse für die Status die das Spiel haben kann
    {
        public abstract void LoadContent(ContentManager Content, GraphicsDeviceManager Graphics);

        public abstract GameState Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, GraphicsDeviceManager Graphics, SpriteBatch SpriteBatch );
    }
}
