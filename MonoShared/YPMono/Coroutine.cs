using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using YPMono;

namespace YPMono
{
    public class Coroutine
    {
        public Coroutine(IEnumerator enumerator)
        {
            isEnable = true;
            this.enumerator = enumerator;
        }

        public IEnumerator enumerator { private set; get; }
        public bool isEnable { get; set; }

        public static Coroutine StartCoroutine(YPEvents update,YPEvents lete,IEnumerator enumerator)
        {
            var c = new Coroutine(enumerator);
            c.Next(update, lete);
            return c;
        }

        public void Next(YPEvents updateEvents, YPEvents lateEvents)
        {
            if (!isEnable) return;
            if (!this.enumerator.MoveNext()) return;
            switch (this.enumerator.Current)
            {
                case WaitForSeconds w:
                    Timer timer = new Timer(w.Time);
                    timer.Elapsed += (o, e) =>
                    {
                        Next(updateEvents,lateEvents);
                        timer.Stop();
                        timer.Dispose();
                    };
                    timer.Start();
                    break;
                default:
                    lateEvents.Add((s) => {
                        updateEvents.Add((s_) => Next(updateEvents, lateEvents));
                    });
                    
                    break;
            }
        }

        public static void StopCoroutine(Coroutine coroutine)
        {
            coroutine.isEnable = false;
        }
    }
    

    public class WaitForSeconds
    {
        public float Time { private set; get; }
        public WaitForSeconds(float time)
        {
            this.Time = time;
        }
    }

}
