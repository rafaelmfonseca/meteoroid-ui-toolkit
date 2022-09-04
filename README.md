meteoroid-ui-toolkit
===
Created by Rafael Moreira Fonseca

<p align="center">
    <a href="https://github.com/rafaelmfonseca/meteoroid-ui-toolkit/blob/master/LICENSE"><img src="https://img.shields.io/badge/License-MIT-brightgreen.svg" /></a>
    <a href="https://unity3d.com/get-unity/download"><img src="https://img.shields.io/badge/unity-2021.2%2B-blue.svg" /></a>
</p>

<p align="center">
    <a href="https://github.com/rafaelmfonseca/meteoroid-ui-toolkit/issues"><img src="https://img.shields.io/github/issues-raw/rafaelmfonseca/meteoroid-ui-toolkit" /></a>
    <a href="https://github.com/rafaelmfonseca/meteoroid-ui-toolkit/releases"><img src="https://img.shields.io/github/downloads/rafaelmfonseca/meteoroid-ui-toolkit/total" /></a>
    <a href="https://github.com/rafaelmfonseca/meteoroid-ui-toolkit"><img src="https://img.shields.io/github/stars/rafaelmfonseca/meteoroid-ui-toolkit" /></a>
    <a href="https://github.com/rafaelmfonseca/meteoroid-ui-toolkit"><img src="https://img.shields.io/github/forks/rafaelmfonseca/meteoroid-ui-toolkit" /></a>
</p>

## Installation
1. Add the following line to your `Packages/manifest.json`:
```json
{
    "dependencies": {
        "com.pixel.meteoroid.ui.toolkit": "https://github.com/rafaelmfonseca/meteoroid-ui-toolkit.git",
    }
}
```

## Getting Started


``` cs

public class MainMenuPage : MonoBehaviour
{
    public class MainMenuPageContainer : Container
    {
        private readonly State<Vector2> _position = new State<Vector2>();

        public MainMenuPageContainer()
        {
            Body = () => new Box
            {
                Anchor = AnchorPresets.StretchAll,
                Pivot = PivotPresets.StretchAll,
                Padding = new Padding(10f, 20f, 30f, 40f),

                Children = new[]
                {
                    new Box
                    {
                        Anchor = AnchorPresets.TopLeft,
                        Pivot = PivotPresets.TopLeft,
                        Size = new Vector2(100f, 200f),
                        Position = _position,
                        Children = new[]
                        {
                            new Drawable()
                            {
                                Sprite = Resources.Load<Sprite>("blocks"),
                                Anchor = AnchorPresets.StretchAll,
                                Pivot = PivotPresets.StretchAll,

                                RaycastTarget = false,
                                RaycastPadding = new Padding(1, 2, 3, 4),
                                Maskable = false,
                            }
                        }
                    },
                    new Box
                    {
                        Anchor = AnchorPresets.TopStretch,
                        Pivot = PivotPresets.TopStretch,
                        Position = new Vector2(0f, 20f),
                        Size = new Vector2(0f, 200f),
                        Padding = new Padding(10f, 0f, 30f, 0f),
                    }
                }
            };
        }
    }

    void Start()
    {
        MeteoroidUI.Render<MainMenuPageContainer>(this.gameObject);
    }
}
```