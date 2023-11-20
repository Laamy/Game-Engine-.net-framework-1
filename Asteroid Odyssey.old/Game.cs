#region Includes

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

#endregion

internal class Game : GameEngine
{
    public EngineInstance Instance = EngineInstance.Instance;
    public SolidObjectMovementProxy Controller;

    public Game()
    {
        // lets add some test objects

        // debug stuff
        {
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

        // load stars
        {
            const int NumStars = 6000;
            float starSize = 2;

            Random ran = new Random(0);

            for (int i = 0; i < NumStars; i++)
            {
                float x = ran.Next(0, 1920);
                float y = ran.Next(0, 1080);

                Console.WriteLine($"Creating star at {x} {y}");

                Instance.Level.children.Add(new SolidTile()
                {
                    Position = new Vector2f(x, y),
                    Size = new Vector2f(2, 2),
                    Color = Color.White
                });
            }
        }

        // load ship
        {
            for (int x = 0; x < ShipMaps.DebugShip.GetLength(0); x++)
            {
                for (int y = 0; y < ShipMaps.DebugShip.GetLength(1); y++)
                {
                    char _byte = ShipMaps.DebugShip[x, y];

                    switch(_byte)
                    {
                        case ' ': // nothingness!
                            break;

                        case '#': // BOXES that you can collide with
                            Instance.Level.children.Add(new SolidObject()
                            {
                                Position = new Vector2f(50 + (y * 40), 50 + (x * 40)),
                                Size = new Vector2f(40, 40),
                                Color = new Color(0x292929FF)
                            });
                            break;

                        case '-': // tiles DO NOT have collision
                            Instance.Level.children.Add(new SolidTile()
                            {
                                Position = new Vector2f(50 + (y * 40), 50 + (x * 40)),
                                Size = new Vector2f(40, 40),
                                Color = new Color(0x202020FF)
                            });
                            break;
                    }
                }
            }
        }

        // player setup
        {
            SolidObject localPlayer = new SolidObject()
            {
                Position = new Vector2f(150, 150),
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