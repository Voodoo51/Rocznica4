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

    //public Transform[] bodys;
    public List<Transform> bodys;
    public Transform head;
    Quaternion bodyTarget;
    public GameObject blood;

 
    //public 

    void Start()
    {

        rb2 = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<Player>().transform;

        //StartCoroutine(RotateBody());


    }

 

    void Update()
    {
        
        dir = (target.position - transform.position).normalized;
        lookDir = target.position - transform.position;
        angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
        Vector3 lookDir2 = (target.position - transform.position).normalized;
    
        transform.right = lookDir2;

       
    }


    IEnumerator RotateBody()
    {
        while(true)
        {
            bodyTarget = head.rotation;
            foreach(Transform body in bodys)
            {
                body.rotation = Quaternion.RotateTowards(body.rotation,bodyTarget,Time.deltaTime * 25);
                bodyTarget = body.rotation; 
            }
            yield return null;
        }
    }
    void FixedUpdate()
    {
        
        rb2.AddForce(35 * dir * lookDir.magnitude * Time.fixedDeltaTime,ForceMode2D.Impulse);
        if(angle > 0)
        {
            //rb2.AddForce(15 * dir * Time.fixedDeltaTime,ForceMode2D.Impulse);
        }
        else
        {
            //rb2.AddForce(-15 * dir * Time.fixedDeltaTime,ForceMode2D.Impulse);
        }
        
        rb2.AddTorque(25*Time.fixedDeltaTime,ForceMode2D.Impulse);
       
    }

    public void OnBodyDeath(int index)
    {
        int i = 1;
        int cunt = bodys.Count;

        while(i < index)
        {

                Instantiate(blood, bodys[cunt - i].position, Quaternion.identity);
                Destroy(bodys[cunt - i].gameObject);
                bodys.Remove(bodys[cunt  - i]);
                i++;
            
            
        }
        if (index == 0)
        {
            while (cunt - i >= 0)
            { 
                Instantiate(blood, bodys[cunt - i].position, Quaternion.identity);
                Destroy(bodys[cunt - i].gameObject);
                bodys.Remove(bodys[cunt - i]);
                i++;
            }
        }
        
  
    }

   
}
