using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    public RectTransform pos;
    void Start()
    {
        
    }

 
    void Update()
    {
        
    }

    public IEnumerator Show(ItemPicked item)
    {
        item.transform.SetParent(transform);
        item.GetComponent<RectTransform>().position = pos.position;
        yield return new WaitForSeconds(3);
    }
}
