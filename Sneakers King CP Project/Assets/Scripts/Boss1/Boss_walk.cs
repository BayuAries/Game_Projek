using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walk : StateMachineBehaviour
{

    Transform player;
    Rigidbody2D rb;
    Transform Bossrotation;
    public float speed = 1f;
    public float attackRange = 0.01f;
    bool boss1;
    Boss1 bosss1;
    


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindWithTag("Boss1").GetComponent<Rigidbody2D>();
        Bossrotation = GameObject.FindWithTag("Boss1").GetComponent<Transform>();
        boss1 = GameObject.FindWithTag("Boss1").GetComponent<SpriteRenderer>();
        //animator.GetComponent<Rigidbody2D>();
        bosss1 = animator.GetComponent<Boss1>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        bosss1.LookAtPlayer();


        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("Attack");
        }

    }

    ////OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

}
