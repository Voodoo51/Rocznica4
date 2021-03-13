using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    
    public HealthBar healthBar;
    public Transform point;
    public GameObject portal;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public virtual void OnDeath()
    {
        Instantiate(portal,transform.position,Quaternion.identity);
    }
}
