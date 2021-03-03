using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public Transform gun;
    public SpriteRenderer playerSprite;

    [HideInInspector]
    public SpriteRenderer gunSprite;

    [HideInInspector]
    public int whatSlotIsOn;

    Inventory inventory;
    Vector3 mousePos;

    bool can;
    void Start()
    {
        gunSprite = gun.GetComponentInChildren<SpriteRenderer>();
        inventory = FindObjectOfType<Inventory>();
        inventory.PickedUp(0,gunSprite.GetComponentInChildren<SpriteRenderer>().sprite);
    }

    // Update is called once per frame
    void Update()
    {
         mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
         
        Vector3 lookDir = mousePos - gun.position;
        float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;
        if(angle < -180 || angle > 0)
        {
            gunSprite.transform.localEulerAngles = new Vector3(0,0,90);
            playerSprite.flipX = false;
        }
        else
        {
            gunSprite.transform.localEulerAngles = new Vector3(0,180,90);
            playerSprite.flipX = true;
        }
        gun.rotation = Quaternion.Euler(Vector3.forward * angle );
       
    }


    void Rotate(int minusOrAdd)
    {
        if(can)
        {
            if(minusOrAdd == 0)
            {
                gun.eulerAngles = new Vector3(gun.eulerAngles.x,gun.eulerAngles.y - 180,gun.eulerAngles.z);
            }
            else
            {
                gun.eulerAngles = new Vector3(gun.eulerAngles.x,gun.eulerAngles.y + 180,gun.eulerAngles.z);
            }
            can = false;
        }

    }
}
