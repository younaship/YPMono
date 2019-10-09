using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Component
    {
        public Component(SceneObject sceneObject)
        {
            this.sceneObject = sceneObject;
        }
        
        public SceneObject sceneObject { protected set; get; }

        public virtual void Start() { }
        public virtual void Update() { }

        public static Component Create(SceneObject sceneObject)
        {
            return new Component(sceneObject);
        }
    }
}
