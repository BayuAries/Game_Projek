using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float sepatuSpeed;
    public int damage;
    Rigidbody2D rb;
    public GameObject sepatuEffect;
    Transform projt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projt = GetComponent<Transform>();
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(sepatuSpeed * transform.localScale.x + 4, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        //boss 1
        BossHealth enemy = col.GetComponent<BossHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
		}

        Boss2 enemy2 = col.GetComponent<Boss2>();
		if (enemy2 != null)
		{
			enemy2.TakeDamage(damage);
		}

        Instantiate(sepatuEffect, rb.velocity, transform.rotation);
        if (col.CompareTag("Player") || col.CompareTag("Attack"));
        {
            return;
        }
        Destroy(gameObject);
    }
}
