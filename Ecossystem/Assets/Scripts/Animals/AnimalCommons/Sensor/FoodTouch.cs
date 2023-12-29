using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class FoodTouch : NetworkBehaviour
{
    Animal animal;
    Hunger hunger;

    private float attackTimer;
    // Start is called before the first frame update
    void Start()
    {
        hunger = GetComponent<Hunger>();
        animal = GetComponent<Animal>();
        attackTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsServer) return;
        if(attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.2f);
        foreach(Collider collider in colliders)
        {
            if (animal == null)
            {
                animal = GetComponent<Animal>();
            }
            else if (collider.gameObject.CompareTag("animal") && animal.carnivorous)
            {
                Animal touchedAnimal = collider.gameObject.GetComponent<Animal>();
                if(touchedAnimal.animalName != animal.animalName && attackTimer <= 0)
                {
                    attackTimer += animal.attackSpeed;
                    touchedAnimal.GetComponent<Damage>()?.TakeDamage(animal.attackDamage, gameObject);
                }
            }
            else
            {
                foreach (string tag in hunger.foodTypes)
                {
                    if (collider.gameObject.CompareTag(tag))
                    {
                        Destroy(collider.gameObject);
                        float value = 0;
                        switch (tag)
                        {
                            case "greenFood":
                                value = 20;
                                break;
                            case "redFood":
                                value = 40;
                                break;
                            case "meat":
                                value = 50;
                                break;
                            default: value = 0; break;
                        }
                        hunger.Restore(value);
                    }
                }
            }
            
        }
    }
}
