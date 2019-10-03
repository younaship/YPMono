#region Using Statements
using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

#endregion

namespace MonoShared
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";	            
            graphics.IsFullScreen = true;		
        }
        
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();
        }
        
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("SPFont");

            //TODO: use this.Content to load your game content here 
        }
         
        protected override void Update(GameTime gameTime)
        {
            var stats = TouchPanel.GetState();
            if (stats.Count > 0) mousePos = stats[0].Position;
            else mousePos = new Vector2(-1, -1);

            // TODO: Add your update logic here			
            base.Update(gameTime);
        }

        Vector2 mousePos;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.DrawString(font, "( "+mousePos.X+" , "+mousePos.Y+" )", new Vector2(10, 10), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            spriteBatch.End();
            //TODO: Add your drawing code here
            
            base.Draw(gameTime);
        }
    }
}
