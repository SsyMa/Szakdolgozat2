using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedObject : MonoBehaviour
{

    RaycastHit hit;
    Animal animal;

    // Start is called before the first frame update
    void Start()
    {
        animal = gameObject.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray downRay = new Ray(transform.position + new Vector3(0f, 100f, 0f), Vector3.down);

        if (Physics.Raycast(downRay, out hit) && hit.collider.tag == "ground")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 100 - hit.distance + animal.height, transform.position.z);
        }
        //TODO: rotation based on tilt
    }
}
