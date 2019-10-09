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
    public partial class SceneObject : Object
    {
        public SceneObject() { Init(); }
        public SceneObject(SceneObject root) { Init(); this.root = root; }
       
        public Transform transform { get; private set; }
        protected bool enableReciveTap = false; // タップを受信するUI

        public SceneObject root { set; get; }
        public List<SceneObject> children { set; get; }
        public List<Component> components { set; get; }

        public YPEvents updateEvents { get; private set; }
        public YPEvents lateUpdateEvents { get; private set; }

        private void Init()
        {
            transform = new Transform(this);
            children = new List<SceneObject>();
            components = new List<Component>();

            updateEvents = new YPEvents();
            lateUpdateEvents = new YPEvents();
        }

        public override void Start(YPScene scene)
        {
            base.Start(scene);
        }

        public override void Update(YPScene scene) {
            base.Update(scene);
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
            foreach (var v in children) v.Update(scene); // Children Object Update Act.
            foreach (var c in components) c.Update(); // Components Update Act.
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

        public void AddComponent<T>(T component)
        {
            var c = component as Component;
            if (c is null) throw new Exception("Error. This is not Component.");
            components.Add(c);
        }

        public void RemoveComponent<T>(T component)
        {
            var c = component as Component;
            if (c is null) return;
            if (components.Contains(c)) components.Remove(c);
        }
    }

}
