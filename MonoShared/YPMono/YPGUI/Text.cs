using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace YPMono.YPGUI
{
    public class Text : UI
    {
        const int FONT_SIZE_PIXEL = 36;

        public Text() { text = ""; color = Color.White; }
        
        public string text { get; set; }
        public Color color { get; set; }

        public Vector2 Center { get; }

        Vector2 tmpTextSize;
        string tmpText;
        public Vector2 GetTextSize()
        {
            if (tmpText == text) return tmpTextSize;
            tmpText = text;
            tmpTextSize = spriteFont.MeasureString(tmpText);
            return tmpTextSize;
        }    


        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);

            scene.drawEvents += (x) => {
                x.DrawString(spriteFont, text, this.transform.Position + GetTextCenter(), color,
                    this.transform.Rotation, GetTextCenter(), this.transform.Scale, SpriteEffects.None, 0); // TopLeft
            };
            
        }

        public Vector2 GetTextCenter()
        {
            var size = GetTextSize();
            return new Vector2(size.X / 2, size.Y / 2);
        }

        protected override void OnTapEvent(YPScene scene, TouchLocation touch, bool isOn)
        {
            base.OnTapEvent(scene, touch, isOn);
            Console.WriteLine("Event:" + touch.State + " On " + isOn + " IsPress " + IsPress);

        }
    }

    class TextSizer
    {
        public string Text { get; private set; }
        public int Size { private set; get; }

        public TextSizer(string text)
        {
            Set(text);
        }

        public void Set(string text)
        {
            this.Text = text;
            GetLengh();
        }

        private void GetLengh()
        {
            Size = Encoding.GetEncoding(932).GetBytes(Text).Length;
        }
    }
}
