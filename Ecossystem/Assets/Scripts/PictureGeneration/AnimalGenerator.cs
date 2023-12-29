using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimalGenerator : MonoBehaviour
{
    public int minx;
    public int minz;
    public int maxx;
    public int maxz;
    public int n;
    public float minsize;
    public float maxsize;
    public List<GameObject> list;
    private List<GameObject> stuff;
    // Start is called before the first frame update
    private void Start()
    {
        stuff = new();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) // You can change the condition to trigger the capture
        {
            foreach(GameObject go in stuff)
            {
                Destroy(go);
            }
            stuff.Clear();
            for (int i = 0; i < n; i++)
            {
                GameObject toInst = list[Random.Range(0, list.Count)];
                float randx = Random.Range(-9f, 9f);
                float randy = Random.Range(-4.5f, 4.5f);
                float randz = Random.Range(3f, 27f);
                Quaternion rot = Quaternion.Euler(Random.Range(minx, maxx), 180, Random.Range(minz, maxz));
                GameObject go = Instantiate(toInst, new(randx, randy, randz), rot);
                go.transform.localScale = Vector3.one * Random.Range(minsize, maxsize);
                stuff.Add(go);
            }
        }
            
    }
}
