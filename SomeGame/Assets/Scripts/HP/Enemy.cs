using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBar healthBar;
    private HealthSystem healthSystem;
    private void Start()
    {
        healthSystem = new HealthSystem(100);
        healthBar.Setup(healthSystem);

        healthSystem.OnDied += HealthSystem_OnDied;
    }

    private void HealthSystem_OnDied()
    {
        LevelController.Instance.TotalKills++;
        
 
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        healthSystem.Damage(50);
    }

    public void TakeHeal()
    {
        healthSystem.Heal(10);
    }
}
