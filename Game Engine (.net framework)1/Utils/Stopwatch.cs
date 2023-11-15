using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;

internal class CSFML_Stopwatch
{
    private DateTime startTime;
    private TimeSpan elapsedTime;
    private bool isRunning;

    /// <summary>
    /// Create a new stopwatch which is counting
    /// </summary>
    /// <returns></returns>
    public static CSFML_Stopwatch StartNew()
    {
        CSFML_Stopwatch watch = new CSFML_Stopwatch();

        watch.Start();

        return watch;
    }

    /// <summary>
    /// Constructor for CSFML Stopwatch
    /// </summary>
    public CSFML_Stopwatch() => Reset();
    
    /// <summary>
    /// Cause the stopwatch to start counting
    /// </summary>
    public void Start()
    {
        if (!isRunning)
        {
            startTime = DateTime.Now;
            isRunning = true;
        }
    }

    /// <summary>
    /// Stop the stopwatch from counting
    /// </summary>
    public void Stop()
    {
        if (isRunning)
        {
            elapsedTime += DateTime.Now - startTime;
            isRunning = false;
        }
    }

    /// <summary>
    /// Resets the stopwatch ready for fresh start again
    /// </summary>
    public void Reset()
    {
        startTime = DateTime.Now;
        elapsedTime = TimeSpan.Zero;
        isRunning = false;
    }

    /// <summary>
    /// Reset then start the stopwatch again
    /// </summary>
    public void Restart()
    {
        Reset();
        Start();
    }

    /// <summary>
    /// Get the currently elapsed time
    /// </summary>
    public TimeSpan Elapsed
    {
        get
        {
            if (isRunning)
            {
                elapsedTime = DateTime.Now - startTime;
            }
            return elapsedTime;
        }
    }

    /// <summary>
    /// Step into the future artifically
    /// </summary>
    /// <param name="milliseconds"></param>
    public void StepMilliseconds(int milliseconds)
    {
        elapsedTime += TimeSpan.FromMilliseconds(milliseconds);
    }

    [DllImport("winmm.dll", SetLastError = true)]
    private static extern uint timeBeginPeriod(uint uPeriod);

    [DllImport("winmm.dll", SetLastError = true)]
    private static extern uint timeEndPeriod(uint uPeriod);

    /// <summary>
    /// Sleep without the limitation of thread.sleep (SecurityWarning)
    /// </summary>
    /// <param name="milliseconds"></param>
    [SecurityWarning("This function changes the system-wide timer resolution for the duration of the sleep, which may impact system-wide timing and power consumption. Use judiciously.")]
    public static void Sleep(int milliseconds)
    {
        timeBeginPeriod((uint)milliseconds);
        Thread.Sleep(milliseconds);
        timeBeginPeriod((uint)milliseconds);
    }
}