#region Includes

using SFML.Graphics;
using SFML.System;
using System.Collections.Generic;

#endregion

internal class Game : GameEngine
{
    public ClientInstance Instance = ClientInstance.Instance;

    public Game()
    {
        // lets add some test objects

        { // text
            Instance.Level.children.Add(new SolidText()
            {
                Position = new Vector2f(10, 10),
                Size = 16,
                Color = Color.Blue,
                Font = Instance.FontRepos.GetFont("Arial"),
                Text =
                    $"0ms\r\n" +
                    $"0/0\r\n",
                Tags = { "FpsCounter" }
            });

            Instance.Level.children.Add(new SolidText()
            {
                Position = new Vector2f(10, 10),
                Size = 16,
                Color = Color.Red,
                Font = Instance.FontRepos.GetFont("Arial"),
                Text = "Hello world!",
                Anchor = Anchor.BottomRight
            });

            Instance.Level.children.Add(new SolidText()
            {
                Position = new Vector2f(10, 10),
                Size = 16,
                Color = Color.Red,
                Font = Instance.FontRepos.GetFont("Arial"),
                Text = "Hello world!",
                Rotation = 45,
                Anchor = Anchor.BottomLeft
            });
        }

        { // squares!!
            Instance.Level.children.Add(new SolidObject()
            {
                Position = new Vector2f(10, 136),
                Size = new Vector2f(50, 50),
                Color = Color.Red
            });

            Instance.Level.children.Add(new SolidObject()
            {
                Position = new Vector2f(10, 36),
                Size = new Vector2f(50, 50),
                Color = Color.Red,
                Anchor = Anchor.BottomRight
            });

            Instance.Level.children.Add(new SolidObject()
            {
                Position = new Vector2f(10, 10),
                Size = new Vector2f(50, 50),
                Color = Color.Red,
                Rotation = 45,
                Anchor = Anchor.TopRight
            });
        }

        // we've finished so start the app
        Start();
    }

    protected override void OnUpdate(RenderWindow ctx)
    {
        ctx.Clear(Color.Black); // clear buffer ready for next frame

        // manually update fps counter
        (Instance.Level.GetTag("FpsCounter")[0] as SolidText).Text =
            $"{Instance.GuiData.DeltaTime_M}ms\r\n" +
            $"{Instance.GuiData.Framerate}/{1000 / Instance.GuiData.Rate}\r\n";

        Instance.Level.Draw(ctx); // draw scene

        ctx.Display(); // swap buffers
    }
}