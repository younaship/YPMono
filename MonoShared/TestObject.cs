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
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(Time.time);
                yield return null;
            }
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine(Time.time);
                yield return new WaitForSeconds(1000);
            }
        }
    }
}
