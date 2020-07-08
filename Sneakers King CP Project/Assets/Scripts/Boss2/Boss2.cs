using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss2 : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;
	public GameObject deathEffect;


    private Animator anim;
    public Animator camAnim;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 250)
        {
            //anim.SetTrigger("stageTwo");
        }

		if (health <= 0)
		{
			Die();
		}
		//slider.value = health;
	}


    public void TakeDamage(int damage)
	{
		if (health<=500){

		health -= damage;
		StartCoroutine(DamageAnimation());

		Debug.Log(health);

        }

		
	}

	void Die()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		//FindObjectOfType<NextLevel>().nextLevel();
	}


	IEnumerator DamageAnimation()
	{
		SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

		for (int i = 0; i < 3; i++)
		{
			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 0;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);

			foreach (SpriteRenderer sr in srs)
			{
				Color c = sr.color;
				c.a = 1;
				sr.color = c;
			}

			yield return new WaitForSeconds(.1f);
		}
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        //deal player damage

        PlayerAdventure player = other.GetComponent<PlayerAdventure>();
		if (player != null)
		{
			player.TakeDamage(damage);
		}

        if (other.CompareTag("Player")){
            if (timeBtwDamage <= 0)
            {
                camAnim.SetTrigger("shake");
                //other.GetComponent<PlayerAdventure>().health -= damage;
            }
        }
    }
}
