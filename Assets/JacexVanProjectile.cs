using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacexVanProjectile : Bullet
{
    float speed = 20; 
    float timeBeforeDeath = 8;
    float timer;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        timer+=Time.deltaTime;
        if(timer>timeBeforeDeath)
        {
            Destroy(gameObject);
        }
    }

}
