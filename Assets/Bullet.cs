using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public EffectManager effectManager;
    public float force;
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.up *  speed * Time.deltaTime);
        
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == "Wall")
        {
            Destroy(gameObject);
        }
        else
        {
            if(tag == "bullet")
            {
                if(c2d.tag == "enemy")
                {
                    effectManager.Check(c2d,gameObject);
                }
            }
            else
            {
                if(c2d.tag == "Player")
                {
                    Destroy(gameObject);
                }
            }
        }
    }
}
