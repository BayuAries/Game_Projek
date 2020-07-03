using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss2 : MonoBehaviour
{
    public int health;
    public int damage;
    private float timeBtwDamage = 1.5f;

    private Animator anim;
    public Animator camAnim;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 250)
        {
            //anim.SetTrigger("stageTwo");
        }

        if (health <= 0)
        {
            //anim.SetTrigger("death");
        }
        //slider.value = health;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //deal player damage
        if (other.CompareTag("Player")){
            if (timeBtwDamage <= 0)
            {
                camAnim.SetTrigger("shake");
                other.GetComponent<PlayerAdventure>().health -= damage;
            }
        }
    }
}
