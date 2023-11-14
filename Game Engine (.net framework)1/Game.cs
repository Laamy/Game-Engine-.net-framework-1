#region Includes

using System.Windows.Forms;

using SFML.Graphics;
using SFML.System;

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
                Color = Color.Red,
                Font = Instance.FontRepos.GetFont("Arial"),
                Text = "Hello world!"
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
                Position = new Vector2f(10, 36),
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
        ctx.DispatchEvents(); // handle window events
        ctx.Clear(Color.Black); // clear buffer ready for next frame

        Instance.Level.Draw(ctx); // draw scene

        ctx.Display(); // swap buffers
    }
}