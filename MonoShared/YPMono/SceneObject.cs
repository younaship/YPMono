using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono
{
    public partial class SceneObject
    {
        public SceneObject() { Init(); }
        public SceneObject(SceneObject root) { Init(); this.root = root; }
       
        public Transform transform { get; private set; }
        public string Name { private set; get; }
        protected bool enableReciveTap = false; // タップを受信するUI

        public SceneObject root { set; get; }
        public List<SceneObject> Children { set; get; }

        public YPEvents updateEvents { get; private set; }
        public YPEvents lateUpdateEvents { get; private set; }

        public virtual void OnCreate(YPScene scene) { }
        public virtual void OnDestory(YPScene scene) { }

        private void Init()
        {
            transform = new Transform(this);
            Children = new List<SceneObject>();

            updateEvents = new YPEvents();
            lateUpdateEvents = new YPEvents();
        }

        bool isFirst = true;
        public virtual void Start(YPScene scene) {
            isFirst = false;
        }

        public virtual void Update(YPScene scene) {
            if (isFirst) Start(scene);
            if (enableReciveTap)
            {
                var stats = TouchPanel.GetState();
                foreach (var v in stats)
                    if (scene.activeTapObjects.ContainsKey(v.Id))
                    {
                        if (this.transform.GetOnPosition(v.Position)) OnTapEvent(scene, v, true);
                        else OnTapEvent(scene, v, false);
                        if (v.State == TouchLocationState.Invalid || v.State == TouchLocationState.Released) scene.activeTapObjects.Remove(v.Id);
                    }
                    else if (v.State == TouchLocationState.Pressed && this.transform.GetOnPosition(v.Position))
                    {
                        scene.activeTapObjects.Add(v.Id, this);
                        OnTapEvent(scene, v, true);
                    }
            }

            updateEvents.Run(scene);
            updateEvents.Clear();
            foreach (var v in Children) v.Update(scene); // Children Object Update Act.
            lateUpdateEvents.Run(scene);
            lateUpdateEvents.Clear();

        }

        /// <summary>
        /// タップイベントをオーバライドできます。
        /// </summary>
        protected virtual void OnTapEvent(YPScene scene, TouchLocation touch, bool isOnObject)
        {

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

}
