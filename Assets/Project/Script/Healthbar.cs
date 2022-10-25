using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    Slider slider;
    float maxHealth;
    float currentHealth;
    void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetHealth()
    {
        return currentHealth;
    }

    public void SetMaxHealth(float hp)
    {
        maxHealth = hp;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
    }

    public void SetHealth(float hp)
    {
        currentHealth = hp;
        slider.value = currentHealth;
    }
}
