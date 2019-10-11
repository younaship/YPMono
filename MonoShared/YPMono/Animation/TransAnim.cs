using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using YPMono;

namespace YPMono.Animation
{
    public class TransAnim : Animation
    {
        public enum Type { Move, Rotate }
        public TransAnim(SceneObject sceneObject) : base(sceneObject)
        {
            this.transform = sceneObject.transform;
            running = new List<Type>();
        }

        public Transform transform { private set; get; }
        public List<Type> running { private set; get; }

        public Coroutine MoveTo(Vector2 position, float time)
        {
            running.Add(Type.Move);
            return sceneObject.StartCoroutine(MoveTo_(transform.Position, position, time));       
        }

        IEnumerator MoveTo_(Vector2 start,Vector2 end,float time)
        {
            var t = Time.time;
            while (Time.time < t + time)
            {
                var l = Time.time - t;
                var par = (float)(l / time);
                transform.Position = Vector2.Lerp(start, end, par);
                yield return null;
            }
            transform.Position = end;
            running.Remove(Type.Move);
        }

        public Coroutine RotateTo(float rad,float time)
        {
            running.Add(Type.Rotate);
            return sceneObject.StartCoroutine(RorateTo_(transform.Rotation, rad, time));
        }

        IEnumerator RorateTo_(float start,float end,float time)
        {
            var t = Time.time;
            while(Time.time < t + time)
            {
                var l = Time.time - t;
                var par = (float)(l / time);
                transform.Rotation = start + par * (end - start);
                yield return null;
            }
            transform.Rotation = start + end;
            running.Remove(Type.Rotate);
        }
    }
}
