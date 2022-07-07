using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour
{
    Rigidbody2D robotRD;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    Animator animator;      ///2 애니메이션 선언
    private bool isMoving;  ///int/bool

    void Start()
    {
        robotRD = GetComponent<Rigidbody2D>(); ///초기화
        animator = GetComponent<Animator>();   ///초기화
    }

    void Update()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f) /// &&이하 캐릭터가 화면에서 벗어나는 걸 방지
        {
            isMoving = true;
            ///2  Walk Animation 시작
            animator.SetBool("isWalking", true);


            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);  /// 좌 이동
            transform.localScale = new Vector2(-2.0f, 2.0f);/// 뒤로돌기
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            isMoving = true;
            ///2  Walk Animation 시작
            animator.SetBool("isWalking", true); 


            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime); /// 우 이동  
            transform.localScale = new Vector2(+2.0f, 2.0f);                /// 뒤로돌기

        }

        if (Input.GetKeyDown(KeyCode.Space))  ///getkeydown 
        {
            ///Jump Animation 시작
            animator.SetTrigger("jumpTrigger");

            robotRD.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse); ///Jump
        }

        if (!isMoving) 
        {
            ///walk Animation 종료
            animator.SetBool("isWalking", false);
        }





    }
}
