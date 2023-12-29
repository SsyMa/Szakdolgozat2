using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class BushSpawner : MonoBehaviour
{
    RaycastHit hit;

    public GameObject bush;

    public void BushSpawn(int bushNumber, float xRange, float zRange)
    {
        for (int i = 0; i < bushNumber; i++)
        {
            float xRand = Random.Range(-xRange, xRange);
            float zRand = Random.Range(-zRange, zRange);

            Ray downRay = new Ray(new Vector3(xRand, 150f, zRand), Vector3.down);
            Physics.Raycast(downRay, out hit);
            if (hit.collider != null && hit.collider.CompareTag("ground") && hit.distance < 140)
            {
                GameObject go = Instantiate(bush, new(xRand, 150 - hit.distance + 0.5f, zRand), Quaternion.Euler(90, 0, 0));
                NetworkObject bushNetworkObject = go.GetComponent<NetworkObject>();
                bushNetworkObject.Spawn(true);
            }
        }
    }
}
