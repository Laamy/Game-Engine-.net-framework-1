#region Includes

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

using SFML.Graphics;
using SFML.System;
using SFML.Window;

using View = SFML.Graphics.View;

#endregion

public class GameEngine
{
    private int counter = 0;

    // sdl stuff
    private RenderWindow window;

    public void Start()
    {
        // sdl renderer
        VideoMode mode = new VideoMode(800, 600);
        window = new RenderWindow(mode, "Game Engine");
        window.Closed += (s, e) => window.Close();
        window.Resized += (s, e) => Size = new Vector2u(e.Width, e.Height);

        window.SetActive();

        EngineInstance Instance = EngineInstance.Instance;

        TargetFps = 144;
        CSFML_Stopwatch stopwatch = CSFML_Stopwatch.StartNew();
        long prevSec = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;

        while (window.IsOpen)
        {
            long elapsedTicks = stopwatch.Elapsed.Ticks;
            long desired = (long)(TimeSpan.TicksPerMillisecond * Instance.GuiData.Rate);

            if (elapsedTicks >= desired)
            {
                stopwatch.Restart();

                long currSec = DateTime.Now.Ticks / TimeSpan.TicksPerSecond;

                if (currSec - prevSec >= 1)
                {
                    Instance.GuiData.Framerate = counter;
                    counter = 0;

                    prevSec = currSec;
                }

                Instance.GuiData.Size = window.Size;
                Instance.GuiData.DeltaTime_M = elapsedTicks / TimeSpan.TicksPerMillisecond;
                Instance.GuiData.DeltaTime = 1f / elapsedTicks;

                OnUpdate(window); // redraw window
                counter++;

                window.DispatchEvents(); // handle window events

                CSFML_Stopwatch.Sleep((int)Math.Floor(Instance.GuiData.Rate));
            }
        }
    }

    protected virtual void OnUpdate(RenderWindow ctx) { }// draw event

    #region Easy Game Properties

    /// <summary>
    /// The games target framerate
    /// </summary>
    public int TargetFps
    {
        get => (int)(1000 / EngineInstance.Instance.GuiData.Rate);
        set => EngineInstance.Instance.GuiData.Rate = 1000f / value;
    }

    public Vector2u Size
    {
        get => window.Size;
        set
        {
            View view = new View(new FloatRect(0, 0, value.X, value.Y));
            window.SetView(view);
        }
    }

    public String Title
    { set => window.SetTitle(value); }

    #endregion
}