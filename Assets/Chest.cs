using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] weapons;
    public GameObject[] items;

    int whatWeapon;
    SpriteRenderer spriteRenderer;
    SpriteRenderer spriteRendererSelf;

    public Sprite chestOpened;

    bool canOpen;
    bool isOpen;
    bool hasItem;

    GameObject player;
    Look playerGun;
    Inventory inventory;
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
        playerGun = FindObjectOfType<Look>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRendererSelf = transform.GetChild(1).GetComponent<SpriteRenderer>();
        inventory = FindObjectOfType<Inventory>();
        int weaponOrItem = Random.Range(0,10);
        whatWeapon = Random.Range(0,weapons.Length);
        
    }

    void Update()
    {
        Rect rect = new Rect(transform.position.x, transform.position.y, 1, 1);
        rect.center = transform.position;
        canOpen = rect.Contains(player.transform.position);
     

        if(!isOpen)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(canOpen)
                {
                
                    isOpen=true;
                    spriteRenderer.sprite = weapons[whatWeapon].GetComponentInChildren<SpriteRenderer>().sprite;
                    spriteRendererSelf.sprite = chestOpened;
                }
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                if(canOpen)
                {
                
                if(inventory.isSlotTaken)
                {
                    isSlotTaken();
                }
                else
                {
                    Sprite sprite = spriteRenderer.sprite;
                    inventory.slots[1].sprite =  sprite;     
                    inventory.weapons[1] = Instantiate(weapons[whatWeapon],playerGun.gun.position,playerGun.gun.rotation);
                    inventory.weapons[1].transform.parent = player.transform; 
                    inventory.weapons[1].SetActive(false);
                    inventory.isSlotTaken = true;
                    Destroy(spriteRenderer);
                    Destroy(gameObject.GetComponent<Chest>());
                }
                }
                
            }
        }
       
    }

    
    void isSlotTaken()
    {
                    Sprite sprite = spriteRenderer.sprite;
                    GameObject oldGun = playerGun.gun.gameObject;
                    

                    spriteRenderer.sprite = inventory.slots[inventory.whatSlotIsOn].sprite;

                    Destroy(oldGun);

                    
                    
                    inventory.weapons[inventory.whatSlotIsOn] = Instantiate(weapons[whatWeapon],playerGun.gun.position,playerGun.gun.rotation);
                    inventory.weapons[inventory.whatSlotIsOn].GetComponentInChildren<SpriteRenderer>().sprite = sprite;
                    inventory.weapons[inventory.whatSlotIsOn].transform.parent = player.transform;

                    playerGun.gunSprite = inventory.weapons[inventory.whatSlotIsOn].GetComponentInChildren<SpriteRenderer>();
                    playerGun.gun = inventory.weapons[inventory.whatSlotIsOn].transform;
                    
                    print(whatWeapon);

                    
                    inventory.PickedUp(inventory.whatSlotIsOn,sprite);
                    inventory.weapons[inventory.whatSlotIsOn].SetActive(true);
                    whatWeapon = oldGun.GetComponentInChildren<Gun>().ID;
    }
    void OnDrawGizmos()
    {
        // Green
        Gizmos.color = new Color(0.0f, 1.0f, 0.0f);
        Rect rect = new Rect(transform.position.x, transform.position.y, 1, 1);
        rect.center = transform.position;
        DrawRect(rect);
    }

    void DrawRect(Rect rect)
    {
        Gizmos.DrawWireCube(new Vector3(rect.center.x, rect.center.y, 0.01f), new Vector3(rect.size.x, rect.size.y, 0.01f));
    }
}
