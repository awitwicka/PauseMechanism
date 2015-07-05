using UnityEngine;
using System.Collections;

public class UIScript : MonoBehaviour {

    public void DestroyCubeProduction(GameObject production)
    {
        GameObject.Destroy(production);
    }
}
