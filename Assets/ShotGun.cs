using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Gun
{
    public override void Shoot()
    {
        for(int i = 0; i < 6; i++)
        {
            base.Shoot();
        }
    }
}
