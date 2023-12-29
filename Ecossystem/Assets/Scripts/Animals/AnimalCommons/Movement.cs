using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : NetworkBehaviour
{
    Animal animal;
    Vector3 velocity;
    float rotationVelocity;
    

    public List<Sensor> sensors;

    // Start is called before the first frame update
    void Start()
    {
        if(!IsServer)
        {
            return;
        }
        if (!animal)
        {
            animal = gameObject.GetComponent<Animal>();
        }
        sensors = new List<Sensor>
        {
            { GetComponent<Sight>() },
            { GetComponent<Damage>() }
        };
        rotationVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer)
        {
            return;
        }
        //Calculating sensor effects
        float acceleration = 0;
        float torque = 0;
        foreach (var s in sensors)
        {
            acceleration += s.Acceleration;
            torque += s.Torque;
        }
        if (acceleration < 0.1f && Math.Abs(torque) < 0.1f)
        {
            torque = 1000;
            velocity = Vector3.zero;
        }
        acceleration = acceleration == Mathf.Infinity ? 0 : acceleration;
        velocity += transform.forward * acceleration * Time.deltaTime;
        if (animal == null)
        {
            animal = gameObject.GetComponent<Animal>();
        }
        if (velocity.magnitude > animal.MaxSpeed)
        {
            velocity *= animal.MaxSpeed / velocity.magnitude;
        }
        velocity.x = Mathf.Floor(velocity.x * 100) / 100f;
        velocity.y = Mathf.Floor(velocity.y * 100) / 100f;
        velocity.z = Mathf.Floor(velocity.z * 100) / 100f;
        if(acceleration >= 500)
        {
            torque = 0;
        }
        rotationVelocity += torque * Time.deltaTime;

        //Debug.Log(animal.animalName + " acc: " + acceleration + " torque: " + torque);

        transform.position += velocity * Time.deltaTime;
        velocity *= 0.9f;
        transform.Rotate(Vector3.up, rotationVelocity * Time.deltaTime);
        rotationVelocity *= 0.5f;
    }
}
