using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace YPMono
{
    public class SceneManager
    {
        public static void LoadScene<T>() where T : YPScene , new()
        {
            var old = YPScene.scene;
            var scene = new T();
            Platform.Platform.Current.SetScene(scene);
        }
    }
}
