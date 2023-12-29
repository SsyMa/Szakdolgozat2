using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acceleration : Evolution
{
    private void Awake()
    {
        cost = 10;
        costIncrease = 2;
        brokeTimer = 0;
        valueIncrease = 1;
        description = "Increases the acceleration of the creatures by +" + valueIncrease;
        numberOfLevels = 30;
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
            em.IncreaseAccelerationServerRpc(valueIncrease);
        }
        else
        {
            //TODO: For x secs it should write not enough dna
            brokeTimer += 2000;
            Debug.Log("Not enough DNA");
        }
    }
}
