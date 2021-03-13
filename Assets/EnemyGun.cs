using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{

    public override void Shoot()
    {
        rotationOffset = Random.Range(-offset, offset + 1);
        Bullet bulletI = Instantiate(bullet, barrel.position, barrel.rotation * Quaternion.Euler(Vector3.forward * rotationOffset));
        bulletI.damage = damage;
    }

    public override void CheckCooldown()
    {
        if(cooldown > cooldownLength)
            {
                cooldown = 0;
                Shoot();
            }
    }
}
