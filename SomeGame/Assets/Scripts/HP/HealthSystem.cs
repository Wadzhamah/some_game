using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour
{
    
    public event EventHandler<float> OnHealthChanged;
    public event Action OnDied;

    private float health;
    private int healtMax;

    public HealthSystem(int healthMax)
    {
        this.healtMax = healthMax;
        health = healthMax;
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetNormilizedHealth()
    {
        return health / healtMax;
    }

    public void Damage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
            OnDied?.Invoke();
        }
        OnHealthChanged?.Invoke(this, GetNormilizedHealth());
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > healtMax)
        {
            health = healtMax;
        }
        OnHealthChanged?.Invoke(this ,GetNormilizedHealth());
    }
}
