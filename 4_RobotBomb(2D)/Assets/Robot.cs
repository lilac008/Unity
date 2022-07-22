using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    Rigidbody2D robotRD;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    Animator ani;           /// 애니메이션 변수
    private bool isMoving;  /// int/bool

    void Start()
    {
        robotRD = GetComponent<Rigidbody2D>();  ///초기화
        ani = GetComponent<Animator>();         ///초기화
    }

    void Update()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f)    /// &&이후 : 캐릭터가 화면에서 벗어나는 걸 방지
        {
            isMoving = true;

            ani.SetBool("isWalking", true);                      ///Walk Animation 시작


            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);    /// 좌 이동
            transform.localScale = new Vector2(-2.0f, 2.0f);                   /// 뒤로돌기
        }


        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            isMoving = true;

            ani.SetBool("isWalking", true);                      ///Walk Animation 시작


            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime);   /// 우 이동  
            transform.localScale = new Vector2(+2.0f, 2.0f);                   /// 뒤로돌기

        }


        if (Input.GetKeyDown(KeyCode.Space))                    ///getkeydown 
        {
            ani.SetTrigger("jumpTrigger");                      ///Jump Animation 시작

            robotRD.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse); ///Jump
        }


        if (!isMoving) 
        {
            ani.SetBool("isWalking", false);                   ///walk Animation 종료
        }





    }
}
