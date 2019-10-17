using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Input
    {
        public int touchCount { get { return YPScene.scene.touchLocations.Count; } }
        public TouchLocation[] touches { get { return GetTouches(); } }
        public Vector2 mousePosition { get { return Mouse.GetState().Position.ToVector2(); } }

        TouchLocation[] GetTouches()
        {
            var l = YPScene.scene.touchLocations;
            TouchLocation[] t = new TouchLocation[l.Count];
            for (int i = 0; i < t.Length; i++)
                t[i] = l[i];
            return t;
        }

    }
}
