using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangsta3 : MonoBehaviour
{
    public int attackDamage = 1;
    public int health = 5;
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected Transform pointA, pointB;
    Transform player;
    protected Vector3 currentTarget;
    protected Animator anim;
    protected SpriteRenderer sprite;
    public GameObject deathEffect;
    public GameObject sepatu;
    public Transform gangsta1;
    protected bool Chasing = false;
    protected bool isHit = false;

    float distance;
    float ydistance;
    public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;


    public virtual void Init()
    {
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        sepatu = GameObject.FindWithTag("sepatu");
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        gangsta1 = GetComponentInChildren<Transform>();
    }
    private void Start()
    {
        Init();
    }
    public void Update()
    {
        distance = player.position.x - transform.position.x;
        ydistance = player.position.y - transform.position.y;
        //Debug.Log(distance);
        if ((distance > -7.5f && distance < 7.5f) && (ydistance < 2 && ydistance > -2))
        {
            currentTarget.x = player.position.x;
            Chasing = true;
            isHit = false;

        }
        if (distance < 0.5f && distance > -0.5f)
        {
            Debug.Log("attack range");
            anim.SetTrigger("Hit");
            isHit = true;
            Attack();

        }
        KillChecker();
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            return;
        }
        Movement();

    }

    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
        if (colInfo != null)
        {
            colInfo.GetComponent<Players>().TakeDamage(attackDamage);
        }
    }
    void OnDrawGizmosSelected()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Gizmos.DrawWireSphere(pos, attackRange);
    }

    public virtual void Movement()
    {
        if (Chasing == false)
        {
            if (currentTarget.x == pointA.position.x)
            {
                sprite.flipX = true;
            }
            else if (currentTarget.x == pointB.position.x)
            {
                sprite.flipX = false;
            }
        }
        else if (Chasing == true)
        {
            if (distance < 0)
            {
                sprite.flipX = true;
            }
            else
            {
                sprite.flipX = false;
            }
        }

        
            if (transform.position.x == pointA.position.x)
            {
                currentTarget.x = pointB.position.x;
                anim.SetTrigger("idle");
            }
            else if (transform.position == pointB.position)
            {
                currentTarget.x = pointA.position.x;
                anim.SetTrigger("idle");
            }



        if (isHit == false)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentTarget.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }

    }

    public void TakeDamage()
    {
        if (health > 0)
        {
            health -= 1;

            Debug.Log(health);
        }

        // StartCoroutine("DamageAnimation");


    }
    public void KillChecker()
    {
        if (health < 1)
        {
            Debug.Log("EnemyKilled");
            Destroy(this.gameObject);
        }
    }

}
