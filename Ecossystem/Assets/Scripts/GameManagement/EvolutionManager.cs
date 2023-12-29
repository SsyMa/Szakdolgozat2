using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void UpdateData();
public class EvolutionManager : NetworkBehaviour
{
    public event UpdateData Update;
    public AnimalData animalData;

    [ServerRpc]
    public void IncreaseAccelerationServerRpc(float value)
    {
        animalData.accelerationMultiplier += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseTorqueServerRpc(float value)
    {
        animalData.torqueMultiplier += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseMaxSpeedServerRpc(float value)
    {
        animalData.maxSpeed += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseStaminaGainServerRpc(float value)
    {
        animalData.staminaGain += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseMaxStaminaServerRpc(float value)
    {
        animalData.maxStamina += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseStartingStaminaServerRpc(float value)
    {
        animalData.startingStamina += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void DecreaseBreedingPointsNeededServerRpc(float value)
    {
        animalData.matingPointsNeeded -= value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseChildNumMaxServerRpc(int value)
    {
        animalData.childNumMax += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseChildRateServerRpc(float value)
    {
        animalData.childRate -= value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseViewDistanceServerRpc(float value)
    {
        animalData.viewDistance += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseFieldOfViewServerRpc(float value)
    {
        animalData.fovHorizontal += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseSightHeightServerRpc(float value)
    {
        animalData.sightHeight += value;
        RaiseEvent();
    }
    [ServerRpc]

    public void IncreaseSightDepthServerRpc(float value)
    {
        animalData.sightDepth += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void ChangeDietServerRpc(float value)
    {
        animalData.diet.Add("redFood");
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseHealthServerRpc(float value)
    {
        animalData.health += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseHealthRegenServerRpc(float value)
    {
        animalData.healthRegen += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseHealthRestorationByFoodServerRpc(float value)
    {
        animalData.healthRestorationByFood += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseAttackDamageServerRpc(float value)
    {
        animalData.attackDamage += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseAttackSpeedServerRpc(float value)
    {
        animalData.staminaGain -= value;
        RaiseEvent();
    }
    [ServerRpc]
    public void ChangeCarnivorousServerRpc()
    {
        animalData.diet.Add("animal");
        animalData.diet.Add("meat");
        animalData.carnivorous = true;
        RaiseEvent();
    }
    [ServerRpc]
    public void DecreaseSpeedOfStaminaLossServerRpc(float value)
    {
        animalData.staminaGain += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void IncreaseDNAFromMatingServerRpc(float value)
    {
        animalData.currencyGainedForMating += value;
        RaiseEvent();
    }
    [ServerRpc]
    public void DecreaseDNACostServerRpc(float value)
    {
        GameObject.FindObjectOfType<CurrencyManager>().DecreaseCost(1);
        RaiseEvent();
    }

    private void RaiseEvent()
    {
        Update?.Invoke();
    }
}
