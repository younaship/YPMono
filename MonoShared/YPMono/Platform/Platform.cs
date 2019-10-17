using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.Platform
{
    public class Platform 
    {
        public enum Type { Android, IOS, Windows }
        public static Type type { get; set; }
        public static IPlatform Current { get; set; }
    }

    public interface IPlatform
    {
       void SetScene(YPScene scene);
    }
}
