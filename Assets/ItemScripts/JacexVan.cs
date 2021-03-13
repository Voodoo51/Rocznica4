using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacexVan : Effect
{
    public JacexVanProjectile van;

    public override void ApplyEffect(Collider2D c2d)
    {
        base.ApplyEffect(c2d);
        if(can)
        {
            Instantiate(van,c2d.transform.position + Vector3.right * 5,Quaternion.identity);
            can = false;
        }
    }
}
