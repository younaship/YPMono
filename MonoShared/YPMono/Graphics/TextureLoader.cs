using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YPMono;

namespace YPMono.Graphics
{
    public class TextureLoader
    {
        public static Texture2D GetFromContent(string path)
        {
            return YPScene.scene.Content.Load<Texture2D>(path);
        }

        public static Texture2D GetFromFile(Stream stream)
        {
            return Texture2D.FromStream(YPScene.scene.GraphicsDevice, stream);
        }
    }
}
