using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class YPEvents
    {
        public Action<YPScene> actions { private set; get; }

        public void Add(Action<YPScene> action)
        {
            actions += action;
        }

        public void Remove(Action<YPScene> action)
        {
            actions -= action;
        }

        public void Run(YPScene scene)
        {
            actions?.Invoke(scene);
        }

        public void Clear ()
        {
            actions = null;
        }
    }
}
