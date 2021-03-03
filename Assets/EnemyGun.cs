using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : Gun
{

    public override void CheckCooldown()
    {
        if(cooldown > cooldownLength)
            {
                cooldown = 0;
                Shoot();
            }
    }
}
