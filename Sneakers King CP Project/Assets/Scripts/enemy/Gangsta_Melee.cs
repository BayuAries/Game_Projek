using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangsta_Melee : Enemy
{
    private Vector3 _currentTarget;
    private Animator _anim;
    private SpriteRenderer _gangstaSprite;
    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
        _gangstaSprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (_anim.GetCurrentAnimatorStateInfo(0).IsName("Enemy_idle"))
        {
            return;
        }
        if (_currentTarget == pointA.position)
        {
            _gangstaSprite.flipX = true;
        }
        else
        {
            _gangstaSprite.flipX = false;
        }



        Movement();
    }

    void Movement()
    {
        if (transform.position == pointA.position)
        {
            _currentTarget = pointB.position;
            _anim.SetTrigger("idle");
            
        }
        else if (transform.position == pointB.position)
        {
            _currentTarget = pointA.position;
            _anim.SetTrigger("idle");
            
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, speed * Time.deltaTime);

    }

}
