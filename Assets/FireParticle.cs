using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : BulletEnemy
{
    public float timeBeforeDeath;
    private float timer;


    void LateUpdate()
    {
        if(timer > timeBeforeDeath)
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}
