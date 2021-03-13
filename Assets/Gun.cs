using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Bullet bullet;
    public Transform barrel;
    public float cooldownLength;

    [HideInInspector]
    public float cooldown;
    
    [HideInInspector]
    public float rotationOffset;
    public int ID;
    public float offset;

    public float damage;
    public static float damageMultiplier = 1;
    public static float cooldownMultiplier = 1;

    
    void Update()
    {
        
        
        CheckCooldown();
            
        
        cooldown += Time.deltaTime;
    }

    public virtual void Shoot()
    {
        rotationOffset = Random.Range(-offset,offset + 1);
        Bullet bulletI = Instantiate(bullet,barrel.position,barrel.rotation * Quaternion.Euler(Vector3.forward * rotationOffset));
        bulletI.damage = damage * damageMultiplier;
       
    }
    
    public virtual void CheckCooldown()
    {
        if(Input.GetMouseButton(0))
        {
            if(cooldown > cooldownLength * cooldownMultiplier)
            {
                cooldown = 0;
                Shoot();
            }
        }
    }
}
