using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChildNumMax : Evolution
{
    private void Awake()
    {
        cost = 50;
        costIncrease = 50;
        brokeTimer = 0;
        valueIncrease = 1;
        description = "Increases the maximum number of children by +" + valueIncrease;
        numberOfLevels = 4;
        currentLevel = 1;
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
            em.IncreaseChildNumMaxServerRpc(Mathf.FloorToInt(valueIncrease));
        }
        else
        {
            //TODO: For x secs it should write not enough dna
            brokeTimer += 2000;
            Debug.Log("Not enough DNA");
        }
    }
}
