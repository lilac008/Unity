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

    public float curBulletDelay = 0f; //�Ѿ� �����̽ð�
    public float maxBulletDelay;

    public GameObject goBullet;     
    public GameObject goPlayer;     



    void Start()/// Scene�� �ε�ɶ� ����Ǵ� �Լ�, Start is called before the first frame update
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        ///rd = GetComponent<Rigidbody2D>();
        ///rd.velocity = Vector2.down * speed; 
    }

    void Update()/// Update is called once per frame
    {
        ///spriteRenderer.sprite = sprites[1];
        ///Invoke("ReturnSprite", 0.1f);       ///Invoke("�����ϰ����ϴ� �Լ�", �����̽ð�)  /  startcouroutine���ε� �Ẹ��
        Fire();
        ReloadBullet();
    }

    void Fire() ///�Ѿ˻���, �Ѿ��� �÷��̾�� ���ϵ���
    {
        if (curBulletDelay < maxBulletDelay)
            return;

        GameObject createBullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        rd = createBullet.GetComponent<Rigidbody2D>();

        Vector3 dirVec = goPlayer.transform.position - transform.position;  //�Ѿ˹��� ����3 = �÷��̾� ��ġ - ? ��ġ  
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
            OnHit(bullet.power);                    ///�� ���
        }
        Destroy(collision.gameObject);  ///���� �Ѿ� �������
    }


    void OnHit(float playerBulletPower)
    {
        health -= playerBulletPower;

        spriteRenderer.sprite = sprites[1];
        Invoke("ReturnSprite", 0.1f);       ///Invoke("�����ϰ����ϴ� �Լ�", �����̽ð�)  /  startcouroutine���ε� �Ẹ��

        if (health <= 0) 
        {
            Destroy(gameObject);
        }
    }






}