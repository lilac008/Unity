using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float health;

    public Sprite[] sprites;
    SpriteRenderer spriteRenderer;

    Rigidbody2D rd;

    public float curBulletDelay = 0f; //총알 딜레이시간
    public float maxBulletDelay;

    public GameObject goBullet;     
    public GameObject goPlayer;     



    void Start()/// Scene에 로드될때 실행되는 함수, Start is called before the first frame update
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ///rd = GetComponent<Rigidbody2D>();
        ///rd.velocity = Vector2.down * speed; 
    }

    void Update()/// Update is called once per frame
    {
        ///spriteRenderer.sprite = sprites[1];
        ///Invoke("ReturnSprite", 0.1f);       ///Invoke("실행하고자하는 함수", 딜레이시간)  /  startcouroutine으로도 써보자
        Fire();
        ReloadBullet();
    }

    void Fire() ///총알생성, 총알이 플레이어에게 향하도록
    {
        if (curBulletDelay < maxBulletDelay)
            return;

        GameObject createBullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        rd = createBullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = goPlayer.transform.position - transform.position;  //총알방향 벡터3 = 플레이어 위치 - ? 위치  
        rd.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);

        
        curBulletDelay = 0;
    }

    void ReloadBullet() 
    { 
        curBulletDelay += Time.deltaTime;
    }


    void ReturnSprite() 
    {
        spriteRenderer.sprite = sprites[0];
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER") 
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "PlayerBullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            OnHit(bullet.power);                    ///피 닳게
        }
        Destroy(collision.gameObject);  ///맞은 총알 사라지게
    }


    void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;

        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);       ///Invoke("실행하고자하는 함수", 딜레이시간)  /  startcouroutine으로도 써보자

        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }






}
