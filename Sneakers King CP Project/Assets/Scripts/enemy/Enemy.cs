using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    [SerializeField]
    protected Transform pointA, pointB;

    public virtual void attack()
    {
        Debug.Log("baseAttack called");
    }

    public abstract void Update();

}
