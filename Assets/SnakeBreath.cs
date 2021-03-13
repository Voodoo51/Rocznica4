using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBreath : MonoBehaviour
{
    public float cooldownLength;
    public float cooldown;

    public float offset;
    public Transform barrel;

    private float rotationOffset;
    public Bullet bullet;

    public float damage;

    private void Update()
    {
        cooldown += Time.deltaTime;
    }

    public void Shoot()
    {
        rotationOffset = Random.Range(-offset, offset + 1);
        Bullet bulletI = Instantiate(bullet, barrel.position, barrel.rotation * Quaternion.Euler(Vector3.forward * rotationOffset));
        bulletI.damage = damage;

    }
    public void CheckCooldown()
    {
  
        if(cooldown > cooldownLength)
            {
                cooldown = 0;
                Shoot();
            }
    
    }
}
