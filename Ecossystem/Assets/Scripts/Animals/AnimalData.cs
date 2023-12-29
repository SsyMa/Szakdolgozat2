using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AnimalData : ScriptableObject
{
    //Name
    public string animalName;

    //Physical properties
    public float height;
    public float width;
    public float length;
    public float accelerationMultiplier;
    public float torqueMultiplier;
    public float maxSpeed;

    //Health
    public float health;
    public float maxHealth;
    public float healthRegen;
    public float healthRestorationByFood;

    //SENSORS
    //Sight
    public float viewDistance;
    public float fovHorizontal;
    public float sightHeight;
    public float sightDepth;

    //StaminaBar
    public float staminaBarDistance;

    public List<string> diet = new()
    {
        {"greenFood"}
    };
    public float startingStamina;
    public float stamina;
    public float maxStamina;
    public float staminaGain;
    public float speedOfStaminaLoss;
    public bool carnivorous;

    //Fighting
    public float attackDamage;
    public float attackSpeed;

    //Water
    public float water;
    public float waterGain;
    public float maxWater;

    //Mating
    public float matingPoints;
    public float matingPointsNeeded;
    public int childNumMax;
    public float childRate;

    //Currency
    public float currencyGainedForMating;
}
