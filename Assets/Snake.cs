using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Rigidbody2D rb2;
    Transform target;
    Vector3 dir;
    Vector3 lookDir;
    float angle;
    
    public Transform[] bodys;
    public Transform head;
    Quaternion bodyTarget;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<PlayerMovement>().transform;
        //StartCoroutine(RotateBody());
    }

    // Update is called once per frame

    void Update()
    {
        dir = (target.position - transform.position).normalized;
        lookDir = target.position - transform.right;
        angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
        Vector3 lookDir2 = (target.position - transform.position).normalized;
        //float angle2 = Vector2.Angle(transform.right, lookDir);
        //transform.right = lookDir2;
          
        
        
       // print(angle);
    }


    IEnumerator RotateBody()
    {
        while(true)
        {
            bodyTarget = head.rotation;
            foreach(Transform body in bodys)
            {
                body.rotation = Quaternion.RotateTowards(body.rotation,bodyTarget,Time.deltaTime * 25);
                print(body);
                bodyTarget = body.rotation; 
            }
            yield return null;
        }
    }
    void FixedUpdate()
    {
        
        rb2.AddForce(25 * dir * Time.fixedDeltaTime,ForceMode2D.Impulse);
        if(angle > 0)
        {
            //rigidbody2D.AddForce(15 * dir * Time.fixedDeltaTime,ForceMode2D.Impulse);
        }
        else
        {
            //rigidbody2D.AddForce(-15 * dir * Time.fixedDeltaTime,ForceMode2D.Impulse);
        }
        
        //rigidbody2D.AddTorque(25*Time.fixedDeltaTime,ForceMode2D.Impulse);
       
    }
}
