using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Molotov : Effect
{
    public Transform player;


    public MolotovProjectile molotov;


    public override void ApplyEffect(Collider2D c2d, int count)
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        Vector3 dir = c2d.transform.position - player.position;
        MolotovProjectile molotovI = Instantiate(molotov,player.position,Quaternion.identity);
        molotovI.AssignValues(5,500,dir);
    }
}
