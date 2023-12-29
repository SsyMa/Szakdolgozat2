using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beary : Animal
{
    EvolutionManager em;

    ScriptableStorage scst;
    AnimalData bearyData;
    //Beware not to overrule base.Update() due to dear unity inconsistency

    void Awake()
    {
        GameObject emgo = GameObject.Find("EvolutionManager");
        //EvolutionManager
        em = emgo.GetComponent<EvolutionManager>();
        //AnimalData
        scst = emgo.GetComponent<ScriptableStorage>();
        bearyData = scst.bearyData;

        em.Update += RefreshValues;
        RefreshValues();

        //Funky Unity
        ready = true;
    }

    private void RefreshValues()
    {
        //Name
        animalName = bearyData.animalName;

        //Physical properties
        height = bearyData.height;
        width = bearyData.width;
        length = bearyData.length;
        AccelerationMultiplier = bearyData.accelerationMultiplier;
        TorqueMultiplier = bearyData.torqueMultiplier;
        MaxSpeed = bearyData.maxSpeed;

        //Health
        health = bearyData.health;
        maxHealth = bearyData.maxHealth;
        healthRegen = bearyData.healthRegen;
        healthRestorationByFood = bearyData.healthRestorationByFood;

        //Sight
        bool changed = !(ViewDistance == bearyData.viewDistance &&
                       FovHorizontal == bearyData.fovHorizontal &&
                       SightHeight == bearyData.sightHeight &&
                       SightDepth == bearyData.sightDepth);
        if (changed)
        {
            ViewDistance = bearyData.viewDistance;
            FovHorizontal = bearyData.fovHorizontal;
            SightHeight = bearyData.sightHeight;
            SightDepth = bearyData.sightDepth;
            Sight s = gameObject.GetComponent<Sight>();
            s.RecreateWedgeMesh();
        }


        //StaminaBar
        staminaBarDistance = bearyData.staminaBarDistance;
        //Stamina handling
        diet = bearyData.diet;
        startingStamina = bearyData.startingStamina;
        stamina = bearyData.stamina;
        maxStamina = bearyData.maxStamina;
        staminaGain = bearyData.staminaGain;
        speedOfStaminaLoss = bearyData.speedOfStaminaLoss;
        carnivorous = bearyData.carnivorous;

        attackDamage = bearyData.attackDamage;
        attackSpeed = bearyData.attackSpeed;

        //Water
        water = bearyData.water;
        waterGain = bearyData.waterGain;
        maxWater = bearyData.maxWater;

        //Mating
        matingPoints = bearyData.matingPoints;
        matingPointsNeeded = bearyData.matingPointsNeeded;
        childNumMax = bearyData.childNumMax;
        childRate = bearyData.childRate;

        //Currency
        CurrencyGainedForMating = bearyData.currencyGainedForMating;
    }
}
