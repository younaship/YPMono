using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono.YPGUI
{
    public class Button : UI
    {
        const byte HOVER_DARK_RANGE = 30;
        protected Texture2D tex;

        public GUIEventHundler onClick { set; get; }
        public GUIEventHundler onHover { set; get; }

        public Color BackColor { set; get; }
        public Color? HoverColor { set; get; }

        public static Vector2 DefaultSize { get { return new Vector2(320, 80); } }

        public Button()
        {
            enableReciveTap = true;
            BackColor = Color.Gray;
            HoverColor = null;

            transform.Size = DefaultSize;
        }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);

            tex = new Texture2D(YPGame.main.GraphicsDevice, 1, 1);
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
            Color hoverColor = HoverColor ?? GetToDark(BackColor);
            
            if (IsVisible)
                scene.drawEvents += (x) =>
                {
                    if (IsPress) x.Draw(tex, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), hoverColor);
                    else x.Draw(tex, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), BackColor);
                };
            
        }
        

        /// <summary>
        /// This act is before Update();
        /// </summary>
        protected override void OnClick()
        {
            base.OnClick();
            onClick?.Invoke();
        }

        /// <summary>
        /// This act is before Update();
        /// </summary>
        protected override void OnHover()
        {
            base.OnHover();
            onHover?.Invoke();
        }

        Color GetToDark(Color color)
        {
            return new Color(AddDark(color.R), AddDark(color.G), AddDark(color.B), color.A);
        }

        byte AddDark(byte val)
        {
            var v = val - HOVER_DARK_RANGE;
            if (v < 0) v = 0;
            return (byte)v;
        }
    }

    
}
