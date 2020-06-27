using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangsta_ranged : Enemy
{
    void Start()
    {
        attack();
    }

    public override void attack()
    {
        Debug.Log("ranged attack");
        base.attack();
    }
    public override void update()
    {
        Debug.Log("Ranged_updating");
    }
}
