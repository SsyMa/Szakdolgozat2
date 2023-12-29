using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{

    public Slider slider;
    
    public void SetMaxStamina(float maxStamina)
    {
        slider.maxValue = maxStamina;
        slider.value = maxStamina;
    }

    public void SetStamina(float stamina)
    {
        slider.value = stamina;
    }

    public float GetMaxStamina()
    {
        return slider.maxValue;
    }
}