﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

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
        public Vector2 Position; //{ set { SetPositon(value); } get { return GetPosition(); } }
        public Vector2 LocalPosition { set; get; }
        public Vector2 Size;
        public float Scale;
        public float Rotation;

        public Vector2 GetCenterPosition()
        {
            return new Vector2(Position.X + (Size.X / 2), Position.Y + (Size.Y / 2));
        }
        
        private Vector2 GetPosition()
        {
            if (sceneObject.root != null) return GetAbsPosition(sceneObject.transform.Position, LocalPosition);
            return LocalPosition;
        }
        private void SetPositon(Vector2 pos)
        {
            if (sceneObject.root != null) this.Position = GetAbsPosition(sceneObject.transform.Position, pos);
            else this.LocalPosition = pos;
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
