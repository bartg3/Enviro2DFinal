using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public float speed;
    public bool MoveRight;

    
    public void TakeDamage ( int damage)
    {
        health -= damage;

        if( health <= 0 )
        {
            enemycounter.scoreValue += 1;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if(MoveRight)
        {
            transform.Translate(2 * Time.deltaTime * speed , 0,0 );
            transform.localScale = new Vector2 (12,12);
        }
        else 
        {
            transform.Translate(-2 * Time.deltaTime * speed , 0,0 );
            transform.localScale = new Vector2 (-12,12);
        }
    }
    void OnTriggerEnter2D(Collider2D trig)
    {
        if(trig.gameObject.CompareTag("Turn"))
        {
            if(MoveRight)
            {
                MoveRight = false;
            }
            else 
            {
                MoveRight = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-25);
        }
    }

}
