#region Includes

using SFML.Graphics;
using SFML.System;
using SFML.Window;

#endregion

internal class Game : GameEngine
{
    public EngineInstance Instance = EngineInstance.Instance;
    public SolidObjectMovementProxy Controller;

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
        }

        {

            Instance.Level.children.Add(new SolidObject()
            {
                Position = new Vector2f(100, 150),
                Size = new Vector2f(20, 150),
                Color = Color.Red,
                Tags = { "LocalPlayer" }
            });

            SolidObject localPlayer = new SolidObject()
            {
                Position = new Vector2f(100, 100),
                Size = new Vector2f(20, 20),
                Color = Color.Red,
                Tags = { "LocalPlayer" }
            };

            Instance.Level.children.Add(localPlayer);

            Controller = new SolidObjectMovementProxy(localPlayer);
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

        Controller.Update(Instance.GuiData.DeltaTime);

        Instance.Level.Draw(ctx); // draw scene

        ctx.Display(); // swap buffers
    }
}