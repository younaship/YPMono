using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono.YPGUI
{
    public class Image : UI
    {
        public Texture2D texture { get; set; }
        public Color color { get; set; }

        public Image()
        {
            color = Color.Gray;
        }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);

            if (IsVisible && texture != null)
                scene.drawEvents += (x) =>
                {
                    Rectangle rectangle = new Rectangle(transform.Position.ToPoint(), transform.Size.ToPoint());
                    /* Rectangle rectangle = new Rectangle(Point.Zero, transform.Size.ToPoint());
                       x.Draw(texture, transform.Position, rectangle, color, transform.Rotation, transform.GetCenterPosition()
                         , transform.Scale, SpriteEffects.None, 0); */
                    x.Draw(texture, rectangle, color);
                };
        }

    }
}