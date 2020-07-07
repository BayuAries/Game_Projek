using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightAttack : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerAdventure enemy = other.GetComponent<PlayerAdventure>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

        Debug.Log("hit " + other.name);

    }
}
