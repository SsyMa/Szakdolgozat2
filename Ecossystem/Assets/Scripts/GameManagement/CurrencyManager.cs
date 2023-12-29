using System;
using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    private float Currency { get; set; }
    public TextMeshProUGUI currencyText;
    private int costDecrease = 0;
    private void Start()
    {
        Currency = 0;
    }

    public void DecreaseCost(int amount)
    {
        costDecrease += amount;
    }

    public void AddCurrency(float amount)
    {
        Currency += amount;
    }
    public bool Spend(int amount)
    {
        if(Currency >= amount - costDecrease)
        {
            Currency -= amount - costDecrease;
            return true;
        }
        return false;
    }
    private void Update()
    {
        RefreshCurrency();
    }

    private void RefreshCurrency()
    {
        currencyText.text = Math.Floor(Currency).ToString();
    }
}
