using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmacznyNapoj : Effect
{
    public override void UpgradeEffectBasedOnCount(int count)
    {
        int sum = 0;
        for(int i = 0; i < count; i++)
        {
            sum += count/10;
        }
        Gun.cooldownMultiplier = 1 - sum;
    }

}
