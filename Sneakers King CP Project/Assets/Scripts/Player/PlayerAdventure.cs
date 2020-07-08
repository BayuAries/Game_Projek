using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerAdventure : MonoBehaviour
{
    //handle rigidbody
    private Rigidbody2D _rigid;
    [SerializeField]
    public int _health = 50;
    private float _energy = 100;
    public bool _grounded = false;
    [SerializeField]
    private float _jumpforce = 5.0f;
    [SerializeField]
    
    private bool resetJumpNeeded = false;
    [SerializeField]
    private float _speed = 2.5f;
    public KeyCode LeftShift;
    private Animator anim;
    private SpriteRenderer _playersprite;

    public KeyCode energyShoot;
    public KeyCode punch;

    public HealthBar healthBar;
    public EnergyBar energyBar;
    public float regeneration = 1;

    public Transform ShootPoint;
    public GameObject projectiles;
    Animator camAnim;
    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _playersprite = GetComponentInChildren<SpriteRenderer>();
        healthBar.SetMaxHealth(_health);
        camAnim = GameObject.FindWithTag("MainCamera").GetComponent<Animator>();
        energyBar.SetMaxHealth(_energy);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        //if lefklik atak
        if (Input.GetKeyDown(punch) && _grounded == true)
        {
            anim.SetTrigger("punch");
        }
        Bar();
        EnergyBar();
        
            
        if (_energy > 0)
        {
            if (Input.GetKeyDown(energyShoot))
            {
                //melempar clone sepatu dan arah lempar
                GameObject cloneSepatu = (GameObject)Instantiate(projectiles, ShootPoint.position, ShootPoint.rotation);
                cloneSepatu.transform.localScale = transform.localScale;

                //animasi melempar (attack)
                anim.SetTrigger("punch");
                _energy -= 5;
            }
        }
        if (_energy < 100)
        {
            _energy += regeneration * Time.deltaTime; ;
        }
    }
    public void Movement()
    {

        //horizontal input
        float move = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(LeftShift))       //lari dengan shift
        { _speed = 6f; }
        else
        { _speed = 2.5f; }
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;       
        }

        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss1")
        {
            _health -= 2;
            Debug.Log(_health);
            _rigid.velocity = new Vector2(_rigid.velocity.x + -3, _rigid.velocity.y + 1f);
            camAnim.SetTrigger("Shake");
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = false;
        }
    }
    IEnumerator ResetJumpNeededRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        resetJumpNeeded = false;
    }
    void Bar()
    {
        healthBar.SetHealth(_health);
    }
    void EnergyBar()
    {
        energyBar.SetHealth(_energy);
    }


    public void TakeDamage(int damage)
	{
		_health -= damage;

		StartCoroutine(DamageAnimation());

        Debug.Log(_health);

		if (_health <= 0)
		{
			Die();
		}
	}

    void Die()
	{
		Destroy(gameObject);
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
}

