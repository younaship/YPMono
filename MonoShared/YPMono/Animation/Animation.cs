using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.Animation
{
    public class Animation
    {
        public Animation(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
        }

        public SceneObject sceneObject { set; get; }
    }
}
