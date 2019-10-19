using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Object
    {
        public string Name { private set; get; }

        public virtual void OnCreate(YPScene scene) { }
        public virtual void OnDestory(YPScene scene) { }

        bool isFirst = true;
        public virtual void Start(YPScene scene)
        {
            isFirst = false;
        }
        public virtual void Update(YPScene scene)
        {
            if (isFirst) Start(scene);
        }

    }

    public class ExList<T> : List<T>
    {
        public new void Add(T item)
        {
            base.Add(item);
        }
    }
}
