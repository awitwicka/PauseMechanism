// <author>Anna Witwicka</author>
// <date>12/03/2015</date>
// <summary>An abstract class representing a scheme for the class generating objects of type T at given rate.</summary>

using UnityEngine;
using System.Collections.Generic;
public static class Production
{
    public static List<IPausable> List = new List<IPausable>();
}
public abstract class Production<T> : MonoBehaviour, IPausable
{
    /// <summary>
    /// Rate in seconds at which ProduceNext is called.
    /// </summary>
    public float ProductionRate = 1;
    private Timer<T> ProductionTimer;
    
    /// <summary>
    /// Function responsible of production of the next element.
    /// </summary>
    /// <returns>New object of type T.</returns>
    abstract public T ProduceNext();
    private void Awake()
    {
        Production.List.Add(this as IPausable);
    }
    private void Start()
    {
        ProductionTimer = new Timer<T>(ProductionRate); 
        ProductionTimer.onTimeElapsed += this.ProduceNext;
        ProductionTimer.StartTimer();
    }
    private void Update() {
        ProductionTimer.TimeLeft -= Time.deltaTime;
    }

    private void OnDestroy()
    {
        Production.List.Remove(this as IPausable);
    }

    /// <summary>
    /// Pauses the production. 
    /// </summary>
    public void Pause() {
        ProductionTimer.PauseTimer();
    }

    /// <summary>
    /// Resumes the production.
    /// </summary>
    public void Resume() {
        ProductionTimer.ResumeTimer();
    }

    /// <summary>
    /// Toggles the production between pause and unpause.
    /// </summary>
    public void ToggleProduction()
    {
        if (ProductionTimer.IsPaused)
            Resume();
        else
            Pause();
    }
}