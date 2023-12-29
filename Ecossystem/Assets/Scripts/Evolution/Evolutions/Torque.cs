using Assets.Scripts.Evolutions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Torque : Evolution
{
    private void Awake()
    {
        cost = 10;
        costIncrease = 2;
        valueIncrease = 1;
        description = "Increases the turning acceleration of the creatures by +" + valueIncrease;
        numberOfLevels = 30;
        currentLevel = 0;
        prequisites = new();
    }
    override public void OnClick()
    {
        em = GameObject.Find("EvolutionManager").GetComponent<EvolutionManager>();
        em.IncreaseTorqueServerRpc(valueIncrease);
    }
}
