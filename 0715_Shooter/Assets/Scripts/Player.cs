using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public bool isTouchTop = false;
    public bool isTouchBottom = false;
    public bool isTouchRight = false;
    public bool isTouchLeft = false;

    Animator anim;

    public GameObject goBullet;     /// game object Bullet

    public float curBulletDelay = 0;    /// 총알 딜레이시간
    public float maxBulletDelay;

    public int life = 0;                    ///피통

    public GameObject goGameManager;

    public bool isHit = false;

    public bool[] joyControl;
    public bool isControl;







    void Start()/// Start is called before the first frame update
    {
        anim = GetComponent<Animator>();    ///초기화 : 로딩시 필요한 초깃값
    }

    void Update()/// Update is called once per frame
    {
        ///float h = Input.GetAxis("Horizontal");            ///소수 - 키보드입력미세하게연출
        ///float h = Input.GetAxisRaw("Horizontal");         ///정수 - 방향,     좌우
        ///Debug.Log("GetAxis" + h);
        ///Debug.Log("GetAxisRaw"+h);

        Move();
        Fire();
        ReloadBullet();


    }

    void Fire() ///총 쏘는 로직
    {
        if (!Input.GetButton("Fire1")) 
        {
            return;
        }

        if (curBulletDelay < maxBulletDelay)        ///총알 시간 딜레이
            return;

        GameObject bullet = Instantiate(goBullet, transform.position, Quaternion.identity);
        Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
        rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse); ///무거울수록 속도가 늦지만 가속도가 붙으면 빠른데, impulse 질량에 대한 계산을 하지 않겠다

        curBulletDelay = 0;
    }

    void ReloadBullet() 
    {
        curBulletDelay += Time.deltaTime;
    }

    private void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (joyControl[0]) { h = -1; v = 1; }   
        if (joyControl[1]) { h = 0; v = 1; }
        if (joyControl[2]) { h = 1; v = 1; }
        if (joyControl[3]) { h = -1; v = 0; }
        if (joyControl[4]) { h = 0; v = 0; }
        if (joyControl[5]) { h = 1; v = 0; }
        if (joyControl[6]) { h = -1; v = -1; }
        if (joyControl[7]) { h = 0; v = -1; }
        if (joyControl[8]) { h = 1; v = -1; }

        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1) || !isControl)
        { h = 0; }
        if ((isTouchTop && h == 1) || (isTouchBottom && h == -1) || !isControl)
        { v = 0; }

        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        if (Input.GetButtonDown("Horizontal") || Input.GetButtonUp("Horizontal"))
        {
            anim.SetInteger("Input", (int)h);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    { isTouchTop = true; }
                    break;
                case "Bottom":
                    { isTouchBottom = true; }
                    break;
                case "Right":
                    { isTouchRight = true; }
                    break;
                case "Left":
                    { isTouchLeft = true; }
                    break;

            }
        }
        else if (collision.gameObject.tag == "EnemyBullet") 
        {
            if (isHit)
                return;
            isHit = true;

            

            life--;

            GameManager gManager = goGameManager.GetComponent<GameManager>();
            gManager.UpdateLifeIcon(life);


            if (life == 0)  ///game over 
            {
            }
            else        ///Respawn Player
            {
                
                gManager.RespawnPlayer();
            }
            gameObject.SetActive(false);    ///총알 맞으면 화면에서 안 보이게
            Destroy(collision.gameObject);
            

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BORDER")
        {
            switch (collision.gameObject.name)
            {
                case "Top":
                    { isTouchTop = false; }
                    break;
                case "Bottom":
                    { isTouchBottom = false; }
                    break;
                case "Right":
                    { isTouchRight = false; }
                    break;
                case "Left":
                    { isTouchLeft = false; }
                    break;

            }
        }

    }

    public void JoyPanel(int type) 
    {
        for (int idx = 0; idx < 9; idx++) 
        {
            joyControl[idx] = idx == type;
        }
    }

    public void JoyDown() { isControl = true; }
    public void JoyUP() { isControl = false; }








}
