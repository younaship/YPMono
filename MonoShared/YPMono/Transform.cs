using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

using YPMono.Animation;

namespace YPMono
{
    public class Transform
    {
        public Transform(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
            Pivot = PivotPoint.TopLeft;
            Scale = 1;
        }

        public SceneObject sceneObject { private set; get; }
        /// <summary>
        /// Can use only "TopLeft" now.
        /// </summary>
        public PivotPoint Pivot { set; get; }
        public Vector2 Position { set { SetPositon(value); } get { return GetPosition(); } }
        public Vector2 LocalPosition { set; get; }
        public Vector2 Size;
        public float Scale;
        float rotation;
        public float Rotation { get { return rotation; } set{ SetRotation(value); } }

        public TransAnim transAnim { get; set; }

        public Vector2 GetCenterPosition()
        {
            return new Vector2(Position.X + (Size.X / 2), Position.Y + (Size.Y / 2));
        }

        public Vector2 GetHalfSize()
        {
            return new Vector2(Size.X / 2, Size.Y / 2);
        }
        
        private Vector2 GetPosition()
        {
            if (sceneObject.root != null) return GetAbsPosition(sceneObject.root.transform.Position, LocalPosition);
            return LocalPosition;
        }
        private void SetPositon(Vector2 pos)
        {
            if (sceneObject.root != null) this.LocalPosition = GetAbsPosition(sceneObject.root.transform.Position, pos);
            else this.LocalPosition = pos;
        }

        private void SetRotation(float rotation)
        {

            if ((rotation > 2 * Math.PI) || (rotation < -2 * Math.PI))
                this.rotation = (float)(rotation % (Math.PI * 2));
            else
                this.rotation = rotation;

            if (Math.Abs(this.rotation) < 0.001f) this.rotation = 0f;

        }

        /// <summary>
        /// Vector2(pos)上にこのTransformがあるかチェックします
        /// </summary>
        /// <returns></returns>
        public bool GetOnPosition(Vector2 pos)
        {
            if (Position.X <= pos.X && Position.X + Size.X >= pos.X)
                if (Position.Y <= pos.Y && Position.Y + Size.Y >= pos.Y)
                    return true;
            return false;
        }
        
        public static Vector2 GetAbsPosition(Vector2 root,Vector2 child)
        {
            return child + root;
        }
    }

    public enum PivotPoint
    {
        TopLeft, Center, TopRight
    }
}
