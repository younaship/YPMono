using System;
using System.Collections.Generic;
using System.Text;

namespace YPLib
{
    public class TextSizer
    {
        public string Text { get; private set; }
        public int Size { private set; get; }

        public TextSizer(string text)
        {
            this.Text = text;
        }

        private void GetLengh()
        {
            Size = Encoding.GetEncoding(932).GetBytes(Text).Length;
        }
    }
}
