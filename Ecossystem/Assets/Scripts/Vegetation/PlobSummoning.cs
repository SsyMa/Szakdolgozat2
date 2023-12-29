using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlobSummoning : MonoBehaviour
{
    public GameObject plob;
    public int summonedAmount;
    public int xRange;
    public int zRange;
    RaycastHit hit;
    float rayCastHeight = 100f;
    public int summoningTime = 5;
    private void Update()
    {
        if (summoningTime <= 0)
        {
            summoningTime = 5;
            Summon();
        }
        else
        {
            summoningTime--;
        }
    }
    public void Summon()
    {
        for (int i = 0; i < summonedAmount; i++)
        {
            int x = Random.Range(-xRange / 2, xRange / 2);
            int z = Random.Range(-zRange / 2, zRange / 2);

            Vector3 rayPosition = new Vector3(x, rayCastHeight, z);
            Ray sightRay = new Ray(rayPosition, Vector3.down);
            if (Physics.Raycast(sightRay, out hit) && hit.collider.CompareTag("ground"))
            {
                Vector3 position = new Vector3(x, rayCastHeight - hit.distance + 0.15f, z);
                //TODO kicser�lni, hogy modul�ris legyen a magass�g f�ggv�ny�ben
                Instantiate(plob, position, Quaternion.identity);
            }




        }
    }
}
