using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShotGun : EnemyGun
{

    public override void Shoot()
    {
        for(int i = 0; i < 6; i++)
        {
            rotationOffset = Random.Range(-offset, offset + 1);
            Bullet bulletI = Instantiate(bullet, barrel.position, barrel.rotation * Quaternion.Euler(Vector3.forward * rotationOffset));
            bulletI.damage = damage;
        }
    }
}
