using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.YPGUI
{
    public class TextButton : UI
    {
        public TextButton()
        {
            this.Button = new Button();
            this.Button.transform.Size = new Vector2(300, 100);
            this.Text = new Text();
            this.Text.transform.Size = new Vector2(300, 100);
            this.Text.root = this.Button;
        }

        public Text Text { set; get; }
        public Button Button { set; get; }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);
            Button.OnCreate(scene);
            Text.OnCreate(scene);
        }

        public override void Start(YPScene scene)
        {
            base.Start(scene);
            Button.Start(scene);
            Text.Start(scene);
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);
            Button.Update(scene);
            Text.Update(scene);
        }

        public override void OnDestory(YPScene scene)
        {
            base.OnDestory(scene);
            Button.OnDestory(scene);
            Text.OnDestory(scene);
        }
    }
}
