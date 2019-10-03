using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace YPMono
{
    public class YPMono
    {
        public static void Invoke(Action action,float time,bool isRepeat)
        {
            Timer timer = new Timer(time);
            timer.Elapsed += (o, e) =>
            {
                action?.Invoke();
            };
            timer.Start(); 

        }
    }
}
