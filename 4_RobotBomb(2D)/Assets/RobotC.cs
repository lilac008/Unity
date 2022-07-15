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

    // Start is called before the first frame update
    void Start()
    {
        robotRD = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isMoving = false;

        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -8.0f) /// &&���� ĳ���Ͱ� ȭ�鿡�� ����� �� ����
        {
            isMoving = true;
            ///2  Walk Animation ����
            animator.SetBool("isWalking", true);


            transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);  /// �� �̵�
            transform.localScale = new Vector2(-2.0f, 2.0f);/// �ڷε���
        }

        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 8.0f)
        {
            isMoving = true;
            ///2  Walk Animation ����
            animator.SetBool("isWalking", true);


            transform.Translate(Vector2.right * walkSpeed * Time.deltaTime); /// �� �̵�  
            transform.localScale = new Vector2(+2.0f, 2.0f);                /// �ڷε���

        }

        if (Input.GetKeyDown(KeyCode.Space))  ///getkeydown 
        {
            ///Jump Animation ����
            animator.SetTrigger("jumpTrigger");

            robotRD.AddForce(transform.up * jumpSpeed, ForceMode2D.Impulse); ///Jump
        }

        if (!isMoving)
        {
            ///walk Animation ����
            animator.SetBool("isWalking", false);
        }



    }
}