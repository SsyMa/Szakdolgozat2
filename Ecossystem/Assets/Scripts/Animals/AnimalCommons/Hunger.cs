using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hunger : MonoBehaviour
{
    //Animal
    Animal animal;
    Mating mating;

    //Food types
    public List<string> foodTypes;

    // Start is called before the first frame update
    void Start()
    {
        //Animal
        animal = GetComponent<Animal>();
        mating = GetComponent<Mating>();
        foodTypes = animal.diet;
    }

    // Update is called once per frame
    void Update()
    {
        foodTypes ??= animal.diet;
        //Stamina control
        if (animal.stamina <= 0)
        {
            Destroy(gameObject);
        }
        animal.stamina -= Time.deltaTime * (1 - animal.speedOfStaminaLoss);
    }

    public void Restore(float amount)
    {
        float newValue = animal.stamina + amount + animal.staminaGain;
        if(newValue >= animal.maxStamina) 
        {
            animal.stamina = animal.maxStamina;
            newValue -= animal.maxStamina;
            mating.AddMatingPoints(newValue);
        }
        else
        {
            animal.stamina += amount;
        }
    }
}
