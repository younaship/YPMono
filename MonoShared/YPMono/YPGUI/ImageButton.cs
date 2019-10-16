using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.YPGUI
{
    public class ImageButton : UI
    {
        public GUIEventHundler onClick { set; get; }
        public GUIEventHundler onHover { set; get; }

        public Color DefaultColor { set; get; }
        public Color HoverColor { set; get; }

        public Texture2D texture { set; get; }

        public ImageButton()
        {
            enableReciveTap = true;
            DefaultColor = Color.White;
            HoverColor = Color.DarkGray;
            
        }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
        }

        public override void Start(YPScene scene)
        {
            base.Start(scene);
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);

            if (IsVisible)
                scene.drawEvents += (x) =>
                {
                    if (IsPress) x.Draw(texture, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), HoverColor);
                    else x.Draw(texture, new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint()), DefaultColor);
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
    }
    
}
