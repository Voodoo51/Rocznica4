using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MolotovProjectile : MonoBehaviour
{
    float force;
    float speed;
    float damage;
    Vector3 direction;
    void Start()
    {
        speed = 5;
    }    
    
    public void Update()
    {
        transform.Translate(direction *  speed * Time.deltaTime);
    }

    public void AssignValues(float _damage, float _force, Vector3 dir)
    {
        damage = _damage;
        force = _force;
        direction = dir;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == "enemy")
        {
            Explode();
        }
        else if(c2d.tag == "wall")
        {
            Explode();
        }
    }

    void Explode()
    {
        print("TEST");
        Destroy(gameObject);
    }
}
