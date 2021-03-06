using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPicked : MonoBehaviour
{
    public Text title;
    public Text description;
    public Image image;

    void Start()
    {
        StartCoroutine(Show());
    }   

    IEnumerator Show()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
