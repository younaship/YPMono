using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono
{
    public class Time
    {
        public static double time { private set; get; }
        public static double deltaTime { private set; get; }

        static double beforeFrameTime = 0;

        public static void SetGameTime(GameTime gameTime)
        {
            time = gameTime.TotalGameTime.TotalSeconds;
            deltaTime = time - beforeFrameTime;
        }
    }
}
