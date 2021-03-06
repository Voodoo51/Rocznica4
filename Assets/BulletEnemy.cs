using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Bullet
{
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(c2d.tag == "Player")
        {
                    Destroy(gameObject);
        }
        
    }
}
