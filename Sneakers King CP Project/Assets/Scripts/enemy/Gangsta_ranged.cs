using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gangsta_ranged : Enemy, IDamageable
{
    public int Health { get ; set; }

    

    //untuk inisialisasi
    public override void Init()
    {
        base.Init();
    }
    public void Damage()
    {
       
    }
}
