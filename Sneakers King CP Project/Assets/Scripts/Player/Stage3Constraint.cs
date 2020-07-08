using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Constraint : MonoBehaviour
{
    Transform playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos.position.x < -8.5f)
        {
            playerPos.transform.position = new Vector3(-8.5f, playerPos.position.y, playerPos.position.z);
        }
        else if (playerPos.position.x > 8.5)
        {
            playerPos.transform.position = new Vector3(8.5f, playerPos.position.y, playerPos.position.z);
        }
    }
}
