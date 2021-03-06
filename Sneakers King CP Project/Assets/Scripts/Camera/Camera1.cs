﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    Transform camPos;
    Transform playerPos;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GetComponent<Transform>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(playerPos.position.x + offset.x, playerPos.position.y + offset.y, offset.z); // Camera follows the player with specified offset position

    }
}
