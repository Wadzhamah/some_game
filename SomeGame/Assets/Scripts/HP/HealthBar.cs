using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider slider;
    private HealthSystem healthSystem;

    private void HealthSystem_OnHealthChanged(object sender, float normilizedHealth)
    {

        slider.DOValue(normilizedHealth, 0.5f);
        
    }

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }
}
