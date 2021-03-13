using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public string name;
    public string description;

    public Type type;
    
    public static float luck=1;
    public int chance;
    public int num;
    public bool can;

    public virtual void ApplyEffect(Collider2D c2d){
        int i = Random.Range(0,chance);
        can = num + luck > i;
        print("Num: " + num.ToString());
        print("Chance: " + chance.ToString());
        print("I: " + i.ToString());

    }

    public virtual void UpgradeEffectBasedOnCount(int count)
    {
        print(count);
        num += count;
    }


    public enum Type{
        OnHit,
        Passive
    }
}
