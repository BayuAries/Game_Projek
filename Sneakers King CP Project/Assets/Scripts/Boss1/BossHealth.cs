using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 500;

	public GameObject deathEffect;

	public bool isInvulnerable = false;
	public Animator _effectAnimation;
	public Animator _effectAnimation2;

	public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;

		Debug.Log(health);

		if (health <= 200)
		{
			GetComponent<Animator>().SetBool("IsEnraged", true);
			_effectAnimation = transform.GetChild(0).GetComponent<Animator>();
			_effectAnimation.SetTrigger("Enraged");
			_effectAnimation2 = transform.GetChild(1).GetComponent<Animator>();
			_effectAnimation2.SetTrigger("Enraged");
		}

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}

}
