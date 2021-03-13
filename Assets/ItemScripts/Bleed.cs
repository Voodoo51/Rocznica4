using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleed : Effect
{
    LivingEntity livingEntity;
    public int HowManyIterations;
    public float TimeBetweenIteration;
    
    void Start()
    {
        livingEntity = GetComponent<LivingEntity>();
        HowManyIterations = 5;
        TimeBetweenIteration = 1;
        StartCoroutine(BleedOut());    
    }

    // Update is called once per frame
    IEnumerator BleedOut()
    {
        int i = 0;
        while(i < HowManyIterations)
        {
            yield return new WaitForSeconds(TimeBetweenIteration);
            livingEntity.color = Color.red;
            livingEntity.health -= 1;
            i++;
            
        }
    }

    public override void ApplyEffect(Collider2D c2d)
    {
        base.ApplyEffect(c2d);
        if(can)
        {
            c2d.gameObject.AddComponent<Bleed>();
            can = false;
        }
    }
}
