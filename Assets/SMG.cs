using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMG : Gun
{
    public override void Shoot()
    {
        StartCoroutine(Delay());
    }


    IEnumerator Delay()
    {
        for(int i = 0; i < 3; i++)
        {
            base.Shoot();
            yield return new WaitForSeconds(0.05f);
        }
    }
}
