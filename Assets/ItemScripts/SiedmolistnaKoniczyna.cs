using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiedmolistnaKoniczyna : Effect
{
    
   public override void UpgradeEffectBasedOnCount(int count)
   {
       float sum=0;
       for(int i = 0; i < count; i++)
       {
           sum += count/10;
       }
       Effect.luck = 1 + sum;
   }
}
