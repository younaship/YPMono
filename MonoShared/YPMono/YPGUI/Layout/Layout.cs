using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace YPMono.YPGUI //.Layout
{
    public class Layout
    {
        public Margin margin;

        public void LayoutUpdate(YPScene scene)
        {

        }
    }

    public class LayoutGroup : SceneObject
    {
        public enum Type { Horizontal }
        public LayoutGroup()
        {
            DynamicLayout = true;
        }
        /// <summary>
        /// 子オブジェクトの動的サイズ変更に対応します。
        /// </summary>
        public bool DynamicLayout { set; get; }
        public Type type { set; get; }

        int childCount = 0;
        bool isChanged = true;

        public override void Update(YPScene scene)
        {
            if (children.Count != childCount)
            {
                isChanged = true;
                childCount = children.Count;
            }
            if (isChanged || DynamicLayout) 
            {
                switch (type) {
                    case Type.Horizontal:
                        Horizontal();
                        break;
                }
            }
            base.Update(scene);
        }

        void Horizontal()
        {
            float nx = 0, maxY = 0;
            foreach (var obj in children)
            {
                UI ui = obj as UI;
                if (ui is null) continue;
                var m = ui.layout.margin;

                ui.transform.Position =
                    new Vector2(ui.transform.Position.X + nx + m.left, ui.transform.Position.Y + m.top);
                nx += m.width + ui.transform.Size.X;
                if (maxY < m.height + ui.transform.Position.Y) maxY = m.height + ui.transform.Position.Y;
            }

            this.transform.Size = new Vector2(nx, maxY);
        }
    }

    public struct Margin
    {
        public float top, bottom, left, right;
        public float width { get { return left + right; } }
        public float height { get { return top + bottom; } }

        public Margin(float vertical, float horizontal) // y , x
        {
            top = horizontal / 2;
            bottom = top;
            right = vertical / 2;
            left = right;
        }

        public Margin(float top, float right, float bottom, float left)
        {
            this.top = top;
            this.right = right;
            this.bottom = bottom;
            this.left = left;
        }

        public static Margin Zero { get { return new Margin(0, 0); } }
    }
}
