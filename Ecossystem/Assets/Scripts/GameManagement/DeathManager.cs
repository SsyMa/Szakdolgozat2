using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathManager : MonoBehaviour
{
    public GameObject meat;

    public void DropMeat(int n, Vector3 parentPosition)
    {
        for(int i = 0; i < n; i++)
        {
            Instantiate(meat, parentPosition, new());
        }
    }
}
