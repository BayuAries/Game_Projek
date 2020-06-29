using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public BossHealth bossHealth;

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
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
