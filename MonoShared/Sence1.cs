using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

using YPMono;
using YPMono.YPGUI;

namespace MonoShared
{
    class Sence1 : YPScene
    {
        Text text;

        protected override void Start()
        {
            
            text = new Text()
            {
                text = "Hello world!\nPlease press Button."
            };
            text.transform.Position = new Vector2(0,0);
            text.transform.Size = new Vector2(300, 100);

            Instantiate(text);
   
            var textButton = new TextButton();
            textButton.Text.text = "OK";
            textButton.transform.Position = new Vector2(350, 350);
            textButton.transform.Size = new Vector2(300, 100);
            textButton.onClick += () =>
            {
                text.text = "Clickd.";
            };

            Instantiate(textButton);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           // text.transform.Rotation += 0.1f;
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
