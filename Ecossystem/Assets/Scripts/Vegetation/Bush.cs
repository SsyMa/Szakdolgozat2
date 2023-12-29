using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class Bush : NetworkBehaviour
{
    public float minx;
    public float maxx;
    public float miny;
    public float maxy;
    public float minz;
    public float maxz;

    public float growTime;
    public float timeUntilGrow;

    public List<GameObject> fruits;

    private List<PlantFood> foods;
    private int maxFoodCount = 3;


    // Start is called before the first frame update
    void Start()
    {
        timeUntilGrow = growTime;
        foods = new();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsHost)
        {
            return;
        }
        if(timeUntilGrow < 0)
        {
            timeUntilGrow = growTime;
            if (foods != null && foods.Count < maxFoodCount)
            {
                int rand = Random.Range(0, 10);
                int fruitNumber = rand >= 9 ? 1 : 0;
                GameObject go = Instantiate(fruits[fruitNumber], gameObject.transform);
                float randx = Random.Range(minx, maxx);
                float randy = Random.Range(miny, maxy);
                float randz = Random.Range(minz, maxz);
                go.transform.localPosition = new(randx, randy, randz);
                PlantFood pf = go.GetComponent<PlantFood>();
                pf.SetBush(this);
                foods.Add(pf);
                NetworkObject plantNetworkObject = go.GetComponent<NetworkObject>();
                plantNetworkObject.Spawn(true);
            }
            
        }
        else
        {
            timeUntilGrow -= Time.deltaTime;
        }
    }


    public void RemoveFoodFromList(PlantFood pf)
    {
        foods.Remove(pf);
    }
}
