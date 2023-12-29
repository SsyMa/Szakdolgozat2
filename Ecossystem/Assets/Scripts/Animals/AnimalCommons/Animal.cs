using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


//Data class for animals
public class Animal : MonoBehaviour
{
    //Funky unity
    public bool ready = false;

    //Name
    public string animalName;

    //Physical properties
    public float height;
    protected float width;
    protected float length;
    public float AccelerationMultiplier { get; set; }
    public float TorqueMultiplier { get; set; }
    public float MaxSpeed { get; set; }

    //HealthBar
    public HealthBar healthBar;

    //Health
    public float health;
    public float maxHealth;
    public float healthRegen;
    public float healthRestorationByFood;

    //SENSORS
    //Sight
    public float ViewDistance { get; set; }
    public float FovHorizontal { get; set; }
    public float SightHeight { get; set; }
    public float SightDepth { get; set; }

    //StaminaBar
    public StaminaBar staminaBar;
    public float staminaBarDistance;

    //Stamina handling
    public List<string> diet;
    public float startingStamina;
    public float stamina;
    public float maxStamina;
    public float staminaGain;
    public float speedOfStaminaLoss;
    public bool carnivorous;

    //Fighting
    public float attackDamage;
    public float attackSpeed;

    //WaterBar
    public WaterBar waterBar;

    //Water
    public float water;
    public float waterGain;
    public float maxWater;

    //Mating
    public float matingPoints;
    public float matingPointsNeeded;
    public int childNumMax;
    public float childRate;

    //Currency
    public float CurrencyGainedForMating { get; set; }

    protected void Update()
    {
        if (staminaBar)
        {
            if(staminaBar.GetMaxStamina() == 1f)
            {
                SetupStamina();
            }
            staminaBar.SetStamina(stamina);
        }
        else
        {
            staminaBar = gameObject.GetComponentInChildren<StaminaBar>();
        }
        if (healthBar)
        {
            if (healthBar.GetMaxHealth() == 1f)
            {
                SetupHealth();
            }
            healthBar.SetHealth(health);
        }
        else
        {
            healthBar = gameObject.GetComponentInChildren<HealthBar>();
        }

        health += healthRegen * Time.deltaTime;
        health = Mathf.Clamp(health, 0, maxHealth);
        
    }

    private void SetupStamina()
    {
        staminaBar.SetMaxStamina(maxStamina);
        staminaBar.SetStamina(stamina);
    }

    private void SetupWater()
    {
        waterBar.SetMaxWater(maxWater);
        waterBar.SetWater(water);
    }

    private void SetupHealth()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }



}
