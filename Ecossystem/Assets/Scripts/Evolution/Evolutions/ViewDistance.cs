using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ViewDistance : Evolution
{
    private void Awake()
    {
        cost = 20;
        costIncrease = 5;
        brokeTimer = 0;
        valueIncrease = 2;
        description = "Increases the view distance of the creatures by +" + valueIncrease;
        numberOfLevels = 25;
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
            em.IncreaseViewDistanceServerRpc(valueIncrease);
        }
        else
        {
            Debug.Log("Not enough DNA");
        }
    }
}
