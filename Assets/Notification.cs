using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    public RectTransform pos;
    public Text bossName;
    public RectTransform bossHPos;
    public HealthBar healthBar;
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

    public void ShowBossHealth(string name, HealthBar bar)
    {
        bossName.text = name;
        bar.GetComponent<RectTransform>().position = bossHPos.position;
        bar.GetComponent<RectTransform>().SetParent(transform);
    }
        
}
