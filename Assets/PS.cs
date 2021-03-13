using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PS : MonoBehaviour
{
    private ParticleSystem particleSystem;
    public float time;
    private float timer;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();   
    }

   
    void LateUpdate()
    {
        timer+=Time.deltaTime;
        if(timer > time)
        {
            Destroy(gameObject);
        }
    }
}
