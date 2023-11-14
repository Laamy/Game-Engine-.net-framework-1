#region Includes

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;

using SFML.Graphics;
using SFML.System;
using SFML.Window;
using View = SFML.Graphics.View;

#endregion

internal class GameEngine
{
    /// <summary>
    /// The games target framerate
    /// </summary>
    public int targetFPS
    {
        get => (int)(1000 / ClientInstance.Instance.GuiData.Rate);
        set => ClientInstance.Instance.GuiData.Rate = 1000f / value;
    }

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

        ClientInstance Instance = ClientInstance.Instance;

        targetFPS = 144;
        long prevMilSec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        while (window.IsOpen)
        {
            long currMilSec = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            long elapsedMilSec = currMilSec - prevMilSec;

            if (elapsedMilSec >= Instance.GuiData.Rate)
            {
                Instance.GuiData.Size = window.Size;
                Instance.GuiData.DeltaTime_M = elapsedMilSec;
                Instance.GuiData.DeltaTime = 1f / elapsedMilSec;

                prevMilSec = currMilSec;
                OnUpdate(window); // redraw window
            }

            window.DispatchEvents(); // handle window events

            Thread.Sleep(1);
        }
    }

    protected virtual void OnUpdate(RenderWindow ctx) { }// draw event

    #region Easy Game Properties

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