using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
   
    //Dictionary<int, string> dic = new Dictionary<int,string>();
    //Tuple<int,Effect>[] para;
    //Tuple<int,string>

    
    public Bleed efekt;
    public static Dictionary<Effect,int> list = new Dictionary<Effect,int>();
    //KeyValuePair<Effect,int> inv;
    
  
    
   void Awake()
   {
       //inv = new KeyValuePair<Effect,int>(efekt,1);
       list.Add(efekt,1);
   }

    public void Check(Collider2D c2d,GameObject bullet)
    {
        foreach(KeyValuePair<Effect,int>  countAndEffect in list)
        {
            countAndEffect.Key.ApplyEffect(c2d,countAndEffect.Value);
        }
        Destroy(bullet);
    }
   
}



