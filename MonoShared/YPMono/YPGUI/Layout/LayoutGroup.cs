using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace YPMono.YPGUI
{
    public class LayoutGroup : UI
    {
        public enum Type { Horizontal,Vertical }

        public LayoutGroup() { Init(); }

        public LayoutGroup(Type type)
        {
            Init();
            this.type = type;
        }

        private void Init()
        {
            this.type = type;
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
                switch (type)
                {
                    case Type.Horizontal:
                        Horizontal();
                        break;
                    case Type.Vertical:
                        Vertical();
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
                    new Vector2(this.transform.Position.X + nx + m.left, this.transform.Position.Y + m.top);
                nx += m.width + ui.transform.Size.X;
                if (maxY < m.height + ui.transform.Size.Y) maxY = m.height + ui.transform.Size.Y;
            }

            this.transform.Size = new Vector2(nx, maxY);
        }

        void Vertical()
        {
            float ny = 0, maxX = 0;
            foreach (var obj in children)
            {
                UI ui = obj as UI;
                if (ui is null) continue;
                var m = ui.layout.margin;

                ui.transform.Position =
                    new Vector2(this.transform.Position.X + m.left, this.transform.Position.Y + m.top + ny);
                ny += m.height + ui.transform.Size.Y;
                if (maxX < m.width + ui.transform.Size.X) maxX = m.width + ui.transform.Size.X;
            }

            this.transform.Size = new Vector2(ny, maxX);
        }
    }
}
