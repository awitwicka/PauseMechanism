// <author>Anna Witwicka</author>
// <date>12/03/2015</date>
// <summary>Class representing a timer firing an event at constant rate.</summary>

using UnityEngine;
using System.Collections;
using System;

public class Timer<T> {

    private bool isPaused = false;
    private bool isRunning = false;
    private float spawnInterval;
    private float timeLeft;
    private int toCompensate = 0;
    public delegate T ElapsedEventHandler();
    public event ElapsedEventHandler onTimeElapsed;

    /// <summary>
    /// Shows if timer is activated.
    /// </summary>
    public bool IsRunning { get { return isRunning; } }
    
    /// <summary>
    /// Shows if timer is paused.
    /// </summary>
    public bool IsPaused { get { return isPaused; } }
    
    /// <summary>
    /// Time left until next event.
    /// </summary>
    public float TimeLeft {
        get{ return timeLeft; } 
        set{
            if (isRunning)
            {
                timeLeft = value;
                if (timeLeft <= 0)
                {
                    if(!isPaused)
                        onTimeElapsed();
                    else
                        toCompensate++;
                    timeLeft = spawnInterval; //restart clock
                }
            }         
        }
    }
    
    /// <summary>
    /// Creates a timer which fires onTimeElapsed event every 'interval' seconds.
    /// </summary>
    /// <param name="interval">Value in seconds, greater than 0.</param>
    /// <exception cref="ArgumentOutOfRangeException" />
    public Timer(float interval)
    {
        if (interval <= 0)
            throw new ArgumentOutOfRangeException("Interval must be greater than 0!");
        spawnInterval = interval;
        timeLeft = interval; 
    }

    /// <summary>
    /// Starts the timer.
    /// </summary>
    public void StartTimer() 
    {
        isRunning = true;
    }

    /// <summary>
    /// Pauses the event execution until ResumeTimer() is called.
    /// </summary>
    public void PauseTimer()
    {
        isPaused = true;
    }

    /// <summary>
    /// Resumes the firing of the event after PauseTimer() was called.
    /// It compensates for not fired events, by firing them as many times as needed.
    /// </summary>
    public void ResumeTimer()
    {
        while (toCompensate-->0)
            onTimeElapsed();
        isPaused = false;
    }

    /// <summary>
    /// Stops the timer.
    /// </summary>
    public void StopTimer() 
    {
        isRunning = false;
        toCompensate = 0;
    }
}
