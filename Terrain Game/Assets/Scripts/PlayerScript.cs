using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    
    public float maxHunger, maxThirst, maxHealth;
    private float hunger, thirst, health;
    public float hungerIncrease, thirstIncrease, healthIncrease;

    void Start()
    {
        health = maxHealth;
    }

    void Update()
    {
        HungerAndThirst();
        if(health <= 0)
        {
            Die();
        }
        print(hunger + ", " + thirst);
    }

    public void HungerAndThirst()
    {
        hunger += 1 * Time.deltaTime;
        thirst += 1 * Time.deltaTime;

        if(hunger >= maxHunger)
        {
            Die();
        }
        if(thirst >= maxThirst)
        {
            Die();  
        }

    }

    public void Die()
    {
        print("Player has died.");
    }
}
