using System;
using System.Collections.Generic;
using System.Text;
using YPMono;
using YPMono.YPGUI;

namespace MonoShared
{
    public class Scene2 : YPScene
    {
        protected override void Start()
        {
            base.Start();
            Instantiate(new TextButton().Set<TextButton>((x) =>
            {
                x.transform.Size = new Microsoft.Xna.Framework.Vector2(300, 50);
                x.Text.text = "OK";
            }));
            
        }
    }
}
