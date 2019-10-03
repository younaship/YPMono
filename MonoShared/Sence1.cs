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
                text = "Hello world."
            };
            text.transform.Position = new Vector2(0,0);
            text.transform.Size = new Vector2(300, 100);

            var btn = new Button() { };
            btn.transform.Position = new Vector2(300, 300);
            btn.transform.Size = new Vector2(150, 100);
            btn.onClick += () => {
                text.text = "Clickd.";
            };

            Instantiate(text);
            Instantiate(btn);

            
            /*
            var textButton = new TextButton();
            textButton.Text.text = "HAY";
            textButton.transform.Position = new Vector2(0, 500);
            Instantiate(textButton);*/
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            text.transform.Rotation += 0.1f;
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
