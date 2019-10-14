using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono.YPGUI
{
    public class Button : UI
    {
        Texture2D tex;

        public GUIEventHundler onClick { set; get; }
        public GUIEventHundler onHover { set; get; }

        public Color BackColor { set; get; }
        public Color HoverColor { set; get; }

        public Button()
        {
            enableReciveTap = true;
            BackColor = Color.Gray;
            HoverColor = Color.DarkGray;
        }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);

            tex = new Texture2D(scene.GraphicsDevice, 1, 1);
            tex.SetData<Color>(new Color[] { Color.White });
        }

        public override void Start(YPScene scene)
        {
            base.Start(scene);
            scene.drawEvents += (x) =>
            {
                x.Draw(tex, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), BackColor);
            };
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);

            if (IsVisible)
                scene.drawEvents += (x) =>
                {
                    if (IsPress) x.Draw(tex, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), HoverColor);
                    else x.Draw(tex, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), BackColor);
                };
            
        }

        protected override void OnTapEvent(YPScene scene, TouchLocation touch, bool isOn)
        {
            base.OnTapEvent(scene, touch, isOn);

        }

        protected override void OnClick()
        {
            base.OnClick();
            onClick?.Invoke();
        }

        protected override void OnHover()
        {
            base.OnHover();
            onHover?.Invoke();
        }
    }

    
}
