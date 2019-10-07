using System;
using System.Collections.Generic;
using System.Text;
using YPMono;

namespace YPMono.Animation
{
    public class TransAnim : Animation
    {
        public TransAnim(SceneObject sceneObject) : base(sceneObject)
        {
            this.transform = sceneObject.transform;
        }

        public Transform transform { set; private get; }

        public void MoveTo()
        {
            
        }
    }
}
