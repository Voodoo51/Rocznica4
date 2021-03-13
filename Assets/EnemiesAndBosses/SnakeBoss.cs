using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeBoss : Boss
{
    public SnakeBreath flamethrower;
    static Transform player;
    public GameObject smoke;
    private float overheat;
    bool overHeatStarted = false;
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        StartCoroutine(CheckDis());
    }

   
    void Update()
    {
        
    }

    IEnumerator CheckDis()
    {

        while (true)
        {
            print(overheat);
            if (overheat > 250)
            {
                StartCoroutine(OverHeat());
                print("Did");
                yield return null;
            }
            else
            { 
                if (Vector3.Distance(transform.position, player.position) < 3.5f)
                 {
                    flamethrower.CheckCooldown();
                    print("s");
                    overheat += 5;
                }
                    yield return new WaitForSeconds(0.1f);
               
            }
        }
                
    }

    IEnumerator OverHeat()
    {
        if (!overHeatStarted)
        {
            overHeatStarted = true;
            Transform t = Instantiate(smoke, flamethrower.transform.position - Vector3.forward * 7, Quaternion.identity).transform;
            t.parent = flamethrower.transform;
            t.transform.localPosition = Vector3.zero;
            t.transform.localScale *= 3;
            yield return new WaitForSeconds(4);
            Destroy(t.gameObject);
            overheat = 0;
            overHeatStarted = false;
        }
    }
}
