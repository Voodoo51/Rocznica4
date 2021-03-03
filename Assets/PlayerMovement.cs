using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;

    Vector2 input;
    Vector3 followPosition;
    public float lerpSpeed;

    Camera cam;
    Vector2 mousePos;

   


    void Start()
    {
        cam = Camera.main; 
      
    }

    
    void Update()
    {
        input = new Vector3(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        followPosition = new Vector3(transform.position.x + input.x/2,transform.position.y + input.y/2,cam.transform.position.z);
        cam.transform.position = Vector3.Lerp(cam.transform.position,followPosition,lerpSpeed * Time.deltaTime);
       
      
       

    }

    
    void FixedUpdate()
    {
        rb.velocity = input * speed * Time.fixedDeltaTime;

       
       
    }
}
