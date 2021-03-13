using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacexVanProjectile : Bullet
{
     
    float timeBeforeDeath = 2;
    float timer;
    public static float chance;


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
