using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject[] bosses;
    private Transform player;
    private bool canUse;

    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        StartCoroutine(CheckCol());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(canUse)
            {
               Boss boss = Instantiate(bosses[Random.Range(0,bosses.Length)],transform.position,Quaternion.identity).GetComponent<RedVanBoss>();
               boss.point = transform;
               Destroy(gameObject.GetComponent<SpawnBoss>());
            }
        }
    }

    IEnumerator CheckCol()
    {
        while(true)
        {
           // print(randomItem);
            Rect rect = new Rect(transform.position.x, transform.position.y, 1, 1);
            rect.center = transform.position;
            canUse = rect.Contains(player.transform.position);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
