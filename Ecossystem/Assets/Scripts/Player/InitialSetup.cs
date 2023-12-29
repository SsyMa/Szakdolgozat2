using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class InitialSetup : NetworkBehaviour
{
    [SerializeField] private InitialSpawner initialSpawner;
    [SerializeField] private ReproductionHandler reproductionHandler;
    [SerializeField] private BushSpawner bushSpawner;
    private bool spawnedAnimals = false;
    private bool spawnedBushes = false;

    private GameObject animalPrefab;

    private void Start()
    {
        if (IsServer)
        {
            //reproductionHandler.CreateCreature(animalPrefab, new(-100, 50, 20));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsServer && IsOwner) {
            if (!spawnedAnimals && Input.GetKey(KeyCode.T))
            {
                spawnedAnimals = true;
                initialSpawner.InitialSpawn();
            }
            if (!spawnedBushes && Input.GetKey(KeyCode.B))
            {
                spawnedBushes = true;
                bushSpawner.BushSpawn(700, 200, 200);
            }
        }
        
    }
}
