using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangsta_Melee : Enemy, IDamageable
{
    public int Health { get; set; }

    //Untuk Insisalisasi
    public override void Init()
    {
        base.Init();
        Health = base.health;

    }
    
    public void Damage()
    {
        Debug.Log("damage");
        isHit = true;
    }
}
