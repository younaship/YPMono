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
            YPGame.main.SetScene(scene);
            scene.OnSceneCreate();
            old.OnSceneDestroy();
        }
    }
}
