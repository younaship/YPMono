# YPMono
MonoGameをUnity風に扱えるようにするためのライブラリ。  
(19/10/01 : 開発開始)

## 例
ボタンをクリックするとメッセージが変わるだけの簡単なサンプル
```
    class Sence1 : YPScene
    {
        protected override void Start()
        {
            Text text = new Text()
            {
                text = "Hello world."
            };
            text.transform.Position = new Vector2(0,0);
            text.transform.Size = new Vector2(300, 100);

            var btn = new Button() { };
            btn.transform.Position = new Vector2(300, 300);
            btn.transform.Size = new Vector2(200, 100);
            btn.onClick += () => { text.text = "Button Clickd."; };

            Instantiate(text);
            Instantiate(btn);
        }
    }
```

テキストが移動するだけの簡単なサンプル
```
    class Sence1 : YPScene
    {
        Text text;
        protected override void Start()
        {
            text = new Text()
            {
                text = "Hello World."
            };
            text.transform.Position = new Vector2(0,0);
            text.transform.Size = new Vector2(300, 100);

            Instantiate(text);
        }
        
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(text.transform.Position.X < 500) text.transform.Position.X += 0.1f;
        }

```
