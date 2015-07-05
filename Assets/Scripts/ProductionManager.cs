// <author>Anna Witwicka</author>
// <date>13/03/2015</date>
// <summary>Class managing all productions.</summary>

using UnityEngine;
using System.Collections.Generic;
using System;

public class ProductionManager: MonoBehaviour {
    /// <summary>
    /// Pauses all objects inheriting from the class Production<T> that are present on the scene.
    /// </summary>
    public void PauseAll() {
        foreach (IPausable item in Production.List)
        {
            item.Pause();
        }
    }
    /// <summary>
    /// Unpauses all objects inheriting from the class Production<T> that are present on the scene.
    /// </summary>
    public void UnpauseAll() {
        foreach (IPausable item in Production.List)
        {
            item.Resume();
        }
    }
}
