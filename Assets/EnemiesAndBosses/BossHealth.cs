using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : LivingEntity
{
    
    void Start()
    {
        healthBar.SetMaxHealth(health);
        _renderer = GetComponent<SpriteRenderer>();
        ogColor = _renderer.color;
        color  = ogColor;
    }
 
    void Update()
    {
        if(health <= 0) 
        {
            GetComponent<Boss>().OnDeath();
            Destroy(healthBar.gameObject);
            Destroy(FindObjectOfType<Notification>().bossName);
            Destroy(GetComponent<Boss>());
            Destroy(gameObject);
        }
        color = Color.Lerp(color, ogColor, Time.deltaTime*2);
       _renderer.color = color;
    }

    public override void TakeDamage(GameObject c2d)
    {
        if(c2d.tag == "bullet")
        {
            try{
            health -= c2d.GetComponent<Bullet>().damage;
            color = Color.red;
            healthBar.SetHealth(health);
            }
            catch
            {

            }
        }
    }

    public void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == "bullet")
        {
            TakeDamage(c2d.gameObject);
        }
    }
}
