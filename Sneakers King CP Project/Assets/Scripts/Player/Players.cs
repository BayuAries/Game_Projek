using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author : Kelompok CP Project

public class Players : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    bool facingRight = true;    //menghadap kanan
    float velX, speed = 3f;    //kecepatan jalan
    int health = 5;             //pengaturan jumlah darah
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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(LeftShift))       //lari dengan shift
            speed = 7f;
        else
            speed = 3f;
        
        //fungsi jump
        if (Input.GetKeyDown(jump) && rb.velocity.y == 0)      
            rb.AddForce(Vector2.up * jumpValue);

        //melempar sepatu
        if (Input.GetKeyDown(trowShoes))
        {
            //melempar clone sepatu dan arah lempar
            GameObject cloneSepatu = (GameObject)Instantiate(sepatu, atackPoint.position, atackPoint.rotation);
            cloneSepatu.transform.localScale = transform.localScale ;

            //animasi melempar (attack)
            anim.SetTrigger("isAttack");
            
        }

        AnimationState();       //pengatur animasi gerakan

        if (!isDead)    //jika tidak mati maka bisa gerak

        velX = Input.GetAxisRaw("Horizontal") * speed;  
    }

    void FixedUpdate()
    {
        if (!isHurt)    //jika tidak sakit

        rb.velocity = new Vector2(velX, rb.velocity.y);     //pindah posisi (bergerak)
    }

    void LateUpdate()
    {
        CheckWhereToFace();     //pengecek arah sesuai gerakan
    }

    //pengecek arah sesuai gerakan
    void CheckWhereToFace()
    {
        Vector3 localScale = transform.localScale;
        if (velX > 0)
        {
            facingRight = true;
        }else if (velX < 0)
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
        if (velX == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", false);
        }
        if (rb.velocity.y == 0)
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
        }
        if (Mathf.Abs(velX) == 3 && rb.velocity.y == 0)
            anim.SetBool("isWalking", true);
        if (Mathf.Abs(velX) == 7 && rb.velocity.y == 0)
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
        if (col.gameObject.name.Equals("baja") || col.gameObject.name.Equals("sepatu"))
        {
            health -= 1;
        }

        if ((col.gameObject.name.Equals("baja") || col.gameObject.name.Equals("sepatu")) && health > 0)
        {
            anim.SetTrigger("isHurt");
            StartCoroutine("Hurt");
        }else
        {
            jumpValue = 0;
            velX = 0;
            isDead = true;
            anim.SetTrigger("isDead");
        }
    }

    IEnumerator Hurt()
    {
        isHurt = true;
        rb.velocity = Vector2.zero;

        if (facingRight)
            rb.AddForce(new Vector2(-100f, 100f));
        else
            rb.AddForce(new Vector2(100f, 100f));

        yield return new WaitForSeconds(0.3f);

        isHurt = false;
    }
}
