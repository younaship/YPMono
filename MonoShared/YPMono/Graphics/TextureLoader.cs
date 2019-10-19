using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YPMono;

namespace YPMono
{
    public class TextureLoader
    {
        public static Texture2D GetFromContent(string path)
        {
            var tex = YPGame.main.Content.Load<Texture2D>(path);
            if (tex is null) throw new Exception("Load Texture Missing.");
            return tex;
        }

        public static Texture2D GetFromFile(Stream stream)
        {
            var tex = Texture2D.FromStream(YPGame.main.GraphicsDevice, stream);
            if (tex is null) throw new Exception("Load Texture Missing.");
            return tex;
        }
    }
}
