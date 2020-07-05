using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    Transform camPos;
    // Start is called before the first frame update
    void Start()
    {
        camPos = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -7f)
        {
            transform.position = new Vector3(-7, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= 36.75f)
        {
            transform.position = new Vector3(36.75f, transform.position.y, transform.position.z);
        }
        
        
        
    }
}
