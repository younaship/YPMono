using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.YPGUI
{
    public class TextButton : Button
    {
        public TextButton()
        {
            this.Text = new Text();
            this.Text.pivot = PivotPoint.Center;
            this.Text.root = this;
        }

        public Text Text { set; get; }

        public override void OnCreate(YPScene scene)
        {
            base.OnCreate(scene);

            this.Text.transform.Size = this.transform.Size;
            scene.Instantiate(Text);
            Text.OnCreate(scene);
        }

        public override void Start(YPScene scene)
        {
            base.Start(scene);
            Text.Start(scene);
        }

        public override void Update(YPScene scene)
        {
            base.Update(scene);
            Text.Update(scene);
        }

        public override void OnDestory(YPScene scene)
        {
            base.OnDestory(scene);
            Text.OnDestory(scene);
        }
    }
}
