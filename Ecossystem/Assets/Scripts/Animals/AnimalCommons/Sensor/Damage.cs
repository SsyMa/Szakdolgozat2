using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : Sensor
{
    Animal animal;
    private float runTime;
    private float runCounter;
    private void Start()
    {
        Acceleration = 0;
        Torque = 0;
        animal = GetComponent<Animal>();
        runTime = 3;
        runCounter = 0;
    }

    private void Update()
    {
        if(runCounter > 0)
        {
            Acceleration = 500;
            runCounter -= Time.deltaTime;
        }
        else
        {
            Acceleration = 0;
        }
    }
    public void TakeDamage(float damage, GameObject attacker)
    {
        if(animal == null)
        {
            animal = GetComponent<Animal>();
        }
        else
        {
            animal.health -= damage;
            if (animal.health <= 0)
            {
                DeathManager dm = GameObject.Find("DeathManager").GetComponent<DeathManager>();
                dm.DropMeat(8, transform.position);
                Destroy(gameObject);
            }
            else
            {
                Quaternion rotation = Quaternion.FromToRotation(animal.gameObject.transform.forward, attacker.transform.forward);
                animal.gameObject.transform.forward = rotation * animal.gameObject.transform.forward;
                runCounter = runTime;
            }
        }
        
    }
}
