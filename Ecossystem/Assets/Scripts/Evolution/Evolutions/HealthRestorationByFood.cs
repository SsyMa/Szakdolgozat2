using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthRestorationByFood : Evolution
{
    private void Awake()
    {
        cost = 30;
        costIncrease = 0;
        brokeTimer = 0;
        valueIncrease = 1;
        description = "Increases the health gained by eating of the creatures by +" + valueIncrease;
        numberOfLevels = 50;
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
            em.IncreaseHealthRestorationByFoodServerRpc(valueIncrease);
        }
        else
        {
            //TODO: For x secs it should write not enough dna
            brokeTimer += 2000;
            Debug.Log("Not enough DNA");
        }
    }
}
