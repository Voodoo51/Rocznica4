using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedVanBoss : Boss
{
    public GameObject redSmallVan;
    private Transform player;

    public float gunLerpSpeed;
    public float gunCrazySpeed;
    public EnemyGun gun;
    SpriteRenderer gunRenderer;

    public GameObject smoke;
    private GameObject temp_gameObject;

    Color ogColor;
    Color toLerp;


    Color healthOgColor;
    Color healthColorToLerp;
    Phase phase;
    float timer = 0;
    SpriteRenderer _renderer;
    void Start()
    {
        _renderer = GetComponentInChildren<SpriteRenderer>();
        healthOgColor = _renderer.color;
        healthColorToLerp = healthOgColor;

        transform.position = transform.position + Vector3.right * 10;
        player = FindObjectOfType<Player>().transform;

        gun.enabled = false;
        gunRenderer = gun.GetComponent<SpriteRenderer>();

        ogColor = gunRenderer.color;
        toLerp = ogColor;

        FindObjectOfType<Notification>().ShowBossHealth("Boss",healthBar);
        healthBar.SetMaxHealth(150);
        StartCoroutine(AtStart());
    
    }

    
    void LateUpdate()
    {
        if(phase != Phase.Minigun && phase != Phase.GoCrazy)
        {
            toLerp = Color.Lerp(toLerp,ogColor,Time.deltaTime * 0.3f);
        }
        healthColorToLerp = Color.Lerp(healthColorToLerp,healthOgColor,Time.deltaTime * 1f);
        _renderer.color = healthColorToLerp;
        gunRenderer.color = toLerp;
        
    }


    IEnumerator AtStart()
    {
        while(Vector3.Distance(transform.position,point.position) > 0.25f)
        {
            transform.position = Vector3.Lerp(transform.position,point.position, Time.deltaTime * 5f);
            yield return null;
        }
        Destroy(point.gameObject);
        StartCoroutine(RedVanHorde());
    }

    enum Phase{
        RedVanHorde,
        Minigun,
        GoCrazy

    }
    //Instantiate(redSmallVan,point.position + (Vector3.right * 10),Quaternion.identity)
    private IEnumerator RedVanHorde()
    {
        float randomYCoordinate;
        while(timer < 4)
        {
            randomYCoordinate = Random.Range(-1f,1f);
            Instantiate(redSmallVan,player.position + ((Vector3.right * 10) +(Vector3.up*randomYCoordinate)),Quaternion.identity);
            
            timer += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        timer = 0;
        phase = Phase.Minigun;
        StartCoroutine(Tired());   
    }
    private IEnumerator Minigun()
    {
        gun.enabled = true;
        while(timer < 7.5f)
        {
            gun.CheckCooldown();

            timer+=Time.deltaTime;
            toLerp = Color.Lerp(toLerp,Color.red,Time.deltaTime*0.2f);

            Vector3 lookDir = player.position - gun.transform.position;
            float angle = Mathf.Atan2(lookDir.y ,lookDir.x) * Mathf.Rad2Deg - 90f;

            gun.transform.rotation = Quaternion.Lerp(gun.transform.rotation, Quaternion.Euler(Vector3.forward * angle), Time.deltaTime * gunLerpSpeed);
            yield return null;
        }
        temp_gameObject = Instantiate(smoke,gun.transform.position - Vector3.forward*3,Quaternion.identity);
        gun.enabled = false;
        phase = Phase.GoCrazy;
        timer = 0; 
        StartCoroutine(Tired());
    }

    private IEnumerator GoCrazy()
    {
        gun.enabled = true;
        gun.cooldownLength = 0.04f;
        while(timer < 6)
        {
            timer+=Time.deltaTime;
            toLerp = Color.Lerp(toLerp,Color.red,Time.deltaTime*0.2f);
            
            gun.CheckCooldown();
            gun.transform.Rotate(Vector3.forward * gunCrazySpeed * Time.deltaTime);
            
            yield return null;
        }
        gun.enabled = false;
        gun.cooldownLength = 0.15f;
        phase = Phase.RedVanHorde;
        timer = 0; 
        StartCoroutine(Tired());
    }
    private IEnumerator Tired()
    {
        while(timer < 4)
        {
            timer+=Time.deltaTime;
            yield return null;
        }
        timer = 0;
       
        StopAllCoroutines();

        switch(phase)
        {
            case Phase.RedVanHorde:
                {
                    Destroy(temp_gameObject);
                    StartCoroutine(RedVanHorde());
                    yield return null;
                }
                break;
            case Phase.Minigun:
                {
                    StartCoroutine(Minigun());
                    yield return null;
                }
                break;
            case Phase.GoCrazy:
                {
                    StartCoroutine(GoCrazy());
                    yield return null;
                }
                break;
        }
        
    }
/*
    void OnTriggerEnter2D(Collider2D c2d)
    {
        if(c2d.tag == "bullet")
        {
            health -= c2d.GetComponent<Bullet>().damage;
            healthBar.SetHealth(health);
        }
    }
    */
}
