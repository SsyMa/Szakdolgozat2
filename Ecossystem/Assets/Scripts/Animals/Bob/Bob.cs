using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bob : Animal
{
    EvolutionManager em;

    ScriptableStorage scst;
    AnimalData bobData;
    //Beware not to overrule base.Update() due to dear unity inconsistency

    void Awake()
    {
        GameObject emgo = GameObject.Find("EvolutionManager");
        //EvolutionManager
        em = emgo.GetComponent<EvolutionManager>();
        //AnimalData
        scst = emgo.GetComponent<ScriptableStorage>();
        bobData = scst.bobData;

        em.Update += RefreshValues;
        RefreshValues();

        //Funky Unity
        ready = true;
    }

    private void RefreshValues()
    {
        //Name
        animalName = bobData.animalName;

        //Physical properties
        height = bobData.height;
        width = bobData.width;
        length = bobData.length;
        AccelerationMultiplier = bobData.accelerationMultiplier;
        TorqueMultiplier = bobData.torqueMultiplier;
        MaxSpeed = bobData.maxSpeed;

        //Health
        health = bobData.health;
        maxHealth = bobData.maxHealth;
        healthRegen = bobData.healthRegen;
        healthRestorationByFood = bobData.healthRestorationByFood;

        //Sight
        bool changed = !(ViewDistance == bobData.viewDistance &&
                       FovHorizontal == bobData.fovHorizontal &&
                       SightHeight == bobData.sightHeight &&
                       SightDepth == bobData.sightDepth);
        if (changed)
        {
            ViewDistance = bobData.viewDistance;
            FovHorizontal = bobData.fovHorizontal;
            SightHeight = bobData.sightHeight;
            SightDepth = bobData.sightDepth;
            Sight s = gameObject.GetComponent<Sight>();
            s.RecreateWedgeMesh();
        }


        //StaminaBar
        staminaBarDistance = bobData.staminaBarDistance;
        //Stamina handling
        diet = bobData.diet;
        startingStamina = bobData.startingStamina;
        stamina = bobData.stamina;
        maxStamina = bobData.maxStamina;
        staminaGain = bobData.staminaGain;
        speedOfStaminaLoss = bobData.speedOfStaminaLoss;
        carnivorous = bobData.carnivorous;

        attackDamage = bobData.attackDamage;
        attackSpeed = bobData.attackSpeed;

        //Water
        water = bobData.water;
        waterGain = bobData.waterGain;
        maxWater = bobData.maxWater;

        //Mating
        matingPoints = bobData.matingPoints;
        matingPointsNeeded = bobData.matingPointsNeeded;
        childNumMax = bobData.childNumMax;
        childRate = bobData.childRate;

        //Currency
        CurrencyGainedForMating = bobData.currencyGainedForMating;
    }

    void OnDestroy()
    {
        em.Update -= RefreshValues;
    }
}
