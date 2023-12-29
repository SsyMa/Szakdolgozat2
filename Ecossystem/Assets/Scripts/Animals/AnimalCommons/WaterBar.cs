using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxWater(float maxWater)
    {
        slider.maxValue = maxWater;
        slider.value = maxWater;
    }

    public void SetWater(float water)
    {
        slider.value = water;
    }

    public float GetMaxWater()
    {
        return slider.maxValue;
    }
}
