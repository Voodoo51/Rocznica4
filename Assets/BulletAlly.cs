using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAlly : Bullet
{
    public EffectManager effectManager;


    void OnTriggerEnter2D(Collider2D c2d)
    {   
        if(c2d.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else if(c2d.tag == "enemy")
        {
            effectManager.Check(c2d,gameObject);
        }
    }
}
