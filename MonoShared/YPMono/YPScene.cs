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
    public partial class YPScene
    {
        protected YPScene(){
            scene = this;
            sceneObjects = new List<SceneObject>();
            backGroundColor = Color.CornflowerBlue;
            activeTapObjects = new Dictionary<int, SceneObject>();

            updateEvents = new YPEvents();
            lateUpdateEvents = new YPEvents();
        }

        public static YPScene scene { get; private set; }
        
        public Action<SpriteBatch> drawEvents { get; set; }
        public YPEvents updateEvents { get; private set; }
        public YPEvents lateUpdateEvents { get; private set; }

        public List<SceneObject> sceneObjects { private set; get; }
        public TouchCollection touchLocations { get; private set; } // Touch.GetState();
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

        public virtual void Start() { }

        public virtual void Update(GameTime gameTime)
        {
            Time.SetGameTime(gameTime);
            touchLocations = TouchPanel.GetState();

            if (isFirst) { isFirst = false; Start(); }

            updateEvents.Run(this);
            updateEvents.Clear();
            foreach (var obj in sceneObjects) obj.Update(this);
            lateUpdateEvents.Run(this);
            lateUpdateEvents.Clear();

        }

        public virtual void Draw(GameTime gameTime)
        {
            YPGame.main.GraphicsDevice.Clear(backGroundColor);
            YPGame.main.spriteBatch.Begin();
            drawEvents?.Invoke(YPGame.main.spriteBatch);
            drawEvents = null;
            YPGame.main.spriteBatch.End();
        }

        public void StartCoroutine(IEnumerator coroutine)
        {
            Coroutine.StartCoroutine(updateEvents, lateUpdateEvents, coroutine);
        }

        public void StopCoroutine(Coroutine coroutine)
        {
            Coroutine.StopCoroutine(coroutine);
        }

        public virtual void OnSceneCreate() { } // Scene already seted.
        public virtual void OnSceneDestroy() { } // Scene already closed and new scene is seted.
    }

    public class YPGame : Game
    {
        public static YPGame main { private set; get; }
        protected GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch { private set; get; }
        public YPScene scene { private set; get; }

        public YPGame(YPScene scene) {
            main = this;
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = true;
            this.scene = scene;
        }

        protected override void LoadContent()
        {
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
            scene.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            scene.Draw(gameTime);
        }

        public void SetScene(YPScene scene)
        {
            this.scene = scene;
        }
    }
}
