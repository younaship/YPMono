using System;
using System.Collections;
using System.Text;

using YPMono;
using YPMono.YPGUI;

namespace MonoShared
{
    public class TestObject : SceneObject
    {
        public override void Start(YPScene scene)
        {
            base.Start(scene);

            StartCoroutine(enumerator(scene));
        }

        IEnumerator enumerator(YPScene yPScene)
        {
            for(int i = 0; i < 33; i++)
            {
                Console.WriteLine("[" + i + "] " + yPScene.updateTime.TotalGameTime);
                yield return null;
            }
            while (true)
            {
                Console.WriteLine("HEY");
                yield return new WaitForSeconds(1000);
            }
        }
    }
}
