using System;
using System.Collections;
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
    class Scene1 : YPScene
    {
        Text text;

        public override void Start()
        { 
            text = new Text()
            {
                text = "Hello world!\nPlease press Button."
            };
            text.transform.Position = new Vector2(200, 200);
            text.transform.Size = new Vector2(300, 100);

            var anim = new TransAnim(text);
            text.AddComponent(anim);

            Instantiate(text);

            var textButton = new TextButton();
            textButton.Text.text = "OK";
            textButton.transform.Position = new Vector2(350, 350);
            textButton.transform.Size = new Vector2(300, 100);
            textButton.onClick += () =>
            {
                text.text = "Clickd.";
                anim.RotateToByDag(720, 1);
            };

            Instantiate(textButton);

            var textButton2 = new TextButton();
            textButton2.Text.text = "OK 2";
            textButton2.transform.Position = new Vector2(350, 500);
            textButton2.transform.Size = new Vector2(300, 100);

            textButton2.onClick += () => {
                Console.WriteLine("2 pushed");              
                SceneManager.LoadScene<Scene2>();
            };

            Instantiate(textButton2);

            
            var image = new ImageButton();
            image.transform.Position = new Vector2(100, 100);
            image.transform.Size = new Vector2(200, 200);
            image.texture = TextureLoader.GetFromContent("oekaki");

            Instantiate(image);/**/
            Instantiate(new TestObject());
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           // text.transform.Rotation += 0.1f;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
         
    }
}
