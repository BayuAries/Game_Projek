using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(float Energy)
    {
        slider.maxValue = Energy;
        slider.value = Energy;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(float Energy)
    {
        slider.value = Energy;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
