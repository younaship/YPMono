using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono
{
    public partial class YPScene : BaseGame
    {
        protected YPScene() : base() {
            sceneObjects = new List<SceneObject>();
            backGroundColor = Color.CornflowerBlue;
            activeTapObjects = new Dictionary<int, SceneObject>();

            updateEvents = new YPEvents();
            lateUpdateEvents = new YPEvents();
        }
        
        public Action<SpriteBatch> drawEvents { get; set; }
        public YPEvents updateEvents { get; private set; }
        public YPEvents lateUpdateEvents { get; private set; }

        public List<SceneObject> sceneObjects { private set; get; }
        public Dictionary<int,SceneObject> activeTapObjects { set; get; } // 指を受け取っているオブジェクト(指id,Obj)
        public Color backGroundColor { get; set; }

        bool isFirst = true;
        
        public void Instantiate(SceneObject obj) {
            obj.OnCreate(this);
            sceneObjects.Add(obj);
        }

        public void Destroy(SceneObject obj) {
            obj.OnDestory(this);
            sceneObjects.Remove(obj);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        protected virtual void Start() { }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            Time.SetGameTime(gameTime);
            if (isFirst) { isFirst = false; Start(); }

            updateEvents.Run(this);
            updateEvents.Clear();
            foreach (var obj in sceneObjects) obj.Update(this);
            lateUpdateEvents.Run(this);
            lateUpdateEvents.Clear();

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backGroundColor);
            spriteBatch.Begin();
            drawEvents?.Invoke(spriteBatch);
            drawEvents = null;
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void StartCoroutine(IEnumerator coroutine)
        {
            Coroutine.StartCoroutine(updateEvents, lateUpdateEvents, coroutine);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            Coroutine.StopCoroutine(coroutine);
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
