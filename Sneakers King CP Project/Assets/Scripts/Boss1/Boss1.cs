using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonoBehaviour
{
    Transform player;

    private SpriteRenderer _BossSprite;


    // Start is called before the first frame update
    void Start()
    {
        _BossSprite = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.x < transform.position.x)
        {
            _BossSprite.flipX = false;
        }else if(player.position.x > transform.position.x)
        {
            _BossSprite.flipX = true;
        }
    }
}
