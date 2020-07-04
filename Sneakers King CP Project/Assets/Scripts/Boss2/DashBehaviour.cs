using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashBehaviour : StateMachineBehaviour
{
    private float timer;
    public float minTime;
    public float maxTime;
    [SerializeField]
    Transform pointA, pointB;
    Rigidbody2D rb;
    private Transform playerPos;
    public float speed;
    float DashDirection;
    Vector3 currentTarget;
    bool destinationReached = false;
    SpriteRenderer sprite;
    SpriteRenderer effectsprite;
    SpriteRenderer effectsprite2;
    Animator dasheffect;
    Animator dasheffect2;
    Animator Aura;
    Animator camAnim;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timer = Random.Range(minTime, maxTime);
        rb = GameObject.FindWithTag("Boss2").GetComponentInChildren<Rigidbody2D>();
        pointA = GameObject.FindWithTag("PointA").GetComponent<Transform>();
        sprite = GameObject.FindWithTag("Boss2").GetComponent<SpriteRenderer>();
        pointB = GameObject.FindWithTag("PointB").GetComponent<Transform>();
        effectsprite = GameObject.FindWithTag("Boss2").transform.GetChild(0).GetComponent<SpriteRenderer>();
        effectsprite2 = GameObject.FindWithTag("Boss2").transform.GetChild(1).GetComponent<SpriteRenderer>();
        dasheffect = GameObject.FindWithTag("Boss2").transform.GetChild(0).GetComponent<Animator>();
        dasheffect2 = GameObject.FindWithTag("Boss2").transform.GetChild(1).GetComponent<Animator>();
        Aura = GameObject.FindWithTag("Boss2").transform.GetChild(2).GetComponent<Animator>();
        camAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        DashDirection = rb.position.x - playerPos.position.x;
        if (rb.position.x == pointA.position.x)
        {
            currentTarget.x = pointB.position.x;
            sprite.flipX = true;
            effectsprite.flipX = true;
            effectsprite2.flipX = true;
            dasheffect.SetTrigger("Dash");
            dasheffect2.SetTrigger("Dash");
            Aura.SetBool("ON", false);
            camAnim.SetTrigger("Shake");
        }
        else if (rb.position.x == pointB.position.x)
        {
            currentTarget.x = pointA.position.x;
            sprite.flipX = false;
            effectsprite.flipX = false;
            effectsprite2.flipX = false;
            dasheffect.SetTrigger("Dash");
            dasheffect2.SetTrigger("Dash");
            Aura.SetBool("ON", false);
            camAnim.SetTrigger("Shake");
        }

        Debug.Log(currentTarget);
        
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, new Vector3(currentTarget.x, rb.transform.position.y, rb.transform.position.z), speed * Time.deltaTime);
        if (timer <= 0)
        {
            animator.SetTrigger("idle");
            dasheffect.ResetTrigger("Dash");
            dasheffect2.ResetTrigger("Dash");
            Aura.SetBool("ON", true);
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
