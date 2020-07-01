using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA, pointB;
    
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    public GameObject deathEffect;
    public GameObject sepatu;
    protected bool isHit = false;

    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        sepatu = GameObject.FindWithTag("sepatu");
    }
    private void Start()
    {
        Init();
    }

    public virtual void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        Movement();       
    }

    public virtual void Movement()
    {
        if (currentTarget == pointA.position)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            anim.SetTrigger("idle");

        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            anim.SetTrigger("idle");

        }
        if (isHit == false)
        {
            
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit " + other.name);
        if (other == other.gameObject.name.Equals("sepatu"))
        {
            health -= 1;
            Debug.Log("Health" + health);
        }
        if (other == other.gameObject.name.Equals("player"))
        {
            health -= 1;
            Debug.Log("Health" + health);
        }
    }


}
