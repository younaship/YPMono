using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using YPMono;

namespace YPMono
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
        public bool IsActiveSameAnim { set; get; }
        public List<Type> running { private set; get; }

        public Coroutine MoveTo(Vector2 position, float time)
        {
            if (!IsActiveSameAnim && running.Contains(Type.Move)) return null;
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

        /// <summary>
        /// Transform Rotate.( need value is "rad". 360°is 2 * PI.)
        /// </summary>
        public Coroutine RotateTo(float rad, float time)
        {
            if (!IsActiveSameAnim && running.Contains(Type.Rotate)) return null;
            running.Add(Type.Rotate);
            return sceneObject.StartCoroutine(RotateTo_(transform.Rotation, rad, time));
        }

        public Coroutine RotateToByDag(float dag,float time)
        {
            return RotateTo((float)((dag / 360) * 2 * Math.PI), time);
        }

        IEnumerator RotateTo_(float start,float end,float time)
        {
            var t = Time.time;
            while(Time.time < t + time)
            {
                var l = Time.time - t;
                var par = (float)(l / time);
                transform.Rotation = start + par * (end - start);
                Console.WriteLine("par:" + par + " r" + transform.Rotation);
                yield return null;
            }
            transform.Rotation = start + end;
            running.Remove(Type.Rotate);
        }
    }
}
