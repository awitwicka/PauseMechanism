// <author>Anna Witwicka</author>
// <date>13/03/2015</date>
// <summary>Interface for all classes that can Pause and Resume their productions.</summary>

using UnityEngine;
using System.Collections;

public interface IPausable {
    /// <summary>
    /// Pauses the production. 
    /// </summary>
    void Pause();
    /// <summary>
    /// Resumes the production.
    /// </summary>
    void Resume();
    /// <summary>
    /// Toggles the production between pause and unpause.
    /// </summary>
    void ToggleProduction();
}
