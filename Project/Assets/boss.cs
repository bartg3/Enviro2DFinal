using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss : MonoBehaviour
{
    public int health = 400;

    
    public void TakeDamage ( int damage)
    {
        health -= damage;

        if( health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
