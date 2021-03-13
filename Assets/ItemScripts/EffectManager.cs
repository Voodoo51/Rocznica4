using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    
    public Bleed efekt;
    public static Dictionary<Effect,int> list = new Dictionary<Effect,int>();
   
   void Start()
   {
       print(list);
   }
    public void Check(Collider2D c2d,GameObject bullet)
    {
        foreach(KeyValuePair<Effect,int>  countAndEffect in list)
        {
            countAndEffect.Key.ApplyEffect(c2d);
        }
        Destroy(bullet);
    }
   
}



