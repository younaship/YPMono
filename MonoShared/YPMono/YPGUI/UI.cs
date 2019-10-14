using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono.YPGUI
{
    public class UI : SceneObject
    {
        public bool IsVisible { set; get; }
        public bool IsPress { private set; get; }
        public static SpriteFont spriteFont { private set; get; }

        public UI() { IsVisible = true; IsPress = false; }

        public override void OnCreate(YPScene scene)
        {
            if (spriteFont == null) spriteFont = spriteFont = scene.Content.Load<SpriteFont>("SPFont");
            base.OnCreate(scene);
        }

        protected override void OnTapEvent(YPScene scene, TouchLocation touch, bool isOn)
        {
            if (touch.State == TouchLocationState.Pressed || touch.State== TouchLocationState.Moved) IsPress = true; 
            else IsPress = false;

            if (IsPress && isOn) OnHover();
            if (touch.State == TouchLocationState.Released)
            {
                if (isOn) OnClick();
            }
        }

        protected virtual void OnClick()
        {
        }

        protected virtual void OnHover()
        {
        }

    }

    public delegate void GUIEventHundler();
}
