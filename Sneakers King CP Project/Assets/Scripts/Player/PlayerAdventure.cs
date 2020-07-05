using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAdventure : MonoBehaviour
{
    //handle rigidbody
    private Rigidbody2D _rigid;

    public bool _grounded = false;
    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    private LayerMask _groundlayer;
    private bool resetJumpNeeded = false;
    [SerializeField]
    private float _speed = 2.5f;

    private Animator anim;
    private SpriteRenderer _playersprite;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _playersprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //if lefklik atak
        if (Input.GetMouseButtonDown(0) && _grounded == true)
        {
            
        }

    }
    public void Movement()
    {

        //horizontal input
        float move = Input.GetAxisRaw("Horizontal");

        if (move > 0)
        {
            _playersprite.flipX = true;
        }
        else if (move < 0)
        {
            _playersprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && _grounded == true)
        {

            _rigid.velocity = new Vector2(_rigid.velocity.x, _jumpforce);
            //_grounded = false;
            resetJumpNeeded = true;
            StartCoroutine(ResetJumpNeededRoutine());

            //jump animation is true
        }
        
        _rigid.velocity = new Vector2(move * _speed, _rigid.velocity.y);
        if (move > 0 || move < 0)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


    }

    //bool IsGrounded()
    //{
    //    RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, Vector2.down, 0.8f, _groundlayer.value);
    //    Debug.DrawRay(transform.position, Vector2.down * 0.8f, Color.green);

    //    if (hitinfo.collider != null)
    //    {

    //        if (resetJumpNeeded == false)
    //        {
    //            _playeranim.Jump(false);
    //            return true;
    //        }


    //    }
    //}


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
            //Debug.Log("grounded");     
        }

    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = false;
            //Debug.Log("groundednot");

        }

    }

    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        resetJumpNeeded = false;
    }



}

