using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    public Image[] slots;
    public GameObject[] weapons;
    public bool isSlotTaken;
    public int whatSlotIsOn;
    Look player;
    GameObject playerG;

    void Start()
    {
        player = FindObjectOfType<Look>();
        weapons[0] = player.gun.gameObject;
        playerG = FindObjectOfType<Player>().gameObject;
    }

    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Alpha1))
         {
              whatSlotIsOn = 0;
              weapons[0].SetActive(true);
              player.gun = weapons[0].transform;
              player.gunSprite = weapons[0].GetComponentInChildren<SpriteRenderer>();
              
              if(isSlotTaken)
              {
                  weapons[1].SetActive(false);
                  
              }
         }
         else if(Input.GetKeyDown(KeyCode.Alpha2))
         {
             if(isSlotTaken)
             {
                whatSlotIsOn = 1;
                weapons[1].SetActive(true);
                weapons[0].SetActive(false);
                player.gun = weapons[1].transform;
                player.gunSprite = weapons[1].GetComponentInChildren<SpriteRenderer>();
             }
         }
    }
    public void PickedUp(int whichSlot, Sprite sprite){
        slots[whichSlot].sprite = sprite; 
    }
    

    public void SelectWeapon(int WhichOne,GameObject weapon)
    {
        GameObject oldGun = weapons[whatSlotIsOn];
        Destroy(oldGun);
        weapons[whatSlotIsOn] = Instantiate(weapon,weapon.transform.position,weapon.transform.rotation);
        weapons[whatSlotIsOn].transform.parent = playerG.transform;

        
        player.gun = weapons[whatSlotIsOn].transform;
        player.gunSprite = weapon.GetComponentInChildren<SpriteRenderer>();
        //player.gun = weapons[whatSlotIsOn].transform;
        //player.gunSprite = weapons[WhichOne].GetComponentInChildren<SpriteRenderer>();
    }
}
