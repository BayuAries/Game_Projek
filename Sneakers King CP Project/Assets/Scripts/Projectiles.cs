using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float sepatuSpeed;
    //public int damage;
    Rigidbody2D rb;
    public GameObject sepatuEffect;
    Transform projt;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projt = GetComponent<Transform>();
        transform.localScale = new Vector3(0.1f, 0.1f, 0);
    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector2(sepatuSpeed * transform.localScale.x + 4, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        Instantiate(sepatuEffect, rb.velocity, transform.rotation);
        Debug.Log(col.name);
        
        Destroy(gameObject);
    }
}
