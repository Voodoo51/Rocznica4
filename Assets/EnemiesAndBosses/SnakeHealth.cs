using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHealth : MonoBehaviour
{
    public Snake snake;
    public int index;
    public float health;

    SpriteRenderer renderer;

    Color color;
    Color ogColor;

    void Start()
    {
        renderer = GetComponentInChildren<SpriteRenderer>();
        ogColor = renderer.color;
        color = ogColor;
    }
    
    void LateUpdate()
    {
        if(health <= 0)
        {
            snake.OnBodyDeath(index);
        }
        color = Color.Lerp(color, ogColor, Time.deltaTime * 2);
        renderer.color = color;
    }

    void OnTriggerEnter2D(Collider2D c2d)
    {
        if (c2d.GetComponent<Bullet>())
        {
            if (c2d.tag == "bullet")
            {
                health -= c2d.GetComponent<Bullet>().damage;
                color = Color.red;
                Destroy(c2d.gameObject);
            }
        }
        else if (c2d.tag == "Player")
        {
            c2d.GetComponent<LivingEntity>().health -= 1;
            color = Color.red;
        }
    }


}
