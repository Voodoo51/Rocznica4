using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
  
    public float force;
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.up *  speed * Time.deltaTime);
        
    }

}
