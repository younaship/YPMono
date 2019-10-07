using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using YPMono;

namespace MonoShared.YPMono
{
    public class Coroutine : IEnumerator
    {
        public Coroutine(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
        }

        public SceneObject sceneObject { private set; get; }
        public Action action { private set; get; }
        public object Current => this;

        public void StartCoroutine(Action action)
        {
            this.action = action;
        }

        public bool MoveNext()
        {
            action?.Invoke();
            return true;
        }

        public void Reset()
        {
            
        }
    }
    

    public class WaitForSeconds
    {
        public float Time { private get; set; }
        public WaitForSeconds(float time)
        {
            this.Time = time;
        }
    }

    public class Test : SceneObject
    {
        public void StartCoroutine(IEnumerator coroutine)
        {
            coroutine.MoveNext();
        }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
            StartCoroutine(enumerator());
        }

        IEnumerator enumerator()
        {
            yield return null;
        }
    }

}
