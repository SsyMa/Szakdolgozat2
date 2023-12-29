using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantFood : MonoBehaviour
{
    private Bush bush;

    public void SetBush(Bush bush) { this.bush = bush; }

    void OnDestroy()
    {
        bush?.RemoveFoodFromList(this);
    }
}
