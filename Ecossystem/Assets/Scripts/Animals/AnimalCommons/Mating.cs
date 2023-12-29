using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mating : MonoBehaviour
{
    //Animal
    Animal animal;
    ReproductionHandler reproductionHandler;
    CurrencyManager currencyManager;

    // Start is called before the first frame update
    void Start()
    {
        //Animal
        animal = GetComponent<Animal>();
        currencyManager = GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>();
        reproductionHandler = GameObject.Find("ReproductionHandler").GetComponent<ReproductionHandler>();
    }

    public void AddMatingPoints(float plusPoints)
    {
        animal.matingPoints += plusPoints;
        if(animal.matingPoints >= animal.matingPointsNeeded)
        {
            animal.matingPoints = 0;
            float randomValue = Random.Range(0, Mathf.Pow(animal.childRate, animal.childNumMax - 1));
            int summonAmount = 0;
            for(int i = animal.childNumMax - 1; i >= 0; i--)
            {
                if(randomValue <= Mathf.Pow(animal.childRate, i))
                {
                    summonAmount++;
                }
            }
            for(int i = 0; i < summonAmount; i++)
            {
                currencyManager.AddCurrency(animal.CurrencyGainedForMating);
                reproductionHandler.CreateCreature(gameObject, gameObject.transform.position);
            }
            
        }
    }
}