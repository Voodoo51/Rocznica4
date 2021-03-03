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
    private float rotationOffset;
    public int ID;
    public float offset;

    public float damage;
    


    
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            CheckCooldown();
            
        }
        cooldown += Time.deltaTime;
    }

    public virtual void Shoot()
    {
        rotationOffset = Random.Range(-offset,offset + 1);
        Bullet bulletI = Instantiate(bullet,barrel.position,barrel.rotation * Quaternion.Euler(Vector3.forward * rotationOffset));
        bulletI.damage = damage;
       
    }
    
    public virtual void CheckCooldown()
    {
            if(cooldown > cooldownLength)
            {
                cooldown = 0;
                Shoot();
            }
    }
}
