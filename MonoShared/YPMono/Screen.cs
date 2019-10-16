using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Screen
    {
        public int height { get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; } }
        public int width { get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; } }
    }
}
