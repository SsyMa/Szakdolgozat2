using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SightObject : MonoBehaviour
{
    HashSet<Collider> colliders;

    private void Start()
    {
        colliders = new HashSet<Collider>();
    }
    public HashSet<Collider> GetColliders()
    {
        HashSet<Collider> ret = colliders;
        colliders = new HashSet<Collider>();
        return ret;
    }

    private void OnTriggerStay(Collider other)
    {
        try
        {
            //if (other.gameObject.CompareTag("animal")) Debug.Log(other.gameObject.GetComponent<Animal>().animalName);
            colliders.Add(other);
        }
        catch
        {

        }
        
    }
}
