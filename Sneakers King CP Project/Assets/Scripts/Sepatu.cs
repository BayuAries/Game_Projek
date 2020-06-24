﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sepatu : MonoBehaviour
{
    public float sepatuSpeed;
    Rigidbody2D rb;
    public GameObject sepatuEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

        // Update is called once per frame
        void Update()
    {
        rb.velocity = new Vector2(sepatuSpeed * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D (Collider2D col)
    {
        

        Instantiate(sepatuEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
