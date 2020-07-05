using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class adventureConstraint : MonoBehaviour
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
        if (playerPos.position.x < -18.35f)
        {
            playerPos.transform.position = new Vector3(-18.35f,playerPos.position.y,playerPos.position.z);
        }
    }
}
