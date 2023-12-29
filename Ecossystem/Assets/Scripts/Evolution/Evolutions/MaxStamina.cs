using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MaxStamina : Evolution
{
    private void Awake()
    {
        cost = 5;
        costIncrease = 1;
        brokeTimer = 0;
        valueIncrease = 1;
        description = "Increases the maximum stamina of the creatures by +" + valueIncrease;
        numberOfLevels = 100;
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
            em.IncreaseMaxStaminaServerRpc(valueIncrease);
        }
        else
        {
            //TODO: For x secs it should write not enough dna
            brokeTimer += 2000;
            Debug.Log("Not enough DNA");
        }
    }
}
