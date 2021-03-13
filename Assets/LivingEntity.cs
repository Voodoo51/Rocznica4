using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivingEntity : MonoBehaviour
{
    [HideInInspector]
    public Color ogColor;
    public Color color;
    Rigidbody2D rb;
    Transform target;
    [HideInInspector]
    public SpriteRenderer _renderer;

    Enemy enemy;

    public float maxHealth;
    public float health;
    public string tagName;

    public HealthBar healthBar;

    void Start()
    {
        ogColor = GetComponentInChildren<SpriteRenderer>().color;
        _renderer = GetComponentInChildren<SpriteRenderer>();
        color  = ogColor;
        rb = GetComponent<Rigidbody2D>();

        if(gameObject.tag == "Player")
        {
            healthBar.SetMaxHealth(health);
            target = FindObjectOfType<Player>().transform;
        }
        else if(gameObject.tag == "enemy")
        {
            target = FindObjectOfType<Player>().transform;
            enemy = GetComponent<Enemy>();
           
        }

    }

    void Update()
    {
       color = Color.Lerp(color, ogColor, Time.deltaTime*2);
       _renderer.color = color;

       if(health < 0)
       {
            Destroy(healthBar);
            Destroy(gameObject);
       }
      
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
            else
            {
                healthBar.SetHealth(health);
            }
           
        }
    }

    public virtual void TakeDamage(GameObject c2d)
    {
        color = Color.red;
        health -= c2d.GetComponent<Bullet>().damage;
        Vector2 dir = transform.position - target.position; 
        rb.AddForce(dir * c2d.GetComponent<Bullet>().force * Time.fixedDeltaTime,ForceMode2D.Impulse); 
            
    }
}
