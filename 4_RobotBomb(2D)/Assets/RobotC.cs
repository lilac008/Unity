using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotC : MonoBehaviour
{
    Rigidbody2D robotRD;
    public float walkSpeed = 10.0f;
    public float jumpSpeed = 10.0f;

    Animator animator;
    private bool isMoving; 

    void Start() /// Start is called before the first frame update
    {
        robotRD = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    void Update() /// Update is called once per frame
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f)     /// &&이후 : 캐릭터가 화면에서 벗어나는 걸 방지
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
