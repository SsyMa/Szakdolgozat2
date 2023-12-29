using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class ReproductionHandler : NetworkBehaviour
{
    public GameObject staminaBarPrefab;

    public void CreateCreature(GameObject animalPrefab, Vector3 parentPosition)
    {
        if (IsServer) {
            GameObject animalGO = Instantiate(animalPrefab, parentPosition, Quaternion.Euler(0, Random.Range(0, 360), 0));
            Animal animal = animalGO.GetComponent<Animal>();
            GameObject staminaBarGO = Instantiate(staminaBarPrefab, animalGO.transform);
            staminaBarGO.transform.localPosition = new Vector3(0, animal.height + animal.staminaBarDistance, 0);
            NetworkObject animalNetworkObject = animalGO.GetComponent<NetworkObject>();
            animalNetworkObject.Spawn(true);
        }
        
    }
}
