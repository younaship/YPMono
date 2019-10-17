using System;
using System.Collections.Generic;
using System.Text;
using YPMono;
using YPMono.YPGUI;

namespace MonoShared
{
    public class Scene2 : YPScene
    {
        public override void Start()
        {
            base.Start();
            Instantiate(new TextButton().Set<TextButton>((x) =>
            {
                x.transform.Position = new Microsoft.Xna.Framework.Vector2(100, 100);
                x.transform.Size = new Microsoft.Xna.Framework.Vector2(300, 100);
                x.Text.text = "OK";
                x.onClick += () => SceneManager.LoadScene<Sence1>();
            }));
            
        }
    }
}
