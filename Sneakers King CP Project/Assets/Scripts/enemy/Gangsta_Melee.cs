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
        
        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("hit " + other.name);
        if (other == other.gameObject.name.Equals("sepatu"))
        {
            health -= 1;
            Debug.Log("Health" + health);
        }
        if (other == other.gameObject.name.Equals("player"))
        {
            health -= 1;
            Debug.Log("Health" + health);
        }
    }
}
