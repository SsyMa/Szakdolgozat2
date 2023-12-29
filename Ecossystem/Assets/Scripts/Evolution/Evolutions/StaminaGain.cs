using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StaminaGain : Evolution
{
    private void Awake()
    {
        cost = 20;
        costIncrease = 5;
        brokeTimer = 0;
        valueIncrease = 10;
        description = "Increases the stamina gain of the creatures by +" + valueIncrease;
        numberOfLevels = 15;
        currentLevel = 0;
        prequisites = new();

    }
    override public void OnClick()
    {
        em = GameObject.Find("EvolutionManager").GetComponent<EvolutionManager>();
        cm = GameObject.Find("CurrencyManager").GetComponent<CurrencyManager>();
        if (currentLevel < numberOfLevels && cm.Spend(cost))
        {
            cost += costIncrease;
            currentLevel++;
            em.IncreaseStaminaGainServerRpc(valueIncrease);
        }
        else
        {
            //TODO: For x secs it should write not enough dna
            brokeTimer += 2000;
            Debug.Log("Not enough DNA");
        }
    }
}
