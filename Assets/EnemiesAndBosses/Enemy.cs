﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Transform player;
    public EnemyGun enemyGun;

    public  SpriteRenderer sprite;
    SpriteRenderer gunSprite;
    public float lerpSpeed;

    public float speed;
    Vector2 dir;
    
    public States states;
    float randomX;
    float randomY;
    float randomTime;


    void Start()
    {
        states = States.idle;
        player = FindObjectOfType<Player>().transform;
        gunSprite = enemyGun.GetComponentInChildren<SpriteRenderer>();
        enemyGun = enemyGun.GetComponentInChildren<EnemyGun>();
        sprite = GetComponentInChildren<SpriteRenderer>();
        randomTime = Random.Range(5,8);
        enemyGun.enabled = false;
        StartCoroutine(Walk());
        StartCoroutine(DistanceCheck());
    }

    // Update is called once per frame
    void Update()
    {
      
        switch(states)
        {
            case States.idle:
            {
               
               
                transform.position = Vector2.MoveTowards(transform.position,dir,Time.deltaTime * speed);
                
                break;
            }
            case States.fight:
            {   
                Vector3 lookDir = player.position - enemyGun.transform.position;
                float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
               if(angle < -180 || angle > 0)
                {
                    gunSprite.transform.localEulerAngles = new Vector3(0,180,90);
                    sprite.flipX = false;
                }
                else
                {
                    sprite.flipX = true;
                    gunSprite.transform.localEulerAngles = new Vector3(0,0,90);
                }
                enemyGun.transform.rotation = Quaternion.Lerp(enemyGun.transform.rotation, Quaternion.Euler(Vector3.forward * angle), Time.deltaTime * lerpSpeed);
                enemyGun.CheckCooldown();
                break;
            }

          

            
        }
        
    }

    void OnCollisionEnter2D(Collision2D cd)
    {
        if(states == States.idle)
        {
            dir = transform.position;
        }
    }

    IEnumerator Walk()
    {
        while(true)
        {
            if(states == States.idle)
            {
                float randomX = Random.Range(-1.5f,1.5f);
                float randomY = Random.Range(-1.5f,1.5f);

                dir = new Vector2(randomX + transform.position.x,randomY + transform.position.y);
                
            }
            else
            {
                enemyGun.enabled = true;
                StopCoroutine(Walk());
            }
            yield return new WaitForSeconds(randomTime);

        }
        
    }


    IEnumerator DistanceCheck()
    {
        while(true){
            if(Vector3.Distance(transform.position,player.position) < 2)
            {
                states = States.fight;
                enemyGun.enabled = true;
                StopAllCoroutines();
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    public enum States
    {
        idle,
        fight
    }
}
