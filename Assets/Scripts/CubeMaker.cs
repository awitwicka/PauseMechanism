// <author>Anna Witwicka</author>
// <date>13/03/2015</date>
// <summary>Class representing a Cube Factory producing Cubes at constant rate.</summary>

using UnityEngine;
using System.Collections;

public class CubeMaker : Production<GameObject> {

    private System.Random rnd = new System.Random();
    public override GameObject ProduceNext()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //cube.AddComponent<Rigidbody>();
        cube.transform.position = new Vector3(rnd.Next(-9, 9), rnd.Next(-3, 3), rnd.Next(-2, 2));
        cube.transform.parent = this.transform;
        return cube;
    }
}

