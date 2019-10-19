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
        public Layout layout { private set; get; }

        public static SpriteFont spriteFont { private set; get; }

        public UI() { IsVisible = true; IsPress = false; layout = new Layout(); }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
            if (spriteFont == null) spriteFont = spriteFont = YPGame.main.Content.Load<SpriteFont>("SPFont");
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

        public override void Update(YPScene scene)
        {
            layout.LayoutUpdate(scene);
            base.Update(scene);
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
