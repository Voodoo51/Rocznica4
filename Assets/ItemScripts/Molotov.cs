using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Effect
{
    public Transform player;


    public MolotovProjectile molotov;

    public override void ApplyEffect(Collider2D c2d)
    {
        base.ApplyEffect(c2d);
        if(can)
        {
            player = FindObjectOfType<Player>().transform;
            Vector3 dir = c2d.transform.position - player.position;
            MolotovProjectile molotovI = Instantiate(molotov,player.position,Quaternion.identity);
            //print(num);
            //print(luck);
            molotovI.AssignValues(5,500,dir);
            can = false;
        }
    }
}
