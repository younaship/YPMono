using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono
{
    public class YPScene : BaseGame
    {

        protected YPScene(): base() {
            SceneObjects = new List<SceneObject>();
            backGroundColor = Color.CornflowerBlue;
            activeTapObjects = new Dictionary<int, SceneObject>();
        }
        
        public Action<SpriteBatch> drawEvents { get; set; }

        public List<SceneObject> SceneObjects { private set; get; }
        public Dictionary<int,SceneObject> activeTapObjects { set; get; } // 指を受け取っているオブジェクト(指id,Obj)
        public Color backGroundColor { get; set; }

        protected GameTime updateTime { set; get; }

        public void Instantiate(SceneObject obj) {
            obj.OnCreate(this);
            SceneObjects.Add(obj);
        }

        public void Destroy(SceneObject obj) {
            obj.OnDestory(this);
            SceneObjects.Remove(obj);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            Start();
        }

        protected virtual void Start() { }

        protected override void Update(GameTime gameTime)
        {
            updateTime = gameTime;
            foreach (var obj in SceneObjects) obj.Update(this);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backGroundColor);
            spriteBatch.Begin();
            drawEvents?.Invoke(spriteBatch);;
            drawEvents = null;
            spriteBatch.End();
            base.Draw(gameTime);
        }

        
    }

    public class BaseGame : Game
    {
        protected BaseGame() {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
        }

        protected GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
#endif
            base.Update(gameTime);
        }
    }
}
