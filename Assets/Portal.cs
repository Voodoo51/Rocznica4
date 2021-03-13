using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.gameObject.GetComponent<Player>())
        {
            GameManager.LoadNextScene();
        }
    }
}
