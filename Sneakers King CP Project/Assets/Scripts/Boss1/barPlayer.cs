using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class barPlayer : MonoBehaviour
{
	public Players players;
	public Slider slider;
    public Gradient gradient;
    public Image fill;

	void Start()
	{
		slider.maxValue = players.health;
        slider.value = players.health;
        fill.color = gradient.Evaluate(1f);
        Debug.Log(slider.value);

	}

	// Update is called once per frame
	void Update()
    {
		slider.value = players.health;
        fill.color = gradient.Evaluate(slider.normalizedValue);


        Debug.Log(slider.value);
    }
}
