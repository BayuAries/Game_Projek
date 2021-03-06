﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author : Kelompok CP Project

public class Players : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true;    //menghadap kanan
    float velX, speed = 3f;    //kecepatan jalan
    public int health = 5;             //pengaturan jumlah darah
    int currentHealth;

    bool isHurt, isDead;        //untuk triger

    public float jumpValue;     //kekuatan lompat

    //buton
    public KeyCode leftbutton;        
    public KeyCode rightbutton;
    public KeyCode jump;
    public KeyCode LeftShift;
    public KeyCode trowShoes;

    //objek dilempar dan titik lempar
    public GameObject sepatu;
    public Transform atackPoint;

    public GameObject deathEffect;

    public HealthBar healthBar;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)    //jika tidak mati maka bisa gerak
            if (Input.GetKey(LeftShift))       //lari dengan shift
                speed = 7f;
            else
                speed = 3f;

        //fungsi jump
        if (Input.GetKeyDown(jump) && rb.velocity.y == 0)
            rb.AddForce(Vector2.up * jumpValue);

        if (!isDead)
            //melempar sepatu
            if (Input.GetKeyDown(trowShoes))
            {
                //melempar clone sepatu dan arah lempar
                GameObject cloneSepatu = (GameObject)Instantiate(sepatu, atackPoint.position, atackPoint.rotation);
                cloneSepatu.transform.localScale = transform.localScale;

                //animasi melempar (attack)
                anim.SetTrigger("isAttack");
            }

        AnimationState();       //pengatur animasi gerakan

        Bar();

        //pindah di atas testnya
        // if (!isDead)    //jika tidak mati maka bisa gerak
        //velX = speed;   
    }

    void FixedUpdate()
    {
        if (!isHurt)    //jika tidak sakit
                        //jalan
            if (Input.GetKey(leftbutton))
            {
                rb.velocity = new Vector2(-speed, rb.velocity.y);
            }
            else if (Input.GetKey(rightbutton))
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }//stop
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        // rb.velocity = new Vector2(velX, rb.velocity.y);     //pindah posisi (bergerak)
    }

    void LateUpdate()
    {
        CheckWhereToFace();     //pengecek arah sesuai gerakan
    }

    //pengecek arah sesuai gerakan
    void CheckWhereToFace()
    {
        Vector3 localScale = transform.localScale;
        if (rb.velocity.x > 0)
        {
            facingRight = true;
        }
        else if (rb.velocity.x < 0)
        {
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || (!facingRight) && (localScale.x > 0))
        {
            localScale.x *= -1;

        }

        transform.localScale = localScale;
    }

    //pengecek animasi gerakan
    void AnimationState()
    {
        if (rb.velocity.x == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if (Mathf.Abs(rb.velocity.x) == 3 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        if (Mathf.Abs(rb.velocity.x) == 7 && rb.velocity.y == 0)
            anim.SetBool("isRunning", true);
        else
            anim.SetBool("isRunning", false);

        if (rb.velocity.y > 0)
            anim.SetBool("isJumping", true);

        if (rb.velocity.y < 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        if ((col.tag == "Enemy") || (col.tag == "sepatu"))
        {
            currentHealth -= 1;
        }

        if (((col.tag == "Enemy") || (col.tag == "sepatu")) && currentHealth > 0)
        {
            anim.SetTrigger("isHurt");
            StartCoroutine("Hurt");
        }
        if (currentHealth < 1)
        {
            jumpValue = 0;
            velX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
        }
    }

    public void TakeDamage(int damage)
	{
        anim.SetTrigger("isHurt");
        StartCoroutine("Hurt");
        currentHealth -= damage;
        currentHealth -= damage;

		Debug.Log(currentHealth);

		// StartCoroutine("DamageAnimation");

		if (currentHealth <= 0)
		{
			jumpValue = 0;
            velX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
            StartCoroutine(wait());
		}
	}

    void Die()
	{
		Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}


    IEnumerator Hurt()
    {
        isHurt = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(10f, 100f));
        else
            rb.AddForce(new Vector2(-10f, 100f));

        yield return new WaitForSeconds(0.3f);

        isHurt = false;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds (1);
        Die();

    }

    void Bar()
    {
        healthBar.SetHealth(currentHealth);
    }
}
