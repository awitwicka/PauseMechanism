// <author>Anna Witwicka</author>
// <date>13/03/2015</date>
// <summary>Class representing a Float Factory that produces an incremented float at constant rate.</summary>

using UnityEngine;
using System.Collections;

public class FloatMaker : Production<float> {

    public float FloatStartValue = 0.0f;
    public float IncrementValue = 1.0f;
    public override float ProduceNext()
    {
        FloatStartValue += IncrementValue;
        Debug.Log("new float value: " + FloatStartValue);
        return FloatStartValue;
    }
}
