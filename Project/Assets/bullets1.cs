using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets1 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody2D rb;
    public GameObject burstEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        
    }
    
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(40);
        }

        Instantiate(burstEffect, transform.position, Quaternion.identity);
        //if the effect doesnt go away from the screen delete the line of code above.
        Destroy(gameObject);
    }
}
