using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableStorage : MonoBehaviour
{
    public AnimalData bobData;
    public AnimalData bobDefault;
    public AnimalData bearyData;
    public AnimalData bearyDefault;

    private void Awake()
    {
        Setup();
    }

    public void Setup()
    {
        SetupBob();
        SetupBeary();
    }

    private void SetupBob()
    {
        bobData.animalName = bobDefault.animalName;
        bobData.height = bobDefault.height;
        bobData.width = bobDefault.width;
        bobData.length = bobDefault.length;
        bobData.accelerationMultiplier = bobDefault.accelerationMultiplier;
        bobData.torqueMultiplier = bobDefault.torqueMultiplier;
        bobData.maxSpeed = bobDefault.maxSpeed;

        bobData.health = bobDefault.health;
        bobData.maxHealth = bobDefault.maxHealth;
        bobData.healthRegen = bobDefault.healthRegen;
        bobData.healthRestorationByFood = bobDefault.healthRestorationByFood;

        bobData.viewDistance = bobDefault.viewDistance;
        bobData.fovHorizontal = bobDefault.fovHorizontal;
        bobData.sightHeight = bobDefault.sightHeight;
        bobData.sightDepth = bobDefault.sightDepth;

        bobData.diet = bobDefault.diet;

        bobData.staminaBarDistance = bobDefault.staminaBarDistance;
        bobData.startingStamina = bobDefault.startingStamina;
        bobData.stamina = bobDefault.stamina;
        bobData.maxStamina = bobDefault.maxStamina;
        bobData.staminaGain = bobDefault.staminaGain;
        bobData.speedOfStaminaLoss = bobDefault.speedOfStaminaLoss;
        bobData.carnivorous = bobDefault.carnivorous;

        bobData.attackDamage = bobDefault.attackDamage;
        bobData.attackSpeed = bobDefault.attackSpeed;

        bobData.water = bobDefault.water;
        bobData.waterGain = bobDefault.waterGain;
        bobData.maxWater = bobDefault.maxWater;

        bobData.matingPoints = bobDefault.matingPoints;
        bobData.matingPointsNeeded = bobDefault.matingPointsNeeded;
        bobData.childNumMax = bobDefault.childNumMax;
        bobData.childRate = bobDefault.childRate;

        bobData.currencyGainedForMating = bobDefault.currencyGainedForMating;
    }

    private void SetupBeary()
    {
        bearyData.animalName = bearyDefault.animalName;
        bearyData.height = bearyDefault.height;
        bearyData.width = bearyDefault.width;
        bearyData.length = bearyDefault.length;
        bearyData.accelerationMultiplier = bearyDefault.accelerationMultiplier;
        bearyData.torqueMultiplier = bearyDefault.torqueMultiplier;
        bearyData.maxSpeed = bearyDefault.maxSpeed;

        bearyData.health = bearyDefault.health;
        bearyData.maxHealth = bearyDefault.maxHealth;
        bearyData.healthRegen = bearyDefault.healthRegen;
        bearyData.healthRestorationByFood = bearyDefault.healthRestorationByFood;

        bearyData.viewDistance = bearyDefault.viewDistance;
        bearyData.fovHorizontal = bearyDefault.fovHorizontal;
        bearyData.sightHeight = bearyDefault.sightHeight;
        bearyData.sightDepth = bearyDefault.sightDepth;

        bearyData.diet = bearyDefault.diet;

        bearyData.staminaBarDistance = bearyDefault.staminaBarDistance;
        bearyData.startingStamina = bearyDefault.startingStamina;
        bearyData.stamina = bearyDefault.stamina;
        bearyData.maxStamina = bearyDefault.maxStamina;
        bearyData.staminaGain = bearyDefault.staminaGain;
        bearyData.speedOfStaminaLoss = bearyDefault.speedOfStaminaLoss;
        bearyData.carnivorous = bearyDefault.carnivorous;

        bearyData.attackDamage = bearyDefault.attackDamage;
        bearyData.attackSpeed = bearyDefault.attackSpeed;

        bearyData.water = bearyDefault.water;
        bearyData.waterGain = bearyDefault.waterGain;
        bearyData.maxWater = bearyDefault.maxWater;

        bearyData.matingPoints = bearyDefault.matingPoints;
        bearyData.matingPointsNeeded = bearyDefault.matingPointsNeeded;
        bearyData.childNumMax = bearyDefault.childNumMax;
        bearyData.childRate = bearyDefault.childRate;

        bearyData.currencyGainedForMating = bearyDefault.currencyGainedForMating;
    }
}
