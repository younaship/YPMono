using Microsoft.Xna.Framework;
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

            
            var layoutA = new LayoutGroup(LayoutGroup.Type.Vertical);
            layoutA.Add(new TextButton().Set<TextButton>((x) =>
            {
                x.layout.margin = new Margin(30);
                x.Text.text = "1";
            }));

            layoutA.Add(new TextButton().Set<TextButton>((x) =>
            {
                x.layout.margin = new Margin(30);
                x.Text.text = "2";
                x.onClick += () => SceneManager.LoadScene<Scene1>();
            })); /**/

            var layoutB = new LayoutGroup(LayoutGroup.Type.Horizontal);
            layoutB.Add(layoutA);

            layoutB.Add(new Image().Set<Image>((x) =>
            {
                x.transform.Size = new Vector2(300, 300);
                x.texture = TextureLoader.GetFromContent("oekaki");
                x.layout.margin = new Margin(30);
            }));

            layoutB.Add(new Image().Set<Image>((x) =>
            {
                x.transform.Size = new Vector2(200, 200);
                x.texture = TextureLoader.GetFromContent("oekaki");
                x.layout.margin = new Margin(30);
            })); 

            Instantiate(layoutB);
        }
    }
}
