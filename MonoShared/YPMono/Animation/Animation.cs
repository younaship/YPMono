using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Animation : Component
    {

        public Animation(SceneObject sceneObject) : base(sceneObject)
        {
            this.sceneObject = sceneObject;
        }
        
    }
}
