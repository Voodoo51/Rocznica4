using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    Color ogColor;
    public Color color;
    Rigidbody2D rb;
    Transform target;
    SpriteRenderer _renderer;

    Enemy enemy;

    public float health;
    public string tagName;

    void Start()
    {
        ogColor = GetComponentInChildren<SpriteRenderer>().color;
        _renderer = GetComponentInChildren<SpriteRenderer>();
        color  = ogColor;
        rb = GetComponent<Rigidbody2D>();

        if(gameObject.tag == "Player")
        {
           
            target = FindObjectOfType<PlayerMovement>().transform;
        }
        else
        {
            target = FindObjectOfType<PlayerMovement>().transform;
            enemy = GetComponent<Enemy>();
           
        }
    }

    void Update()
    {
       color = Color.Lerp(color, ogColor, Time.deltaTime*2);
       _renderer.color = color;

       if(health < 0)
        Destroy(gameObject);
      
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == tagName)
        {
            TakeDamage(c2d.gameObject);
            if(enemy != null)
            {
                enemy.states = Enemy.States.fight;
                enemy.enemyGun.enabled = true;
            }
           
        }
    }

    public void TakeDamage(GameObject c2d)
    {
        color = Color.red;
        health -= c2d.GetComponent<Bullet>().damage;
        Vector2 dir = transform.position - target.position; 
        rb.AddForce(dir * c2d.GetComponent<Bullet>().force * Time.fixedDeltaTime,ForceMode2D.Impulse); 
            
    }
}
