using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GangMember : Enemy
{
    void Start()
    {
        attack();
    }

    // Update is called once per frame
    public override void update()
    {
        Debug.Log("Gangsta_melee updating");
    }
}
