using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Boss2HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public Boss2 bossHealth;

    void Start()
    {
        slider.maxValue = bossHealth.health;
        slider.value = bossHealth.health;


        fill.color = gradient.Evaluate(1f);
        // SetMaxHealth(bossHealth.health);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = bossHealth.health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

        // SetHealth(bossHealth.health);
    }

}
