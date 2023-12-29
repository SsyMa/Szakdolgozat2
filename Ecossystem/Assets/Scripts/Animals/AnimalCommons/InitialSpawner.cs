using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSpawner : MonoBehaviour
{
    public GameObject bob;
    public GameObject beary;
    public ReproductionHandler reproductionHandler;

    public void InitialSpawn()
    {
        reproductionHandler.CreateCreature(bob, new Vector3(-100, 50, 20));
        reproductionHandler.CreateCreature(beary, new Vector3(-100, 50, 10));
    }
}
