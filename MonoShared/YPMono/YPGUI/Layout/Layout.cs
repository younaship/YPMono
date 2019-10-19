using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace YPMono.YPGUI //.Layout
{
    public class Layout
    {
        public Margin margin;

        public void LayoutUpdate(YPScene scene)
        {

        }
    }

    public struct Margin
    {
        public float top, bottom, left, right;
        public float width { get { return left + right; } }
        public float height { get { return top + bottom; } }

        public Margin(float margin)
        {
            top = margin;
            bottom = margin;
            right = margin;
            left = margin;
        }

        public Margin(float vertical, float horizontal) // y , x
        {
            top = horizontal / 2;
            bottom = top;
            right = vertical / 2;
            left = right;
        }

        public Margin(float top, float right, float bottom, float left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        public static Margin Zero { get { return new Margin(0, 0); } }
    }
}
